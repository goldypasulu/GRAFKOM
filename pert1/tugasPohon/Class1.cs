using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugasPohon
{
    class Class1
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(1280, 720),
                Title = "Tugas Pohon"
            };
            using(var window = new windows(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }

        }
    }
}
