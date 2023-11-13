namespace CollectionsInCsharp
{
    internal class Program
    {
        static CollectionExamples collectionExamples = new CollectionExamples();
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            collectionExamples.GetByURL();

            Console.ReadKey();
        }
    }
}