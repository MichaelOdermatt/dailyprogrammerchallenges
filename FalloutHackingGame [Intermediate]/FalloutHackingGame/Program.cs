static void Main(string[] args)
{
    int numberOfGuesses = 4;
    int numberOfPasswords = 10;
    int passwordLength = 8;
    
    var random = new Random();
    var passwords = GetRandomPasswords(passwordLength, numberOfPasswords, random);
    var correctPassword = passwords[random.Next(passwords.Count)];
    
    PrintStrings(passwords);
    
    string input;
    do
    {
        Console.WriteLine("\nnumber of guesses left {0}", numberOfGuesses);
    
        input = CleanString(Console.ReadLine(), passwordLength);

        int matchingChars = NumberOfMatchingChars(input, correctPassword);
        Console.WriteLine("{0} / {1}", matchingChars, passwordLength);
    
        numberOfGuesses--;
        if (numberOfGuesses <= 0)
            break;
    
    } while (correctPassword != input);
    
    Evaluate(input, correctPassword);
}

static List<string> GetRandomPasswords(int length, int numOfPasswords, Random random)
{
    string[] lines = File.ReadAllLines("enable1.txt").Where(value => value.Length == length).ToArray();
    var passwords = new List<string>();

    for (int i = 0; i < numOfPasswords; i++)
        passwords.Add(lines[random.Next(lines.Length)].ToUpper());

    return passwords;
}

static int NumberOfMatchingChars(string value1, string value2)
{
    char[] chars1 = value1.ToCharArray();
    char[] chars2 = value2.ToCharArray();
    int matchingChars = 0;

    for (int i = 0; i < chars1.Length; i++)
        if (chars1[i] == chars2[i])
            matchingChars++;

    return matchingChars;
}

static void PrintStrings(List<string> strings)
{
    foreach (string s in strings)
        Console.WriteLine(s);
}

static void Evaluate(string guess, string correctPassword)
{
    if (guess.Equals(correctPassword))
        Console.WriteLine("ACCESS GRANTED");
    else
        Console.WriteLine("ACCESS DENIED");

    Environment.Exit(0);
}

static string CleanString(string? input, int maxLength)
{
    if (input == null)
        input = "";

    if (input.Length > maxLength)
        input = input.Substring(0, maxLength);

    return input.ToUpper();
}

Main(new String[] {});
