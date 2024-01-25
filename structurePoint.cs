using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image4glass
{
    public class PolePoint
    {
        private bool is_defined;
        private int x;
        private int y;
        public bool isDefined
        {
            get { return is_defined; }
            set { is_defined = value; }
        }
        public double X
        {
            get { return Convert.ToDouble(x); }
        }
        public double Y
        {
            get { return Convert.ToDouble(y); }
        }

        public void SetXYCoordinates(int x_fromImg, int y_fromImg)
        {
            x = x_fromImg;
            y = y_fromImg;
            isDefined = true;
        }
        public void SetXYCoordinates(Point p)
        {
            x = p.X;
            y = p.Y;
            isDefined = true;
        }
        public Point ToPoint()
        {
            return new Point(x, y);
        }

        public override string ToString()
        {
            return is_defined ? string.Concat( "{ X= ", x.ToString(), ", Y= ", y.ToString(), " }") : "Undefined";
        }
        public PolePoint()
        {
            isDefined = false;
            x = 0;
            y = 0;
        }
        public PolePoint(Point init)
        {
            isDefined = false;
            x = init.X;
            y = init.Y;
        }
    }
}
