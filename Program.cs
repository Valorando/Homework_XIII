/*Написать программу которая будет сохранять историю математических операций калькулятора в Json файл и пользователь 
по желанию может просмотреть все математические операции которые он проводил
Калькулятор должен быть полностью реализован */

using System.IO;
using System.Text.Json;

if (!File.Exists("Calculator_log.json"))
{
    using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Create))
    {
        Calculator calculator = new Calculator();
        await JsonSerializer.SerializeAsync(fs, calculator);
    }
}

Console.ForegroundColor = ConsoleColor.Green;
while (true)
{
    try
    {
        int key;
        int first_digit;
        int second_digit;
        DateTime date = DateTime.Now;

        Console.WriteLine();
        Console.WriteLine("Введите 1 для сложения.");
        Console.WriteLine("Введите 2 для вычитания.");
        Console.WriteLine("Введите 3 для умножения.");
        Console.WriteLine("Введите 4 для деления.");
        Console.WriteLine("Введите 5 для просмотра истории операций.");
        Console.WriteLine("Введите 6 для выхода из программы.");
        Console.WriteLine();
        Console.Write("Ваш выбор: ");
        key = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();

        if (key == 1)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите первое число: ");
                Console.WriteLine();
                first_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите второе число: ");
                Console.WriteLine();
                second_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{first_digit} + {second_digit}");

                Calculator calculator = new Calculator(first_digit, second_digit, "Plus", date);
                calculator.Plus();

                using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        string json = JsonSerializer.Serialize(calculator);
                        writer.WriteLine($"\n{json}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 2)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите первое число: ");
                Console.WriteLine();
                first_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите второе число: ");
                Console.WriteLine();
                second_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{first_digit} - {second_digit}");

                Calculator calculator = new Calculator(first_digit, second_digit, "Minus", date);
                calculator.Minus();

                using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        string json = JsonSerializer.Serialize(calculator);
                        writer.WriteLine($"\n{json}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 3)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите первое число: ");
                Console.WriteLine();
                first_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите второе число: ");
                Console.WriteLine();
                second_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{first_digit} * {second_digit}");

                Calculator calculator = new Calculator(first_digit, second_digit, "Multiply", date);
                calculator.Multiply();

                using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        string json = JsonSerializer.Serialize(calculator);
                        writer.WriteLine($"\n{json}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 4)
        {
            try
            {
                Console.WriteLine();
                Console.Write("Введите первое число: ");
                Console.WriteLine();
                first_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Введите второе число: ");
                Console.WriteLine();
                second_digit = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"{first_digit} / {second_digit}");

                if (second_digit == 0)
                {
                    throw new DivideByZeroException("Can't divide by zero.");
                }

                Calculator calculator = new Calculator(first_digit, second_digit, "Divide", date);
                calculator.Divide();

                using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Append))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        string json = JsonSerializer.Serialize(calculator);
                        writer.WriteLine($"\n{json}");
                    }
                }
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Общая ошибка: {ex.Message}");
                Console.WriteLine();
            }

        }

        if (key == 5)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("История операций калькулятора:");
                Console.WriteLine();
                using (FileStream fs = new FileStream("Calculator_log.json", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        string content = sr.ReadToEnd();
                        Console.WriteLine(content);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine();
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine();
            }
        }

        if (key == 6)
        {
            break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine($"Ошибка: {ex.Message}");
        Console.WriteLine();
    }
}


class Calculator
{

    public double First_digit { get; set; }
    public double Second_digit { get; set; }
    public double Result { get; set; }
    public string Operation { get; set; }
    public DateTime Date { get; set; }

    public Calculator()
    {
        First_digit = 0;
        Second_digit = 0;
        Result = 0;
        Operation = "";
        Date = DateTime.MinValue;
    }

    public Calculator(double first_digit, double second_digit, string operation, DateTime date)
    {
        First_digit = first_digit;
        Second_digit = second_digit;
        Operation = operation;
        Date = date;
    }

    public void Plus()
    {
        Result = First_digit + Second_digit;
        Console.WriteLine();
        Console.WriteLine($"Результат: {Result}");
        Console.WriteLine();
    }

    public void Minus()
    {
        Result = First_digit - Second_digit;
        Console.WriteLine();
        Console.WriteLine($"Результат: {Result}");
        Console.WriteLine();
    }

    public void Multiply()
    {
        Result = First_digit * Second_digit;
        Console.WriteLine();
        Console.WriteLine($"Результат: {Result}");
        Console.WriteLine();
    }

    public void Divide()
    {
        Result = First_digit / Second_digit;
        Console.WriteLine();
        Console.WriteLine($"Результат: {Result}");
        Console.WriteLine();
    }

}