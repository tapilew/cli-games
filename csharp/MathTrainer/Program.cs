// todo - [x] select quantity of digits for each operand
// todo - [x] track time taken to complete each operation and total time
// todo - [x] select quantity of operands
// todo - [ ] select custom ranges (either quantity or digits)
// todo - [ ] improve precision in time tracking
// todo - [ ] set some defaults
// todo - [ ] format operations
// todo - [ ] do unit tests

using System.Diagnostics;
using System.Text;

System.Random random = new System.Random();
int correctAnswers = 0;
int operations = 0;
int operands = 0;
int totalSeconds = 0;
int totalMinutes = 0;

Console.WriteLine("Operation options:\n" +
    "'addition' (+)\n'subtraction' (-)\n" +
    "'multiplication' (*)\n'division' (/)\n");
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

    Console.Write($"{sb.ToString()} = "); // to change
    Stopwatch stopwatchOp = new Stopwatch();
    stopwatchOp.Start();
    int userAnswer = Convert.ToInt32((Console.ReadLine()));
    stopwatchOp.Stop();
    int opSeconds = stopwatchOp.Elapsed.Seconds;
    int opMinutes = stopwatchOp.Elapsed.Minutes;

    if (userAnswer == result)
    {
        correctAnswers++;
        Console.WriteLine("That's correct!");
    }
    else
    {
        Console.WriteLine($"Nope... it was {result}");
    }
    int minutesTakenOp = stopwatchOp.Elapsed.Minutes;
    Console.WriteLine($"You answered this operation in {opSeconds} seconds ({opMinutes} minutes).\n");
}

stopwatch.Stop();
totalSeconds = stopwatch.Elapsed.Seconds;
totalMinutes = stopwatch.Elapsed.Minutes;
Console.WriteLine($"Goodbye! your score was {correctAnswers}/{operations}");
Console.WriteLine($"Total time: {totalSeconds} seconds ({totalMinutes} minutes)");