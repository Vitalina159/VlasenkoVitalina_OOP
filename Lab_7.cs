using System.Numerics;

namespace OOP_Vlas
{
    // Інтерфейс для розв'язання рівняння у множині дійсних чисел R
    public interface IRealQuadraticSolver
    {
        // Повертаємо кортеж, де значення можуть бути null, якщо коренів у R немає
        (double? x1, double? x2) SolveReal(double a, double b, double c);
    }

    // Інтерфейс для розв'язання рівняння у множині комплексних чисел
    public interface IComplexQuadraticSolver
    {
        (Complex x1, Complex x2) SolveComplex(double a, double b, double c);
    }

    // Клас, що реалізує обидва інтерфейси
    public class QuadraticSolver : IRealQuadraticSolver, IComplexQuadraticSolver
    {
        public (double? x1, double? x2) SolveReal(double a, double b, double c)
        {
            if (a == 0) throw new ArgumentException("Коефіцієнт 'a' не може бути нулем.");

            double discriminant = b * b - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                return (x1, x2);
            }
            else if (Math.Abs(discriminant) < 1e-10) // D == 0
            {
                double x = -b / (2 * a);
                return (x, x);
            }
            else
            {
                // У дійсних числах коренів немає, повертаємо null
                return (null, null);
            }
        }

        public (Complex x1, Complex x2) SolveComplex(double a, double b, double c)
        {
            if (a == 0) throw new ArgumentException("Коефіцієнт 'a' не може бути нулем.");

            double discriminant = b * b - 4 * a * c;
            
            // Complex.Sqrt автоматично обробляє від'ємні значення, повертаючи уявні числа
            Complex sqrtD = Complex.Sqrt(discriminant);

            Complex x1 = (-b + sqrtD) / (2 * a);
            Complex x2 = (-b - sqrtD) / (2 * a);

            return (x1, x2);
        }
    }

    public class Lab_7
    {
        public static void Run()
        {
            var solver = new QuadraticSolver();
            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\nВведіть коефіцієнти квадратного рівняння ax^2 + bx + c = 0:");
                Console.Write("a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("b: ");
                double b = double.Parse(Console.ReadLine());
                Console.Write("c: ");
                double c = double.Parse(Console.ReadLine());

                Console.WriteLine("\nОберіть спосіб розв'язання:");
                Console.WriteLine("1 - У дійсних числах (R)");
                Console.WriteLine("2 - У комплексних числах");
                Console.WriteLine("0 - Вихід");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        var realRes = solver.SolveReal(a, b, c);
                        if (realRes.x1.HasValue)
                            Console.WriteLine($"Дійсні корені: x1 = {realRes.x1}, x2 = {realRes.x2}");
                        else
                            Console.WriteLine("У дійсних числах коренів немає (дискримінант < 0).");
                        break;

                    case 2:
                        var compRes = solver.SolveComplex(a, b, c);
                        Console.WriteLine($"Комплексні корені: x1 = {compRes.x1}, x2 = {compRes.x2}");
                        break;

                    case 0:
                        continueProgram = false;
                        break;

                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
            }
        }
    }
}