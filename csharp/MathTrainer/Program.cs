// todo - [x] select quantity of digits for each operand
// todo - [ ] track time taken to complete each operation and total time
// todo - [ ] select quantity of operands
// todo - [ ] select custom ranges (either quantity or digits)
// todo - [ ] set some defaults
// todo - [ ] format operations
// todo - [ ] do unit tests

System.Random random = new System.Random();

int correctAnswers = 0;
int operations = 0;
int digitsFirst = 0;
int digitsSecond = 0;

Console.WriteLine("Operation options:\n" +
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

Console.WriteLine($"Great! Let's do {op}");
Console.Write("Select the amount of DIGITS the FIRST operand should have: ");
digitsFirst = System.Convert.ToInt32(Console.ReadLine());
Console.Write("Select the amount of DIGITS the SECOND operand should have: ");
digitsSecond = System.Convert.ToInt32(Console.ReadLine());
Console.Write("Select the number of operations to perform: ");
operations = System.Convert.ToInt32(Console.ReadLine());

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
    int userAnswer = System.Convert.ToInt32((Console.ReadLine()));

    if (userAnswer == result)
    {
        correctAnswers++;
        Console.WriteLine("That's correct!");
    }
    else
    {
        Console.WriteLine($"Nope... it was {result}");
    }
}

Console.WriteLine($"Goodbye! your score was {correctAnswers}/{operations}");