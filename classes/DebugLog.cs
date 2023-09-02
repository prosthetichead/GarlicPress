using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GarlicPress
{
    internal static class DebugLog
    {
        private static RichTextBox? log;
        public static RichTextBox logRitchTextBox { set { log = value; } }
                
        public static void Write(string text, Color? color = null, bool timestamp = true, bool newLine = true) {
            Color lineColor = Color.LimeGreen;
            if (color != null)
            {
                lineColor = (Color)color;
            }

            if (log != null) {
                log.HideSelection = false;
                if (timestamp) {
                    log.SelectionColor = Color.WhiteSmoke;
                    log.AppendText(DateTime.Now.ToString("s") + " :: ");
                }                
                log.SelectionColor = lineColor;
                log.AppendText(text);
                if (newLine)
                    log.AppendText("\n");
                log.Refresh();
            }

        }

    }
}
