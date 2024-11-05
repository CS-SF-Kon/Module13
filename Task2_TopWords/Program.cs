namespace Task2_TopWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string originalText = string.Empty;
            
            try
            {
                originalText = File.ReadAllText(args[0]); // указать путь в качестве параметра
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Wrong path: {ex.ToString()}");
                Console.WriteLine("Finishing program");
                return;
            }

            char[] delimeters = { ' ', '\n', '\r' };

            var noPunct = new string(originalText.Where(c => !char.IsPunctuation(c)).ToArray()); // удаление пунктуации
            var words = noPunct.Split(delimeters, StringSplitOptions.RemoveEmptyEntries); // разделение текста по пробелам

            var uniqueWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!uniqueWords.ContainsKey(word))
                {
                    uniqueWords[word] = 1; // слово добавляется в словарь, если его ещё не было
                }
                else
                {
                    uniqueWords[word]++; // счётчик слова увеличивается, если слово уже есть в словаре
                }
            }

            var topWords = uniqueWords.OrderByDescending(x => x.Value).Take(10); // сортировка и фильтрация топ 10 часто встречающихся слов

            Console.WriteLine($"Total unique words: {uniqueWords.Count}");

            Console.WriteLine("Top words:");
            foreach (var word in topWords)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}
