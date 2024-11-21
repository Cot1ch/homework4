using System;


namespace homework4
{
    internal class Program
    {
        static void Main()
        {
            Task1();
            Task2();
            Task3();
            Task4();
            Task5();
            Task6();

            Console.WriteLine("Нажмите что-нибудь для выхода");
            Console.ReadKey();
        }

        /// <summary>
        /// Вывести наибольшее из двух введённых чисел 
        /// </summary>
        /// <returns> - </returns>
        static void Task1()
        {
            Console.WriteLine("Упражнение 5.1\n");

            Console.WriteLine("Введите первое число");
            int firstNum = EnterNumber();
            Console.WriteLine("Введите второе число");
            int secondNum = EnterNumber();

            Max(firstNum, secondNum);
        }

        /// <summary>
        /// Поменять местами 2 числа при помощи ref  
        /// </summary>
        /// <returns> - </returns>
        static void Task2()
        {
            
            Console.WriteLine("Упражнение 5.2\n");

            Console.WriteLine("Введите первое число");
            double firstNumb = EnterNumber();
            Console.WriteLine("Введите второе число");
            double secondNumb = EnterNumber();

            Change(ref firstNumb, ref secondNumb);
            Console.WriteLine($"{firstNumb} <_> {secondNumb}");
        }

        /// <summary>
        /// Посчитать факториал числа по его номеру
        /// </summary>
        /// <returns> - </returns>
        static void Task3()
        {
            
            Console.WriteLine("Упражнение 5.3\n");

            Console.WriteLine("Введите натуральное число, факториал которого нужно посчитать");
            int number = EnterPosNumber();
            int answer = Factorial(number);
            if (answer != -1)
            {
                Console.WriteLine($"Факториал числа {number} = {answer}");
            }
        }

        /// <summary>
        /// Посчитать факториал числа при помощи рекурсии
        /// </summary>
        /// <returns> - </returns>
        static void Task4()
        {
            Console.WriteLine("Упражнение 5.4\n");

            Console.WriteLine("Введите число, факториал которого нужно вычислить");
            int number = EnterPosNumber();
            int answer = recFactorial(number);
            if (answer != -1)
            {
                Console.WriteLine($"{answer}");
            }
            
        }

        /// <summary>
        /// Посчитать НОД 2 или 3 чисел 
        /// </summary>
        /// <returns> - </returns>
        static void Task5()
        {
            Console.WriteLine("Домашнее задание 5.1\n");

            Console.WriteLine("НОД скольких чисел будем считать? 2 или 3? Введите в консоль");

            bool flag = true;
            int count = 2;

            do
            {
                int counter = EnterNumber();
                if (counter == 2 || counter == 3)
                {
                    count = counter;
                    flag = false;
                }
                else
                {
                    Console.WriteLine("2 или 3, пожалуйста");
                }
            }
            while (flag);

            Console.WriteLine("Введите первое натуральное число");
            int firstNum = EnterPosNumber();

            Console.WriteLine("Введите второе натуральное число");
            int secondNum = EnterPosNumber();

            if (count == 3)
            {
                Console.WriteLine("Введите третье натуральное число");
                int thirdNum = EnterPosNumber();

                Console.WriteLine(NOD(firstNum, secondNum, thirdNum));
            }
            else
            { // count = 2
                Console.WriteLine(NOD(firstNum, secondNum));
            }
        }

        /// <summary>
        /// Вывести число ряда Фибоначчи по его номеру
        /// </summary>
        /// <returns> - </returns>
        static void Task6()
        {
            
            Console.WriteLine("Домашнее задание 5.2\n");

            Console.WriteLine("Введите номер искомого числа Фибоначчи");
            int n_fib = EnterPosNumber();
            Console.WriteLine(Fibb(n_fib));
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к целому числу. Ввод продолжается до тех пор, 
        /// пока пользователь не введет число.
        /// </summary>
        /// <returns>Число типа int</returns>
        static int EnterNumber()
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber)
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести целое число");
                }
            }
            while (flag);

            return number;
        }

        /// <summary>
        /// Считывает строку символов с консоли и преобразует ее к неотрицательному целому числу. 
        /// Ввод продолжается до тех пор,по ка пользователь не введет число.
        /// </summary>
        /// <returns>Число типа int</returns>
        static int EnterPosNumber()
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber && (number >= 0))
                {
                    flag = false;
                }
                else
                {
                    Console.WriteLine("Неверный ввод - необходимо ввести целое неотрицательное число");
                }
            }
            while (flag);

            return number;
        }

        /// <summary>
        /// К 1 заданию
        /// Принимает 2 целых числа и выводит максимальное из них
        /// </summary>
        /// <returns> - </returns>
        static void Max(int a, int b)
        {
            Console.WriteLine($"Максимальное число равно {Math.Max(a, b)}");
        }

        /// <summary>
        /// Ко 2 заданию
        /// Принимает 2 числа и меняет их местами
        /// </summary>
        /// <returns> - </returns>
        static void Change(ref double firstNumber, ref double secondNumber)
        {
            double dop = firstNumber;
            firstNumber = secondNumber;
            secondNumber = dop;
        }

        /// <summary>
        /// К 3 заданию
        /// Считает факториал введённого неотрицательного числа
        /// </summary>
        /// <returns>Число типа int</returns>
        static int Factorial(int x)
        {
            try
            {
                int answer = 1;
                while (x > 0)
                {
                    answer = checked(answer * x);
                    x--;
                }

                return answer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return -1;            
        }

        /// <summary>
        /// К 4 заданию
        /// Рекурсивно считает факториал введённого неотрицательного числа
        /// </summary>
        /// <returns>Число типа int</returns>
        static int recFactorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else if (number == -1) 
            { 
                return -1;
            }
            else
            {
                return number * recFactorial(number - 1);
            }
        }

        /// <summary>
        /// К 5 заданию
        /// Считает НОД 2 введённых натуральных чисел 
        /// </summary>
        /// <returns>Число типа int</returns>
        static int NOD(int alfa, int beta)
        //К 5 заданию
        {
            int min = Math.Min(alfa, beta);
            alfa = Math.Max(alfa, beta);
            beta = min;
            while (alfa % beta != 0)
            {
                int dop = alfa % beta;
                alfa = beta;
                beta = dop;
            }
            return beta;
        }

        /// <summary>
        /// К 5 заданию
        /// Считает НОД 3 введённых натуральных чисел 
        /// </summary>
        /// <returns>Число типа int</returns>
        static int NOD(int alfa, int beta, int gamma)
        //К 5 заданию
        {
            int min = Math.Min(alfa, beta);
            alfa = Math.Max(alfa, beta);
            beta = min;
            while (alfa % beta != 0)
            {
                int dop = alfa % beta;
                alfa = beta;
                beta = dop;
            }
            min = Math.Min(beta, gamma);
            gamma = Math.Max(gamma, beta);
            beta = min;
            while (gamma % beta != 0)
            {
                int dop = gamma % beta;
                gamma = beta;
                beta = dop;
            }
            return beta;
        }
        
        /// <summary>
        /// К 6 заданию
        /// Считает число ряда Фибоначчи по его номеру
        /// </summary>
        /// <returns>Число типа int</returns>
        static int Fibb(int number)
        //К 6 заданию
        {
            if (number == 0 || number == 1)
            {
                return 1;
            }
            else
            {
                return Fibb(number - 1) + Fibb(number - 2);
            }
        }
    }
}
