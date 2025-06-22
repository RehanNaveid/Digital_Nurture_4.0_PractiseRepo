public static class DocumentFactorySelector
{
    public static DocumentFactory GetFactory(string type)
    {
        switch (type.ToUpper())
        {
            case "WORD":
                return new WordDocumentFactory();
            case "PDF":
                return new PdfDocumentFactory();
            case "EXCEL":
                return new ExcelDocumentFactory();
            default:
                throw new ArgumentException("Invalid document type: " + type);
        }
    }
}
