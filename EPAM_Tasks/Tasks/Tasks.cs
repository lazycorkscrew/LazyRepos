using System;
//using System.Linq;

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
        //Если ничего не нашёл - возвращает -1
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
            //string[] words = bigString.Split(new char[] { ' ', '.', ',', '?', '!', ':', ';', '-' }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = MySplit(bigString, new char[] { ' ', '.', ',', '?', '!', ':', ';', '-' });

            string [] distinctWords = new string[0];

            for (int i = 0; i < words.Length; i++)
            {
                int found = -1;
                for (int j = 0; j < distinctWords.Length; j++)
                {
                    if (words[i] == distinctWords[j])
                    {
                        found = j;
                        break;
                    }
                }
                if (found >= 0) distinctWords = Remove(distinctWords, (uint)found, 1);
                else distinctWords = Add(distinctWords, words[i]);
            }
            return distinctWords;
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
                    if ((chars[i] == '[' && chars[i + 1] == ']') ||
                        (chars[i] == '(' && chars[i + 1] == ')') ||
                        (chars[i] == '{' && chars[i + 1] == '}'))
                    {
                        chars = Remove(chars, i, 2);
                        somethingsDeleted = true;
                        i--;
                    }
                }
            }
            return (chars.Length == 0 ? true : false);
        }

        //Функция добавления элемента в конец массива
        public static T[] Add<T>(T[] array, T value)
        {
            T[] newArray = new T[array.Length +1];
            for (uint i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[newArray.Length - 1] = value;
            return newArray;
        }

        //Функция удаления элемента из массива
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

        //Функция разбиения строки 
        public static string[] MySplit(string str, char [] separator, bool RemoveEmptyEntries = true)
        {
            //Узнаём общее количество разделений.
            int countSeparators = 0;
            for(int i = 0; i < str.Length; i++)
            {
                for(int j = 0; j < separator.Length; j++)
                {
                    if (str[i] == separator[j])
                        countSeparators++;
                }
            }

            //Находим индексы всех разделителей.
            int[] separatorIndexes = new int[countSeparators];
            int index = 0;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = 0; j < separator.Length; j++)
                {
                    if (str[i] == separator[j])
                    {
                        separatorIndexes[index] = i;
                        index++;
                    }
                }
            }

            //Сортируем
            Sort(separatorIndexes);

            //Обрезаем строку по индексам разделителей
            int start = 0;
            int end = 0;
            index = 0;
            string[] separated = new string[countSeparators+1];
            
            for(int i = 0; i < countSeparators; i++)
            {
                if(i == 0)
                {
                    start = 0;
                    end = separatorIndexes[0]-1;
                }
                else
                {
                    start = separatorIndexes[i-1]+1;
                    end = separatorIndexes[i]-1;
                }
                char[] part = new char[(end-start)+1];
                int partIndex = 0;

                for(int j = start; j <= end; j++)
                {
                    part[partIndex] = str[j];
                    partIndex++;
                }
                
                    separated[index] = new string(part);
                    index++;
            }
            int finalPartIndex = 0;
            char[] finalPart = new char[(str.Length - end)-2];

            for (int j = end+2; j < str.Length; j++)
            {
                finalPart[finalPartIndex] = str[j];
                finalPartIndex++;
            }
            separated[index] = new string(finalPart);

            for(int i = 0; i < separated.Length; i++)
            {
                if (separated[i] == string.Empty)
                    separated = Remove(separated, (uint)i, 1);
            }


            return separated;


        }
    }
}