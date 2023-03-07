// TODO - [ ] determine value of binary with 1 in each place
// TODO - [ ] determine how many 1s would be enough to represent n number

// TODO - [ ] do octal conversions/operations
// TODO - [ ] do hexadecimal conversions/operations
// TODO - [ ] do truth tables & propositional logic

// TODO - [ ] integrate pre-calculus topics
// TODO - [ ] integrate calculus tops
// TODO - [ ] integrate discrete maths topics

// TODO - [ ] select custom ranges (either quantity or digits)
// TODO - [ ] improve precision in time tracking
// TODO - [ ] set some defaults
// TODO - [ ] format operations
// TODO - [ ] do unit tests
// TODO - [ ] handle exceptions
// TODO - [ ] format and explain answers

using System.Diagnostics;
using System.Text;
System.Random random = new System.Random();

static int DecimalToBinary(int decimalValue)
{
    if (decimalValue == 0) return 0;
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
    int seconds,
    int minutes)
{
    int totalSeconds = minutes * 60 + seconds;
    return ($"Goodbye! your score was {correctAnswers}/{totalQuestions}\n") +
        ($"Total time: {totalSeconds} seconds ({minutes} minutes)");
}

static string ReportQuestionResult(
    int userAnswer,
    int correctAnswer,
    int seconds,
    int minutes)
{
    string message = "";
    bool answeredRight = userAnswer == correctAnswer;
    int totalSeconds = minutes * 60 + seconds;
    message += answeredRight ? "That's correct!" : $"Nope... it was {correctAnswer}";
    message += $"\nYou answered in {totalSeconds} seconds ({minutes} minutes).\n";
    return message;
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
                "3) binary addition\n4) binary subtraction\n" +
                "5) binary multiplication\n6) binary division" +
                "\nChoose: ";
        default:
            return "nope...";
    }
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

static int BinaryToDecimal(int binaryValue)
{
    string binaryText = Convert.ToString(binaryValue);
    char[] reversedBinary = binaryText.Reverse().ToArray();
    int result = 0;
    for (int i = 0; i < reversedBinary.Length; i++)
    {
        int digit = Convert.ToInt32(Convert.ToString(reversedBinary[i]));
        if (digit == 1)
        {
            result += Convert.ToInt32(Math.Pow(2.0, Convert.ToDouble(i)));
        }
    }
    return result;
}

static int[] GetNBinariesToSubtract(int n, int maxDigits)
{
    Random rnd = new Random();
    int[] binaries = new int[n];
    binaries[0] = GetRandomBinaryWithNDigits(maxDigits);
    int difference = BinaryToDecimal(binaries[0]);
    for (int i = 1; i < n; i++)
    {
        int nextNumber = rnd.Next(difference);
        difference -= nextNumber;
        int nextBinary = DecimalToBinary(nextNumber);
        binaries[i] = nextBinary;
    }
    return binaries;
}

static int SolveBinaryOperation(string operation, int[] binaryOperands)
{
    int[] decimalOperands = new int[binaryOperands.Length];
    for (int i = 0; i < decimalOperands.Length; i++)
    {
        decimalOperands[i] = BinaryToDecimal(binaryOperands[i]);
    }
    int decimalResult = SolveOperation(operation, decimalOperands);
    int binaryResult = DecimalToBinary(decimalResult);
    return binaryResult;
}

static int GetRandomBinaryWithNDigits(int digits)
{
    Random rnd = new Random();
    int[] powers = new int[digits];
    for (int i = 0; i < powers.Length; i++)
    {
        powers[i] = Convert.ToInt32(Math.Pow(2, Convert.ToDouble(i)));
    }
    int minimumDecimal = powers[powers.Length - 1];
    int maximumDecimal = SolveOperation("addition", powers);
    int decimalValue = rnd.Next(minimumDecimal, maximumDecimal);
    int binaryValue = DecimalToBinary(decimalValue);
    return binaryValue;
}

static int GetRandomIntWithNDigits(int digits)
{
    Random random = new Random();
    int max = GetMaximumNumberWithNDigits(digits);
    int min = GetMinimumNumberWithNDigits(digits);
    return random.Next(min, max);

}

static int[] AskDigitsPerOperand(int operandsQuantity)
{
    int[] digitsPerOperand = new int[operandsQuantity];
    for (int i = 0; i < operandsQuantity; i++)
    {
        int operandNumber = i + 1;
        digitsPerOperand[i] = PromptForNumber(
            $"How many DIGITS should operand {operandNumber} have: ");
    }
    return digitsPerOperand;
}

