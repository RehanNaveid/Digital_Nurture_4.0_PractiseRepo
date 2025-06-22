using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter document type (WORD, PDF, EXCEL): ");
        string? type = Console.ReadLine()?.Trim();

        try
        {
            DocumentFactory factory = DocumentFactorySelector.GetFactory(type ?? "");
            IDocument doc = factory.CreateDocument();
            doc.Open();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
