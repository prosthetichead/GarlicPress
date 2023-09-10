using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GarlicPress.classes.bitmapClasses;
internal static class BitmapUtilites
{
    public static void DrawRotatedImage(Graphics g, Bitmap img, float angle, float x, float y, float? width = null, float? height = null)
    {
        // Set the width and height if not provided
        width ??= img.Width;
        height ??= img.Height;

        // Translate to the desired position
        g.TranslateTransform(x, y);

        // Rotate the graphics object
        g.RotateTransform(angle);

        // Draw the image at its translated and rotated location
        g.DrawImage(img, 0, 0, width.Value, height.Value);

        // Reset the graphics transformation
        g.ResetTransform();
    }

    public static Bitmap ApplyTransparency(Bitmap original, float transparency)
    {
        Bitmap transparentImg = new Bitmap(original.Width, original.Height);
        Graphics g = Graphics.FromImage(transparentImg);

        ColorMatrix colorMatrix = new ColorMatrix
        {
            Matrix33 = transparency
        };
        ImageAttributes attributes = new ImageAttributes();
        attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
        g.DrawImage(original, new Rectangle(0, 0, transparentImg.Width, transparentImg.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
        g.Dispose();

        return transparentImg;
    }

    public static Bitmap ApplyGrayscale(Bitmap original)
    {
        Bitmap grayscaleBitmap = new Bitmap(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixelColor = original.GetPixel(x, y);
                int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11); // weighted sum method
                Color grayColor = Color.FromArgb(pixelColor.A, grayValue, grayValue, grayValue);
                grayscaleBitmap.SetPixel(x, y, grayColor);
            }
        }

        return grayscaleBitmap;
    }

