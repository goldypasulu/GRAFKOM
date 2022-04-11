using System.Collections.Generic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using OpenTK.Mathematics;
using LearnOpenTK.Common;

namespace ConsoleApp2
{
    class Window3d : GameWindow
    {
        List<Asset3d> objectList = new List<Asset3d>();

        public Window3d(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
           
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.1f, 0.1f, 0.1f, 1.0f);
            GL.Enable(EnableCap.DepthTest);

            var cube1 = new Asset3d(new Vector3(0.5f, 0.5f, 0));
            var cube2 = new Asset3d(new Vector3(0.25f, 0f, 0));
            cube1.createCuboid(2, 0, 0, 1); //sama dengan createBoxVertices
            //cube1.rotate(cube1.objectCenter, cube1._euler[1], 45);

            cube2.createCuboid(1, 0, 0, 1);
            cube1.child.Add(cube2);
            objectList.Add(cube1);


            foreach (Asset3d i in objectList)
            {
                i.load(Size.X, Size.Y);
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi
            Matrix4 temp = Matrix4.Identity;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); // DepthBufferBit juga harus di clear karena kita memakai depth testing.

            foreach (Asset3d i in objectList)
            {
                i.render();
                i.rotate(Vector3.Zero, Vector3.UnitZ, 45 * time);
                i.rotate(i.objectCenter, i._euler[0], 180 * time);

                foreach (Asset3d j in i.child)
                {
                    j.rotate(Vector3.Zero, Vector3.UnitY, 180 * time);
                }
            }

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            float time = (float)args.Time; //Deltatime ==> waktu antara frame sebelumnya ke frame berikutnya, gunakan untuk animasi

            if (!IsFocused)
            {
                return; //Reject semua input saat window bukan focus.
            }

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }
}