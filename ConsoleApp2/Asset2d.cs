using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ConsoleApp2
{

    static class Constants
    {
        public const string path = "../../../Shaders/";
    }
    internal class Asset2d
    {
        float[] _vertices =
        {

        };

        uint[] _indices =
        {

        };

        float[] _colors =
        {

        };

        int _vertexBufferObject;
        int _elementBufferObject;
        int _vertexArrayObject;
        Shader _shader;
        int indexs;
        int[] _pascal;

        // Constructor
        public Asset2d(float[] vertices, uint[] indices, float[] colors)
        {
            _vertices = vertices;
            _indices = indices;
            _colors = colors;
            indexs = 0;
        }

        public void load()
        {
            // Inisialisasi
            _vertexBufferObject = GL.GenBuffer();

            // Menentukan target dan yang menghandlenya
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            // Parameter 1 = var _vertices itu disimpan di shader index ke berapa
            // Parameter 2 = Berapa index dalam var _vertices
            // Parameter 3 = Jenis vertex yang dikirim tipenya apa
            // Parameter 4 = Apa data perlu dinormalisasi
            // Parameter 5 = Berapa banyak titik yang ada di dalam 1 vertex
            // Parameter 6 = Vertex start dari data yg mau diolah
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            // 0 = Referensi dari Parameter 1
            GL.EnableVertexAttribArray(0);


            /*// Buat verteks beda warna
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 0);

            // 0 = Referensi dari Parameter 1
            GL.EnableVertexAttribArray(0);

            // Untuk set warna nya
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, false, 6 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);*/

            if (_indices.Length != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint),
                    _indices, BufferUsageHint.StaticDraw);
            }

            _shader = new Shader(Constants.path + "Shader.vert", Constants.path + "Shader.frag");
            _shader.Use();
        }

        public void render(int pilihan)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);

            if (_indices.Length != 0)
            {
                // Segitiga Multiple
                GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (pilihan == 0)
                {
                    // Segitiga Single
                    GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
                }
                else if (pilihan == 1)
                {
                    // Lingkaran
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0, ((_vertices.Length + 1) / 3));
                }
                else if (pilihan == 2)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, indexs);
                }
                else if (pilihan == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, ((_vertices.Length + 1) / 3));
                }

            }

            // Untuk set color bebas pakai uniform
            int colorsindexLocation = GL.GetUniformLocation(_shader.Handle, "ourColor");

            if (_colors.Length != 0)
            {
                GL.Uniform4(colorsindexLocation, _colors[0], _colors[1], _colors[2], _colors[3]);
            }
            else
            {
                GL.Uniform4(colorsindexLocation, 0.0f, 0.2588f, 0.1451f, 0.0f);
            }

        }

        public void createCircle(float center_x, float center_y, float radius)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                // x
                _vertices[i * 3] = radius * (float)Math.Cos(degInRad) + center_x;
                // y
                _vertices[i * 3 + 1] = radius * (float)Math.Sin(degInRad) + center_y;
                // z
                _vertices[i * 3 + 2] = 0;

            }
        }

        public void createEllips(float center_x, float center_y, float radiusX, float radiusY)
        {
            _vertices = new float[1080];
            for (int i = 0; i < 360; i++)
            {
                double degInRad = i * Math.PI / 180;
                // x
                _vertices[i * 3] = radiusX * (float)Math.Cos(degInRad) + center_x;
                // y
                _vertices[i * 3 + 1] = radiusY * (float)Math.Sin(degInRad) + center_y;
                // z
                _vertices[i * 3 + 2] = 0;

            }
        }

        public void updateMousePosition(float _x, float _y)
        {
            _vertices[indexs * 3] = _x;
            _vertices[indexs * 3 + 1] = _y;
            _vertices[indexs * 3 + 2] = 0;
            indexs++;

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        }

        public List<int> getRow(int rowIndex)
        {
            List<int> currow = new List<int>();

            // 1st element of every row is 1
            currow.Add(1);

            // Check if the row that has to
            // be returned is the first row
            if (rowIndex == 0)
            {
                return currow;
            }
            // Generate the previous row
            List<int> prev = getRow(rowIndex - 1);

            for (int i = 1; i < prev.Count; i++)
            {

                // Generate the elements
                // of the current row
                // by the help of the
                // previous row
                int curr = prev[i - 1] + prev[i];
                currow.Add(curr);
            }
            currow.Add(1);

            // Return the row
            return currow;
        }

        public Vector2 getP(int n, float t)
        {
            Vector2 p = new Vector2(0, 0);
            float k;
            for (int i = 0; i < n; i++)
            {
                k = (float)Math.Pow((1 - t), n - 1 - i)
                    * (float)Math.Pow(t, i) * _pascal[i];
                p.X += k * _vertices[i * 3];
                p.Y += k * _vertices[i * 3 + 1];
            }

            return p;
        }

        public List<float> createCurveBezier()
        {
            List<float> _vertices_bezier = new List<float>();
            List<int> pascal = getRow(indexs - 1);
            _pascal = pascal.ToArray();

            for (float t = 0; t <= 1.0f; t += 0.01f)
            {
                Vector2 p = getP(indexs, t);
                _vertices_bezier.Add(p.X);
                _vertices_bezier.Add(p.Y);
                _vertices_bezier.Add(0);
            }

            return _vertices_bezier;
        }

        public bool getVerticesLength()
        {
            if (_vertices[0] == 0)
            {
                return false;
            }
            if ((_vertices.Length + 1) / 3 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setVertices(float[] _temp)
        {
            _vertices = _temp;
        }
    }
}