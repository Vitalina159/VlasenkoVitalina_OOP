namespace OOP_Vlas;

public class Lab_6
{
    public static void Run()
    {
        Console.WriteLine("Завдання 1.1 (Найбільше від'ємне)");
        Task1_1();

        Console.WriteLine("\nЗавдання 1.2 (Косинус кута)");
        Task1_2();

        Console.WriteLine("\nЗавдання 1.3 (Стиснення масиву)");
        Task1_3();

        Console.WriteLine("\nЗавдання 2.1 (Сортування парних рядків)");
        Task2_1();

        Console.WriteLine("\nЗавдання 2.2 (Сума стовпців)");
        Task2_2();

        Console.WriteLine("\nЗавдання 2.3 (Мінімум сум діагоналей)");
        Task2_3();
    }

    // Допоміжний метод для виведення матриці
    public static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
                Console.Write(matrix[i, j] + "\t");
            Console.WriteLine();
        }
    }

    // Найбільше серед від'ємних
    public static void Task1_1()
    {
        Console.Write("Введіть розмір масиву: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write($"Введіть елемент arr[{i}]: ");
            arr[i] = double.Parse(Console.ReadLine());
        }

        double? maxNegative = null;
        bool found = false;

        foreach (double x in arr)
        {
            if (x < 0)
            {
                if (!found || x > maxNegative)
                {
                    maxNegative = x;
                    found = true;
                }
            }
        }

        if (found) Console.WriteLine($"Результат: {maxNegative}");
        else Console.WriteLine("Від'ємних чисел немає.");
    }

    // Косинус кута між векторами
    public static void Task1_2()
    {
        Console.Write("Введіть розмірність векторів (n): ");
        int n = int.Parse(Console.ReadLine());
        double[] x = new double[n];
        double[] y = new double[n];

        Console.WriteLine("Введіть елементи вектора X:");
        for (int i = 0; i < n; i++) x[i] = double.Parse(Console.ReadLine());

        Console.WriteLine("Введіть елементи вектора Y:");
        for (int i = 0; i < n; i++) y[i] = double.Parse(Console.ReadLine());

        double dotProduct = 0, normX = 0, normY = 0;
        for (int i = 0; i < n; i++)
        {
            dotProduct += x[i] * y[i];
            normX += x[i] * x[i];
            normY += y[i] * y[i];
        }

        if (normX == 0 || normY == 0) Console.WriteLine("Помилка: Нульовий вектор.");
        else Console.WriteLine($"Косинус кута: {dotProduct / (Math.Sqrt(normX) * Math.Sqrt(normY)):F4}");
    }

    // Стиснути масив, видаливши елементи в інтервалі [a, b]
    public static void Task1_3()
    {
        Console.Write("Введіть розмір масиву: ");
        int n = int.Parse(Console.ReadLine());
        double[] arr = new double[n];
        for (int i = 0; i < n; i++) { Console.Write($"arr[{i}] = "); arr[i] = double.Parse(Console.ReadLine()); }

        Console.Write("Введіть a: "); double a = double.Parse(Console.ReadLine());
        Console.Write("Введіть b: "); double b = double.Parse(Console.ReadLine());

        int insertIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            if (!(Math.Abs(arr[i]) >= a && Math.Abs(arr[i]) <= b))
                arr[insertIndex++] = arr[i];
        }
        while (insertIndex < arr.Length) arr[insertIndex++] = 0;

        Console.WriteLine($"Результат: {string.Join(", ", arr)}");
    }

    // Сортування елементів парних рядків
    public static void Task2_1()
    {
        Console.Write("Кількість рядків: "); int rows = int.Parse(Console.ReadLine());
        Console.Write("Кількість стовпців: "); int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++) { Console.Write($"matrix[{i},{j}] = "); matrix[i, j] = int.Parse(Console.ReadLine()); }

        for (int i = 0; i < rows; i++)
        {
            if (i % 2 == 0)
            {
                int[] row = new int[cols];
                for (int j = 0; j < cols; j++) row[j] = matrix[i, j];
                Array.Sort(row); Array.Reverse(row);
                for (int j = 0; j < cols; j++) matrix[i, j] = row[j];
            }
        }
        Console.WriteLine("Матриця після сортування парних рядків:");
        PrintMatrix(matrix);
    }

    //Сума елементів у стовпцях без від'ємних
    public static void Task2_2()
    {
        Console.Write("Кількість рядків: "); int rows = int.Parse(Console.ReadLine());
        Console.Write("Кількість стовпців: "); int cols = int.Parse(Console.ReadLine());
        int[,] matrix = new int[rows, cols];

        for (int i = 0; i < rows; i++)
            for (int j = 0; j < cols; j++) { Console.Write($"matrix[{i},{j}] = "); matrix[i, j] = int.Parse(Console.ReadLine()); }

        Console.WriteLine("Оригінальна матриця:");
        PrintMatrix(matrix);

        for (int j = 0; j < cols; j++)
        {
            int sum = 0; bool hasNegative = false;
            for (int i = 0; i < rows; i++)
            {
                if (matrix[i, j] < 0) { hasNegative = true; break; }
                sum += matrix[i, j];
            }
            if (!hasNegative) Console.WriteLine($"Сума стовпця {j}: {sum}");
        }
    }

    //Мінімум серед сум модулів діагоналей, паралельних побічній
    public static void Task2_3()
    {
        Console.Write("Розмір квадратної матриці (n): "); int n = int.Parse(Console.ReadLine());
        int[,] matrix = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++) { Console.Write($"matrix[{i},{j}] = "); matrix[i, j] = int.Parse(Console.ReadLine()); }

        Console.WriteLine("Ваша матриця:");
        PrintMatrix(matrix);

        double minSum = double.MaxValue;
        for (int k = 0; k <= 2 * (n - 1); k++)
        {
            int currentSum = 0;
            for (int i = 0; i < n; i++)
            {
                int j = k - i;
                if (j >= 0 && j < n) currentSum += Math.Abs(matrix[i, j]);
            }
            if (currentSum < minSum) minSum = currentSum;
        }
        Console.WriteLine($"Мінімальна сума модулів: {minSum}");
    }
}