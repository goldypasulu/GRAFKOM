using LearnOpenTK.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace tugasPohon
{
    internal class windows : GameWindow
    {



        //int _vertexBufferObject;
        //int _vertexArrayObject;
        //int _elementbuffer;
        //int vertexElementObject;
        //int vertexArrayObject;
        //Shader _shader;

        static class Constants
        {
            //public const string path = "C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/pert1/shader/";
            public const string path = "C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/tugasPohon/shader/";
            //public const string path = "../../../shader";
        }
        Asset2D[] _object = new Asset2D[4];
        public windows(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            //segitiga
            base.OnLoad();
            GL.ClearColor(0.0f, 0.29f, 1.0f, 1.0f);
            _object[1] = new Asset2D(
                new float[]
                {
                    -0.25f,-0.2f,0.0f,
                    0.25f,-0.2f,0.0f,
                    0.0f,0.5f,0.0f
                },
                new uint[] { }
                );
            _object[1].Load(Constants.path + "shader.vert", Constants.path + "shader.frag");
            _object[2] = new Asset2D(
               new float[]
               {
                    0.25f,0.2f,0.0f,
                    -0.25f,0.2f,0.0f,
                    0.0f,0.9f,0.0f
               },
               new uint[] { }
               );
            _object[2].Load(Constants.path + "segitiga2.vert", Constants.path + "segitiga2.frag");
            _object[0] = new Asset2D(
              new float[]
              {
                   -0.25f,-0.6f,0.0f,
                    0.25f,-0.6f,0.0f,
                    0.0f,0.1f,0.0f
              },
              new uint[] { }
              );
            _object[0].Load(Constants.path + "segitiga3.vert", Constants.path + "segitiga3.frag");
            _object[3] = new Asset2D(
              new float[]
              {
                    0.10f,-0.60f,0.0f,
                    0.10f,-0.95f,0.0f,
                   -0.10f,-0.95f,0.0f,
                   -0.10f,-0.60f,0.0f
              },
              new uint[] 
              {
                  0,1,2,
                  0,2,3
              }
              );
            _object[3].Load(Constants.path + "persegi.vert", Constants.path + "persegi.frag");




            //_shader = new Shader("C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/pert1/shader/shader.vert", "C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/pert1/shader/shader.frag");
            //_shader.Use();


        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //_shader.Use();
            //int vertColorLoc = GL.GetUniformLocation(_shader.Handle, "ourColor");
            //GL.Uniform4(vertColorLoc, 0.2f, 0.3f, 0.1f, 1.0f);
            //GL.BindVertexArray(_vertexArrayObject);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            //GL.BindVertexArray(vertexArrayObject);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, 4);
            //GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            _object[0].render();
            _object[1].render();
            _object[2].render();
            _object[3].render();
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
    }
}
