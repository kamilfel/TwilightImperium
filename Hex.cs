using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    class Hex
    {
        public string color;
        public int id;
        public Point coords;
        public PointF center;
        public Point[] points = new Point[6];
        public Point[] points2 = new Point[6];
        public Hex(int i,  int ring, int number, int width, int height)
        {
            id = i;
            int hexLength = width / 11;
            color = "White";

            coords.X = ring;
            coords.Y = number;

            if (ring == 0)
            {
                center.X = width / 2.0f;
                center.Y = height / 2.0f;
            }
            else if (ring == 1)
            {
                double angle = (coords.Y / 6.0d) * 2 * Math.PI;
                center.X = width / 2.0f + (float)(hexLength * Math.Sqrt(3) * Math.Sin(angle));
                center.Y = height / 2.0f + (float)(hexLength * Math.Sqrt(3) * Math.Cos(angle));
            }
            else if (ring == 2)
            {
                double angle = (coords.Y / (6.0d * 2)) * 2 * Math.PI;
                double radius = 0;

                if (coords.Y % 2 == 0) radius = 2 * hexLength * Math.Sqrt(3);
                else radius = hexLength * 3;

                center.X = width / 2 + (float)(radius * Math.Sin(angle));
                center.Y = height / 2 + (float)(radius * Math.Cos(angle));
            }
            else if (ring == 3)
            {
                double angle = ((double)(coords.Y) / (6.0d * 3)) * 2 * Math.PI;
                double radius = 3 * hexLength * Math.Sqrt(3);

                if (coords.Y % 3 == 0)
                {
                    center.X = width / 2 + (float)(radius * Math.Sin(angle));
                    center.Y = height / 2 + (float)(radius * Math.Cos(angle));
                }
                else
                {
                    PointF point1 = new PointF();
                    PointF point2 = new PointF();
                    angle = (double)((coords.Y - (coords.Y % 3)) / (6.0d * 3)) * 2 * Math.PI;
                    point1.X = width / 2 + (float)(radius * Math.Sin(angle));
                    point1.Y = height / 2 + (float)(radius * Math.Cos(angle));
                    angle = (double)((coords.Y + 3 - (coords.Y % 3)) / (6.0d * 3)) * 2 * Math.PI;
                    point2.X = width / 2 + (float)(radius * Math.Sin(angle));
                    point2.Y = height / 2 + (float)(radius * Math.Cos(angle));

                    center.X = ((3 - (coords.Y % 3)) * point1.X + (coords.Y % 3) * point2.X) / 3.0f;
                    center.Y = ((3 - (coords.Y % 3)) * point1.Y + (coords.Y % 3) * point2.Y) / 3.0f;

                }
            }

            Point pointCoords = new Point();
            pointCoords.X = (int)(center.X - hexLength / 2.0f);
            pointCoords.Y = (int)(center.Y - hexLength * Math.Sqrt(3) / 2.0f);
            points[0] = pointCoords;
            points2[0].X = (int)(4 * points[0].X + center.X) / 5;
            points2[0].Y = (int)(4 * points[0].Y + center.Y) / 5;

            pointCoords.X = (int)(center.X + hexLength / 2.0f);
            pointCoords.Y = (int)(center.Y - hexLength * Math.Sqrt(3) / 2.0f);
            points[1] = pointCoords;
            points2[1].X = (int)(4 * points[1].X + center.X) / 5;
            points2[1].Y = (int)(4 * points[1].Y + center.Y) / 5;

            pointCoords.X = (int)(center.X + hexLength);
            pointCoords.Y = (int)(center.Y);
            points[2] = pointCoords;
            points2[2].X = (int)(4 * points[2].X + center.X) / 5;
            points2[2].Y = (int)(4 * points[2].Y + center.Y) / 5;

            pointCoords.X = (int)(center.X + hexLength / 2.0f);
            pointCoords.Y = (int)(center.Y + hexLength * Math.Sqrt(3) / 2.0f);
            points[3] = pointCoords;
            points2[3].X = (int)(4 * points[3].X + center.X) / 5;
            points2[3].Y = (int)(4 * points[3].Y + center.Y) / 5;

            pointCoords.X = (int)(center.X - hexLength / 2.0f);
            pointCoords.Y = (int)(center.Y + hexLength * Math.Sqrt(3) / 2.0f);
            points[4] = pointCoords;
            points2[4].X = (int)(4 * points[4].X + center.X) / 5;
            points2[4].Y = (int)(4 * points[4].Y + center.Y) / 5;

            pointCoords.X = (int)(center.X - hexLength);
            pointCoords.Y = (int)(center.Y);
            points[5] = pointCoords;
            points2[5].X = (int)(4 * points[5].X + center.X) / 5;
            points2[5].Y = (int)(4 * points[5].Y + center.Y) / 5;

        }
    }
}
