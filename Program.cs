namespace Assignment_3
{
    internal class Program
    {
      static readonly Dictionary<int, string> NumWords = new Dictionary<int, string> 
      {
           {0, "zero"}, {1, "one"}, {2, "two"}, {3, "three"}, {4, "four"},
        {5, "five"}, {6, "six"}, {7, "seven"}, {8, "eight"}, {9, "nine"},
        {10, "ten"}, {11, "eleven"}, {12, "twelve"}, {13, "thirteen"},
        {14, "fourteen"}, {15, "fifteen"}, {16, "sixteen"},
        {17, "seventeen"}, {18, "eighteen"}, {19, "nineteen"},
        {20, "twenty"}, {30, "thirty"}, {40, "forty"}, {50, "fifty"},
        {60, "sixty"}, {70, "seventy"}, {80, "eighty"}, {90, "ninety"},
        {100, "hundred"}, {1000, "thousand"}
      };
        
     static string ConvertToWords(int number)
        {
            if (number == 0)
                return NumWords[0];

            List<string> words = new List<string>();

            if (number >= 1000)
            {
                int thousands = number / 1000;
                words.Add(NumWords[thousands]);
                words.Add(NumWords[1000]);
                number %= 1000;
            }

            if (number >= 100)
            {
                int hundreds = number / 100;
                words.Add(NumWords[hundreds]);
                words.Add(NumWords[100]);
                number %= 100;
                if (number > 0)
                    words.Add("and");
            }

            if (number > 0)
            {
                if (number <= 19)
                {
                    words.Add(NumWords[number]);
                }
                else
                {
                    int tens = (number / 10) * 10;
                    words.Add(NumWords[tens]);

                    int ones = number % 10;
                    if (ones > 0)
                        words.Add(NumWords[ones]);
                }
            }

            return string.Join(" ", words);
     }
    

        static void Main(string[] args)
        {
            Console.WriteLine("Enter up to 4 numbers:");

            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;

                if (int.TryParse(input, out int number) && number >= 0 && number <= 9999)
                {
                    string words = ConvertToWords(number);
                    Console.WriteLine($"{number} in words is {words}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 9999.");
                }
            }
        }
    }
    
}
