using System.Text.RegularExpressions;

static string Decode(string key, string alienText)
{
    Dictionary<string, string> alienLettersByLatinLetters = ParseKey(key);
    Dictionary<string, string>.KeyCollection alienLetters = alienLettersByLatinLetters.Keys;

    var output = "";
    var temp = "";

    foreach (char character in alienText)
    {
        if (IsSpecialCharacter(character))
            output += character;
        else
            temp += character;

        if (alienLetters.Contains(temp))
        {
            output += alienLettersByLatinLetters[temp];
            temp = "";
        }
    }

    return output; 
}

static Dictionary<string, string> ParseKey(string key)
{
    MatchCollection matchLetters = Regex.Matches(key, @"[A-Za-z]\s[gG]+");
    var AlienLettersByLatinLetters = new Dictionary<string, string>();

    foreach (Match letter in matchLetters)
    {
        string alienLetter = letter.Value.Split()[1];
        string latinLetter = letter.Value.Split()[0];

        AlienLettersByLatinLetters.Add(alienLetter, latinLetter);
    }

    return AlienLettersByLatinLetters; 
}

static bool IsSpecialCharacter(char value)
{
    return !Char.IsLetterOrDigit(value);
}

string alienKey = "H GgG d gGg e ggG l GGg o gGG r Ggg w ggg";
string alienText = "GgGggGGGgGGggGG, ggggGGGggGGggGg!";

Console.WriteLine(Decode(alienKey, alienText));

// https://www.reddit.com/r/dailyprogrammer/comments/3x3hqa/20151216_challenge_245_intermediate_ggggggg_gggg/