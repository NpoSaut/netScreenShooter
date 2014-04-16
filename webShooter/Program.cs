using System;
using System.Drawing.Imaging;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Shooting;

namespace webShooter
{
    static class Program
    {
        private static readonly CancellationTokenSource TokenSource = new CancellationTokenSource();

        [STAThread]
        static void Main()
        {
            ListeningLoop();

            Application.Run();
        }

        private static async void ListeningLoop()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://+:4444/");
            listener.IgnoreWriteExceptions = true;
            listener.Start();
            while (true)
            {
                var context = await listener.GetContextAsync();
                try
                {
                    if (context.Request.Url.LocalPath == "/screen.png")
                    {
                        var screenshot = Shooter.MakeScreenShot(Screen.PrimaryScreen);
                        screenshot.Save(context.Response.OutputStream, ImageFormat.Png);
                    }
                }
                finally
                {
                    context.Response.Close();
                }
            }
        }
    }
}
