﻿using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pert1
{
    class Class1
    {
        static void Main(string[] args)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new OpenTK.Mathematics.Vector2i(800, 600),
                Title = "pertemuan 1"
            };
            using (var window = new windows(GameWindowSettings.Default, nativeWindowSettings)) 
            {
                window.Run();
            }

        }
    }
}
