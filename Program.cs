namespace OOP_Vlas
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine(" МЕНЮ ЛАБОРАТОРНИХ");
                Console.WriteLine("1. Запустити Лабораторну №5");
                Console.WriteLine("2. Запустити Лабораторну №6");
                Console.WriteLine("3. Запустити Лабораторну №7");
                Console.WriteLine("4. Запустити Лабораторну №8");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Lab_5.Run();
                        Console.WriteLine("Лабораторна №5 запущена.");
                        break;
                    case "2":
                        Console.Clear();
                        Lab_6.Run();
                        break;
                    case "3":
                        Console.Clear();
                        Lab_7.Run();
                        Console.WriteLine("Лабораторна №7 запущена.");
                        break;
                    case "4":
                        Console.Clear();
                        Lab_8.Run();
                        Console.WriteLine("Лабораторна №8 запущена.");
                        break;
                    case "0":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}