namespace OOP_Vlas;

class TRTriangle
{
    protected double a, b, c;

    public TRTriangle() { a = b = c = 1; }

    public TRTriangle(double side)
    {
        if (side > 0) a = b = c = side;
        else a = b = c = 1;
    }

    public TRTriangle(TRTriangle other)
    {
        a = other.a;
        b = other.b;
        c = other.c;
    }

    public virtual void Input()
    {
        Console.Write("Введіть сторону трикутника: ");
        if (double.TryParse(Console.ReadLine(), out double side))
        {
            if (side <= 0)
            {
                Console.WriteLine("Сторона повинна бути > 0. Встановлено 1.");
                a = b = c = 1;
            }
            else a = b = c = side;
        }
    }

    public virtual void Output() => Console.WriteLine($"Сторони: {a}, {b}, {c}");

    public double Area() => (Math.Sqrt(3) / 4) * a * a;

    public double Perimeter() => a + b + c;

    public static bool operator ==(TRTriangle t1, TRTriangle t2) => t1.a == t2.a;
    public static bool operator !=(TRTriangle t1, TRTriangle t2) => t1.a != t2.a;

    public override bool Equals(object obj) => obj is TRTriangle t && t.a == this.a;
    public override int GetHashCode() => a.GetHashCode();

    public static TRTriangle operator +(TRTriangle t, double value) => new TRTriangle(t.a + value);

    public static TRTriangle operator -(TRTriangle t, double value)
    {
        double newSide = t.a - value;
        if (newSide <= 0)
        {
            Console.WriteLine("Результат ≤ 0, встановлено 1");
            return new TRTriangle(1);
        }
        return new TRTriangle(newSide);
    }

    public static TRTriangle operator *(TRTriangle t, double value) => new TRTriangle(t.a * value);
}

class TPiramid : TRTriangle
{
    private double height;

    public TPiramid() : base() { height = 1; }

    public TPiramid(double side, double h) : base(side)
    {
        height = (h > 0) ? h : 1;
    }

    public new void Input()
    {
        base.Input();
        Console.Write("Введіть висоту піраміди: ");
        if (double.TryParse(Console.ReadLine(), out double h))
        {
            height = (h > 0) ? h : 1;
            if (h <= 0) Console.WriteLine("Помилка! Висота повинна бути > 0. Встановлено 1.");
        }
    }

    public new void Output()
    {
        base.Output();
        Console.WriteLine($"Висота піраміди: {height}");
    }

    public double Volume() => (1.0 / 3) * Area() * height;
}

public class Lab_5
{
    public static void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Трикутник 1");
        TRTriangle t1 = new TRTriangle();
        t1.Input();
        t1.Output();

        Console.WriteLine($"Площа: {t1.Area()}");
        Console.WriteLine($"Периметр: {t1.Perimeter()}");

        Console.WriteLine("\nТрикутник 2");
        TRTriangle t2 = new TRTriangle();
        t2.Input();
        t2.Output();

        if (t1 == t2) Console.WriteLine("Трикутники рівні");
        else Console.WriteLine("Трикутники не рівні");

        Console.WriteLine("\nОперації 1 трикутника");

        TRTriangle t3 = t1 + 2;
        Console.WriteLine("Додавання 2:");
        t3.Output();

        TRTriangle t4 = t1 - 2;
        Console.WriteLine("Віднімання 2:");
        t4.Output();

        TRTriangle t5 = t1 * 3;
        Console.WriteLine("Множення на 3:");
        t5.Output();

        Console.WriteLine("\nПіраміда");
        TPiramid p1 = new TPiramid();
        p1.Input();
        p1.Output();
        Console.WriteLine($"Об'єм: {p1.Volume()}");
    }
}