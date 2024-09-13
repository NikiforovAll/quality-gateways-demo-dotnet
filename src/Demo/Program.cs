string filePath = "path/to/your/file.txt";

using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
using var reader = new StreamReader(fileStream);
var lines = new List<string>();

while (!reader.EndOfStream)
{
    var line = await reader.ReadLineAsync();
    lines.Add($"{Guid.NewGuid()} - {line}[{CountCapitalLetters(line)}]");
}

foreach (string line in lines)
{
    Console.WriteLine(line);
}

// Counts the number of capital letters in a string
static int CountCapitalLetters(string input)
{
    int count = 0;
    foreach (char c in input)
    {
        if (char.IsUpper(c))
        {
            count++;
        }
    }

    return count;
}
