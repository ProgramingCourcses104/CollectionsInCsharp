namespace CollectionsInCsharp
{
    internal class Program
    {
        static CollectionExamples collectionExamples = new CollectionExamples();
        static ExamplesUseJson examplesUseJson = new ExamplesUseJson();
        static void Main(string[] args)
         {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            examplesUseJson.ExampleJsonReadWrite();

            collectionExamples.WriteCollectionJson();

            Console.ReadKey();
        }
    }
}