static int[] GetOperandValuesWithNDigits(string numberSystem, int[] digitsPerOperand)
{
    int[] operandValues = new int[digitsPerOperand.Length];
    for (int i = 0; i < digitsPerOperand.Length; i++)
    {
        int digits = digitsPerOperand[i];
        switch (numberSystem)
        {
            case "decimal":
                operandValues[i] = GetRandomIntWithNDigits(digits);
                break;
            case "binary":
                operandValues[i] = GetRandomBinaryWithNDigits(digits);
                break;
        }
    }
    return operandValues;
}

var mode = PromptForString(WelcomeMessage("home"));

if (mode == "1" || mode == "arithmetic")
{
    int correctAnswers = 0;
    var operationType = PromptForString(WelcomeMessage("arithmetic"));
    operationType = IdentifyOperationType(operationType);
    int operands = PromptForNumber($"\nGreat! Let's do {operationType}\n" +
        "Select the amount of OPERANDS of each operation: ");
    int[] digitsPerOperand = AskDigitsPerOperand(operands);
    int operations = PromptForNumber("\nSelect the number of operations to perform: ");
    Console.WriteLine();
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    for (int i = 0; i < operations; i++)
    {
        int[] operandValues = GetOperandValuesWithNDigits("decimal", digitsPerOperand);
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

    if (binaryMode == "1" || binaryMode == "decimal to binary" ||
        binaryMode == "2" || binaryMode == "binary to decimal")
    {
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
    }
    else if (binaryMode == "3" || binaryMode == "binary addition" || binaryMode == "add")
    {
        int correctAnswers = 0;
        int operands = PromptForNumber($"\nGreat! Let's do binary addition\n" +
            "Select the amount of OPERANDS of each addition: ");
        int[] digitsPerOperand = AskDigitsPerOperand(operands);
        int operations = PromptForNumber("\nSelect the number of operations to perform: ");
        Console.WriteLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            int[] operandValues = GetOperandValuesWithNDigits("binary", digitsPerOperand);
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber(PromptOperation("addition", operandValues));
            int result = SolveBinaryOperation("addition", operandValues);
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
    else if (binaryMode == "4" || binaryMode == "binary subtraction" || binaryMode == "sub")
    {
        int correctAnswers = 0;
        int operands = PromptForNumber($"\nGreat! Let's do binary subtraction\n" +
            "Select the amount of OPERANDS of each subtraction: ");
        int maximumDigits = PromptForNumber(
            "\nWhat are the maximum DIGITS that operands would have: ");
        int operations = PromptForNumber("\nSelect the number of operations to perform: ");
        Console.WriteLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            int[] operandValues = GetNBinariesToSubtract(operands, maximumDigits);
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber(PromptOperation("subtraction", operandValues));
            int result = SolveBinaryOperation("subtraction", operandValues);
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
    else if (binaryMode == "5" || binaryMode == "binary multiplication" || binaryMode == "mlp")
    {
        int correctAnswers = 0;
        int operands = PromptForNumber($"\nGreat! Let's do binary multiplication\n" +
            "Select the amount of OPERANDS of each multiplication: ");
        int[] digitsPerOperand = AskDigitsPerOperand(operands);
        int operations = PromptForNumber("\nSelect the number of operations to perform: ");
        Console.WriteLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            int[] operandValues = GetOperandValuesWithNDigits("binary", digitsPerOperand);
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber(PromptOperation("multiplication", operandValues));
            int result = SolveBinaryOperation("multiplication", operandValues);
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
    else if (binaryMode == "6" || binaryMode == "division" || binaryMode == "div")
    {
        int correctAnswers = 0;
        int operands = PromptForNumber($"\nGreat! Let's do binary division\n" +
            "Select the amount of OPERANDS of each division: ");
        int[] digitsPerOperand = AskDigitsPerOperand(operands);
        int operations = PromptForNumber("\nSelect the number of operations to perform: ");
        Console.WriteLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for (int i = 0; i < operations; i++)
        {
            int[] operandValues = GetOperandValuesWithNDigits("binary", digitsPerOperand);
            Stopwatch stopwatchOp = new Stopwatch();
            stopwatchOp.Start();
            int userAnswer = PromptForNumber(PromptOperation("division", operandValues));
            int result = SolveBinaryOperation("division", operandValues);
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
    else
    {
        Console.WriteLine("Not a valid option provided, try again...");
    }
}
else
{
    Console.WriteLine("Not a valid option provided, try again");
}
