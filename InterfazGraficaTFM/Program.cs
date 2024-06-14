using LearnOpenTK.Common;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Diagnostics;
using System.Reflection;
using System.Reflection.Metadata;

namespace InterfazGrafica
{

    public class Game : GameWindow
    {
        static int width = 800;
        static int height = 800;
        static string title = "FirstWindow";

        private int VertexBufferObject;
        private int VertexArrayObject;
        private int ElementBufferObject;
        float Color = 1.0f;

        float[] verticesCubo = 
        {
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 0.0f,

            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 1.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,

            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,

            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,
             0.5f, -0.5f, -0.5f,  1.0f, 1.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
             0.5f, -0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f, -0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f, -0.5f, -0.5f,  0.0f, 1.0f,

            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
             0.5f,  0.5f, -0.5f,  1.0f, 1.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
             0.5f,  0.5f,  0.5f,  1.0f, 0.0f,
            -0.5f,  0.5f,  0.5f,  0.0f, 0.0f,
            -0.5f,  0.5f, -0.5f,  0.0f, 1.0f,
            ////////////////////////////////
             5, 0f, 0f,  0.0f, 0.0f,    //frente
             6f, 0f, 0f,  1.0f, 0.0f,
             6f,  1f, 0f,  1.0f, 1.0f,
             6f,  1f, 0f,  1.0f, 1.0f,
             5f,  1f, 0f,  0.0f, 1.0f,
             5f, 0f, 0f,  0.0f, 0.0f,

             5, 0f, -1f,  0.0f, 0.0f,   //espalda
             6f, 0f, -1f,  1.0f, 0.0f,
             6f,  1f, -1f,  1.0f, 1.0f,
             6f,  1f, -1f,  1.0f, 1.0f,
             5f,  1f, -1f,  0.0f, 1.0f,
             5f, 0f, -1f,  0.0f, 0.0f,

             5f,  1f,  0f,  1.0f, 0.0f,  //lado izquierdo
             5f,  1f, -1f,  1.0f, 1.0f,
             5f, 0f, -1f,  0.0f, 1.0f,
             5f, 0f, -1f,  0.0f, 1.0f,
             5f, 0f,  0f,  0.0f, 0.0f,
             5f,  1f,  0f,  1.0f, 0.0f,

             6f,  1f,  0f,  1.0f, 0.0f, //lado derecho
             6f,  1f, -1f,  1.0f, 1.0f,
             6f, 0f, -1f,  0.0f, 1.0f,
             6f, 0f, -1f,  0.0f, 1.0f,
             6f, 0f,  0f,  0.0f, 0.0f,
             6f,  1f,  0f,  1.0f, 0.0f,

             5f, 0f, -1f,  0.0f, 1.0f, //base
             6f, 0f, -1f,  1.0f, 1.0f,
             6f, 0f,  0f,  1.0f, 0.0f,
             6f, 0f,  0f,  1.0f, 0.0f,
             5f, 0f,  0f,  0.0f, 0.0f,
             5f, 0f, -1f,  0.0f, 1.0f,

             5f, 1f, -1f,  0.0f, 1.0f,// parte alta
             6f, 1f, -1f,  1.0f, 1.0f,
             6f, 1f,  0f,  1.0f, 0.0f,
             6f, 1f,  0f,  1.0f, 0.0f,
             5f, 1f,  0f,  0.0f, 0.0f,
             5f, 1f, -1f,  0.0f, 1.0f,
        };
        

        float[] verticesCuadradoColor =
        {
            //positions            colors//
            0.5f,  0.5f, 0.0f,    1.0f, 0.0f, 0.0f,   // top right
            0.5f, -0.5f, 0.0f,    0.0f, 1.0f, 0.0f,  // bottom right
            -0.5f, -0.5f, 0.0f,   0.0f, 0.0f, 1.0f,   // bottom left
            -0.5f,  0.5f, 0.0f,   1.0f, 0.0f, 1.0f,  // top left
        };

        float[] verticesCuadradoTextura =
        {
            //Position          Texture coordinates
             0.5f,  0.5f, 0.0f, 1.0f, 1.0f, // top right
             0.5f, -0.5f, 0.0f, 1.0f, 0.0f, // bottom right
            -0.5f, -0.5f, 0.0f, 0.0f, 0.0f, // bottom left
            -0.5f,  0.5f, 0.0f, 0.0f, 1.0f  // top left
        };

