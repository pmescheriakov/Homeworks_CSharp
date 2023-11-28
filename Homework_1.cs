using System;

class Calculator
{
    public static double Add(double a, double b) => a + b;
    public static double Subtract(double a, double b) => a - b;
    public static double Multiply(double a, double b) => a * b;
    public static double Divide(double a, double b) => b != 0 ? a / b : double.NaN;
}

class Homework_1
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        double number1;
        while (!double.TryParse(Console.ReadLine(), out number1))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите первое число: ");
        }

        Console.Write("Введите второе число: ");
        double number2;
        while (!double.TryParse(Console.ReadLine(), out number2))
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
            Console.Write("Введите второе число: ");
        }

        Console.WriteLine($"Сумма: {Calculator.Add(number1, number2)}");
        Console.WriteLine($"Разность: {Calculator.Subtract(number1, number2)}");
        Console.WriteLine($"Произведение: {Calculator.Multiply(number1, number2)}");
        Console.WriteLine($"Деление: {Calculator.Divide(number1, number2)}");
    }
}
