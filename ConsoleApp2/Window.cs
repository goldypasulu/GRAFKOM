//using OpenTK.Windowing.Desktop;
//using OpenTK.Graphics.OpenGL4;
//using OpenTK.Windowing.Common;
//using OpenTK.Windowing.GraphicsLibraryFramework;

//namespace ConsoleApp2
//{
//    /*static class Constants
//    {
//        public const string path = "../../../Shaders/";
//    }*/

//    internal class Window : GameWindow
//    {
//        /*// Ini segitiga dari pertemuan 1
//        float[] _vertices =
//        {
//             //x    //y    //z
//             -0.5f, -0.5f, 0.0f, // Vertex 1
//             0.5f, -0.5f, 0.0f,  // Vertex 2
//             0.0f, 0.5f, 0.0f    // Vertex 3
//         };
//*/
//        // Segitiga warna warni
//        /*float[] _vertices =
//        {
//             //x    //y    //z     // Colors
//             -0.5f, -0.5f, 0.0f, 1.0f, 0.0f, 0.0f, // Vertex 1, Merah
//             0.5f, -0.5f, 0.0f,  0.0f, 1.0f, 0.0f, // Vertex 2, Hijau
//             0.0f, 0.5f, 0.0f,   0.0f, 0.0f, 1.0f  // Vertex 3, Biru
//         };*/

//        /*float[] _vertices =
//        {
//            //x    //y    //z
//            0.5f, 0.5f, 0.0f,    // Top right
//            0.5f, -0.5f, 0.0f,   // Bottom right
//            -0.5f, -0.5f, 0.0f,  // Bottom left
//            -0.5f, 0.5f, 0.0f    // Top left

//        };

//        uint[] _indices =
//        {
//            0, 1, 3, // Segitiga pertama
//            1, 2, 3  // Segitiga kedua
//        };*/

//        /*int _vertexBufferObject;
//        //int _elementBufferObject;
//        int _vertexArrayObject;
//        Shader _shader;*/


//        Asset3d[] _object3d = new Asset3d[8];

//        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
//        {
//        }

//        protected override void OnLoad()
//        {
//            base.OnLoad();

//            // Ganti background warna
//            GL.ClearColor(0.6553f, 0.851f, 0.6941f, 1.0f);

//            _object3d[0] = new Asset3d();
//            _object3d[0].createBoxVertices(0, 0, 0, 0.5f);
//            _object3d[0].load(Constants.path + )

//            _object[0] = new Asset3d(
//                new float[]
//                {
//                    -0.75f, 0.75f, 0.0f,
//                    -0.25f, 0.75f, 0.0f,
//                    -0.75f, 0.25f, 0.0f,
//                },

//                new uint[]
//                {

//                },

//                new float[]
//                {

//                }
//             );

//            _object[1] = new Asset3d(
//                new float[]
//                {
//                    0.75f, -0.75f, 0.0f,
//                    0.25f, -0.75f, 0.0f,
//                    0.75f, -0.25f, 0.0f,
//                },

//                new uint[]
//                {

//                },

//                new float[]
//                {

//                }

//             );

//            _object[2] = new Asset3d(
//                new float[]
//                {

//                },

//                new uint[]
//                {

//                },

//                new float[]
//                {

//                }
//             );

//            _object[3] = new Asset3d(
//                new float[]
//                {

//                },

//                new uint[]
//                {

//                },

//                new float[]
//                {

//                }
//             );

//            _object[4] = new Asset2d(
//                new float[1080],
//                new uint[]
//                {

//                },

//                new float[]
//                {

//                }
//             );

//            _object[5] = new Asset2d(
//                new float[]
//                {

//                },

//                new uint[]
//                {

//                },

//                new float[]
//                {
//                    0.1f, 0.1f, 0.1f, 0.0f
//                }
//               );


//            _object[0].load();
//            _object[1].load();
//            _object[2].createCircle(0.0f, 0.0f, 0.5f);
//            _object[2].load();
//            _object[3].createEllips(0.0f, 0.0f, 0.6f, 0.5f);
//            _object[3].load();
//            _object[4].load();
//            _object[5].load();

//        }


//        protected override void OnRenderFrame(FrameEventArgs args)
//        {
//            base.OnRenderFrame(args);
//            GL.Clear(ClearBufferMask.ColorBufferBit);
//            _object[0].render(0);
//            _object[1].render(0);
//            _object[2].render(1);
//            _object[3].render(1);


//            if (_object[4].getVerticesLength())
//            {
//                List<float> _verticesTemp = _object[4].createCurveBezier();
//                _object[5].setVertices(_verticesTemp.ToArray());
//                _object[5].load();
//                _object[5].render(3);
//            }

//            _object[4].render(2);


//            SwapBuffers();
//        }

//        protected override void OnResize(ResizeEventArgs e)
//        {
//            base.OnResize(e);
//            Console.WriteLine("Sudah di resize");
//            GL.Viewport(0, 0, Size.X, Size.Y);
//        }

//        protected override void OnUpdateFrame(FrameEventArgs args)
//        {
//            base.OnUpdateFrame(args);

//            var input = KeyboardState;
//            var mouse_input = MouseState;

//            if (input.IsKeyDown(Keys.Escape))
//            {
//                Close();
//            }

//            if (input.IsKeyReleased(Keys.A))
//            {
//                Console.WriteLine("A sudah di tekan");
//            }

//        }

//        protected override void OnMouseDown(MouseButtonEventArgs e)
//        {
//            base.OnMouseDown(e);
//            if (e.Button == MouseButton.Left)
//            {
//                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
//                float _y = -(MousePosition.Y - Size.Y / 2) / (Size.Y / 2);

//                Console.WriteLine("x: " + _x + ", y: " + _y);
//                _object[4].updateMousePosition(_x, _y);

//            }
//        }
//    }
//}