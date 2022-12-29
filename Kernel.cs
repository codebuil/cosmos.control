using System;
using System.Drawing;
using Cosmos.System.Graphics;
using Sys = Cosmos.System;
using Cosmos.Debug.Kernel;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System.Graphics.Fonts;

namespace Cosmos_Graphic_Subsytem
{
    public class windowss
    {
        public int x = 0;
        public int y = 0;
        public int w = 0;
        public int h = 0;
        public Bitmap dc;
        public int colorss;
    }
    public class mmouse
    {
        public int xx = 0;
        public int yy = 0;
        public int ini = 0;
        public int clicks = 0;
    }
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
        int maxy=200;
        int maxx = 320;
        int xxxx = 0;
        int yyyy = 0;
        Boolean c1 = false;
        private Canvas canvas;
        private Bitmap bitmap;
        windowss cursors;
        Boolean Mmouseini = false;
        int cursorSize = 10;
        Color colorCursor= Color.White;
        Color desktopColor=Color.Green;
        int colors(byte reds, byte greens, byte blues)
        {
            return blues | greens << 8 | reds << 16;
        }
        int parts(int i, int t)
        {
            return i / t;
        }
        Boolean inside(int x, int y, int x1, int y1, int x2, int y2)
        {
            if (x > x1 && x < x2 && y > y1 && y < x2) return true;
            return false;
        }
        void psets(Bitmap b, int x, int y, int colors)
        {
            int n = 0;
            int[] bt = b.rawData;
            if (x < b.Width && y < b.Height && x > -1 && y > -1) bt[y * b.Width + x] = colors;
        }
        Bitmap createsbitmap(uint x, uint y)
        {
            Bitmap bitmap = new Bitmap(x, y, ColorDepth.ColorDepth32);
            return bitmap;
        }
        windowss createWindow(int x, int y, int w, int h, int colorss)
        {
            windowss windowsss = new windowss();
            windowsss.y = y;
            windowsss.x = x;
            windowsss.w = w;
            windowsss.h = h;
            windowsss.dc = createsbitmap((uint)windowsss.w, (uint)windowsss.h);

            windowsss.colorss = colorss;

            return windowsss;
        }
        mmouse drawcursor()
        {
            Pen pen = new Pen(Color.DarkGreen);
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = maxx - 1;
            int yy = maxy - 1;

            mmouse Mmouse = new mmouse();
            int c = new Pen(Color.Black).ValueARGB;
            if (!Mmouseini)
            {
                Mmouseini = true;
                cursors = createWindow(0, 0, cursorSize, cursorSize, colors(0, (byte)parts(0xff, n), 0));

                x = (int)Sys.MouseManager.X;
                n = 0;
                y = (int)Sys.MouseManager.Y;
                xxxx = x;
                yyyy = y;
            }
            else
            {
                x = (int)Sys.MouseManager.X;
                n = 0;
                y = (int)Sys.MouseManager.Y;
                xxxx = x;
                yyyy = y;
                xxxx = x;
                yyyy = y;
                getCursor(cursors.dc, x, y);
            }


            while (n == 0)
            {
                x = (int)Sys.MouseManager.X;
                n = (int)Sys.MouseManager.MouseState;
                y = (int)Sys.MouseManager.Y;
                if (x != xx || y != yy)
                {
                    if (!c1)
                    {
                        xx = x;
                        yy = y;
                        getCursor(cursors.dc, x, y);
                        c1 = true;
                    }
                    else
                    {

                        canvas.DrawImage(cursors.dc, new Point(xx, yy));
                        getCursor(cursors.dc, x, y);
                        canvas.DrawFilledEllipse(new Pen(colorCursor), new Point(x + (cursorSize / 2), y + (cursorSize / 2)), (cursorSize - 1) / 2, (cursorSize - 1) / 2);
                        xx = x;
                        yy = y;
                        xxxx = xx;
                        yyyy = yy;
                        canvas.Display();

                    }
                }

            }
            Mmouse.xx = x;
            Mmouse.yy = y;
            Mmouse.clicks = n;
            return Mmouse;
        }
        void getCursor(Bitmap bts, int x, int y)
        {
            int n = 0;
            int nn = 0;
            for (n = 0; n < cursorSize; n++)
            {
                for (nn = 0; nn < cursorSize; nn++)
                {
                    psets(bts, nn, n, canvas.GetPointColor(x + nn, y + n).ToArgb());
                }
            }
            Bitmap createsbitmap(uint x, uint y)
            {
                Bitmap bitmap = new Bitmap(x, y, ColorDepth.ColorDepth32);
                return bitmap;
            }

        }

        protected override void BeforeRun()
        {
           
           
            
            
            Console.WriteLine("Cosmos booted successfully. Let's go in Graphic Mode");
            
            Mode start = new Mode(maxx, maxy, ColorDepth.ColorDepth32);


            
            
            canvas = FullScreenCanvas.GetFullScreenCanvas(start);
            

            
            canvas.Clear(Color.Green);
            Sys.MouseManager.ScreenHeight = (uint)(maxy - cursorSize);
            Sys.MouseManager.ScreenWidth = (uint)(maxx - cursorSize);
        }

        protected override void Run()
        {
            Pen pen = new Pen(Color.DarkGreen);
            int n = 0;
            int x = 0;
            int y = 0;
            int xx = maxx - 1;
            int yy = maxy - 1;
            int nn = 0;
            mmouse Mmouse = new mmouse();
            Boolean c1 = false;
            int c = new Pen(Color.Black).ValueARGB;
            try
            {
                control rets = new control();
                rets.x = 10;
                rets.y = 10;
                rets.w = 100;
                rets.h = 100;
                rets.texts = "hello wold...";
                rets.draws(canvas);


                while (1 == 1)
                {
                    Mmouse = drawcursor();

                    if (Mmouse.clicks > 0)
                    {

                        Boolean nnn = inside(Mmouse.xx, Mmouse.yy, rets.x, rets.y, rets.x + rets.w, rets.y + rets.h);
                        if (nnn)

                        {
                            Console.Beep();
                            
                            
                            
                            c1 = false;

                        }



                    }
                }
            }
            catch (Exception e)
            {

            }
        }
   }
}