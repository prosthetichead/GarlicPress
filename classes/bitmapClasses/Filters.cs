namespace GarlicPress.classes.bitmapClasses;

public interface IFilter
{
    Bitmap Apply(Bitmap bmp);
    IFilter Clone();
}

public class Filters
{
    public static readonly Dictionary<string, Type> FilterTypeMap = new Dictionary<string, Type>
    {
        { nameof(SaturationFilter), typeof(SaturationFilter) },
        { nameof(ContrastFilter), typeof(ContrastFilter) },
        { nameof(BrightnessFilter), typeof(BrightnessFilter) },
        { nameof(BlurFilter), typeof(BlurFilter) },
        { nameof(GaussianBlurFilter), typeof(GaussianBlurFilter) },
        { nameof(GradientFilter), typeof(GradientFilter) },
        { nameof(TransparencyFilter), typeof(TransparencyFilter) },
        { nameof(GrayscaleFilter), typeof(GrayscaleFilter) },
    };

    public class SaturationFilter : IFilter
    {
        public float Saturation { get; set; }

        public SaturationFilter()
        {
            Saturation = 1.0F;
        }

        public SaturationFilter(float saturation)
        {
            Saturation = saturation;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.AdjustSaturation(bmp, Saturation);
        }

        public IFilter Clone()
        {
            return new SaturationFilter(Saturation);
        }
    }

    public class ContrastFilter : IFilter
    {
        public float Contrast { get; set; }

        public ContrastFilter()
        {
            Contrast = 0.0F;
        }

        public ContrastFilter(float contrast)
        {
            Contrast = contrast;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.AdjustContrast(bmp, Contrast);
        }

        public IFilter Clone()
        {
            return new ContrastFilter(Contrast);
        }
    }

    public class BrightnessFilter : IFilter
    {
        public float Brightness { get; set; }

        public BrightnessFilter()
        {
            Brightness = 1.0F;
        }

        public BrightnessFilter(float brightness)
        {
            Brightness = brightness;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.AdjustBrightness(bmp, Brightness);
        }

        public IFilter Clone()
        {
            return new BrightnessFilter(Brightness);
        }
    }


    public class BlurFilter : IFilter
    {
        public int BlurAmount { get; set; }

        public BlurFilter()
        {
            BlurAmount = 1;
        }

        public BlurFilter(int blurAmount)
        {
            BlurAmount = blurAmount;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.ApplyBlur(bmp, BlurAmount);
        }

        public IFilter Clone()
        {
            return new BlurFilter(BlurAmount);
        }
    }

    public class GaussianBlurFilter : IFilter
    {
        public int BlurAmount { get; set; }

        public GaussianBlurFilter()
        {
            BlurAmount = 1;
        }

        public GaussianBlurFilter(int blurAmount)
        {
            BlurAmount = blurAmount;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.ApplyGaussianBlur(bmp, BlurAmount);
        }

        public IFilter Clone()
        {
            return new GaussianBlurFilter(BlurAmount);
        }
    }

    public class GradientFilter : IFilter
    {
        public string? Color1 { get; set; }
        public string? Color2 { get; set; }
        public float Width { get; set; }
        public float Start { get; set; }
        public float Angle { get; set; }

        public GradientFilter()
        {
            Color1 = null;
            Color2 = null;
            Width = 0.2F;
            Start = 0.5F;
            Angle = 0;
        }

        public GradientFilter(string? color1, string? color2, float width, float start, float angle)
        {
            Color1 = color1;
            Color2 = color2;
            Width = width;
            Start = start;
            Angle = angle;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.ApplyColorGradient(bmp, Color1, Color2,Width, Start, Angle);
        }

        public IFilter Clone()
        {
            return new GradientFilter(Color1, Color2, Width, Start, Angle);
        }
    }

    public class TransparencyFilter : IFilter
    {
        public float Transparency { get; set; }

        public TransparencyFilter()
        {
            Transparency = 0.5F;
        }

        public TransparencyFilter(float transparency)
        {
            Transparency = transparency;
        }

        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.ApplyTransparency(bmp, Transparency);
        }

        public IFilter Clone()
        {
            return new TransparencyFilter(Transparency);
        }
    }

    public class GrayscaleFilter : IFilter
    {
        public Bitmap Apply(Bitmap bmp)
        {
            return BitmapUtilites.ApplyGrayscale(bmp);
        }

        public IFilter Clone()
        {
            return new GrayscaleFilter();
        }
    }
}
