namespace CountCharFrequency
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();

            Dictionary<char, int> dc = new Dictionary<char, int>();

            foreach (var item in str1)
            {
                if (dc.ContainsKey(item))
                {
                    dc[item]++;
                }
                else
                {
                    dc.Add(item, 1);
                }
            }

            foreach (var item in dc)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }
    }
}