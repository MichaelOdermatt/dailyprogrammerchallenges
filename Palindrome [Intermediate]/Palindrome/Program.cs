static void Main(string[] args)
{
    string? input = Console.ReadLine();

    int number;
    bool isNumber = Int32.TryParse(input, out number);

    if (!isNumber)
        return;

    do
        number++;
    while (!IsPalindrome(number + ""));

    Console.WriteLine(number);
}

static bool IsPalindrome(string number)
{
    string? numberReversed = Reverse(number);

    if (number.Equals(numberReversed))
        return true;
    else
        return false;
}

static string Reverse(string value)
{
    char[] chars = value.ToCharArray();
    Array.Reverse(chars);
    return new string(chars);
}

Main(new string[]{});
// https://www.reddit.com/r/dailyprogrammer/comments/n3var6/20210503_challenge_388_intermediate_next/

// code golf
/*

int n;
if (!int.TryParse(Console.ReadLine(), out n)) return;
do n++;
while (!(n+""==((Func<string, string>)(n =>{
    var c = n.ToCharArray();
    Array.Reverse(c);
    return new string(c);
}))(n+"")));
Console.WriteLine(n);

*/
