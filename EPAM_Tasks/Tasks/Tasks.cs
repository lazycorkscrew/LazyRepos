using System;
using System.Collections.Generic;
using System.Linq;

namespace EPAM_Tasks
{
    public static class Tasks
    {
        //Задание 1
        //Пузырьковая сортировка целочисленного массива с возвращением значения.
        //Вместо этой функции можно использовать Array.Sort<int>(int [] array);
        public static int[] Sort(int[] arrayToSort, bool onlyShow = false)
        {
            int[] arrayToWork = (onlyShow ? (int[])arrayToSort.Clone() : arrayToSort);
            int temp;

            for (int i = 1; i != arrayToWork.Length; i++)
            {
                for (int j = 0; j < arrayToWork.Length - i; j++)
                {
                    if (arrayToWork[j] > arrayToWork[j + 1])
                    {
                        temp = arrayToWork[j + 1];
                        arrayToWork[j + 1] = arrayToWork[j];
                        arrayToWork[j] = temp;
                    }
                }
            }
            return arrayToWork;
        }

        //Задание 2
        //Бинарный поиск в массиве. При успешном поиске возвращает индекс первого вхождения
        //Если ничего не нашёл = возвращает -1
        //Вместо этой функции можно использовать Array.BinarySearch<int>(int [] array, int value);
        public static int Find(int[] array, int value)
        {
            int modific = array.Length / 2; //Модификатор позиции.
            int findPosition = modific; //текущая позиция равная половине массива.
            sbyte lastIteration = 0;

            while (lastIteration < 2)
            {
                if (modific != 1)
                {
                    if (modific / 2 != 0)
                        modific /= 2;
                    else modific = 1;
                }
                else lastIteration++;

                if (array[findPosition - 1] < value)
                {
                    findPosition += modific;
                }
                else if (array[findPosition - 1] > value)
                {
                    findPosition -= modific;
                }
                else
                {
                    for (int i = findPosition - 1; i > 0; i--)
                    {
                        if (array[i] != value)
                        {
                            Console.WriteLine($"{array[i + 1]} [{i + 1}]");
                            return i + 1;
                        }
                    }
                    Console.WriteLine($"{array[findPosition - 1]} [{findPosition - 1}]");
                    return findPosition - 1;
                }
            }
            return -1;
        }

        //Задание 3
        public static string[] DistinctStrings(string bigString)
        {
            string[] words = bigString.Split(new char[] { ' ', '.', ',', '?', '!', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> distinctWords = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                int found = -1;
                for (int j = 0; j < distinctWords.Count; j++)
                {
                    if (words[i] == distinctWords[j])
                    {
                        found = j;
                        break;
                    }
                }
                if (found >= 0) distinctWords.RemoveAt(found);
                else distinctWords.Add(words[i]);
            }
            return distinctWords.ToArray();
        }

        //Задание 4
        public static ulong Factorial(ushort value)
        {
            {
                ulong c = 1;
                for (uint i = 1; i <= value; i++)
                {
                    c *= i;
                }
                return c;
            }
        }



        //Задание 5
        public static bool Validate(char[] charsTemp)
        {
            //Создаём массив, содержащий в себе только скобки, без сторонних символов.


            int capacity = 0;
            for (int i = 0; i < charsTemp.Length; i++)
            {
                if (charsTemp[i] == '(' || charsTemp[i] == ')' || charsTemp[i] == '[' || charsTemp[i] == ']' || charsTemp[i] == '{' || charsTemp[i] == '}')
                    capacity++;
            }
            char[] charsArr = new char[capacity];
            int index = 0;
            for (int i = 0; i < charsTemp.Length; i++)
            {
                if (charsTemp[i] == '(' || charsTemp[i] == ')' || charsTemp[i] == '[' || charsTemp[i] == ']' || charsTemp[i] == '{' || charsTemp[i] == '}')
                {
                    charsArr[index] = charsTemp[i];
                    index++;
                }
            }

            //Если число символов нечётное - о валидности не может идти и речи.
            if (charsArr.Length % 2 != 0)
                return false;

            //List<char> chars = charsArr.ToList<char>();

            //По умолчанию, пустая строка является валидной.
            if (charsArr.Length == 0)
                return true;

            char[] chars = charsArr;

            //Если последовательность начинается с закрытой скобки, или заканчивается открытой - 
            //о валидности не может идти и речи.
            if (chars[0] == ']' || chars[0] == ')' || chars[0] == '}')
                return false;
            if (chars[chars.Length - 1] == '[' || chars[chars.Length - 1] == '(' || chars[chars.Length - 1] == '{')
                return false;

            //Убираем в цикле все открывающиеся, и сразу закрывающиеся скобки (до тех пор, пока они убираются).
            bool somethingsDeleted = true;
            while (somethingsDeleted)
            {
                somethingsDeleted = false;
                for (uint i = 0; i < chars.Length - 1; i++)
                {
                    //Если в списке не осталось больше элементов - то строка валидная.
                    if (chars.Length == 0)
                        return true;

                    if ((chars[i] == '[' && chars[i + 1] == ']') ||
                        (chars[i] == '(' && chars[i + 1] == ')') ||
                        (chars[i] == '{' && chars[i + 1] == '}'))
                    {
                        chars = Remove(chars, i, 2);
                        GC.Collect();
                        somethingsDeleted = true;
                        i--;
                    }
                }
            }
            return (chars.Length == 0 ? true : false);
        }


        //Функция удаления элемента массива
        public static T[] Remove<T>(T[] array, uint index, int count)
        {
            T[] newArray = new T[array.Length - count];
            for (uint i = 0; i < array.Length - count; i++)
            {
                if (i >= index)
                    newArray[i] = array[i + count];
                else newArray[i] = array[i];
            }
            return newArray;
        }
    }
}
