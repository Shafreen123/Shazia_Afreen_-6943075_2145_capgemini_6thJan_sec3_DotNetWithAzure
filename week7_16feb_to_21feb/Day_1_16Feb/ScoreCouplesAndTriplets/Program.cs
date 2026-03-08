namespace ScoreCouplesAndTriplets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input1 = [1, 2, 3, 4];

            int score = 0;

            for (int i = 1; i < input1.Length; i++)
            {
                if ((input1[i - 1] + input1[i]) % 2 == 0)
                {
                    score += 5;
                }
            }



            for (int i = 1; i < input1.Length - 1; i++)
            {

                int prev = input1[i - 1];
                int curr = input1[i];
                int next = input1[i + 1];

                int sum = prev + curr + next;
                int prod = prev * curr * next;

                if (sum % 2 != 0 && prod % 2 == 0)
                {
                    score += 10;
                }

            }

            Console.WriteLine(score);
        }
    }
}