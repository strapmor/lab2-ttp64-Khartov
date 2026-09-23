namespace lab2_ttp64_Khartov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
            Console.ReadKey();
        }

        static bool ArrayInput(out string[] arr)
        {
            Console.Write("Введите массив чисел одной строкой: ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                arr = new string[0];
                return false;
            }
            arr = input.Split(' ');
            return true;
        }

        static void Task1()
        {
            Console.Write("Задание 1. ");
            // Ввод
            if (!ArrayInput(out string[] splitted)) return;

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

        static bool MakeMatrix(out int[,] arr)
        {
            Console.Write("Введите первую размерность двумерного массива: ");
            if (!int.TryParse(Console.ReadLine(), out int m))
            {
                arr = new int[0, 0];
                return false;
            }
            Console.Write("Введите вторую размерность двумерного массива: ");
            if (!int.TryParse(Console.ReadLine(), out int n))
            {
                arr = new int[0, 0];
                return false;
            }

            arr = new int[m, n];
            return true;
        }

        static void MatrixOutput(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.Write($"|\t{arr[i, j]}\t");
                }
                Console.WriteLine("|");
            }
        }

        static void Task2()
        { 
            Console.Write("Задание 2. ");

            // Заполнение массива
            if(!MakeMatrix(out int[,] arr)) return;
            int counter = 1;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i % 2 == 0)
                        arr[i, j] = counter;
                    else
                        arr[i, (arr.GetLength(1) - j - 1)] = counter;
                    counter++;
                }
            }

            // Вывод
            MatrixOutput(arr);
        }

        static void Task3()
        {
            Console.Write("Задание 3. ");
            // Создаем двумерный и одномерный массивы. Если что-то вводится не так - завершаем функцию
            if(!MakeMatrix(out int[,] matrix)) return;
            int[] arr = new int[matrix.Length];
            if(!ArrayInput(out string[] stringArray)) return;

            // Переносим числа в числовой массив
            for(int i = 0; i < arr.Length; i++)
            {
                // Если число введённых чисел меньше размера массива, то оставшиеся элементы обнуляем
                if (i >= stringArray.Length)
                {
                    arr[i] = 0;
                    continue;
                }
                if (!int.TryParse(stringArray[i], out arr[i])) return;
            }
                

            // Заполняем двумерный массив
            int k = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = arr[k];
                    k++;
                }
            }

            // Вывод
            MatrixOutput(matrix);
        }

        static void Task4()
        {
            Console.Write("Задание 4. ");
            if (!MakeMatrix(out int[,] matrix)) return;
        }
    }
}
