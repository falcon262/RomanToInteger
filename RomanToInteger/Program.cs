namespace RomanToInteger
{
    public class Program
    {
        static void Main(string[] args)
        {
            RomanToInt("XL");
        }

        public static int RomanToInt(string s)
        {
            Dictionary<char, int> romanMapping = new Dictionary<char, int>();

            romanMapping.Add('I', 1);
            romanMapping.Add('V', 5);
            romanMapping.Add('X', 10);
            romanMapping.Add('L', 50);
            romanMapping.Add('C', 100);
            romanMapping.Add('D', 500);
            romanMapping.Add('M', 1000);

            int[] validRomans = new int[s.Length];

            char[] chars = s.ToCharArray();

            char[] romanValues = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            int result = 0;

            if (chars.Length < 1 || chars.Length > 15)
            {
                Console.WriteLine("Invalid Input");
                return 0;
            }

            for (int j = 0; j < chars.Length; j++)
            {
                for (int i = 0; i < romanValues.Length; i++)
                {
                    if (chars[j] == romanValues[i])
                    {
                        validRomans[j] = 1;
                    }
                }
            }

            foreach (var item in validRomans)
            {
                if (item == 0)
                {
                    Console.WriteLine("Invalid Input");
                    return 0;
                }
            }

            Console.WriteLine($"Input: s = {s}");

            for (int i = 0; i < chars.Length; i++)
            {
                if (i < chars.Length - 1)
                {
                    if (chars[i] == 'I' && chars[i + 1] == 'V')
                    {
                        int four = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + four;
                        i++;
                    }
                    else if (chars[i] == 'I' && chars[i + 1] == 'X')
                    {
                        int nine = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + nine;
                        i++;
                    }
                    else if (chars[i] == 'X' && chars[i + 1] == 'L')
                    {
                        int forty = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + forty;
                        i++;
                    }
                    else if (chars[i] == 'X' && chars[i + 1] == 'C')
                    {
                        int ninety = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + ninety;
                        i++;
                    }
                    else if (chars[i] == 'C' && chars[i + 1] == 'D')
                    {
                        int fourhundred = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + fourhundred;
                        i++;
                    }
                    else if (chars[i] == 'C' && chars[i + 1] == 'M')
                    {
                        int nineHundred = romanMapping[chars[i + 1]] - romanMapping[chars[i]];
                        result = result + nineHundred;
                        i++;
                    }
                    else
                    {
                        result = result + romanMapping[chars[i]];
                    }
                }
                else
                {
                    result = result + romanMapping[chars[i]];
                }
            }

            Console.WriteLine($"Output: {result}");

            return result;
        }


    }
}