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

static int DecimalToBinary(int decimalValue)
{
    string binaryText = "";
    int quotient = decimalValue;
    while (quotient > 1)
    {
        int remainder = quotient % 2;
        quotient /= 2;
        binaryText = remainder + binaryText;
    }
    binaryText = 1 + binaryText;
    return Convert.ToInt32(binaryText);
}

static string IdentifyOperationType(string operation)
{

    if (operation == "addition" ||
        operation == "add" ||
        operation == "+")
    {
        return "addition";
    }
    else if (operation == "subtraction" ||
        operation == "subtract" ||
        operation == "sub" ||
        operation == "-")
    {
        return "subtraction";
    }
    else if (operation == "multiplication" ||
        operation == "multiply" ||
        operation == "mlp" ||
        operation == "*")
    {
        return "multiplication";
    }
    else if (operation == "division" ||
        operation == "divide" ||
        operation == "div" ||
        operation == "/")
    {
        return "division";
    }
    else
    {
        return "nope...";
    }

}

static string ReportTotalScore(
    int correctAnswers,
    int totalQuestions,
    int totalSeconds,
    int totalMinutes)
{
    return ($"Goodbye! your score was {correctAnswers}/{totalQuestions}\n") +
        ($"Total time: {totalSeconds} seconds ({totalMinutes} minutes)");
}

static string WelcomeMessage(string state)
{
    switch (state)
    {
        case "home":
            return "Welcome to the math trainer!\n\n" +
                "Select what you want to do...\n" +
                "1) arithmetic\n2) binary\n" +
                "Choose: ";
        case "arithmetic":
            return "\nOperation options:\n" +
                "'addition' (+)\n'subtraction' (-)\n" +
                "'multiplication' (*)\n'division' (/)\n" +
                "Select your operation type: ";
        case "binary":
            return "\n1) decimal to binary\n2) binary to decimal\n" +
                "Choose: ";
        default:
            return "nope...";
    }
}

static string ReportQuestionResult(
    int userAnswer,
    int correctAnswer,
    int seconds,
    int minutes)
{
    string message = "";
    bool answeredRight = userAnswer == correctAnswer;
    message += answeredRight ? "That's correct!" : $"Nope... it was {correctAnswer}";
    message += $"\nYou answered in {seconds} seconds ({minutes} minutes).\n";
    return message;
}

static int SolveOperation(string operationType, int[] operands)
{
    int result = operands[0];
    for (int i = 1; i < operands.Length; i++)
    {
        switch (operationType)
        {
            case "addition":
                result += operands[i];
                break;
            case "subtraction":
                result -= operands[i];
                break;
            case "multiplication":
                result *= operands[i];
                break;
            case "division":
                result /= operands[i];
                break;
        }
    }
    return result;
}

static string PromptOperation(string operationType, int[] operands)
{
    StringBuilder sb = new StringBuilder();
    sb.Append(operands[0]);
    char opSymbol = ' ';
    switch (operationType)
    {
        case "addition":
            opSymbol = '+';
            break;
        case "subtraction":
            opSymbol = '-';
            break;
        case "multiplication":
            opSymbol = '*';
            break;
        case "division":
            opSymbol = '/';
            break;
    }
    for (int j = 1; j < operands.Length; j++)
    {
        sb.Append($" {opSymbol} {operands[j]}");
    }
    sb.Append(" = ");
    return sb.ToString();
}

static int PromptForNumber(string prompt)
{
    Console.Write(prompt);
    int answer = Convert.ToInt32(Console.ReadLine());
    return answer;
}

static string PromptForString(string prompt)
{
    Console.Write(prompt);
    string answer = Console.ReadLine();
    return answer;
}

static int GetMinimumNumberWithNDigits(int digits)
{
    return Convert.ToInt32("1" + new string('0', digits - 1));
}

static int GetMaximumNumberWithNDigits(int digits)
{
    return Convert.ToInt32("1" + new string('0', digits)) - 1;
}

var mode = PromptForString(WelcomeMessage("home"));

