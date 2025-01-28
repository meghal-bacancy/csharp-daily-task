//Write a program that tries to open and read from a file. Make sure to use the finally block to ensure that the file is always closed properly. 

using System.IO;

StreamReader reader = null;

try
{
    reader = new StreamReader("D:\\bacancy_training\\csharp-daily-task\\day2\\day2\\text_file.txt");
    Console.WriteLine(reader.ReadToEnd());
}
catch (FileNotFoundException)
{
    Console.WriteLine("The file was not found.");
}
catch (IOException ex)
{
    Console.WriteLine($"An I/O error occurred: {ex.Message}");
}
finally
{
    if (reader != null)
    {
        reader.Close();
    }
}