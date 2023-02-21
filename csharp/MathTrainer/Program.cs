// todo - [x] select quantity of digits for each operand
// todo - [x] track time taken to complete each operation and total time
// todo - [ ] improve precision in time tracking
// todo - [ ] select quantity of operands
// todo - [ ] select custom ranges (either quantity or digits)
// todo - [ ] set some defaults
// todo - [ ] format operations
// todo - [ ] do unit tests

using System.Diagnostics;
System.Random random = new System.Random();

int correctAnswers = 0;
int operations = 0;
int digitsFirst = 0;
int digitsSecond = 0;
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
Console.Write("Select the amount of DIGITS the FIRST operand should have: ");
digitsFirst = System.Convert.ToInt32(Console.ReadLine());
Console.Write("Select the amount of DIGITS the SECOND operand should have: ");
digitsSecond = System.Convert.ToInt32(Console.ReadLine());
Console.Write("Select the number of operations to perform: ");
operations = System.Convert.ToInt32(Console.ReadLine());
Console.WriteLine();

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();

for (int i = 0; i < operations; i++)
{
    int minNumFirst = System.Convert.ToInt32("1" + new string('0', digitsFirst - 1));
    int maxNumFirst = System.Convert.ToInt32("1" + new string('0', digitsFirst)) - 1;
    int minNumSecond = System.Convert.ToInt32("1" + new string('0', digitsSecond - 1));
    int maxNumSecond = System.Convert.ToInt32("1" + new string('0', digitsSecond)) - 1;
    int operand1 = random.Next(minNumFirst, maxNumFirst);
    int operand2 = random.Next(minNumSecond, maxNumSecond);
    int result = 0;
    char opSymbol = ' ';
    switch (op)
    {
        case "addition":
            result = operand1 + operand2;
            opSymbol = '+';
            break;
        case "subtraction":
            result = operand1 - operand2;
            opSymbol = '-';
            break;
        case "multiplication":
            result = operand1 * operand2;
            opSymbol = '*';
            break;
        case "division":
            result = operand1 / operand2;
            opSymbol = '/';
            break;
    }

    Console.Write($"{operand1} {opSymbol} {operand2} = ");
    Stopwatch stopwatchOp = new Stopwatch();
    stopwatchOp.Start();
    int userAnswer = System.Convert.ToInt32((Console.ReadLine()));
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