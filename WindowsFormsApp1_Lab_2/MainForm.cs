using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1_Lab_2
{
    public partial class MainForm : Form
    {
        string current_type;
        int id = -1;
        List<GraphObject> elements = new List<GraphObject>();
        IGraphFactory factory = new RandomObjectFactory();
        public MainForm()

        {
            Random rand = new Random();

            if (rand.Next(0, 3) == 0)
            {
                current_type = "Rectangle";
            }
            else if (rand.Next(0, 2) == 1)
            {
                current_type = "Ellipse";
            }
            else  
            {
                current_type = "ComposedRectangles";
            }

                InitializeComponent();
        }
       
        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Draw(GraphObject go)
        {
            elements.Add(go);
            this.panel1.Invalidate();
        }
        private void AddFigure(object sender, EventArgs e)
        {
            if (current_type == "Rectangle")
            {
                Rectangle go = new Rectangle();
                Draw(go);
            }
            else if (current_type == "Ellipse")
            {
                Ellipse go = new Ellipse();
                Draw(go);
            }
            else if (current_type == "ComposedRectangles")
            {
                CompositeRectangles go = new CompositeRectangles();
                Draw(go);
            }

        }

        private void ClearFigures(object sender, EventArgs e)
        {
            elements.Clear();
            this.panel1.Invalidate();
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {

            foreach (GraphObject elem in elements)
            {
                elem.Draw(e.Graphics);

            }
        }


        private void SelectObject(object sender, MouseEventArgs e)
        {
            if (elements.Count > 0)
            {
                int i = 0;
                foreach (GraphObject element in elements)
                {
                    if (element.ContainsPoint(e.Location))
                    {
                        id = i;
                    }
                    element.Selected = false;
                    i++;
                }
                if (id > -1)
                {
                    elements[id].Selected = true;
                    this.panel1.Invalidate();
                }

            }
        }

        private void MouseDoublrClick_CreateOblect(object sender, MouseEventArgs e)
        {
            if (current_type == "Rectangle")
            {
                Rectangle go = new Rectangle();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex) { MessageBox.Show("Incorrect coord"); }
                elements.Add(go);
            }
            else if (current_type == "Ellipse")
            {
                Ellipse go = new Ellipse();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            }
            else if (current_type == "ComposedRectangles")
            {
                CompositeRectangles go = new CompositeRectangles();
                try
                {
                    go.X = e.X;
                    go.Y = e.Y;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show("Incorrect coord");
                }
                elements.Add(go);
            }
           
            this.panel1.Invalidate();
        }

        private void rectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                current_type = "Rectangle";
            }
        }

        private void ellipseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            {
                current_type = "Ellipse";
            }
        }

        private void Left(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements[id].X -= 5;
                this.panel1.Invalidate();
            }
        }

        private void right(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements[id].X += 5;
                this.panel1.Invalidate();
            }
        }

        private void down(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements[id].Y += 5;
                this.panel1.Invalidate();
            }
        }

        private void up(object sender, EventArgs e)
        {
            if (id > -1)
            {
                elements[id].Y -= 5;
                this.panel1.Invalidate();
            }
        }

        private void composedRectangle_Click(object sender, EventArgs e)
        {
            current_type = "ComposedRectangles";
        }

        private void twoTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new TwoTypeFactory();
        }

        private void randomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            factory = new RandomObjectFactory();
        }
    }
}
