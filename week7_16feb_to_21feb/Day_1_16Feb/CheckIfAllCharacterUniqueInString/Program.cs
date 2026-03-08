namespace CheckIfAllCharacterUniqueInString
{
    internal class Program
    {
        public static bool UniqueCharacter(string str)
        {
            HashSet<char> hs = new HashSet<char>();

            foreach (var item in str)
            {
                if (!hs.Add(item))
                {
                    return false;
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            string str1 = Console.ReadLine();

            Console.WriteLine(UniqueCharacter(str1) ? "Yes All Characters are Unique in the String" : "No All CHaracters are Not Unique in the String");
        }
    }
}