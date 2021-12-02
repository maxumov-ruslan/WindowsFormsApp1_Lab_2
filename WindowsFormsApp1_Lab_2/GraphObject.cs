using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace WindowsFormsApp1_Lab_2
{
    abstract class GraphObject
    {
        protected int x, y, w, h;
        protected SolidBrush brush;
        static Random r = new Random();
        public bool Selected { get; set; }
        
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
            Selected = false;
            Color[] cols = { Color.Red, Color.Green, Color.Yellow, Color.Tomato, Color.Cyan };
            var c = cols[r.Next(cols.Length)];
            x = r.Next(200);
            y = r.Next(200);
            w = 50;
            h = 50;
            brush = new SolidBrush(c);
        }
        abstract public bool ContainsPoint(Point p);


        abstract public void Draw(Graphics g);
        
    }
}
