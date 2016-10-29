using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

/*
 * سلام خوبید ؟ 
 * @ سلام. خوبم. تو خوبی؟
 * این کلاس شیپ و بجه هاشه 
 * یه مشکل اینه که نمیدونم چجوری قطاع رو بکشم 
 * یه مشکل دیگه اینه که نمیدونم اینا کار میکنند و اگر کار میکنند درست کار میکنند یا نه 
 * و یه مشکل دیگه هم اینه که :
 * Graphics 
 * چجوری باید مقدار دهی شه ؟
 * @ اول باید یه کنترل داشته باشی بعد بتونی گرافیکس بگیری ازش.
 * توی اسنیک یه چیز عجیبی بود بنم کنترل و اینا :|
 */

// توضیحاتا رو خوندی، اونایی که به درد نمی‌خورن رو پاک کن. توی کامیتای قبلی هستن دیگه، فقط کد رو شلوغ می‌کنن.

// جا‌هایی که باید پیاده کنی رو یه همچین چیزی نوشتم:
// کلا «تودو»‌ها رو باید انجام بدی.
// ToDo Implement this.

// سعی کن بیش‌تر از یه خط خالی پشت سر هم هیچ جا نذاری.

// هر کلاس رو هم توی یه فایل جدا بنویس. این جوری راحت‌تره.

// برای گرفتن گرافیک هم به فورمت نگاه کن.

namespace Shooter
{

    // چون خود ویندوز فورمز با دابل کار نمی‌کنه و با فلوت کار می‌کنه، به جای دابل از فلوت استفاده می‌کنیم.
    // double -> float
    // و از کلاس
    // PointF
    // که مال خود ویندوز فورمز‌ه برای نقطه استفاده می‌کنیم.

    // یه نکته‌ی مهم:
    // یادته توی کلاس پدر (پدر همه‌ی جونورا) گفتم که یه مکان داره؟
    // برای این که راحت بشه مکان یه جونوری رو تغییر داد، شکل رو بدون مکان تعریف می‌کنیم. یعنی یه جوری که مرکز دایره‌ی محیطیش بیفته روی مبدأ مختصات.
    // اون وقت یه کلاس دیگه درست می‌کنیم برای یه شکل مکان‌دار.

    // شکل اسم نمی‌خواد. به چه دردش می‌خوره؟
    public abstract class Shape
    {

        public Shape()
        {
        }

        // شکل که نباید گرافیکس توی خودش نگه داره که. باید یه چیز کلی باشه که هر جایی بشه کشیدش.
        // تابع کشیدن خودش گرافیکسی که می‌خواد رو می‌گیره. مکان مرکز دایره‌ی محیطی رو هم دیگه می‌گیره دیگه.
        public abstract void Draw(Graphics g, PointF location);
        // منظورم از اشتراک داشتن اشتراک واقعی بود، نه این که دایره‌هاشون اشتراک داشته باشن.
        // دایره‌ها رو برای به دست آوردن یه فاصله‌ی تخمینی استفاده می‌کنیم.
        public abstract bool HasIntersection(PointF p);
        public abstract bool HasIntersection(Shape p);
        public abstract float GetBoundingCircleRadius();

        public bool GetApproximateDistance(LocatedShape a, LocatedShape b)
        {
            // این تابع رو خودت بنویس. دستش نزدم.
            // ToDo Implement this.
            Circle c1 = a.GetBoundingCircleRadius();
            Circle c2 = b.GetBoundingCircleRadius();
            float d = Math.Sqrt((o1.X - o2.X) * (o1.X - o2.X) + (o1.Y - o2.Y) * (o1.Y - o2.Y));
            return (d <= c1.Radius + c2.Radius);
        }

        public Color Color { get; set; }

    }

    public struct LocatedShape
    {

        public LocatedShape(Shape shape, PointF location)
        {
            this.Shape = shape;
            this.Location = location;
        }

        public void Draw(Graphics g)
        {
            // ToDo Implement this.
        }

        public Shape Shape { get; }
        public PointF Location { get; }

    }

    public class Triangle : Shape
    {
        // خودت دیگه با توجه به تغییراتی که توی کلاس شیپ دادم این رو درست کن دیگه.

        // در ضمن، مثلث رو به یه شکل عجیبی می‌خوایم نگه داریم!
        // شعاع دایره‌ی محیطی رو نگه دار با سه تا زاویه. این جوری هر مثلثی رو می‌شه یکتا تعیین کرد.

        public Triangle(string name, Point possition, float l, float degree, Color color) : base(name, possition, color)
        {
            L = l;
            Degree = degree;
        }
        public override Circle GetBoundingCircleRadius()
        {
            float radius = L / (2 * cos30);
            Circle c = new Shooter.Circle("BC", this.Possition, radius, this.Color);
            return c;
        }

        public override void Draw()
        {
            SolidBrush b = new SolidBrush(Color);
            Point o = this.Possition;
            Point[] p = new Point[] {new Point ((int)(o.X - (L / 2)),(int)(o.Y + ((L / 2) * tan30))),
                                     new Point ((int)(o.X + (L / 2)),(int)(o.Y + ((L / 2) * tan30))),
                                     new Point (o.X,(int)(o.Y + L / (2 * cos30))) };
            Graphics.FillPolygon(b, p);
        }

        public override void Draw(Graphics g, PointF location)
        {
            // ToDo Implement this.
        }

        public override bool HasIntersection(PointF p)
        {
            // ToDo Shayan will do this.
        }

        public override bool HasIntersection(Shape p)
        {
            // ToDo Shayan will do this.
        }

        public float L { get; set; }
        public float Degree { get; set; }
        // این دو تا به چه دردی می‌خورن؟؟ چرا از تابعای کلاس
        // Math
        // استفاده نمی‌کنی؟
        private float cos30 = 0.866;
        private float tan30 = 0.577;
    }

    // این دیگه چه جور اشتباهی‌ه؟؟ دایره یه قطاعه نه قطاع یه دایره که...
    // در ضمن، از اون جایی که دایره کار رو خیلی سخت می‌کرد، کلاً حذفش کنیم بهتره. مثلث کارمون رو راه می‌اندازه.

    public class Sector : Shape
    {

        public Sector(Point possition, float radius, float startdegree, float degree, Color color) : base(name, possition, radius, color)
        {
            this.StartDegree = startdegree;
            this.Degree = degree;
            this.Radius = radius;
        }

        public override Circle GetBoundingCircleRadius()
        {
            Circle c = new Circle("BC", Possition, Radius, Color);
            return c;
        }

        public float Radius { get; }
        public float StartDegree { get; }
        public float Degree { get; }
    }

    public class Circle : Sector
    {
    
        public Circle(string name, Point possition, float radius, Color color) : base(name, possition, color)
        {
            Radius = radius;
        }

    }
}
