using System;
using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(800, 800),
                Title = "Pertemuan 3"
            };


            using (var window = new Window3d(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
    }
}