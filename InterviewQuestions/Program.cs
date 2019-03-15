using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace InterviewQuestions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Print all valid phone numbers of length
            //PrintNumbersTo250();
            //substring addition write a program to add the substring
            //TestIsInSubString();
            ////Length is given as input Print all possible permutations of numbers between 0-9
            ////todo TestAllPossiblePemutationsForNumber0To9();
            ////Stepping number
            ////Given N and M find all stepping numbers in range N to M. The stepping number: A number is called as a stepping number if the adjacent digits have a difference of 1.e.g 123 is stepping number, but 358 is not a stepping number.
            //Debug.WriteLine(IsSteppingNumber(123));
            //Debug.WriteLine(IsSteppingNumber(358));
            //Palindrome: a word, phrase, number, or other sequence of symbols or elements, whose meaning may be
            //interpreted the same way in either forward or reverse
            FindPalindrome();
            ////GetAllPossibleDatesForAGivenMonth();
            //GetAllPossibleDatesForAGivenYear();

            //LookAndSayTest();

            //Seed of a number Consider a number 123, the product of the number with its digits(123 * 1 * 2 * 3 = 738) is 738.
            //Therefore, 123 is the seed root of 738
            SeedOfNumber(738);
            //FixedSeedRandoms(738);
            //FixedSeedRandoms(1716);
            //Fibonacci_Iterative(20);
        }


        public static void EvaluateLeftToRight()
        {
            //3*4 + 8-9 only +, -, * operators

        }
        public static void Fibonacci_Iterative(int len)
        {
            int a = 0, b = 1, c = 0;
            Console.Write("{0} {1}", a, b);
            for (int i = 2; i < len; i++)
            {
                c = a + b;
                Console.Write(" {0}", c);
                a = b;
                b = c;
            }
        }
        public static void PrintNumbersTo250()
        {
            for (int i = 0; i <= 250; i++)
            {
                if ((i % 3) == 0 && ((i % 5) == 0))
                    Debug.WriteLine("ThreeFive");
                else if ((i % 3) == 0)
                    Debug.WriteLine("Three");
                else if ((i % 5) == 0)
                    Debug.WriteLine("Five");
                else
                    Debug.WriteLine(i);
            }
        }


        

        //}

        public static void PrintNumbers()
        {
            for(int i = 0; i <= 250; i++)
            {
                if ((i % 3) == 0 && ((i % 5) == 0))
                    Debug.WriteLine("ThreeFive");
                else if ((i % 3) == 0)
                    Debug.WriteLine("Three");
                else if ((i % 5) == 0)
                    Debug.WriteLine("Five");
                else
                    Debug.WriteLine(i);
            }
        }

        public static void TestIsInSubString()
        {
            int[] arr = { 1, 5, 9, 11, 2, 4 };
            int sum = 27;
            Console.Write(CheckifInSubstring(arr, sum));
        }

        public static String CheckifInSubstring(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int total = 0;
                for (int j = i; j < arr.Length; j++)
                {
                    total = total + arr[j];
                    if (total == sum)
                    {
                        return i + "-" + j;
                    }
                    else if (total > sum)
                    {
                        break;
                    }
                }
            }
            return "Not found";
        }

        public static void TestAllPossiblePemutationsForNumber0To9()
        {
            FormPermut fp = new FormPermut();
            int n =9, i;
            //int[] arr1 = new int[] {0,1,2,3,4,5,6,7,8,9};
            int[] arr1 = new int[] { 0, 1, 2, 3, 4, 5};

            for (i = 0; i < n; i++)
            {
                Console.Write(" element - {0} : ", i);
                arr1[i] = Convert.ToInt32(Console.ReadLine());
            }
            fp.PrnPermut(arr1, 0, n - 1);
        }

        public static bool IsSteppingNumber(int value)
        {
            var digits = GetDigitsReverse(value).ToList();
            return digits
                .Zip(digits.Skip(1), Tuple.Create)
                .All(x => Math.Abs(x.Item1 - x.Item2) == 1);
        }

        public static IEnumerable<int> GetDigitsReverse(int value)
        {
            while (value > 0)
            {
                yield return value % 10;
                value /= 10;
            }
        }

        public static void GetAllPossibleDatesForAGivenMonth()
        {
            
        }

        public static void GetAllPossibleDatesForAGivenYear()
        {
            int year = 2018;
            int month = 1;
            List<DateTime> list = new List<DateTime>();
            DateTime date = new DateTime(year, month, 1);
            DateTime date2 = new DateTime(year, 12, 31);

            do
            {
                list.Add(date);
                date = date.AddDays(1);
            } while (date.Date <= date2.Date);

            foreach (var d in list)
            {
                Debug.WriteLine(d.ToShortDateString());
            }
        }

        public static void LookAndSayTest()
        {
            String num = "1";
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(num);
                num = LookAndSay(num);
            }
        }

        public static String LookAndSay(String number)
        {
            StringBuilder result = new StringBuilder();

            char repeat = number[0];
            number = number.Substring(1) + " ";
            int times = 1;

            foreach (char actual in number)
            {
                if (actual != repeat)
                {
                    result.Append(times + "" + repeat);
                    times = 1;
                    repeat = actual;
                }
                else
                {
                    times += 1;
                }
            }
            return result.ToString();
        }

        static void FixedSeedRandoms(int seed)
        {
            Console.WriteLine(
                "\nRandom numbers from a Random object with " +
                "seed = {0}:", seed);
            Random fixRand = new Random(seed);
            RunIntNDoubleRandoms(fixRand);
        }

        public static void SeedOfNumber(int number)
        {
            int seed = 0, seed2;

            while (seed <= number)
            {
                seed2 = seed;
                int val = seed;
                while (seed > 0)
                {
                    val = val * (seed % 10);
                    seed = seed / 10;

                }
                seed = seed2 + 1;
                if (val == number)
                {
                    Debug.WriteLine("seed is " + (seed - 1));
                }
            }
        }
        static void RunIntNDoubleRandoms(Random randObj)
        {
            // Generate the first six random integers.
            for (int j = 0; j < 6; j++)
                Console.Write(" {0,10} ", randObj.Next());
            Console.WriteLine();

            // Generate the first six random doubles.
            for (int j = 0; j < 6; j++)
                Console.Write(" {0:F8} ", randObj.NextDouble());
            Console.WriteLine();
        }

        public static void FindPalindrome()
        {
            string[] array =
            {
                "civic",
                "deified",
                "deleveled",
                "devoved",
                "dewed",
                "Hannah",
                "kayak",
                "level",
                "madam",
                "racecar",
                "radar",
                "redder",
                "refer",
                "repaper",
                "reviver",
                "rotator",
                "rotor",
                "sagas",
                "solos",
                "sexes",
                "stats",
                "tenet",
                "Dot",
                "Net",
                "Perls",
                "Is",
                "Not",
                "A",
                "Palindrome",
                ""
            };

            foreach (string value in array)
            {
                Debug.WriteLine("{0} = {1}", value, IsPalindrome(value));
            }
        }

        public static bool IsPalindrome(string value)
        {
            int min = 0;
            int max = value.Length - 1;
            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
    }
}
