using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tugasPohon
{
    internal class Asset2D
    {
        //float[] _verticesSquare =
        //{
        //    //x   //y   //z
        //    0.5f,0.5f,0.0f,//vertex1
        //    0.5f,-0.5f,0.0f,//
        //    -0.5f,-0.5f,0.0f,
        //    -0.5f,0.5f,0.0f

        //};
        float[] _verticestriangel =
           {
               //x   //y   //z
             

           };
        uint[] _indices = //untuk mengabungkan gambar
        {

        };
        int _elementbuffer;
        int _vertexBufferObject;
        int _vertexArrayObject;
        Shader _shader;
        public Asset2D(float[] verctices, uint[] indices)
        {
            _verticestriangel = verctices;
            _indices = indices;
        }
        public void Load(string shadervert, string shaderfrag)
        {
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _verticestriangel.Length * sizeof(float), _verticestriangel, BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            ////Mereperensentasikan satu baris  jika tulisanya 6  = isi baris 6
            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);
            //GL.EnableVertexAttribArray(0);
            //////Untuk mmebuat komputer membaca warna dari index 3
            //GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            //////GL v lek ^ di isi 1 maka V juga 1
            //GL.EnableVertexAttribArray(1);

            //persegi
            //vertexElementObject = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ArrayBuffer, vertexElementObject);
            //GL.BufferData(BufferTarget.ArrayBuffer, _verticesSquare.Length * sizeof(float), _verticesSquare, BufferUsageHint.StaticDraw);
            //vertexArrayObject = GL.GenVertexArray();
            //GL.BindVertexArray(vertexArrayObject);
            //GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            //GL.EnableVertexAttribArray(0);
            //_elementbuffer = GL.GenBuffer();
            //GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementbuffer);
            //GL.BufferData(BufferTarget.ElementArrayBuffer,_indices.Length * sizeof(uint), _indices,BufferUsageHint.StaticDraw);

            if (_indices.Length != 0)
            {
                _elementbuffer = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementbuffer);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            }
            //_shader = new Shader("C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/pert1/shader/shader.vert", "C:/Users/HP-Omen/Documents/petra/GrafKom/pert1/pert1/shader/shader.frag");
            _shader = new Shader(shadervert, shaderfrag);
            _shader.Use();
        }
        public void render()
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            if (_indices.Length != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }

        }
    }
}
