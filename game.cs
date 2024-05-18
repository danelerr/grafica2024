using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace ProGrafica
{
    class game : GameWindow
    {
        private Double theta = 0;
        private double phi = 0;
        Escena cuarto;
        public Ejecucion hilo;
        private Libreto libreto;
        Thread miHilo;



        public game(int widht, int height, string title) : base(widht, height, GraphicsMode.Default, title)
        {
            // -------------------- EL OBJETO TV ------------------- //

            Color color1 = Color.Black; 
            Color color2 = Color.FromArgb(41, 41, 41);
            Color color3 = Color.FromArgb(32, 32, 32);
            Color color4 = Color.FromArgb(23, 22, 22);

            // Definir los vértices de cada polígono
            Poligono cara1 = new Poligono(color1, new Point(0f, 0f, 1f));
            cara1.addVertice(2f, 2f, 0f);
            cara1.addVertice(48, 2f, 0f);
            cara1.addVertice(48f, 38f, 0f);
            cara1.addVertice(2f, 38f, 0f);

            Poligono cara2 = new Poligono(color2, new Point(0f, 0f, 0f));
            cara2.addVertice(22f, 0f, 0f);
            cara2.addVertice(22f, -20f, 0f);
            cara2.addVertice(26f, -20f, 0f);
            cara2.addVertice(26f, 0f, 0f);

            Poligono cara3 = new Poligono(color3, new Point(0f, 0f, 0f));
            cara3.addVertice(0f, 0f, 0f);
            cara3.addVertice(50f, 0f, 0f);
            cara3.addVertice(50f, 40f, 0f);
            cara3.addVertice(0f, 40f, 0f);

            Poligono cara4 = new Poligono(color4, new Point(0f, 0f, 0f));
            cara4.addVertice(12f, -20f, 0f);
            cara4.addVertice(36f, -20f, 0f);
            cara4.addVertice(36f, -10f, 0f);
            cara4.addVertice(12f, -10f, 0f);

            Poligono cara5 = new Poligono(color3, new Point(0f, 0f, 0f));
            cara5.addVertice(0f, 0f, -8f);
            cara5.addVertice(50f, 0f, -8f);
            cara5.addVertice(50f, 40f, -8f);
            cara5.addVertice(0f, 40f, -8f);

            Poligono cara6 = new Poligono(color2, new Point(0f, 0f, 0f));
            cara6.addVertice(22f, 0f, -8f);
            cara6.addVertice(22f, -20f, -8f);
            cara6.addVertice(26f, -20f, -8f);
            cara6.addVertice(26f, 0f, -8f);

            Poligono cara7 = new Poligono(color4, new Point(0f, 0f, 0f));
            cara7.addVertice(12f, -20f, -8f);
            cara7.addVertice(36f, -20f, -8f);
            cara7.addVertice(36f, -10f, -8f);
            cara7.addVertice(12f, -10f, -8f);

            Poligono cara8 = new Poligono(color3, new Point(0f, 0f, 0f));
            cara8.addVertice(0f, 0f, 0f);
            cara8.addVertice(0f, 0f, -8f);
            cara8.addVertice(0f, 40f, 0f);
            cara8.addVertice(0f, 40f, -8f);

            Poligono cara9 = new Poligono(color4, new Point(0f, 0f, 0f));
            cara9.addVertice(36f, -20f, 0f);
            cara9.addVertice(36f, -20f, -8f);
            cara9.addVertice(36f, -10f, -8f);
            cara9.addVertice(36f, -10f, 0f);

            Poligono cara10 = new Poligono(color4, new Point(0f, 0f, 0f));
            cara10.addVertice(12f, -20f, 0f);
            cara10.addVertice(12f, -20f, -8f);
            cara10.addVertice(12f, -10f, -8f);
            cara10.addVertice(12f, -10f, 0f);


            Dictionary<string, Poligono> poligonosTV = new Dictionary<string, Poligono>();
            poligonosTV.Add("cara1", cara1);
            poligonosTV.Add("cara2", cara2);
            poligonosTV.Add("cara3", cara3);
            poligonosTV.Add("cara4", cara4);
            poligonosTV.Add("cara5", cara5);
            poligonosTV.Add("cara6", cara6);
            poligonosTV.Add("cara7", cara7);
            poligonosTV.Add("cara8", cara8);
            poligonosTV.Add("cara9", cara9);
            poligonosTV.Add("cara10", cara10);

            Partes parteTV = new Partes(new Point(0, 0, 0), poligonosTV);

            Dictionary<string, Partes> partesTV = new Dictionary<string, Partes>();
            partesTV.Add("TV", parteTV);

            Objeto tv = new Objeto(new Point(-25, 15, -25), partesTV);

            // -------------------- EL OBJETO TV ------------------- //


            // -------------------- EL OBJETO FLORERO ------------------- //
            // Definir los colores para cada parte del florero
            Color baseColor = Color.Magenta;
            Color lowerBodyColor = Color.Green;
            Color upperBodyColor = Color.Blue;
            Color mouthColor = Color.Yellow;

            // Base del florero
            Poligono baseFlorero = new Poligono(baseColor, new Point(0, -10, 0));
            baseFlorero.addVertice(-2, 0, -2);
            baseFlorero.addVertice(2, 0, -2);
            baseFlorero.addVertice(2, 0, 2);
            baseFlorero.addVertice(-2, 0, 2);

            // Cuerpo inferior del florero
            Poligono cuerpoInferiorFrente = new Poligono(lowerBodyColor, new Point(0, -5, 0));
            cuerpoInferiorFrente.addVertice(-2, -5, 2);
            cuerpoInferiorFrente.addVertice(2, -5, 2);
            cuerpoInferiorFrente.addVertice(1, 0, 2);
            cuerpoInferiorFrente.addVertice(-1, 0, 2);

            Poligono cuerpoInferiorAtras = new Poligono(lowerBodyColor, new Point(0, -5, 0));
            cuerpoInferiorAtras.addVertice(-2, -5, -2);
            cuerpoInferiorAtras.addVertice(2, -5, -2);
            cuerpoInferiorAtras.addVertice(1, 0, -2);
            cuerpoInferiorAtras.addVertice(-1, 0, -2);

            Poligono cuerpoInferiorIzq = new Poligono(lowerBodyColor, new Point(0, -5, 0));
            cuerpoInferiorIzq.addVertice(-2, -5, -2);
            cuerpoInferiorIzq.addVertice(-2, -5, 2);
            cuerpoInferiorIzq.addVertice(-1, 0, 1);
            cuerpoInferiorIzq.addVertice(-1, 0, -1);

            Poligono cuerpoInferiorDer = new Poligono(lowerBodyColor, new Point(0, -5, 0));
            cuerpoInferiorDer.addVertice(2, -5, -2);
            cuerpoInferiorDer.addVertice(2, -5, 2);
            cuerpoInferiorDer.addVertice(1, 0, 1);
            cuerpoInferiorDer.addVertice(1, 0, -1);

            // Cuerpo superior del florero
            Poligono cuerpoSuperiorFrente = new Poligono(upperBodyColor, new Point(0, 0, 0));
            cuerpoSuperiorFrente.addVertice(-1, 0, 2);
            cuerpoSuperiorFrente.addVertice(1, 0, 2);
            cuerpoSuperiorFrente.addVertice(1.5f, 5, 2);
            cuerpoSuperiorFrente.addVertice(-1.5f, 5, 2);

            Poligono cuerpoSuperiorAtras = new Poligono(upperBodyColor, new Point(0, 0, 0));
            cuerpoSuperiorAtras.addVertice(-1, 0, -2);
            cuerpoSuperiorAtras.addVertice(1, 0, -2);
            cuerpoSuperiorAtras.addVertice(1.5f, 5, -2);
            cuerpoSuperiorAtras.addVertice(-1.5f, 5, -2);

            Poligono cuerpoSuperiorIzq = new Poligono(upperBodyColor, new Point(0, 0, 0));
            cuerpoSuperiorIzq.addVertice(-1, 0, 2);
            cuerpoSuperiorIzq.addVertice(-1, 0, -2);
            cuerpoSuperiorIzq.addVertice(-1.5f, 5, -1);
            cuerpoSuperiorIzq.addVertice(-1.5f, 5, 1);

            Poligono cuerpoSuperiorDer = new Poligono(upperBodyColor, new Point(0, 0, 0));
            cuerpoSuperiorDer.addVertice(1, 0, 2);
            cuerpoSuperiorDer.addVertice(1, 0, -2);
            cuerpoSuperiorDer.addVertice(1.5f, 5, -1);
            cuerpoSuperiorDer.addVertice(1.5f, 5, 1);

            // Boca del florero
            Poligono bocaFlorero = new Poligono(mouthColor, new Point(0, 5, 0));
            bocaFlorero.addVertice(-1.5f, 0, -1.5f);
            bocaFlorero.addVertice(1.5f, 0, -1.5f);
            bocaFlorero.addVertice(1.5f, 0, 1.5f);
            bocaFlorero.addVertice(-1.5f, 0, 1.5f);

    
            Dictionary<string, Poligono> poligonosBase = new Dictionary<string, Poligono>();
            poligonosBase.Add("Base", baseFlorero);


            Dictionary<string, Poligono> poligonosCuerpoInferior = new Dictionary<string, Poligono>();
            poligonosCuerpoInferior.Add("CuerpoInferiorFrente", cuerpoInferiorFrente);
            poligonosCuerpoInferior.Add("CuerpoInferiorAtras", cuerpoInferiorAtras);
            poligonosCuerpoInferior.Add("CuerpoInferiorIzq", cuerpoInferiorIzq);
            poligonosCuerpoInferior.Add("CuerpoInferiorDer", cuerpoInferiorDer);

            Dictionary<string, Poligono> poligonosCuerpoSuperior = new Dictionary<string, Poligono>();
            poligonosCuerpoSuperior.Add("CuerpoSuperiorFrente", cuerpoSuperiorFrente);
            poligonosCuerpoSuperior.Add("CuerpoSuperiorAtras", cuerpoSuperiorAtras);
            poligonosCuerpoSuperior.Add("CuerpoSuperiorIzq", cuerpoSuperiorIzq);
            poligonosCuerpoSuperior.Add("CuerpoSuperiorDer", cuerpoSuperiorDer);

            Dictionary<string, Poligono> poligonosBoca = new Dictionary<string, Poligono>();
            poligonosBoca.Add("Boca", bocaFlorero);

            Partes basePart = new Partes(new Point(0, 0, 0), poligonosBase);
            Partes cuerpoInferiorPart = new Partes(new Point(0, 0, 0), poligonosCuerpoInferior);
            Partes cuerpoSuperiorPart = new Partes(new Point(0, 0, 0), poligonosCuerpoSuperior);
            Partes bocaPart = new Partes(new Point(0, 0, 0), poligonosBoca);


            Dictionary<string, Partes> partesFlorero = new Dictionary<string, Partes>();
            partesFlorero.Add("Base", basePart);
            partesFlorero.Add("CuerpoInferior", cuerpoInferiorPart);
            partesFlorero.Add("CuerpoSuperior", cuerpoSuperiorPart);
            partesFlorero.Add("Boca", bocaPart);

            // Crear el objeto florero
            Objeto florero = new Objeto(new Point(-40, 0, -20), partesFlorero);
            // -------------------- EL OBJETO FLORERO ------------------- //




            // -------------------- EL OBJETO CUBO ------------------- //

            Color colorFrontal = Color.Red;
            Color colorTrasero = Color.Blue;
            Color colorIzquierdo = Color.Green;
            Color colorDerecho = Color.Yellow;
            Color colorSuperior = Color.Orange;
            Color colorInferior = Color.Purple;


            Poligono caraFrontal = new Poligono(colorFrontal, new Point(0, 0, 0));
            caraFrontal.addVertice(-4, -4, 4);
            caraFrontal.addVertice(4, -4, 4);
            caraFrontal.addVertice(4, 4, 4);
            caraFrontal.addVertice(-4, 4, 4);

            Poligono caraTrasera = new Poligono(colorTrasero, new Point(0, 0, 0));
            caraTrasera.addVertice(-4, -4, -4);
            caraTrasera.addVertice(4, -4, -4);
            caraTrasera.addVertice(4, 4, -4);
            caraTrasera.addVertice(-4, 4, -4);

            Poligono caraIzquierda = new Poligono(colorIzquierdo, new Point(0, 0, 0));
            caraIzquierda.addVertice(-4, -4, -4);
            caraIzquierda.addVertice(-4, -4, 4);
            caraIzquierda.addVertice(-4, 4, 4);
            caraIzquierda.addVertice(-4, 4, -4);

            Poligono caraDerecha = new Poligono(colorDerecho, new Point(0, 0, 0));
            caraDerecha.addVertice(4, -4, -4);
            caraDerecha.addVertice(4, -4, 4);
            caraDerecha.addVertice(4, 4, 4);
            caraDerecha.addVertice(4, 4, -4);

            Poligono caraSuperior = new Poligono(colorSuperior, new Point(0, 0, 0));
            caraSuperior.addVertice(-4, 4, -4);
            caraSuperior.addVertice(4, 4, -4);
            caraSuperior.addVertice(4, 4, 4);
            caraSuperior.addVertice(-4, 4, 4);

            Poligono caraInferior = new Poligono(colorInferior, new Point(0, 0, 0));
            caraInferior.addVertice(-4, -4, -4);
            caraInferior.addVertice(4, -4, -4);
            caraInferior.addVertice(4, -4, 4);
            caraInferior.addVertice(-4, -4, 4);

            Dictionary<string, Poligono> poligonosCubo = new Dictionary<string, Poligono>();
            poligonosCubo.Add("CaraFrontal", caraFrontal);
            poligonosCubo.Add("CaraTrasera", caraTrasera);
            poligonosCubo.Add("CaraIzquierda", caraIzquierda);
            poligonosCubo.Add("CaraDerecha", caraDerecha);
            poligonosCubo.Add("CaraSuperior", caraSuperior);
            poligonosCubo.Add("CaraInferior", caraInferior);

            Partes parteCubo = new Partes(new Point(0, 0, 0), poligonosCubo);

            Dictionary<string, Partes> partesCubo = new Dictionary<string, Partes>();
            partesCubo.Add("Cubo", parteCubo);

            Objeto cubo = new Objeto(new Point(10, 10, 0), partesCubo);

            // -------------------- EL OBJETO CUBO ------------------- //




            // -------------------- EL OBJETO PARED ------------------- //

            Color colorPared = Color.FromArgb(1, 255, 255, 204);
            Poligono paredpoly = new Poligono(colorPared, new Point(0, 0, 0));
            paredpoly.addVertice(0, 40, 40);
            paredpoly.addVertice(0, -40, 40);
            paredpoly.addVertice(0, -40, -40);
            paredpoly.addVertice(0, 40, -40);
            Dictionary<string, Poligono> poligonosPared = new Dictionary<string, Poligono>();
            poligonosPared.Add("Pared", paredpoly);
            Partes paredPart = new Partes(new Point(20, 0, 0), poligonosPared);
            paredPart.addPoligono("CaraDeLaPared", paredpoly);

            // -------------------- EL OBJETO PARED ------------------- //



            // -------------------- EL OBJETO REPISA ------------------- //

            Color colorRepisa = Color.FromArgb(101, 56, 24);
            Poligono plataformaRepisa = new Poligono(colorRepisa, new Point(0, -5, 0));
            plataformaRepisa.addVertice(-50, 0, -50);
            plataformaRepisa.addVertice(-50, 0, 50);
            plataformaRepisa.addVertice(50, 0, 50);
            plataformaRepisa.addVertice(50, 0, -50);

            Poligono repisaIzq = new Poligono(colorRepisa, new Point(0, -7, 50));
            repisaIzq.addVertice(-50, 5, 0);
            repisaIzq.addVertice(50, 5, 0);
            repisaIzq.addVertice(50, -5, 0);
            repisaIzq.addVertice(-50, -5, 0);

            Poligono repisaDer = new Poligono(colorRepisa, new Point(0, -7, -50));
            repisaDer.addVertice(-50, 5, 0);
            repisaDer.addVertice(50, 5, 0);
            repisaDer.addVertice(50, -5, 0);
            repisaDer.addVertice(-50, -5, 0);

            Poligono repisaDel = new Poligono(colorRepisa, new Point(-50, -7, 0));
            repisaDel.addVertice(0, 5, 50);
            repisaDel.addVertice(0, 5, -50);
            repisaDel.addVertice(0, -5, -50);
            repisaDel.addVertice(0, -5, 50);

            Dictionary<string, Poligono> poligonosRepisa = new Dictionary<string, Poligono>();
            poligonosRepisa.Add("Plataforma", plataformaRepisa);
            poligonosRepisa.Add("LadoIzquierdo", repisaIzq);
            poligonosRepisa.Add("LadoDerecho", repisaDer);
            poligonosRepisa.Add("LadoDelantero", repisaDel);
            Partes repisaPart = new Partes(new Point(0, 0, 0), poligonosRepisa);
           

            Dictionary<string, Partes> partesRepisa = new Dictionary<string, Partes>();
            partesRepisa.Add("ParteRepisa", repisaPart);
            //partesRepisa.Add("Pared", paredPart);

            Objeto repisa = new Objeto(new Point(0, 0, 0), partesRepisa);

            // -------------------- EL OBJETO REPISA ------------------- //




            // -------------------- CREACION DE LA ESCENA ------------------- //

            Dictionary<string, Objeto> objetosCuarto = new Dictionary<string, Objeto>();
            objetosCuarto.Add("Repisa", repisa);
            objetosCuarto.Add("Cubo", cubo);
            objetosCuarto.Add("TV", tv);
            objetosCuarto.Add("Florero", florero);


            cuarto = new Escena(new Point(0, 0, 0), objetosCuarto);

            // -------------------- CREACION DE LA ESCENA ------------------- //





            // -------------------- CREACION DE LA ANIMACION ------------------- //
            // -------------------- CREACION DE LA ANIMACION ------------------- //
            List<Transformacion> listaDeConversiones = new List<Transformacion>();
            List<Transformacion> listaDeConversiones2 = new List<Transformacion>();
            List<Transformacion> listaDeConversiones3 = new List<Transformacion>();

            // eje x
            Transformacion accion1 = new Transformacion("Traslacion", -70, "x", 10000, 0);
            listaDeConversiones.Add(accion1);

            // eje z
            Transformacion accion2 = new Transformacion("Rotacion", 2000, "z", 10000, 0);
            listaDeConversiones2.Add(accion2);

            // eje y
            int alturaInicial = 10;
            int duracionInicial = 1000;
            int duracionIncremento = 300;
            long tiempoInicio = 0;
            int numRebotes = 2;

            for (int i = 0; i < numRebotes; i++)
            {
                int alturaRebote = alturaInicial / (i + 1);
                int duracionRebote = duracionInicial + (duracionIncremento * i);

                Transformacion accionSubida = new Transformacion("Traslacion", alturaRebote, "y", duracionRebote, tiempoInicio);
                Transformacion accionBajada = new Transformacion("Traslacion", -alturaRebote, "y", duracionRebote, tiempoInicio + duracionRebote);

                listaDeConversiones3.Add(accionSubida);
                listaDeConversiones3.Add(accionBajada);

                tiempoInicio += 2 * duracionRebote;
            }

            Acciones acciones = new Acciones("Cubo", listaDeConversiones);
            Acciones acciones2 = new Acciones("Cubo", listaDeConversiones2);
            Acciones acciones3 = new Acciones("Cubo", listaDeConversiones3);

            List<Acciones> listaDeAcciones = new List<Acciones>();
            listaDeAcciones.Add(acciones);
            listaDeAcciones.Add(acciones2);
            listaDeAcciones.Add(acciones3);
            // -------------------- CREACION DE LA ANIMACION ------------------- //
            // -------------------- CREACION DE LA ANIMACION ------------------- //

            // -------------------- CREACION DE LA ANIMACION ------------------- //





            // -------------------- CREACION DE LA EJECUCION  ------------------- //
            libreto = new Libreto(listaDeAcciones, cuarto);
            hilo = new Ejecucion(libreto);
            miHilo = new Thread(hilo.Execute);
            // -------------------- CREACION DE LA EJECUCION  ------------------- //


        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);





            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.Ortho(-70, 70, -70, 70, -70, 70);
            GL.Enable(EnableCap.DepthTest);
            GL.Rotate(15f, 0, 1, 0);
            GL.Rotate(20f, 1, 0, 0);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit); //wea de la doc
            
            cuarto.draw();

            SwapBuffers();
            base.OnRenderFrame(e);
        }

        [Obsolete]
        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.K)
            {
                 miHilo.Start();
            }

            if (e.Key == Key.L)
            {
                if (hilo.pause)
                {
                    hilo.UnPause();
                }
                else
                {
                    hilo.Pause();
                }
            }

            if (e.Key == Key.P)
            {
                hilo.Stop();

            }

            base.OnKeyDown(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);


            base.OnResize(e);
        }
    }
}
