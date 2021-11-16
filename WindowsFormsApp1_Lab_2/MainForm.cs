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
        public MainForm()
        {
            InitializeComponent();
        }
        List<GraphObject> elements = new List<GraphObject>();
        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFigure(object sender, EventArgs e)
        {
            elements.Add(new GraphObject());
            panel1.Invalidate();// чтобы позже вызывался Paint
        }

        private void ClearFigures(object sender, EventArgs e)
        {
            
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
            
            foreach (GraphObject elem in elements)
            {
                elem.Draw(e.Graphics);
               
            }
        }

        private void MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var gr = new GraphObject();
            try
            {
                gr.X = e.X;
                gr.Y = e.Y;
            }
            catch (ArgumentException ex)
            {

                statusLabel.Text = ex.Message;
            }
            

            elements.Add(gr);
            panel1.Invalidate();
        }
    }
}
