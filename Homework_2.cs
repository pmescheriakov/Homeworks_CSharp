using System;

class Homework_2
{
    static void Main()
    {
        Console.Write("Введите длину массива: ");
        int array_length;
        while (!int.TryParse(Console.ReadLine(), out array_length) || array_length <= 0)
        {
            Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
            Console.Write("Введите длину массива: ");
        }

        double[] arr = new double[array_length];

        for (int i = 0; i < array_length; i++)
        {
            Console.Write($"Введите число #{i + 1}: ");
            while (!double.TryParse(Console.ReadLine(), out arr[i]))
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите число.");
                Console.Write($"Введите число #{i + 1}: ");
            }
        }

        Console.WriteLine("\nИтоговый массив:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
}
