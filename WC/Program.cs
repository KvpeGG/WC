using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;


class Program
{
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);


    static void Main(string[] args)
    {

        const int SPA_SETDESKWALLPAPER = 20;
        const int SPIF_UPDATEINFILE = 1;
        const int SPIF_SENDCHANGE = 2;

        string[] array = { "WallpaperDay.png", "WallpaperNight.png" };
        string  wallpaperPathDay = "C:\\WC\\" + array[0];
        string wallpaperPathNight = "C:\\WC\\" + array[1];


        TimeSpan start = new TimeSpan(9, 0, 0);
        TimeSpan end = new TimeSpan(18, 0, 0);
        TimeSpan start2 = new TimeSpan(19, 0, 0);
        TimeSpan end2 = new TimeSpan(8, 0, 0);
        TimeSpan now = DateTime.Now.TimeOfDay;

        while (true)
        {
            if (now >= start && now <= end) //Day Wallpaper
            {
                SystemParametersInfo(SPA_SETDESKWALLPAPER, 0, wallpaperPathDay, SPIF_UPDATEINFILE | SPIF_SENDCHANGE);
                Thread.Sleep(600000);
                
            }
            else if (now >= start2 && now <= end2) //Night Wallpaper
            {
                SystemParametersInfo(SPA_SETDESKWALLPAPER, 0, wallpaperPathNight, SPIF_UPDATEINFILE | SPIF_SENDCHANGE);
                Thread.Sleep(600000);
            }


        }
        
    }
}