using System;
using System.Diagnostics;
using System.Linq;

namespace NumberLetterCounts
{
    class Program
    {
        static void Main(String[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            Int32 charCount = 0;
            for (Int32 i = 1; i <= 1000; i++)
            {
                charCount += GetNumStringLen(i);
            }
            timer.Stop();
            Console.WriteLine($"Sum: {charCount}");
            Console.WriteLine($"Solved in {timer.ElapsedMilliseconds} ms");
        }
        static Int32 GetNumStringLen(Int32 num)
        {
            String result;
            String number = num.ToString();
            switch (number.Length)
            {
                case 1:
                    result = Enum.Parse<Ones>(number).ToString();
                    break;
                case 2:
                    result = GetTensText(number);
                    break;
                case 3:
                    Char[] digits = number.ToCharArray();
                    String hundredsText = $"{Enum.Parse<Ones>($"{digits[0]}").ToString()}Hundred";
                    if (digits[1] != '0') //Have Tenths place value
                    {
                        String tensText = GetTensText(number.Substring(1), number.Skip(1).ToArray());
                        result = $"{hundredsText}and{tensText}";
                    }
                    else if (digits[1] == '0' && digits[2] != '0') //Have Ones place value no Tenths place value
                    {
                        String onesText = Enum.Parse<Ones>($"{digits[2]}").ToString();
                        result = $"{hundredsText}and{onesText}";
                    }
                    else //Only have Hundreths place value no Tenths or Ones place value
                    {
                        result = hundredsText;
                    }
                    break;
                default:
                    result = "OneThousand";
                    break;
            }
            return result.Length;
        }
        static String GetTensText(String num, Char[] digits = null)
        {
            String result;
            String onesText;
            String tensText;
            if (num.StartsWith("1"))
            {
                result = Enum.Parse<Teens>(num).ToString();
            }
            else
            {
                digits ??= num.ToCharArray();
                if (num.EndsWith("0"))
                {
                    tensText = Enum.Parse<Tens>($"{digits[0]}0").ToString();
                    result = tensText;
                }
                else
                {
                    tensText = Enum.Parse<Tens>($"{digits[0]}0").ToString();
                    onesText = Enum.Parse<Ones>($"{digits[1]}").ToString();
                    result = $"{tensText}{onesText}";
                }
            }
            return result;
        }
        enum Ones
        {
            One = 1, Two = 2, Three = 3,
            Four = 4, Five = 5, Six = 6,
            Seven = 7, Eight = 8, Nine = 9
        }
        enum Teens
        {
            Ten = 10, Eleven = 11, Twelve = 12,
            Thirteen = 13, Fourteen = 14, Fifteen = 15,
            Sixteen = 16, Seventeen = 17, Eighteen = 18,
            Nineteen = 19
        }
        enum Tens
        {
            Twenty = 20, Thirty = 30, Forty = 40,
            Fifty = 50, Sixty = 60, Seventy = 70,
            Eighty = 80, Ninety = 90
        }
    }
}