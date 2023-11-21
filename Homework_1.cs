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
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введите второе число: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Сумма: {Calculator.Add(number1, number2)}");
        Console.WriteLine($"Разность: {Calculator.Subtract(number1, number2)}");
        Console.WriteLine($"Произведение: {Calculator.Multiply(number1, number2)}");
        Console.WriteLine($"Деление: {Calculator.Divide(number1, number2)}");
    }
}
