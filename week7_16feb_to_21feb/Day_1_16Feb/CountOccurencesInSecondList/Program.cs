namespace CountOccurencesInSecondList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = [5, 3, 4, 6];
            int[] input2 = [5, 4, 2, 1, 4, 3, 3, 2, 5, 3];

            Dictionary<int, int> dict = new Dictionary<int, int>();

            foreach (var item in input2)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item] += item;
                }
                else
                {
                    dict.Add(item, item);
                }
            }

            foreach (var item in input1)
            {
                if (dict.ContainsKey(item))
                {
                    Console.WriteLine(item + " - " + dict[item]);
                }
                else
                {
                    Console.WriteLine(item + " - " + 0);
                }
            }


            
        }
    }
}