        //array de ints de 32 bits
        uint[] indices =
        {
            0,1,3, //primer triangulo
            1,2,3  //segundo triangulo
        };
        
        float[] vertices = {

            -0.5f, -0.5f, 0.0f, //vertice izq inf
            0.5f, -0.5f, 0.0f,//vertice der inf
            0.0f, 0.5f, 0.0f,//vertice superior

        };

        private Shader shader;
        private Shader shader2;

        private Camera camera;

        private Texture _texture;
        private Texture _texture2;
        private Texture _texture3;
        private Texture _texture4;
        private Texture _texture5;
        private Texture _texture6;
        private Texture _texture7;
        private Texture _texture8;

        Stopwatch stopwatch = new Stopwatch();
        double timeValue;

        float speed = 2f;
        float sensibilidad = 0.03f;

        Vector3 position = new Vector3(0.0f, 0.0f, 3.0f);
        Vector3 front = new Vector3(0.0f, 0.0f, -1.0f);
        Vector3 up = new Vector3(0.0f, 1.0f, 0.0f);

        Matrix4 MovingMatrix;


        Vector3 _cameraPosition;
        Vector3 _ViewVectorUp;
        Vector3 _cameraTarget;
        Matrix4 view;


        Vector2 lastPos;
        bool _firstMove = true;
        public float _pitch;
        public float _yaw = -MathHelper.PiOver2;
        public float _fov = MathHelper.PiOver2;
        public Game(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

        /*protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);

            if (IsFocused) // check to see if the window is focused  
            {
                Mouse.SetPosition(e.X + Width / 2f, e.Y + Height / 2f);
            }
        }*/

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            if (!IsFocused) // check to see if the window is focused
            {
                return;
            }

            KeyboardState input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            if (input.IsKeyDown(Keys.W))
            {
                position += front * speed * (float)e.Time; //Forward 
            }

            if (input.IsKeyDown(Keys.S))
            {
                position -= front * speed * (float)e.Time; //Backwards
            }

            if (input.IsKeyDown(Keys.A))
            {
                position -= Vector3.Normalize(Vector3.Cross(front, up)) * speed * (float)e.Time; //Left
            }

            if (input.IsKeyDown(Keys.D))
            {
                position += Vector3.Normalize(Vector3.Cross(front, up)) * speed * (float)e.Time; //Right
            }

            if (input.IsKeyDown(Keys.Space))
            {
                position += up * speed * (float)e.Time; //Up 
            }

            if (input.IsKeyDown(Keys.LeftShift))
            {
                position -= up * speed * (float)e.Time; //Down
            }
            Console.WriteLine(position);
            Console.WriteLine("fov: " + _fov);

            //ratón
            var mouse = MouseState;
            if (_firstMove)
            {
                lastPos = new Vector2(mouse.X, mouse.Y);
                _firstMove = false;
            }
            else
            {
                float deltaX = mouse.X - lastPos.X;
                float deltaY = mouse.Y - lastPos.Y;
                lastPos = new Vector2(mouse.X, mouse.Y);
                
                _yaw += deltaX * sensibilidad;
                _pitch -= deltaY * sensibilidad;

                if (_pitch > 89.0f)
                {
                    _pitch = 89.0f;
                }
                else if (_pitch < -89.0f)
                {
                    _pitch = -89.0f;
                }
                else
                {
                    _pitch -= deltaY * sensibilidad;
                }
            }

            front.X = (float)Math.Cos(MathHelper.DegreesToRadians(_pitch)) * (float)Math.Cos(MathHelper.DegreesToRadians(_yaw));
            front.Y = (float)Math.Sin(MathHelper.DegreesToRadians(_pitch));
            front.Z = (float)Math.Cos(MathHelper.DegreesToRadians(_pitch)) * (float)Math.Sin(MathHelper.DegreesToRadians(_yaw));
            front = Vector3.Normalize(front);
        
     
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);

