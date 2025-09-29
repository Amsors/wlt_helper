using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;  
using wlt_helper.Services;
using System.Net.NetworkInformation;

namespace wlt_helper
{
    internal static class Program
    {
        [STAThread]
        static async Task Main()
        {
            Debug.WriteLine("≥Ã–Ú∆Ù∂Ø");
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}