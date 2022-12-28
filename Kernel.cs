using System;
using System.Drawing;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;
using Cosmos.Debug.Kernel;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System.Graphics.Fonts;

namespace Cosmos_Graphic_Subsytem
{
    public class control {
        public int x = 0;
        public int y = 0;
        public int w = 0;
        public int h = 0;
        public Boolean raised = false;
        public Pen Colors = new Pen(Color.Green);
        public String texts = "";
        public control()
        {

        }
        public void draws(Canvas c) {
            Pen p = new Pen(Color.Black);
            Point pp = new Point(x,y);
           
            
            c.DrawRectangle(p, pp, w, h);
            c.DrawString(texts, PCScreenFont.Default, p, pp) ;
            
            c.Display();

        }    
    
    }
    public class Kernel : Sys.Kernel
    {

        public Debugger debugger = new Debugger("System", "CGS");

        private Canvas canvas;
        private Bitmap bitmap;

        
        protected override void BeforeRun()
        {
           
           
            
            
            Console.WriteLine("Cosmos booted successfully. Let's go in Graphic Mode");
            
            Mode start = new Mode(320, 200, ColorDepth.ColorDepth32);


            
            
            canvas = FullScreenCanvas.GetFullScreenCanvas(start);
            

            
            canvas.Clear(Color.Green);
        }

        protected override void Run()
        {
            try
            {
                control rets = new control();
                rets.x = 10;
                rets.y = 10;
                rets.w = 100;
                rets.h = 100;
                rets.texts = "hello wold...";
                rets.draws(canvas);


                
                Console.ReadKey();

                Console.ReadKey();

                Sys.Power.Shutdown();
            }
            catch (Exception e)
            {

            }
        }
   }
}