if (mode == "1" || mode == "arithmetic")
{
    int correctAnswers = 0;
    var operationType = PromptForString(WelcomeMessage("arithmetic"));
    operationType = IdentifyOperationType(operationType);
    int operands = PromptForNumber($"\nGreat! Let's do {operationType}\n" +
        "Select the amount of OPERANDS of each operation: ");
    int[] digitsPerOperand = new int[operands];
    for (int i = 0; i < operands; i++)
    {
        int operandNumber = i + 1;
        digitsPerOperand[i] = PromptForNumber(
            $"How many DIGITS should operand {operandNumber} have: ");
    }
    int operations = PromptForNumber("\n Select the number of operations to perform: ");
    Console.WriteLine();
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < operations; i++)
    {
        int[] operandValues = new int[operands];
        for (int j = 0; j < operands; j++)
        {
            int minimum = GetMinimumNumberWithNDigits(digitsPerOperand[j]);
            int maximum = GetMaximumNumberWithNDigits(digitsPerOperand[j]);
            int value = random.Next(minimum, maximum);
            operandValues[j] = value;
        }
        Stopwatch stopwatchOp = new Stopwatch();
        stopwatchOp.Start();
        int userAnswer = PromptForNumber(PromptOperation(operationType, operandValues));
        int result = SolveOperation(operationType, operandValues);
        stopwatchOp.Stop();
        if (userAnswer == result) correctAnswers++;
        Console.WriteLine(ReportQuestionResult(
            userAnswer,
            result,
            stopwatchOp.Elapsed.Seconds,
            stopwatchOp.Elapsed.Minutes));
    }

    stopwatch.Stop();
    Console.WriteLine(ReportTotalScore(
        correctAnswers,
        operations,
        stopwatch.Elapsed.Seconds,
        stopwatch.Elapsed.Minutes));
}
else if (mode == "2" || mode == "binary")
{
    var binaryMode = PromptForString(WelcomeMessage("binary"));
    int minimum = PromptForNumber(
        "Write a range of numbers to convert from or to\n" +
        "Minimum: ");
    int maximum = PromptForNumber("Maximum: ");
    int conversions = PromptForNumber("How many times you want to convert?: ");
    Console.WriteLine();
    int[] decimals = new int[conversions];
    int[] binaries = new int[conversions];
    for (int i = 0; i < conversions; i++)
    {
        int decimalValue = random.Next(minimum, maximum + 1);
        decimals[i] = decimalValue;
        binaries[i] = DecimalToBinary(decimalValue);
    }
    if (binaryMode == "1" || binaryMode == "decimal to binary")
    {
        int correctAnswers = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < conversions; i++)
        {
            int decimalValue = decimals[i];
            int binaryValue = binaries[i];
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber($"Convert {decimalValue} to binary: ");
            stopwatchOp.Stop();
            if (userAnswer == binaryValue) correctAnswers++;
            Console.WriteLine(ReportQuestionResult(
                userAnswer,
                binaryValue,
                stopwatchOp.Elapsed.Seconds,
                stopwatchOp.Elapsed.Minutes));
        }
        stopwatch.Stop();
        Console.WriteLine(ReportTotalScore(
            correctAnswers,
            conversions,
            stopwatch.Elapsed.Seconds,
            stopwatch.Elapsed.Minutes));
    }
    else if (binaryMode == "2" || binaryMode == "binary to decimal")
    {
        int correctAnswers = 0;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < conversions; i++)
        {
            int decimalValue = decimals[i];
            int binaryValue = binaries[i];
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber($"Convert {binaryValue} to decimal: ");
            stopwatchOp.Stop();
            if (userAnswer == decimalValue) correctAnswers++;
            Console.WriteLine(ReportQuestionResult(
                userAnswer,
                decimalValue,
                stopwatchOp.Elapsed.Seconds,
                stopwatchOp.Elapsed.Minutes));
        }
        stopwatch.Stop();
        Console.WriteLine(ReportTotalScore(
            correctAnswers,
            conversions,
            stopwatch.Elapsed.Seconds,
            stopwatch.Elapsed.Minutes));
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
