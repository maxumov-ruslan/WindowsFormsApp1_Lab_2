using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp1_Lab_2
{
    class GraphObject
    {
        int x, y, w, h;
        private SolidBrush brush;
        static Random r = new Random();
        public bool Selected { get; set; }
        static public int MaxSize { get; set; }
        public int X
        {
            get { return x; }
            set
            {
                if (value < 0) { throw new ArgumentException("x<0!"); }

                x = value;
            }
        }
        public int Y
        {
            get { return y; }
            set
            {
                if (value < 0) { throw new ArgumentException("y<0!"); }
                y = value;
            }
        }
        
        public GraphObject()
        {
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Tomato,Color.Cyan };
            var c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            w = 50;
            h = 50;
            brush = new SolidBrush(c);
        }
        public void Draw(Graphics g)
        {
            g.FillRectangle(brush, x, y, w, h);
            if (Selected ==true)
            {
                g.DrawRectangle(Pens.Aquamarine, x, y, w, h);
            }
            else
            {
                g.DrawRectangle(Pens.Black, x, y, w, h);
            }
            
        }
    }
}
