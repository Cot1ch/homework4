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

        static void Task1()
        {
            //Написать метод, возвращающий наибольшее из двух введённых чисел
            //Вход: 2 целых числа
            //Выход -> макс. число
            Console.WriteLine("Упражнение 5.1\n");

            Console.WriteLine("Введите первое число");
            int firstNum = EnterNumber();
            Console.WriteLine("Введите второе число");
            int secondNum = EnterNumber();

            Max(firstNum, secondNum);

        }
        static void Task2()
        {
            //Поменять 2 числа местами, используя ref
            //Ввод: 2 числа
            //Вывод -> 2 числа :)
            Console.WriteLine("Упражнение 5.2\n");

            Console.WriteLine("Введите первое число");
            double firstNumb = EnterNumber();
            Console.WriteLine("Введите второе число");
            double secondNumb = EnterNumber();

            Change(ref firstNumb, ref secondNumb);
            Console.WriteLine($"{firstNumb} <_> {secondNumb}");
        }
        static void Task3()
        {
            //Посчитать факториал числа
            //Ввод: число
            //Вывод -> факториал числа
            Console.WriteLine("Упражнение 5.3\n");

            Console.WriteLine("Введите натуральное число, факториал которого нужно посчитать");
            int number = EnterPosNumber();
            int answer = Factorial(number);
            if (answer != -1)
            {
                Console.WriteLine($"Факториал числа {number} = {answer}");
            }
        }
        static void Task4()
        {
            //Посчитать факториал числа через рекурсию
            //Ввод: число
            //Вывод -> факториал числа
            Console.WriteLine("Упражнение 5.4\n");

            Console.WriteLine("Введите число, факториал которого нужно вычислить");
            int number = EnterPosNumber();
            int answer = recFactorial(number);
            if (answer != -1)
            {
                Console.WriteLine($"{answer}");
            }
            
        }
        static void Task5()
        {
            //Посчитать НОД чисел по алгоритму Евклида
            //Ввод: количество чисел (2, 3), сами числа
            //Вывод -> НОД
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
        static void Task6()
        {
            ///Вывести число Фмбоначчи по номеру
            ///Ввод: порядковый номер числа Фибоначчи
            ///Вывод: само число
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

        static int EnterPosNumber()
        {
            bool flag = true;
            int number;
            do
            {
                bool isNumber = int.TryParse(Console.ReadLine(), out number);
                if (isNumber & number >= 0)
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

        static void Max(int a, int b)
        //К 1 заданию
        {
            Console.WriteLine($"Максимальное число равно {Math.Max(a, b)}");
        }

        static void Change(ref double firstNumber, ref double secondNumber)
        //К 2 заданию
        {
            double dop = firstNumber;
            firstNumber = secondNumber;
            secondNumber = dop;
        }

        static int Factorial(int x)
        //К 3 заданию
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

        static int recFactorial(int number)
        //К 4 заданию
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
