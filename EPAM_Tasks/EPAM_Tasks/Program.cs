using System;

namespace EPAM_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] massiv = { 3, 4, 12, 7, 8, 5, 11, 9, 3, 10, 2, 1, 15, 8, 13, 0, 14, 6 };

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Задание 1 - Сортировка целочисленного массива.");
            Console.ForegroundColor = ConsoleColor.Gray;

            //Показывает исходный массив.
            Console.WriteLine("Оригинальный массив:");
            ShowArray(massiv);

            //Демонстрация сортировки без изменения оригинала.
            Console.WriteLine("\nОтсортированная копия:");
            ShowArray(Tasks.Sort(massiv, true));

            Console.WriteLine("\nОригинальный массив:");
            ShowArray(massiv);

            //Демонстрация сортировки оригинала.
            Console.WriteLine("\nСортируем оригинал:");
            Tasks.Sort(massiv);
            //можно использовать Array.Sort<int>(massiv);
            ShowArray(massiv);

            Console.WriteLine("\nВыводим оригинальный массив:");
            ShowArray(massiv);

            Console.WriteLine("\nУдаляем третий элемент:");
            massiv = Tasks.Remove(massiv, 2, 1);
            ShowArray(massiv);
            
            Console.WriteLine("\n\nСледующее задание >>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nЗадание 2 - Поиск в отсортированном массиве.");
            Console.ForegroundColor = ConsoleColor.Gray;

            while (true)
            {
                try
                {
                    Console.Write("Введите искомое число: \n > ");
                    Console.WriteLine(Tasks.Find(massiv, Convert.ToInt32(Console.ReadLine())) >= 0 ? "Нашли" : "не нашли");
                    
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное значение. Входными данными должно являться целое число.");
                }
            }

            Console.WriteLine("\nСледующее задание >>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nЗадание 3 - Поиск в строке слов, встречающихся только один раз.");
            Console.ForegroundColor = ConsoleColor.Gray;
            string str = "один два три, два,.пять пять четыре двоа?";
            Console.WriteLine(str);


            string[] strs = Tasks.MySplit(str, new char[] {' ', ',', '.', '?'});
            foreach (string s in strs)
                Console.Write($"\n{s}");
            Console.WriteLine("\n");

            string[] words = Tasks.DistinctStrings(str);
            foreach (string word in words)
            {
                Console.Write($"{word} ");
            }

            Console.WriteLine("\n\nСледующее задание >>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nЗадание 4 - Вычисление факториала.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Введите число: \n > ");

            while (true)
            {
                try
                {
                    Console.WriteLine($"Факториал числа равен {Tasks.Factorial(Convert.ToUInt16(Console.ReadLine()))}");
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите корректное значение. Входными данными должно являться целое число.");
                }
            }

            Console.WriteLine("\nСледующее задание >>");
            Console.ReadKey();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nЗадание 5 - Скобочная последовательность.");
            Console.ForegroundColor = ConsoleColor.Gray;

            string[] forValidate = {
                "namespace Test{ class Program{ static void Main(string[] args) {Console.WriteLine(\"Hello, world!\");}}}",
                "{([](){})[{}()]{[]()}}",
                "{([](){})[{)()]{[]()}}",
                "{([](){}))([{}()]}[]()}}",
            };

            foreach (string s in forValidate)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(s);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (Tasks.Validate(s.ToCharArray()))
                    Console.WriteLine("\n - Правильно.");
                else Console.WriteLine("\n - Неправильно.");
            }
            Console.ReadKey();
        }

        static void ShowArray(int[] array)
        {
            foreach (int v in array)
            {
                Console.Write($"{v} ");
            }
        }
    }
}

