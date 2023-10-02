char letter = 'a';
char digit = '4';
char symbol = '!';
char newLine = '\n';

var isUppercase = char.IsUpper(letter);
var isLetter = char.IsLetter(digit);
var isWhitespace = char.IsWhiteSpace(newLine);
var aToUpper = char.ToUpper(letter);

char someChar = (char)100;
int asInt = (int)'t';


for (char c = 'A'; c < 'z'; ++c)
{
    Console.Write(c + ", ");
}

Console.ReadKey();