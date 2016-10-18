using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;



/*
 * سلام خوبید ؟ 
 * این کلاس شیپ و بجه هاشه 
 * یه مشکل اینه که نمیدونم چجوری قطاع رو بکشم 
 * یه مشکل دیگه اینه که نمیدونم اینا کار میکنند و اگر کار میکنند درست کار میکنند یا نه 
 * و یه مشکل دیگه هم اینه که :
 * Graphics 
 * چجوری باید مقدار دهی شه ؟
 * توی اسنیک یه چیز عجیبی بود بنم کنترل و اینا :|
 */
namespace Shooter
{
    public abstract class Shape
    {
        public Shape(String name, Point possition, Color color)
        {
            _Name = name;
            Possition = possition;
            Color = color;
        }

        public abstract void drawMe();

        public bool checkIntersect(Shape a, Shape b)
        {
            Circle c1 = a.getBoundingCircle();
            Circle c2 = b.getBoundingCircle();
            Point o1 = a.Possition;
            Point o2 = b.Possition;
            double d = Math.Sqrt((o1.X - o2.X) * (o1.X - o2.X) + (o1.Y - o2.Y) * (o1.Y - o2.Y));
            return (d <= c1.Radius + c2.Radius);

        }


        public abstract Circle getBoundingCircle();






        private readonly String _Name;
        public String Name { get; }
        public Point Possition { get; set; }
        public Color Color { get; set; }

        public Graphics Graphics { set; get; }

    }
    public class Triangle : Shape
    {
        public Triangle(string name, Point possition, double l, double degree, Color color) : base(name, possition, color)
        {
            L = l;
            Degree = degree;
        }
        public override Circle getBoundingCircle()
        {
            double radius = L / (2 * cos30);
            Circle c = new Shooter.Circle("BC", this.Possition, radius, this.Color);
            return c;
        }

        public override void drawMe()
        {
            SolidBrush b = new SolidBrush(Color);
            Point o = this.Possition;
            Point[] p = new Point[] {new Point ((int)(o.X - (L / 2)),(int)(o.Y + ((L / 2) * tan30))),
                                     new Point ((int)(o.X + (L / 2)),(int)(o.Y + ((L / 2) * tan30))),
                                     new Point (o.X,(int)(o.Y + L / (2 * cos30))) };
            Graphics.FillPolygon(b, p);
        }

        public double L { get; set; }
        public double Degree { get; set; }
        private double cos30 = 0.866;
        private double tan30 = 0.577;
    }
    public class Sector : Circle
    {
        public Sector(string name, Point possition, double radius, double startdegree, double degree, Color color) : base(name, possition, radius, color)
        {
            StartDegree = startdegree;
            Degree = degree;
        }
        public override Circle getBoundingCircle()
        {
            Circle c = new Shooter.Circle("BC", Possition, Radius, Color);
            return c;
        }
        public override void drawMe()
        {

        }
        double StartDegree { set; get; }
        double Degree { set; get; }
    }
    public class Circle : Shape
    {
        public Circle(string name, Point possition, double radius, Color color) : base(name, possition, color)
        {
            Radius = radius;
        }

        public override Circle getBoundingCircle()
        {
            return this;
        }

        public override void drawMe()
        {
            SolidBrush b = new SolidBrush(Color);

            Point p = new Point(Possition.X - (int)(Math.Sqrt(2) * Radius),
                                 Possition.Y - (int)(Math.Sqrt(2) * Radius));
            Size s = new Size((int)(2 * Radius), (int)(2 * Radius));
            Rectangle r = new Rectangle(p, s);
            Graphics.FillEllipse(b, r); // &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
        }

        public double Radius { set; get; }

    }
}


  