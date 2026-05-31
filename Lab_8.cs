namespace OOP_Vlas
{
    public class Lab_8
    {
        public static void Run()
        {
            string filePath = @"D:\OOP_Vlas\matrix.txt";

            try
            {
                Console.WriteLine("Початок виконання Лабораторної №8 ");
                
                var (matrixA, matrixB) = ReadTwoMatricesFromFile(filePath);

                Console.WriteLine($"Матриця A ({matrixA.GetLength(0)}x{matrixA.GetLength(1)}) та Матриця B ({matrixB.GetLength(0)}x{matrixB.GetLength(1)}) зчитані.");
                
                Console.WriteLine("\nРезультат множення матриці А:");
                int[,] resultArr = MultiplyMatrices(matrixA, matrixB);
                PrintMatrix(resultArr);
                
                var listA = ConvertArrayToLinkedList(matrixA);
                var listB = ConvertArrayToLinkedList(matrixB);

                Console.WriteLine("\nРезультат множення матриці В:");
                var resultList = MultiplyLinkedListMatrices(listA, listB);
                PrintLinkedListMatrix(resultList);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nПОМИЛКА: {ex.Message}");
            }
        }
        
        static int[,] MultiplyMatrices(int[,] A, int[,] B)
        {
            int rA = A.GetLength(0), cA = A.GetLength(1);
            int rB = B.GetLength(0), cB = B.GetLength(1);

            if (cA != rB) throw new Exception($"Неможливо помножити: стовпці A ({cA}) не дорівнюють рядкам B ({rB}).");

            int[,] result = new int[rA, cB];
            for (int i = 0; i < rA; i++)
                for (int j = 0; j < cB; j++)
                    for (int k = 0; k < cA; k++)
                        result[i, j] += A[i, k] * B[k, j];
            return result;
        }

        static LinkedList<LinkedList<int>> MultiplyLinkedListMatrices(LinkedList<LinkedList<int>> A, LinkedList<LinkedList<int>> B)
        {
            int rA = A.Count;
            int cA = A.First.Value.Count;
            int cB = B.First.Value.Count;

            if (cA != B.Count) throw new Exception("LinkedList матриці несумісні для множення.");

            var result = new LinkedList<LinkedList<int>>();
            
            int[,] bArr = ConvertLinkedListToArray(B);
            int[,] aArr = ConvertLinkedListToArray(A);
            int[,] res = MultiplyMatrices(aArr, bArr);

            return ConvertArrayToLinkedList(res);
        }
        static (int[,] A, int[,] B) ReadTwoMatricesFromFile(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException("Файл matrix.txt не знайдено на диску D.");

            var allLines = File.ReadAllLines(path).ToList();
            int splitIndex = allLines.FindIndex(string.IsNullOrWhiteSpace);
            if (splitIndex == -1) throw new Exception("Файл має бути розділений порожнім рядком на дві матриці.");

            var linesA = allLines.Take(splitIndex).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();
            var linesB = allLines.Skip(splitIndex + 1).Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

            return (ParseToMatrix(linesA), ParseToMatrix(linesB));
        }

        static int[,] ParseToMatrix(List<string> lines)
        {
            int rows = lines.Count;
            int cols = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            int[,] matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var parts = lines[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < cols; j++)
                    matrix[i, j] = int.Parse(parts[j]);
            }
            return matrix;
        }
        static LinkedList<LinkedList<int>> ConvertArrayToLinkedList(int[,] arr)
        {
            var list = new LinkedList<LinkedList<int>>();
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                var row = new LinkedList<int>();
                for (int j = 0; j < arr.GetLength(1); j++) row.AddLast(arr[i, j]);
                list.AddLast(row);
            }
            return list;
        }

        static int[,] ConvertLinkedListToArray(LinkedList<LinkedList<int>> list)
        {
            int rows = list.Count;
            int cols = list.First.Value.Count;
            int[,] arr = new int[rows, cols];
            int i = 0;
            foreach (var row in list)
            {
                int j = 0;
                foreach (var val in row) arr[i, j++] = val;
                i++;
            }
            return arr;
        }

        static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++) Console.Write($"{matrix[i, j]}\t");
                Console.WriteLine();
            }
        }

        static void PrintLinkedListMatrix(LinkedList<LinkedList<int>> matrix)
        {
            foreach (var row in matrix)
            {
                foreach (var val in row) Console.Write($"{val}\t");
                Console.WriteLine();
            }
        }
    }
}