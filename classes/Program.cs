using AdvancedSharpAdbClient;
using System.Diagnostics;
using System.Reflection;

namespace GarlicPress
{
    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            if (Properties.Settings.Default.settingsUpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.settingsUpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }



    }


}