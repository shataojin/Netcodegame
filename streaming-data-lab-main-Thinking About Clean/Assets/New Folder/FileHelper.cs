using System.Collections.Generic;
using System.IO;

public static class FileHelper
{
    public static void WriteToFile(string filePath, LinkedList<string> lines)
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            foreach (string line in lines)
                sw.WriteLine(line);
        }
    }

    public static LinkedList<string> ReadFromFile(string filePath)
    {
        LinkedList<string> lines = new LinkedList<string>();

        using (StreamReader sr = new StreamReader(filePath))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                lines.AddLast(line);
            }
        }

        return lines;
    }
}
