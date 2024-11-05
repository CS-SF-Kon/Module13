using System.Diagnostics;

namespace Task1_List_and_LinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = string.Empty;

            try
            {
                originalText = File.ReadAllText(args[0]); // указать путь в качестве первого параметра
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong path: {ex.ToString()}");
                Console.WriteLine("Finishing program");
                return;
            }

            char[] delimeters = new char[] { ' ', '\r', '\n' };

            var words = originalText.Split(delimeters, StringSplitOptions.RemoveEmptyEntries); // текст делится на слова по пробелам и символам новой строки

            var result = new List<double>();

            switch (args[1]) // вторым параметром определится проверяемая коллекция
            {
                case "L": // "L" для проверки "List"
                    for (int i = 0; i < 10; i++) // код будет запущен 10 раз для достоверности
                    {
                        var watch = new Stopwatch();
                        var listedWords = new List<string>();

                        watch.Start();
                        listedWords.AddRange(words); // добавление слов в простой список
                        watch.Stop();

                        Console.WriteLine($"List - {listedWords.Count} - {watch.Elapsed.TotalMilliseconds} ms");
                        result.Add(watch.Elapsed.TotalMilliseconds);
                    }

                    Console.WriteLine($"Average result for List - {result.Average()} ms"); // итоговый результат, усредняйщий результат 10 попыток
                    break;

                case "LL": // "LL" для проверки "LinkedList"
                    for (int i = 0; i < 10; i++)
                    {
                        var watch = new Stopwatch();
                        var linkListedWords = new LinkedList<string>();

                        watch.Start();
                        foreach (var word in words)
                        {
                            linkListedWords.AddLast(word); // добавление слов в связанный список
                        }
                        watch.Stop();

                        Console.WriteLine($"Linked list - {linkListedWords.Count} - {watch.Elapsed.TotalMilliseconds} ms");
                        result.Add(watch.Elapsed.TotalMilliseconds);
                    }

                    Console.WriteLine($"Average result for LinkedList - {result.Average()} ms");
                    break;
                
                default:
                    Console.WriteLine("Wrong parameter");
                    break;
            }
        }
    }
}
