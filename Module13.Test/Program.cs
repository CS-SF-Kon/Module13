namespace Module13.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string txt = "Подсчитайте, сколько уникальных символов в этом предложении, используя HashSet<T>, учитывая знаки препинания, но не учитывая пробелы в начале и в конце предложения.";

            var chars = txt.ToCharArray();

            var hSet = new HashSet<char>();

            foreach (char c in chars)
            {
                hSet.Add(c);
            }
            List<string> a = new List<string>();
            var b = new List<string>();

            Console.WriteLine(hSet.Count);
            
        }
    }
}