            if (_fov > 150.0f)
            {
                _fov = 150.0f;
            }
            else if (_fov < 1.0f)
            {
                _fov = 1.0f;
            }
            else
            {
                _fov -= e.OffsetY;
            }
            
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, e.Width, e.Height); //asigna las coordenadas normalizadas del dispositivo (NDC) a la ventana
        }
        
        protected override void OnLoad()
        {
            base.OnLoad();
            CursorState = CursorState.Grabbed;
            _fov = 60;
            position = (-10f, 0f, 0f);
            /*float[] borderColor = { 1.0f, 1.0f, 0.0f, 1.0f };
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureBorderColor, borderColor);*/


            int nrAttributes = 0;
            GL.GetInteger(GetPName.MaxVertexAttribs, out nrAttributes);
            Console.WriteLine("Maximum number of vertex attributes supported: " + nrAttributes);

            GL.Enable(EnableCap.DepthTest);
            GL.ClearColor(0.1f, 0.7f, 0.7f, 1.0f); //Color de la ventana

            //Creando un VBO vertex buffer object
            VertexBufferObject = GL.GenBuffer(); //genera un VBO
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferObject); //asigna el buffer que acabamos de crear al buffer target que elijamos, en este caso sería un ArrayBuffer porque tenemos 
                                                                         //un array de vértices dando lugar a nuestro triángulo

            GL.BufferData(BufferTarget.ArrayBuffer, verticesCubo.Length * sizeof(float), verticesCubo, BufferUsageHint.StaticDraw);//Crea el espacio en la memoria para almacenar el buffer
                                                                                                                                           //teniendo en cuenta el tipo de buffer, dato, tamaño y uso de la memoria
                 
            //Creando un VAO vertex array object
            VertexArrayObject = GL.GenVertexArray(); //genera un VAO
            GL.BindVertexArray(VertexArrayObject);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0); //atrib pointer de las posiciones

            //Creando un EBO element buffer object
            ElementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, ElementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

            shader = new Shader("shader.vert", "shader.frag");
            shader.Use();

            int vertexLocation = shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);



            int texCoordLocation = shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float)); //atrib pointer de los colores 

            ////////////
            
           /*shader2 = new Shader("shader2.vert", "shader2.frag");
           shader2.Use();

            int vertexLocation2 = shader2.GetAttribLocation("aPosition2");
            GL.EnableVertexAttribArray(vertexLocation2);
            GL.VertexAttribPointer(vertexLocation2, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 180);



            int texCoordLocation2 = shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation2);
            GL.VertexAttribPointer(texCoordLocation2, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float)); //atrib pointer de los colores
            */
            _texture = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Peepo.jpg");
            _texture.Use(TextureUnit.Texture0);

            _texture2 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/awesomeface.png");
            _texture2.Use(TextureUnit.Texture1);

            _texture3 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo.png");
            _texture3.Use(TextureUnit.Texture2);

            _texture4 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo2.png");
            _texture4.Use(TextureUnit.Texture3);

            _texture5 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo3.png");
            _texture5.Use(TextureUnit.Texture4);

            _texture6 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo4.png");
            _texture6.Use(TextureUnit.Texture5);

            _texture7 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo5.png");
            _texture7.Use(TextureUnit.Texture6);

            _texture8 = Texture.LoadFromFile("../../../../../InterfazGraficaTFM/InterfazGraficaTFM/bin/Fondo6.png");
            _texture8.Use(TextureUnit.Texture7);

            shader.SetInt("texture1", 0);
            shader.SetInt("texture2", 1);
            shader.SetInt("texture3", 2);
            shader.SetInt("texture4", 3);
            shader.SetInt("texture5", 4);
            /*shader2.SetInt("texture1", 0);
            shader2.SetInt("texture2", 1);*/

        }
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            /*float period = 8.0f;
            Console.WriteLine("valor del tiempo en segundos: " + timeValue);
            float greenValue = ((float)Math.Sin(timeValue)/period) / 2.0f + 0.5f;
            //Console.WriteLine("Valor del seno: " + greenValue);*/
            //int vertexColorLocation = GL.GetUniformLocation(shader.Handle, "ourColor");
            //GL.Uniform4(vertexColorLocation, 0.0f, greenValue, 0.0f, 1.0f);


            GL.BindVertexArray(VertexArrayObject);


            stopwatch.Start();
            timeValue = stopwatch.Elapsed.TotalSeconds;

            //RotacionPlano();
            //CreacionCamara();
            //Matriz3DMovimiento();

            float tiempo = (float)timeValue;
            Matrix4 rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(tiempo * -80));
            Matrix4 rotation2 = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(tiempo * -60));
            Matrix4 rotation3 = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(tiempo * -50));
            Matrix4 rotation4 = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians( -50)) * rotation2;
            Matrix4 rotation5 = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(100)) * rotation4;
            Matrix4 rotation6 = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(-100)) * rotation4;
            Matrix4 rotation7 = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(-70)) * rotation4;
            float SinTime = ((float)Math.Sin(timeValue)) * 5f ;
            Matrix4 translation = Matrix4.CreateTranslation(0.0f, 0.0f, SinTime * -1f);
            
            Vector3 cameraStart = (-5f, 0.0f, 20f);
            shader.SetMatrix4("model", rotation);
            shader.SetMatrix4("view", translation * Matrix4.LookAt(position, position + front  , up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            //WalkAround();

            _texture5.Use(TextureUnit.Texture0);
            _texture2.Use(TextureUnit.Texture1);
            //_texture3.Use(TextureUnit.Texture0);
            shader.Use();
            

            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);//Cubo 1
            

            shader.SetMatrix4("model", rotation2);
            shader.SetMatrix4("view", Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture3.Use(TextureUnit.Texture0);
            //shader.Use();
            GL.DrawArrays(PrimitiveType.Triangles, 36, 72);// Cubo 2
            
            shader.SetMatrix4("model", rotation3);
            shader.SetMatrix4("view", Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture4.Use(TextureUnit.Texture0);
            //shader.Use();
            GL.DrawArrays(PrimitiveType.Triangles, 36, 72);// Cubo 3

            shader.SetMatrix4("model", rotation4);
            shader.SetMatrix4("view", Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture5.Use(TextureUnit.Texture0);
            GL.DrawArrays(PrimitiveType.Triangles, 36, 72);// Cubo 4

            //GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

            shader.SetMatrix4("model", rotation5);
            shader.SetMatrix4("view", translation * Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture6.Use(TextureUnit.Texture0);
            GL.DrawArrays(PrimitiveType.Triangles, 36, 72);// Cubo 5

            shader.SetMatrix4("model", rotation6);
            shader.SetMatrix4("view", Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture7.Use(TextureUnit.Texture0);
            GL.DrawArrays(PrimitiveType.Triangles, 36, 72);// Cubo 6

            shader.SetMatrix4("model", rotation7);
            shader.SetMatrix4("view", Matrix4.LookAt(position, position + front, up));
            shader.SetMatrix4("projection", Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(_fov), width / height, 0.1f, 100.0f));

            _texture8.Use(TextureUnit.Texture0);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 36);// Cubo 7




            SwapBuffers();
            
        }
        void WalkAround()
        {
            MovingMatrix = Matrix4.LookAt(position, position + front, up);
            shader.SetMatrix4("MovingMatrix", MovingMatrix);
        }
        void CreacionCamara()
        {
        //Creacion de la camara paso a paso
            //Seteas posicion
            Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 3.0f);
            //Seteas dirección del objetivo
            Vector3 Target = Vector3.Zero;
            Vector3 cameraDirection = Vector3.Normalize(cameraPosition - Target);
            //Seteas Eje X
            Vector3 ViewVectorUp = Vector3.UnitY;
            Vector3 cameraRigth = Vector3.Normalize(Vector3.Cross(cameraDirection, ViewVectorUp));
            //Seteas eje Y
            Vector3 cameraUp = Vector3.Cross(cameraDirection, cameraRigth);

            _cameraPosition = cameraPosition;
            _cameraTarget = Target;
            _ViewVectorUp = cameraUp;

        //Así podriamos crear la matriz view de nuestra camara en un solo paso
            view = Matrix4.LookAt(_cameraPosition, _cameraTarget, _ViewVectorUp);

        }
        void RotacionPlano()
        {
            float tiempo = (float)timeValue;
            Matrix4 rotation = Matrix4.CreateRotationX(MathHelper.DegreesToRadians(tiempo * 50));
            Matrix4 scale = Matrix4.CreateScale(1.5f, 1.5f, 1.5f);
            Matrix4 trans = rotation * scale;
            shader.SetMatrix4("transform", trans);
        }
        void Matriz3DMovimiento()
        {
            float tiempo = (float)timeValue;
            Matrix4 rotation = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(tiempo * -70));
            float greenValue = ((float)Math.Sin(timeValue)) /2 - 0.7f;
            //Console.WriteLine(greenValue);
            //Matrix4 view = Matrix4.CreateTranslation(0.0f, 0.0f, greenValue * 10.0f);
            
            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(60.0f), width / height, 0.1f, 100.0f);

            shader.SetMatrix4("model", rotation);
            shader.SetMatrix4("view", view);
            shader.SetMatrix4("projection", projection);
        }
        static void Main(string[] args)
        {
            using (Game game = new Game(width, height, title))
            {
                game.Run();
            }
        }
        protected override void OnUnload()
        {
            base.OnUnload();

            shader.Dispose();
        }
        public void MatrizTranslacion()
        {
            Vector4 vec = new Vector4(1.0f, 0.0f, 0.0f, 1.0f);
            Matrix4 translationMatrix = Matrix4.CreateTranslation(1f, 1f, 0.0f);
            vec *= translationMatrix;
            Console.WriteLine("{0}, {1}, {2}", vec.X, vec.Y, vec.Z);
        }
        public void RotarEscalarCuboTIME()
        {
            float tiempo = (float)timeValue;
            Matrix4 rotation = Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(tiempo * 10));
            Matrix4 scale = Matrix4.CreateScale(2f, 2f, 2f);

            Matrix4 trans = rotation * scale;
        }
    }
    
    
    public class Shader
    {
        private bool disposedValue = false;

        public int Handle;
        public Shader(string vertexPath, string fragmentPath)
        {

            
            int VertexShader;
            int FragmentShader;

            string VertexShaderSource = File.ReadAllText(vertexPath);
            string FragmentShaderSource = File.ReadAllText(fragmentPath);

            VertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(VertexShader, VertexShaderSource);

            FragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(FragmentShader, FragmentShaderSource);

            GL.CompileShader(VertexShader);
            GL.GetShader(VertexShader, ShaderParameter.CompileStatus, out int VertexSuccess);
            if(VertexSuccess == 0)
            {
                string infoLog = GL.GetShaderInfoLog(VertexShader);
                Console.WriteLine(infoLog);
            }

            GL.CompileShader(FragmentShader);
            GL.GetShader(FragmentShader, ShaderParameter.CompileStatus, out int FragmentSuccess);
            if(FragmentSuccess == 0)
            {
                string infoLog = GL.GetShaderInfoLog(FragmentShader);
                Console.WriteLine(infoLog);
            }

            Handle = GL.CreateProgram();

            GL.AttachShader(Handle, VertexShader);
            GL.AttachShader(Handle, FragmentShader);

            GL.LinkProgram(Handle);

            GL.GetProgram(Handle, GetProgramParameterName.LinkStatus, out int success);
            if(success == 0)
            {
                string infoLog = GL.GetProgramInfoLog(Handle);
                Console.WriteLine(infoLog);
            }

            //Una vez linkeados los shader al program la informacion al compilar va directamente a este y por lo tanto ya no necesitamos los shaders individuales
            GL.DetachShader(Handle, VertexShader);
            GL.DetachShader(Handle, FragmentShader);
            GL.DeleteShader(VertexShader);
            GL.DeleteShader(FragmentShader);

        }
        
        public void Use()
        {
            GL.UseProgram(Handle);
        }
        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(Handle, attribName);
        }
        public void SetInt(string name, int value)
        {
            int location = GL.GetUniformLocation(Handle, name);
            GL.Uniform1(location, value);
        }
        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Handle);
            int location = GL.GetUniformLocation(Handle, name);
            GL.UniformMatrix4(location, true, ref data);
        }
        protected virtual void Dispose(bool disposing) //no sé por qué es necesario este bool, si lo quito no puedo usar la función derivada public void Dispose()
        {
            if (!disposedValue)
            {
                GL.DeleteProgram(Handle);

                disposedValue = true;
            }
        }
        
        //No hace nada
        Shader()
        {
            GL.DeleteProgram(Handle);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}