using System;
using System.Threading;

namespace Tumakov4
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();

            Console.WriteLine("Нажмине что-нибудь для закрытия окна");
            Console.ReadKey();
        }

        /// <summary>
        /// Создать массив из 20 случайных чисел -> Пользователь вводит 2 числа из этого массива -> Меняем их в массиве местами.
        /// </summary>
        /// <returns> - </returns>
        static void Task1()
        {
            
            Console.WriteLine("1 задание\n");

            Random random = new Random();
            Console.Write("Выберите и введите в консоль 2 числа из массива\nМассив: ");

            int[] array = new int[20];
            for (int k = 0; k < 20; k++)
            {
                array[k] = random.Next(10000);
                Console.Write(array[k] + " ");
            }
            Console.WriteLine("\nВведите первое число");

            int firstNum = EnterNumberFromArray(array);

            int secondNum = -1;
            bool notEqual = true;
            do
            {
                Console.WriteLine("Введите второе число");
                int dop = EnterNumberFromArray(array);
                if (dop == firstNum)
                {
                    Console.WriteLine("Вы уже выбрали это число");
                }
                else
                {
                    secondNum = dop;
                    notEqual = false;
                }
            }
            while (notEqual);

            int firstIndex = Array.IndexOf(array, firstNum);
            int secondIndex = Array.IndexOf(array, secondNum);

            array[firstIndex] = secondNum;
            array[secondIndex] = firstNum;

            //Вывод
            Console.WriteLine("Итоговый массив:");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(array[i] + " ");
            }

        }

        /// <summary>
        /// Вычислить сумму, произведение и среднее арифметическое массива, используя ref и out.
        /// </summary>
        /// <returns> - </returns>
        static void Task2()
        {
            Console.WriteLine("\n\n2 задание\n");

            double[] array = EnterArray();

            Console.WriteLine($"Сумма массива равна {Sum(array)}");

            double answer = 1;
            Mul(ref answer, array);
            Console.WriteLine($"Сумма массива равна {answer}");

            double mean = -1;
            Mean(out mean, array);
            Console.WriteLine($"Сумма массива равна {mean}");
        }

        /// <summary>
        /// Если пользователь вводит цифры от 0 до 9 - вывести эти числа, нарисованные символом #.
        /// Если пользователь вводит другое число - вывести ошибку и поменять цвет консоли.
        /// Если пользователь ввёл не число - создать исключение.
        /// </summary>
        /// <returns> - </returns>
        static void Task3()
        {
            Console.WriteLine("\n3 задание\n");

            Console.WriteLine("Консоль ваша. Вводите числа со спокойной душой.\nДля выхода введите exit или закрыть");
            string input;

            do
            {
                input = Console.ReadLine();
                if (input != "exit" & input != "закрыть")
                {
                    DrawNumber(input);
                }
                else
                {
                    break;
                }
            }
            while (true);
            Console.WriteLine("Программа окончена");
        }

        /// <summary>
        /// Создать структуту Дед и 5 дедов, у которых есть имя, уровень ворчливости, список матерных слов и количество  синяков=0.
        /// Пользователь вводит имя деда, список слов в махаче. За каждое слово из списка в словарном запасе деда +1 фингал.
        /// Вывести количество фингалов.
        /// </summary>
        /// <returns> - </returns>
        static void Task4()
        {
            Console.WriteLine("\n4 задание\n");

            Ded ded1 = new Ded();
            ded1.name = "Игаарь";
            string[] mat1 = { "проститутки", "гады", "тварь" };
            ded1.phrases = mat1;
            ded1.level = (Level)1;
            ded1.Print();

            Ded ded2 = new Ded();
            ded2.name = "Вова";
            string[] mat2 = { "гады", "тварь", "псина", "ну ты это да конечно" };
            ded2.phrases = mat2;
            ded2.level = (Level)2;
            ded2.Print();

            Ded ded3 = new Ded();
            ded3.name = "Никто не помнит, даже он сам";
            string[] mat3 = { "раскудрить её в качель", "проститутки" };
            ded3.phrases = mat3;
            ded3.level = (Level)0;
            ded3.Print();

            Ded ded4 = new Ded();
            ded4.name = "Петя";
            string[] mat4 = { "гады" };
            ded4.phrases = mat4;
            ded4.level = (Level)3;
            ded4.Print();

            Ded ded5 = new Ded();
            ded5.name = "Вася";
            string[] mat5 = { "продажные", "а вот при социализме", "тварь ты поганая", "растудыть его туды", };
            ded5.phrases = mat5;
            ded5.level = (Level)4;
            ded5.Print();

            Console.WriteLine("Введите имя деда");
            string dedName = Console.ReadLine();
            string[] names = { "Игаарь", "Вова", "Никто не помнит, даже он сам", "Петя", "Вася" };

            while (Array.IndexOf(names, dedName) == -1)
            {
                Console.WriteLine("Введите имя деда из списка выше");
                dedName = Console.ReadLine();
            }

            Console.WriteLine("Введите фразы деда через символ _, пожалуйста");
            switch (dedName)
            {
                case "Игаарь":
                    Console.WriteLine(ded1.Mahach(ded1.phrases, Console.ReadLine().Split('_')));
                    break;
                case "Вова":
                    Console.WriteLine(ded2.Mahach(ded2.phrases, Console.ReadLine().Split('_')));
                    break;
                case "Никто не помнит, даже он сам":
                    Console.WriteLine(ded3.Mahach(ded3.phrases, Console.ReadLine().Split('_')));
                    break;
                case "Петя":
                    Console.WriteLine(ded4.Mahach(ded4.phrases, Console.ReadLine().Split('_')));
                    break;
                case "Вася":
                    Console.WriteLine(ded5.Mahach(ded5.phrases, Console.ReadLine().Split('_')));
                    break;
            }
        }

        /// <summary>
        /// Метод возвращает число, если оно есть в переданном массиве и если оно число.
        /// Ввод до победного.
        /// </summary>
        /// <returns> Число типа int </returns>
        static int EnterNumberFromArray(int[] arr)
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber & Array.IndexOf(arr, number) != -1)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести число из массива");
                }
            }
            while (flag);

            return number;
        }

        /// <summary>
        /// Метод считывает массив строк с консоли и переводит его в массив чисел, если это возможно.
        /// Ввод продолжается до победного.
        /// </summary>
        /// <returns> Массив double[] </returns>
        static double[] EnterArray()
        {
            bool flag = true;
            string[] strNums;
            double[] nums;

            do
            {
                bool secFlag = true;
                Console.WriteLine("Введите массив чисел через пробел");
                strNums = Console.ReadLine().Split();
                nums = new double[strNums.Length];

                for (int i = 0; i < strNums.Length; i++)
                {
                    if (int.TryParse(strNums[i], out int number))
                    {
                        nums[i] = number;
                    }
                    else
                    {
                        secFlag = false;
                        break;
                    }
                }
                if (!secFlag)
                {
                    Console.WriteLine("Неверный ввод - нужен массив чисел");
                }
                else
                {
                    flag = false;
                }
            }
            while (flag);
            return nums;
        }

        /// <summary>
        /// Ко 2 заданию
        /// Считает сумму переданного массива
        /// </summary>
        /// <returns> Число типа double </returns>
        static double Sum(params double[] arr)
        {
            double sum = 0;
            foreach (double d in arr)
            {
                sum += d;
            }
            return sum;

        }

        /// <summary>
        /// Ко 2 заданию
        /// Считает произведение массива через ref
        /// </summary>
        /// <returns> - </returns>
        static void Mul(ref double ans, params double[] arr)
        {
            foreach (double d in arr)
            {
                ans *= d;
            }
        }

        /// <summary>
        /// Ко 2 заданию
        /// Считает среднее арифметическое массива через out
        /// </summary>
        /// <returns> - </returns>
        static void Mean(out double ans, params double[] arr)
        {
            ans = Sum(arr) / arr.Length;
        }

        /// <summary>
        /// К 3 заданию.
        /// Рисует переданную цифру символом #.
        /// Если число не из [0, 9] - выдает ошибку.
        /// Если не число - уведомляет об этом.
        /// </summary>
        /// <returns> - </returns>
        static void DrawNumber(string inputS)
        {
            if (int.TryParse(inputS, out int number))
            {
                switch (number)
                {
                    case 0:
                        Console.WriteLine("###\n# #\n# #\n# #\n###");
                        break;
                    case 1:
                        Console.WriteLine("  #\n  #\n  #\n  #\n  #");
                        break;
                    case 2:
                        Console.WriteLine("###\n  #\n###\n#  \n###");
                        break;
                    case 3:
                        Console.WriteLine("###\n  #\n###\n  #\n###");
                        break;
                    case 4:
                        Console.WriteLine("# #\n# #\n###\n  #\n  #");
                        break;
                    case 5:
                        Console.WriteLine("###\n#  \n###\n  #\n###");
                        break;
                    case 6:
                        Console.WriteLine("###\n#  \n###\n# #\n###");
                        break;
                    case 7:
                        Console.WriteLine("###\n  #\n  #\n  #\n  #");
                        break;
                    case 8:
                        Console.WriteLine("###\n# #\n###\n# #\n###");
                        break;
                    case 9:
                        Console.WriteLine("###\n# #\n###\n  #\n###");
                        break;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("ОШИБКА");
                        Thread.Sleep(3000);
                        Console.BackgroundColor = ConsoleColor.Black;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Не число");
            }
        }

        /// <summary>
        /// Структура Дед.
        /// </summary>
        public struct Ded
        {
            public string name;
            public int countBruises;
            public string[] phrases;
            public Level level;

            /// <summary>
            /// Возвращает количество совпадений в переданных массивах строк
            /// </summary>
            /// <returns> Строка string </returns>
            public string Mahach(string[] phrase, params string[] words)
            {
                foreach (string word in words)
                {
                    if (Array.IndexOf(phrase, word.ToLower()) != -1)
                    {
                        countBruises++;
                    }
                }
                return $"Количество синяков после махача = {countBruises}";
            }

            /// <summary>
            /// Вывод деда
            /// </summary>
            /// <returns> - </returns>
            public void Print()
            {
                Console.WriteLine($"Имя деда: {name}");
                Console.WriteLine($"Уровень ворчливости деда: {level}");
                Console.WriteLine($"Синяки: {countBruises}");
            }
        }

        public enum Level //4
        { слабый, средний, сильный, маразм, трёхэтажный }
    }
}