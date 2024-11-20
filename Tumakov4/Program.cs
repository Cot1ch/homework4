using System;
using System.Threading;

namespace Tumakov4
{
    internal class Program
    {
        static void Main()
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();

            Console.WriteLine("Нажмине что-нибудь для закрытия окна");
            Console.ReadKey();
        }
        static void Task1()
        {
            //
            //
            //
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

            ///Вывод
            Console.WriteLine("Итоговый массив:");
            for (int i = 0; i < 20; i++)
            {
                Console.Write(array[i] + " ");
            }

        }

        static void Task2()
        {
            //
            //
            //
            Console.WriteLine("\n2 задание");

            double[] array = EnterArray();

            Console.WriteLine($"Сумма массива равна {Sum(array)}");

            double answer = 1;
            Mul(ref answer, array);
            Console.WriteLine($"Сумма массива равна {answer}");

            double mean = -1;
            Mean(out mean, array);
            Console.WriteLine($"Сумма массива равна {mean}");
        }

        static int EnterNumberFromArray(int[] arr)
        {//1
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
        static double[] EnterArray()
        {//2
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
        static double Sum(params double[] arr)
        {//2
            double sum = 0;
            foreach (double d in arr)
            {
                sum += d;
            }
            return sum;

        }

        static void Mul(ref double ans, params double[] arr)
        {//2
            foreach (double d in arr)
            {
                ans *= d;
            }
        }

        static void Mean(out double ans, params double[] arr)
        {//2
            ans = Sum(arr) / arr.Length;
        }
        static void Task3()
        {
            //
            //САЛАВАТ Задержка и заливка консоли тупит
            //
            Console.WriteLine("3 задание");

            Console.WriteLine("Консоль ваша. Вводите числа со спокойной душой.\nДля выхода введите exit или закрыть");
            string input = Console.ReadLine();

            do
            {

                if (input.ToLower() == "exit" || input.ToLower() == "закрыть")

                {
                    break;
                }
                else if (int.TryParse(input, out int number))
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
                            Thread.Sleep(3000);
                            Console.BackgroundColor = ConsoleColor.Black;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Не число");
                }
                input = Console.ReadLine();

            }
            while (true);

            Console.WriteLine("Программа окончена");
        }

        static void Task4()
        {
            Console.WriteLine("4 задание");

            Ded ded1 = new Ded();
            ded1.name = "Игаарь";
            ded1.phrases = ["Проститутки!", ""];
            ded1.level = (Level)0;

            Console.WriteLine($"{ded1.phrases}");

        }
        public struct Ded
        {
            public string name;
            public int countBruises;
            public string[] phrases;
            public Level level;

        }
        public enum Level
        { слабый, средний, сильный, маразм, трёхэтажный}
    }
}
