namespace lab2_ttp64_Khartov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            Task2();
            Console.ReadKey();
        }

        static void Task1()
        {
            Console.Write("Задание 1. Введите массив чисел одной строкой: ");
            // Ввод
            string? input = Console.ReadLine();
            if (input == null) return;
            string[] splitted = input.Split(' ');

            // Переносим в массив интов через цикл
            int[] arr = new int[splitted.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(splitted[i]);
            }
            // Или через LINQ
            //int[] arr = splitted.Select(int.Parse).ToArray();

            // Инвертируем
            int[] inverted = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                inverted[arr.Length - i - 1] = arr[i];
            }

            // Вывод
            Console.Write("Исходный массив:");
            foreach (int i in arr)
            {
                Console.Write($"\t{i}");
            }
            Console.WriteLine();

            Console.Write("Инвертированный массив:");
            foreach (int i in inverted)
            {
                Console.Write($"\t{i}");
            }
            Console.WriteLine();
        }

        static void Task2()
        {
            // Ввод размеров и заполнение массива
            Console.Write("Задание 2. Введите первую размерность двумерного массива: ");
            int m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вторую размерность двумерного массива: ");
            int n = Convert.ToInt32(Console.ReadLine());

            int[,] arr = new int[m, n];
            int counter = 1;
            for (int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i % 2 == 0)
                        arr[i, j] = counter;
                    else
                        arr[i, (arr.GetLength(1) - j - 1)] = counter;
                    counter++;
                }
            }

            // Вывод
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"|\t{arr[i, j]}\t");
                }
                Console.WriteLine("|");
            }
        }
    }
}
