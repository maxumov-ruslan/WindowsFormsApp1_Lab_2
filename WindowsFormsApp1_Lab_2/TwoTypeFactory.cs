using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1_Lab_2
{
    class TwoTypeFactory : IGraphFactory
    {
        private bool type = false;
        public GraphObject CreateGraphObject()
        {
            type = !type;
            if (type)
            {
                return new Rectangle();
            }
            else
            {
                return new Ellipse();
            }

        }
    }
}
