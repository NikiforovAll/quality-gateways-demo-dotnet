string filePath = "path/to/your/file.txt";

FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

StreamReader reader = new StreamReader(fileStream);
List<string> lines = new List<string>();

while (!reader.EndOfStream)
{
    string line = await reader.ReadLineAsync();
    lines.Add($"{new Guid()} - {line}[{CountCapitalLetters(line)}]");
}

foreach (string line in lines)
{
    Console.WriteLine(line);
}

// Counts the number of capital latters in a string, the typo in word 'latters' is intentional
int CountCapitalLetters(string input, string param1 = default, int param2 = 0, bool param3 = false, object param4 = null)
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
