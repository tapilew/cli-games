// TODO - [x] new option to convert decimal to binary
// TODO - [x] new option to convert binary to decimal
// TODO - [ ] new option to add binary
// TODO - [ ] new option to subtract binary
// TODO - [ ] determine value of binary with 1 in each place
// TODO - [ ] determine how many 1s would be enough to represent n number

// TODO - [ ] select custom ranges (either quantity or digits)
// TODO - [ ] improve precision in time tracking
// TODO - [ ] set some defaults
// TODO - [ ] format operations
// TODO - [ ] do unit tests

using System.Diagnostics;
using System.Text;
System.Random random = new System.Random();

var mode = "";
Console.WriteLine("Welcome to the math trainer!\n\nSelect what you want to do...");
Console.WriteLine("1) arithmetic\n2) binary");
Console.Write("Choose: ");
mode = Console.ReadLine();
if (mode == "1" || mode == "arithmetic")
{
    int correctAnswers = 0;
    int operations = 0;
    int operands = 0;
    int totalSeconds = 0;
    int totalMinutes = 0;

    Console.WriteLine("\nOperation options:\n" +
        "'addition' (+)\n'subtraction' (-)\n" +
        "'multiplication' (*)\n'division' (/)");
    Console.Write("Select your operation type: ");

    var op = Console.ReadLine();

    if (op == "addition" || op == "add" || op == "+")
    {
        op = "addition";
    }
    else if (op == "subtraction" || op == "subtract" || op == "sub" || op == "-")
    {
        op = "subtraction";
    }
    else if (op == "multiplication" || op == "multiply" || op == "mlp" || op == "*")
    {
        op = "multiplication";
    }
    else if (op == "division" || op == "divide" || op == "div" || op == "/")
    {
        op = "division";
    }
    else
    {
        Console.WriteLine("Not a valid option provided... Please try again.");
    }

    Console.WriteLine($"Great! Let's do {op}\n");
    Console.Write("Select the amount of OPERANDS of each operation: ");

    operands = Convert.ToInt32(Console.ReadLine());
    int[] digitsPerOperand = new int[operands];

    for (int i = 0; i < operands; i++)
    {
        int operandNumber = i + 1;
        Console.Write($"How many DIGITS should operand {operandNumber} have: ");
        digitsPerOperand[i] = Convert.ToInt32(Console.ReadLine());
    }

    Console.Write("\nSelect the number of operations to perform: ");
    operations = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();

    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();

    for (int i = 0; i < operations; i++)
    {
        int[] operandValues = new int[operands];
        for (int j = 0; j < operands; j++)
        {
            int min = Convert.ToInt32("1" + new string('0', digitsPerOperand[j] - 1));
            int max = Convert.ToInt32("1" + new string('0', digitsPerOperand[j])) - 1;
            int value = random.Next(min, max);
            operandValues[j] = value;
        }
        char opSymbol = ' ';
        int result = operandValues[0];
        StringBuilder sb = new StringBuilder();
        sb.Append(operandValues[0]);
        for (int j = 1; j < operands; j++)
        {
            switch (op)
            {
                case "addition":
                    opSymbol = '+';
                    result += operandValues[j];
                    break;
                case "subtraction":
                    opSymbol = '-';
                    result -= operandValues[j];
                    break;
                case "multiplication":
                    opSymbol = '*';
                    result *= operandValues[j];
                    break;
                case "division":
                    opSymbol = '/';
                    result /= operandValues[j];
                    break;
            }
            sb.Append($" {opSymbol} {operandValues[j]}");
        }

        Console.Write($"{sb.ToString()} = ");
        Stopwatch stopwatchOp = new Stopwatch();
        stopwatchOp.Start();
        int userAnswer = Convert.ToInt32((Console.ReadLine()));
        stopwatchOp.Stop();
        if (userAnswer == result)
        {
            correctAnswers++;
            Console.WriteLine("That's correct!");
        }
        else
        {
            Console.WriteLine($"Nope... it was {result}");
        }
        int opMinutes = stopwatchOp.Elapsed.Minutes;
        int opSeconds = stopwatchOp.Elapsed.Seconds;
        Console.WriteLine($"You answered this operation in {opSeconds}" +
            $"seconds ({opMinutes} minutes).\n");
    }

    stopwatch.Stop();
    totalSeconds = stopwatch.Elapsed.Seconds;
    totalMinutes = stopwatch.Elapsed.Minutes;
    Console.WriteLine($"Goodbye! your score was {correctAnswers}/{operations}");
    Console.WriteLine($"Total time: {totalSeconds} seconds ({totalMinutes} minutes)");
}
else if (mode == "2" || mode == "binary")
{
    Console.WriteLine("\n1) decimal to binary\n2) binary to decimal");
    Console.Write("Choose: ");
    var binaryMode = Console.ReadLine();
    Console.WriteLine("\nWrite a range of numbers to convert from or to");
    int minimum = 0;
    int maximum = 0;
    int conversions = 0;
    Console.Write("Minimum: ");
    minimum = Convert.ToInt32(Console.ReadLine());
    Console.Write("Maximum: ");
    maximum = Convert.ToInt32(Console.ReadLine());
    Console.Write("How many times you want to convert?: ");
    conversions = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    int[] decimals = new int[conversions];
    int[] binaries = new int[conversions];
    for (int i = 0; i < conversions; i++)
    {
        int decimalValue = random.Next(minimum, maximum + 1);
        decimals[i] = decimalValue;
        string binaryText = "";
        int quotient = decimalValue;
        while (quotient > 1)
        {
            int remainder = quotient % 2;
            quotient /= 2;
            binaryText = remainder + binaryText;
        }
        binaryText = 1 + binaryText;
        binaries[i] = Convert.ToInt32(binaryText);
    }
    if (binaryMode == "1" || binaryMode == "decimal to binary")
    {
        int correctAnswers = 0;
        int totalSeconds = 0;
        int totalMinutes = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < conversions; i++)
        {
            int decimalValue = decimals[i];
            int binaryValue = binaries[i];
            Console.Write($"Convert {decimalValue} to binary: ");
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            stopwatchOp.Stop();
            int secondsToConvert = stopwatchOp.Elapsed.Seconds;
            int minutesToConvert = stopwatchOp.Elapsed.Minutes;
            if (userAnswer == binaryValue)
            {
                correctAnswers++;
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine($"Nope... it was {binaryValue}");
            }
            Console.WriteLine($"You converted this number in " +
                $"{secondsToConvert} seconds ({minutesToConvert} minutes).\n");
        }
        stopwatch.Stop();
        totalSeconds = stopwatch.Elapsed.Seconds;
        totalMinutes = stopwatch.Elapsed.Minutes;
        Console.WriteLine($"Goodbye! your score was {correctAnswers}/{conversions}");
        Console.WriteLine($"Total time: {totalSeconds} seconds ({totalMinutes} minutes)");
    }
    else if (binaryMode == "2" || binaryMode == "binary to decimal")
    {
        int correctAnswers = 0;
        int totalSeconds = 0;
        int totalMinutes = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < conversions; i++)
        {
            int decimalValue = decimals[i];
            int binaryValue = binaries[i];
            Console.Write($"Convert {binaryValue} to decimal: ");
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = Convert.ToInt32(Console.ReadLine());
            stopwatchOp.Stop();
            int secondsToConvert = stopwatchOp.Elapsed.Seconds;
            int minutesToConvert = stopwatchOp.Elapsed.Minutes;
            if (userAnswer == decimalValue)
            {
                correctAnswers++;
                Console.WriteLine("That's correct!");
            }
            else
            {
                Console.WriteLine($"Nope... it was {decimalValue}");
            }
            Console.WriteLine($"You converted this number in " +
                $"{secondsToConvert} seconds ({minutesToConvert} minutes).\n");
        }
        stopwatch.Stop();
        totalSeconds = stopwatch.Elapsed.Seconds;
        totalMinutes = stopwatch.Elapsed.Minutes;
        Console.WriteLine($"Goodbye! your score was {correctAnswers}/{conversions}");
        Console.WriteLine($"Total time: {totalSeconds} seconds ({totalMinutes} minutes)");
    }
    else
    {
        Console.WriteLine("Not a valid option provided, try again...");
    }
}
else
{
    Console.WriteLine("Not a valid option provided, try again");
}