    /// <summary>
    /// Adjust the brightness of the image.
    /// </summary>
    /// <param name="original"></param>
    /// <param name="brightnessFactor"></param>
    /// <returns></returns>
    public static Bitmap AdjustBrightness(Bitmap original, float brightnessFactor)
    {
        Bitmap adjustedBitmap = new Bitmap(original.Width, original.Height);

        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                Color pixelColor = original.GetPixel(x, y);
                int r = Clamp((int)(pixelColor.R * brightnessFactor), 0, 255);
                int g = Clamp((int)(pixelColor.G * brightnessFactor), 0, 255);
                int b = Clamp((int)(pixelColor.B * brightnessFactor), 0, 255);
                adjustedBitmap.SetPixel(x, y, Color.FromArgb(pixelColor.A, r, g, b));
            }
        }

        return adjustedBitmap;
    }

    /// <summary>
    /// Adjusts saturation level of the image.
    /// saturationLevel is between -1 to 1; -1 is fully desaturated and 1 is maximum saturation.
    /// </summary>
    /// <param name="original"></param>
    /// <param name="saturationLevel">between -1 to 1; -1 is fully desaturated and 1 is maximum saturation.</param>
    /// <returns></returns>
    public static Bitmap AdjustSaturation(Bitmap original, float saturationLevel)
    {
        Bitmap adjustedBitmap = new Bitmap(original.Width, original.Height);
        using (Graphics graphics = Graphics.FromImage(adjustedBitmap))
        {
            float saturation = 1 + saturationLevel;
            float RW = 0.3086f;
            float RG = 0.6094f;
            float RB = 0.0820f;

            ColorMatrix mat = new ColorMatrix(new float[][]
            {
            new float[] { (1.0f - saturation) * RW + saturation, (1.0f - saturation) * RW, (1.0f - saturation) * RW, 0, 0},
            new float[] { (1.0f - saturation) * RG, (1.0f - saturation) * RG + saturation, (1.0f - saturation) * RG, 0, 0},
            new float[] { (1.0f - saturation) * RB, (1.0f - saturation) * RB, (1.0f - saturation) * RB + saturation, 0, 0},
            new float[] { 0, 0, 0, 1, 0},
            new float[] { 0, 0, 0, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(mat);
            graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
        }
        return adjustedBitmap;
    }

    /// <summary>
    /// Adjusts contrast level of the image.
    /// contrastLevel is in range -100 to 100
    /// </summary>
    /// <param name="original"></param>
    /// <param name="contrastLevel">range -100 to 100</param>
    /// <returns></returns>
    public static Bitmap AdjustContrast(Bitmap original, float contrastLevel)
    {
        Bitmap adjustedBitmap = new Bitmap(original.Width, original.Height);
        using (Graphics graphics = Graphics.FromImage(adjustedBitmap))
        {
            float translatedContrast = contrastLevel * 0.01f + 1.0f;
            float shift = 0.5f * (1.0f - translatedContrast);

            ColorMatrix mat = new ColorMatrix(new float[][]
            {
            new float[] { translatedContrast, 0, 0, 0, 0},
            new float[] { 0, translatedContrast, 0, 0, 0},
            new float[] { 0, 0, translatedContrast, 0, 0},
            new float[] { 0, 0, 0, 1, 0},
            new float[] { shift, shift, shift, 0, 1}
            });

            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(mat);
            graphics.DrawImage(original, new Rectangle(0, 0, original.Width, original.Height), 0, 0, original.Width, original.Height, GraphicsUnit.Pixel, attributes);
        }
        return adjustedBitmap;
    }

    private static int Clamp(int value, int min, int max)
    {
        return value < min ? min : value > max ? max : value;
    }

    public static Bitmap ApplyGaussianBlur(Bitmap original, int radius)
    {
        if (radius <= 0) return (Bitmap)original.Clone();

        Bitmap blurredBitmap = new Bitmap(original.Width, original.Height);
        int[] kernel = CreateGaussianKernel(radius);
        int kernelSize = kernel.Length;
        int bounds = kernelSize / 2;

        Rectangle rect = new Rectangle(0, 0, original.Width, original.Height);

        BitmapData originalData = original.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        BitmapData blurredData = blurredBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

        int byteCount = originalData.Stride * original.Height;
        byte[] originalBytes = new byte[byteCount];
        byte[] blurredBytes = new byte[byteCount];

        Marshal.Copy(originalData.Scan0, originalBytes, 0, byteCount);

        int bytesPerPixel = 4;
        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                int red = 0;
                int green = 0;
                int blue = 0;
                int alpha = 0;
                int weight = 0;

                for (int k = -bounds; k <= bounds; k++)
                {
                    int idx = x + k;
                    if (idx >= 0 && idx < original.Width)
                    {
                        int offset = (y * originalData.Stride) + idx * bytesPerPixel;
                        red += originalBytes[offset + 2] * kernel[k + bounds];
                        green += originalBytes[offset + 1] * kernel[k + bounds];
                        blue += originalBytes[offset] * kernel[k + bounds];
                        alpha += originalBytes[offset + 3] * kernel[k + bounds];
                        weight += kernel[k + bounds];
                    }
                }

                for (int k = -bounds; k <= bounds; k++)
                {
                    int idy = y + k;
                    if (idy >= 0 && idy < original.Height)
                    {
                        int offset = (idy * originalData.Stride) + x * bytesPerPixel;
                        red += originalBytes[offset + 2] * kernel[k + bounds];
                        green += originalBytes[offset + 1] * kernel[k + bounds];
                        blue += originalBytes[offset] * kernel[k + bounds];
                        alpha += originalBytes[offset + 3] * kernel[k + bounds];
                        weight += kernel[k + bounds];
                    }
                }

                int blurredOffset = (y * blurredData.Stride) + x * bytesPerPixel;
                blurredBytes[blurredOffset + 2] = (byte)(red / weight);
                blurredBytes[blurredOffset + 1] = (byte)(green / weight);
                blurredBytes[blurredOffset] = (byte)(blue / weight);
                blurredBytes[blurredOffset + 3] = (byte)(alpha / weight);
            }
        }

        Marshal.Copy(blurredBytes, 0, blurredData.Scan0, byteCount);

        original.UnlockBits(originalData);
        blurredBitmap.UnlockBits(blurredData);

        return blurredBitmap;
    }


    private static int[] CreateGaussianKernel(int radius)
    {
        int size = radius * 2 + 1;
        int[] kernel = new int[size];
        int[] distances = new int[size];
        int total = 0;

        for (int i = 0; i <= radius; i++)
        {
            int value = (int)(1000 * Math.Exp(-i * i / (2 * radius * radius)));
            kernel[radius + i] = value;
            kernel[radius - i] = value;
            total += value * (i == 0 ? 1 : 2);
        }

        for (int i = 0; i < kernel.Length; i++)
        {
            kernel[i] = 1000 * kernel[i] / total;
        }

        return kernel;
    }

    public static Bitmap ApplyBlur(Bitmap original, int radius)
    {
        Bitmap blurredBitmap = new Bitmap(original.Width, original.Height);
        Rectangle rect = new Rectangle(0, 0, original.Width, original.Height);

        BitmapData originalData = original.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        BitmapData blurredData = blurredBitmap.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

        int byteCount = originalData.Stride * original.Height;
        byte[] originalBytes = new byte[byteCount];
        byte[] blurredBytes = new byte[byteCount];

        Marshal.Copy(originalData.Scan0, originalBytes, 0, byteCount);

        int bytesPerPixel = 4;
        for (int y = 0; y < original.Height; y++)
        {
            for (int x = 0; x < original.Width; x++)
            {
                int avgR = 0, avgG = 0, avgB = 0;
                int count = 0;

                for (int yOff = -radius; yOff <= radius; yOff++)
                {
                    for (int xOff = -radius; xOff <= radius; xOff++)
                    {
                        int nX = x + xOff;
                        int nY = y + yOff;

                        if (nX >= 0 && nX < original.Width && nY >= 0 && nY < original.Height)
                        {
                            int offset = (nY * originalData.Stride) + nX * bytesPerPixel;
                            byte blue = originalBytes[offset];
                            byte green = originalBytes[offset + 1];
                            byte red = originalBytes[offset + 2];
                            byte alpha = originalBytes[offset + 3];

                            if (alpha != 0)
                            {
                                avgR += red;
                                avgG += green;
                                avgB += blue;
                                count++;
                            }
                        }
                    }
                }

                if (count > 0)
                {
                    avgR /= count;
                    avgG /= count;
                    avgB /= count;
                }

                int blurredOffset = (y * blurredData.Stride) + x * bytesPerPixel;
                blurredBytes[blurredOffset] = (byte)avgB;
                blurredBytes[blurredOffset + 1] = (byte)avgG;
                blurredBytes[blurredOffset + 2] = (byte)avgR;
                blurredBytes[blurredOffset + 3] = originalBytes[(y * originalData.Stride) + x * bytesPerPixel + 3]; // Copy alpha from the original
            }
        }

        Marshal.Copy(blurredBytes, 0, blurredData.Scan0, byteCount);

        original.UnlockBits(originalData);
        blurredBitmap.UnlockBits(blurredData);

        return blurredBitmap;
    }

    public static Bitmap ApplyColorGradient(Bitmap originalBitmap, string? startColorHex = null, string? endColorHex = null, float transitionWidth = 1.0f, float transitionStart = 0.0f, float angleInDegrees = 0)
    {
        Color? startColor = HexToColor(startColorHex);
        Color? endColor = HexToColor(endColorHex);
        Bitmap resultBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);
        double radians = angleInDegrees * Math.PI / 180.0;
        float cosAngle = (float)Math.Cos(radians);
        float sinAngle = (float)Math.Sin(radians);

        for (int y = 0; y < originalBitmap.Height; y++)
        {
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                float projection = x * cosAngle + y * sinAngle;
                float relativePosition = projection / (cosAngle * originalBitmap.Width + sinAngle * originalBitmap.Height);

                Color baseColor = originalBitmap.GetPixel(x, y);
                Color blendedColor = CalculateBlendedColor(baseColor, startColor, endColor, transitionWidth, transitionStart, relativePosition);

                resultBitmap.SetPixel(x, y, blendedColor);
            }
        }

        return resultBitmap;
    }

    private static Color CalculateBlendedColor(Color baseColor, Color? startColor, Color? endColor, float transitionWidth, float transitionStart, float relativePosition)
    {
        float weight = CalculateWeight(relativePosition, transitionStart, transitionWidth);

        if (!startColor.HasValue) startColor = baseColor;
        if (!endColor.HasValue) endColor = baseColor;

        if (IsTransparent(startColor.Value))
        {
            return TransitionFromTransparent(baseColor, weight);
        }
        else if (IsTransparent(endColor.Value))
        {
            return TransitionToTransparent(baseColor, weight);
        }
        else
        {
            if (startColor.Value.A < 255) startColor = BlendColors(baseColor, startColor.Value);
            if (endColor.Value.A < 255) endColor = BlendColors(baseColor, endColor.Value);

            return Lerp(startColor.Value, endColor.Value, weight);
        }
    }

    private static float CalculateWeight(float relativePosition, float transitionStart, float transitionWidth)
    {
        if (relativePosition <= transitionStart) return 0;
        if (relativePosition >= transitionStart + transitionWidth) return 1;
        return (relativePosition - transitionStart) / transitionWidth;
    }

    private static bool IsTransparent(Color color)
    {
        return color.A == 0;
    }

    private static Color TransitionFromTransparent(Color baseColor, float weight)
    {
        return Color.FromArgb((int)(baseColor.A * weight), baseColor.R, baseColor.G, baseColor.B);
    }

    private static Color TransitionToTransparent(Color baseColor, float weight)
    {
        return Color.FromArgb((int)(baseColor.A * (1 - weight)), baseColor.R, baseColor.G, baseColor.B);
    }

    private static Color BlendColors(Color baseColor, Color topColor)
    {
        float baseAlpha = baseColor.A / 255f;
        float topAlpha = topColor.A / 255f;
        float outAlpha = topAlpha + baseAlpha * (1 - topAlpha);

        int r = (int)((topColor.R * topAlpha + baseColor.R * baseAlpha * (1 - topAlpha)) / outAlpha);
        int g = (int)((topColor.G * topAlpha + baseColor.G * baseAlpha * (1 - topAlpha)) / outAlpha);
        int b = (int)((topColor.B * topAlpha + baseColor.B * baseAlpha * (1 - topAlpha)) / outAlpha);

        return Color.FromArgb((int)(outAlpha * 255), r, g, b);
    }

    private static Color Lerp(Color start, Color end, float weight)
    {
        int a = (int)(start.A + weight * (end.A - start.A));
        int r = (int)(start.R + weight * (end.R - start.R));
        int g = (int)(start.G + weight * (end.G - start.G));
        int b = (int)(start.B + weight * (end.B - start.B));

        return Color.FromArgb(a, r, g, b);
    }

    private static Color? HexToColor(string? hex)
    {
        if (string.IsNullOrEmpty(hex))
            return null;

        hex = hex.TrimStart('#');

        if (hex.Length == 8)
        {
            // With alpha
            return Color.FromArgb(
                Convert.ToInt32(hex.Substring(6, 2), 16),  // Alpha
                Convert.ToInt32(hex.Substring(0, 2), 16),  // Red
                Convert.ToInt32(hex.Substring(2, 2), 16),  // Green
                Convert.ToInt32(hex.Substring(4, 2), 16)   // Blue
            );
        }
        else if (hex.Length == 6)
        {
            // Without alpha
            return Color.FromArgb(
                Convert.ToInt32(hex.Substring(0, 2), 16),  // Red
                Convert.ToInt32(hex.Substring(2, 2), 16),  // Green
                Convert.ToInt32(hex.Substring(4, 2), 16)   // Blue
            );
        }
        else
        {
            throw new ArgumentException("Invalid HEX format.");
        }
    }
}
