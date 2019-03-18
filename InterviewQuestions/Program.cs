using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Globalization;

namespace InterviewQuestions
{

    class Program
    {
        static void Main(string[] args)
        {
            //string digit = args[0];
            /*
            string keystrokes = Console.ReadKey().Key.ToString();

            if (string.IsNullOrEmpty(keystrokes) || !keystrokes.All(Char.IsDigit))
            {
                Debug.WriteLine("Please enter a digit.... ");
            }
            Debug.WriteLine(keystrokes);

            //Print all valid phone numbers of length, print alternative 
            //message that is divisble by 3 and 5
            
            PrintNumbersTo250();
            //substring addition write a program to add the substring
            //TestIsInSubString();
            ////Length is given as input Print all possible permutations of numbers between 0-9
            ////todo TestAllPossiblePemutationsForNumber0To9();

            //Stepping number
            //Given N and M find all stepping numbers in range N to M. The stepping number: A number is called as a 
            //stepping number if the adjacent digits have a difference of 1.e.g 123 is stepping number, but 358 is not a stepping number.
            //Yes 
            Debug.WriteLine(IsSteppingNumber(123));
            //No
            Debug.WriteLine(IsSteppingNumber(358));
            //Yes
            Debug.WriteLine(IsSteppingNumber(545));

            //Debug.WriteLine(IsSteppingNumber(123));
            //Debug.WriteLine(IsSteppingNumber(358));

            //Palindrome: a word, phrase, number, or other sequence of symbols or elements, whose meaning may be
            //interpreted the same way in either forward or reverse
            FindPalindrome();
            ////GetAllPossibleDatesForAGivenMonth();
            
            //List all dates for a given year
            GetAllPossibleDatesForAGivenYear();

            //Print numbers in the following manor 
            //1, 11, 21, 1211, 111221, 312211
            LookAndSayTest();

            //Seed of a number Consider a number 123, the product of the number with its digits(123 * 1 * 2 * 3 = 738) is 738.
            
            //Therefore, 123 is the seed root of 738
            SeedOfNumber(738);

            //All possible Test Permutations, This is all possible combinations 
            //TestPermutation("0123456789");

            //Test Fibonacci series
            Fibonacci_Iterative(20);

            TestPermutation("ABC");
            
            //Test Substring Addition, the array represents numbers that 
            //allows you to add up to 16
            int[] theArray = { 1, 3, 5, 7, 9 };
            Debug.WriteLine(TestSubstringAddition(16, theArray));
            
            //Test correct phone formatting with the following constraints
            //If a number contains a 4 it should start with 4
            //No two consectives digits can be the same 
            //Three digits will be completely disallowed 7 6 3
            int[] disallowed = { 2, 7, 9 };
            //QA=Fail
            //Valid number
            Debug.WriteLine(TestValidPhoneNumbers("4164151534", disallowed));
            //Not valid number
            Debug.WriteLine(TestValidPhoneNumbers("9124721234", disallowed));
            //0 - NULL
            //1 - v, t, f, r, q
            //2 - f, t, k
            GenerateAllPossibleCharSequences(int.Parse(keystrokes));
            
            //Write an efficient program to find the sum of contiguous subarray within
            //a one-dimensional array of numbers which has the largest sum.
            Debug.Write(LargestSumContigousSubArray(new int[] {-1, 3, 5, 7 -5, -10}));
            
            //Given the expression like 3*4 + 8-9
            //evaluate it strictly from left to right
            OrderFromLeftToRight();
            
            //Given a M * N, if the element in the matrix
            //then the other eight elements around 
            //it, then named that element be mountain 
            //point 
            //todo
            SelectTheMountainPoint();
            
            Debug.WriteLine(ClimbTime(60.5));
            Debug.WriteLine(ComputeTime(60.5));
            
            BinaryTree("EPIC");
            
            int N = 3;
            PrintDesirable("",0, N);
            
            //In 1-9 keypad one is not working
            //You know the correct password 18684
            //you know that the entered key 164
            //8 isn't working, 1 key... 
            //The sequence is correct
            Debug.WriteLine($"Is Password Validated: {ValidatePassword("164", "18684", '8')}");
            

            //A program removes all non-numeric characters
            Debug.WriteLine(MassageAlphaNumerics("123edfrs&^%dd"));
            
            Debug.WriteLine(PhoneNumbersMassage("12234567890", new char[] { '1','2','3' }));
            
            TwoDimensionalSpaceAllPermutations();
            
            WalkingRobot(2);
            
            ConstructTriangleFormArray();
            
            GetElementsClockWise2DArray();
            GetElementsCountClockWise2DArray();
            
            PatientsNProblems();
            
            //pass
            Debug.WriteLine(VerifyIfPasswordIsValid("143183Qs"));
            //fail
            Debug.WriteLine(VerifyIfPasswordIsValid("123123Qs"));
            Debug.WriteLine(PrintContinuousAlphabet());
            PrintAllPossibleCombKeyPad("23");
            TotalCostOfAirlineTicket(4);
            ReverseWordsInString();
            ChangeToGiven(288);
            BasketHitRates();
            SeriesOfIntsOddEven();
            Debug.WriteLine(SortString("Abcdefa"));
            
            //Colorful
            Debug.WriteLine(ColorfulNumbers(new[] { 2, 6, 3, }));
            //Not Colorful
            Debug.WriteLine(ColorfulNumbers(new[] { 2, 3, 6, }));
            */
            PrintWeekForDate(DateTime.Now);

        }

        public static void PrintWeekForDate(DateTime date)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            var first = GetFirstDayOfWeek(date, defaultCultureInfo);
            var last = first.AddDays(7);
            Debug.WriteLine(string.Format("First day {0}, Last day {1}",first, last));
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        public static bool ColorfulNumbers(int[] numbers)
        {
            //Determine if a number is colorful or not;
            //263, definition totals are all different 
            //2,6,3 2x6, 6x3, 2x3x6
            //total two numbers 
            List<int> sums = new List<int>();
            //Add two
            for (int i= 0; i < numbers.Length; i++)
            {
                if (i < numbers.Length - 1)
                {
                    var s = numbers[i];
                    var e = numbers[i + 1];
                    sums.Add(s * e);
                }
            }
            //Adds them all up
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i < numbers.Length - 1)
                {
                    var s = numbers[i];
                    var e = numbers[i + 1];
                    var t = numbers[i + 2];
                    sums.Add(s * e * t);
                    break;
                }
            }
            //Two with the same number indicates not a colorful number
            var duplicates = sums
            .GroupBy(i => i)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key);
                foreach (var d in duplicates)
                    Debug.WriteLine(d); // 4,3

            if (duplicates.Any())
                return true;
            return false;
        }

        public static string SortString(string input)
        {
            char[] chars = input.ToArray();
            Array.Sort(chars);
            return new string(chars);
        }

        public static void SeriesOfIntsOddEven()
        {
            var odd = 0;
            var even = 0;
            Console.WriteLine("Press 0 then enter to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    // Do something
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.D0);
            var keys = Console.ReadLine();
            int numeric = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                if (int.TryParse(keys[i].ToString(), out numeric))
                {
                    if (numeric % 2 == 0)
                        even++;
                    else
                        odd++;
                }
            }
            Debug.WriteLine(string.Format("Total even: {0}", even));
            Debug.WriteLine(string.Format("Total odd: {0}", odd));
        }

        public static void FrequencyOfMedicine()
        {

        }

        public static void BasketHitRates()
        {
            //HitRate = hits/numberOfChances

        }

        public static void ChangeToGiven(int amount)
        {
            int remaining = 0;
            //give out 2.88 based on dominations of $1, 1c, 5c, 10c, 25c
            var tdollar = amount / 100;
            remaining = amount - (tdollar * 100);

            var tquarters = remaining / 25;
            remaining = remaining - (tquarters * 25);

            var tdim = remaining / 10;
            remaining = remaining - (tdim * 10);

            var tnickel = remaining / 5;
            remaining = remaining - (tnickel *5);

            var tcent = remaining / 1;
            remaining = remaining - tcent;

            //zero
            Debug.WriteLine("total dollars:"+tdollar);
            Debug.WriteLine("total tquarters:" + tquarters);
            Debug.WriteLine("total tdim:" + tdim);
            Debug.WriteLine("total tnickel:" + tnickel);
            Debug.WriteLine("total tcent:" + tcent);
        }

        public static void ReverseWordsInString()
        {
            var str = "This is great";
            string[] words = str.Split(new char[0]);
            Array myArray = Array.CreateInstance(typeof(String), 3);

            for (int i = 0; i < words.Length; i++)
            {
                myArray.SetValue(words[i], i);
            }

            PrintIndexAndValues(myArray);
            Array.Reverse(myArray);
            PrintIndexAndValues(myArray);
        }

        public static void PrintIndexAndValues(Array myArray)
        {
            for (int i = myArray.GetLowerBound(0); i <= myArray.GetUpperBound(0); i++)
                Console.WriteLine("\t[{0}]:\t{1}", i, myArray.GetValue(i));
        }

        public static void TotalCostOfAirlineTicket(int totalPersons)
        {
            double baseFare = 40.0;
            double tax = 0.04;
            double segments = 10.0;//max is two segments
            double security = 10.0; //max is three segments
            double securityTotal;
            double segmentsTotals;

            if (totalPersons > 2)
                segmentsTotals = 2 * segments;
            else
                segmentsTotals = totalPersons * segments;

            if (totalPersons > 3)
                securityTotal = 3 * security;
            else
                securityTotal = totalPersons * security;

            double total = baseFare + (baseFare*tax)+ 
                           (segmentsTotals) + (securityTotal);

            Debug.WriteLine(total);
        }

        public static string ColorfulNumber()
        {

            return string.Empty;
        }

        public static string PrintSequencesOfInput()
        {
            String str = "4678912356012356";
            StringBuilder sb = new StringBuilder();
            bool flag = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] + 1 == str[i])
                {
                    sb.Append(str[i - 1]);
                    flag = true;
                }
                else
                {
                    if (flag)
                    {
                        sb.Append(str[i - 1]);
                        sb.Append(';');
                    }
                    flag = false;
                }
            }
            if(str[str.Length-2]+1 == str[str.Length-1])
            {
                sb.Append(str[str.Length - 1]);
                sb.Append(';');
            }

            return sb.ToString();
        }

        public static void PrintAllPossibleCombKeyPad(string key)
        {
            List<KeyPad> keypad = new List<KeyPad>();
            keypad.Add(new KeyPad(){ key = '2', Alphas = "ABC"});
            keypad.Add(new KeyPad() { key = '3', Alphas = "DEF" });
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < key.Length; i++)
            {
                //figure out what letters are applicable
                var k = key[i].ToString();
                var al = keypad.Where(x => x.key.ToString() == k).First();
                if (al != null)
                {
                    sb.Append(al.Alphas);
                }
            }

            var kk = sb.ToString();
            //Figure out all possible combinations...
            permute(kk, 0, kk.Length -1);
        }

        public static string PrintContinuousAlphabet()
        {
             return "AbcDefljdflsjflmnopflsjflasjftuvWxYz";
        }
        
        //Must be 5-12 characters long
        //must contain at least one number and one lower case
        //
        public static bool VerifyIfPasswordIsValid(string pass)
        {
            List<string> sequences = new List<string>();
            //populate with all sequences
            for (int i = 0; i < pass.Length; i++)
            {
                if (i < pass.Length-1)
                {
                    var first = pass[i].ToString();
                    var next = pass[i + 1].ToString();
                    sequences.Add(first+next);
                }
            }
            //check for 5-12 characters long
            if (!PasswordLength(pass))
                return false;
            //At least one number & one lower case 
            if (!OneUpperOneLower(pass))
                return false;
            //Check to see if the sequence repeats itself
            for (int i = 0; i < pass.Length; i++)
            {
                if (i < pass.Length - 1)
                {
                    var first = pass[i].ToString();
                    var next = pass[i + 1].ToString();
                    if (sequences.Contains(first + next))
                    {
                        return false;
                    }
                }
            }
            //everything is good return true
            return true;
        }

        public static bool PasswordLength(string pass)
        {
            if (pass.Length >= 5 && pass.Length <= 12)
                return true;
            else
                return false;
        }

        public static bool OneUpperOneLower(string pass)
        {
            //(?=.*[a - z])         #At least one lower case
            //(?=.*[A - Z])         #At least one upper case
            var regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])");
            if (regex.IsMatch(pass))
                return true;
            return false;
        }

        public static void PatientsNProblems()
        {
            //Develop data structure 
            //problems are bool
            //
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient()
                {
                    Id = 1, 
                    Name = "John Doe",
                    Problem = new List<Problem>()
                    {
                       new Problem()
                       {
                           Name = "Diabetes",
                           HasProblem = true,
                       },
                       new Problem()
                       {
                           Name = "Liver Disease",
                           HasProblem = true
                       },
                        new Problem()
                        {
                            Name = "Kidney Disease",
                            HasProblem = true
                        },
                    }
                });

            patients.Add(new Patient()
            {
                Id = 1,
                Name = "Henry Doe",
                Problem = new List<Problem>()
                {
                    new Problem()
                    {
                        Name = "Diabetes",
                        HasProblem = true,
                    },
                    new Problem()
                    {
                        Name = "Liver Disease",
                        HasProblem = false
                    },
                    new Problem()
                    {
                        Name = "Kidney Disease",
                        HasProblem = false
                    },
                }
            });

            var totalWithAtLeast3 = GetPatientsWithAtLeastThree(patients);
            //should be one
            Debug.WriteLine(totalWithAtLeast3);
        }

        public static List<Patient> GetPatientsWithAtLeastThree(List<Patient> patients)
        {
            List<Patient> pWithThree = new List<Patient>();
            var count = 0;
            foreach (var p in patients)
            {
                var total = p.Problem.Where(x => x.HasProblem == true).Count();
                if(total >= 3)
                    pWithThree.Add(p);
                

            }

            return pWithThree;
        }

        public static void CowsAndBulls()
        {
            //Player A chooses a word
            //Player B guesses the word 

        }

        public static void GetElementsCountClockWise2DArray()
        {
            string[,] codes = new string[,]
            {
                {"AA", "BB"},
                {"CC", "DD"}
            };
            for (int i = 0; i <= codes.GetUpperBound(0); i++)
            {
                string s1 = codes[0, i];
                string s2 = codes[1, i];
                Debug.WriteLine("{0}, {1}", s1, s2);
            }
        }

        public static void GetElementsClockWise2DArray()
        {
            string[,] codes = new string[,]
            {
                {"AA", "BB"},
                {"CC", "DD"}
            };
            for (int i = 0; i <= codes.GetUpperBound(0); i++)
            {
                string s1 = codes[i, 0];
                string s2 = codes[i, 1];
                Debug.WriteLine("{0}, {1}", s1, s2);
            }
        }

        public static void ConstructTriangleFormArray()
        {
            var path = new int[] { 4, 7, 3, 6, 7 };

            //for (int i = 0; i < path.Length; i++)
            //{
                //11
                var eleven = path[0] + path[1];
                var ten = path[1] + path[2];
                var nine = path[2] + path[3];
                var thirteen = path[3] + path[4];
            //}
            

            var t21 = eleven + ten;
            var t19 = ten + nine;
            var t22 = nine + thirteen;


            var t40 = t21 + t19;
            var t41 = t19 + t22;

            var t81 = t40 + t41;

            var l1 = string.Join(",", path);
            var l2 = eleven.ToString() + ',' + ten.ToString() + ',' + nine.ToString() + ',' + thirteen.ToString();
            var l3 = t21.ToString() + ',' + t19.ToString() + ',' + t22.ToString();
            var l4 = t40.ToString() + ',' + t41.ToString();
            var l5 = t81.ToString();

            Debug.WriteLine(l5);
            Debug.WriteLine(l4);
            Debug.WriteLine(l3);
            Debug.WriteLine(l2);
            Debug.WriteLine(l1);
        }

        public static void WalkingRobot(int x)
        {
            var currentStep = 0;
            //x steps forward
            var path = new int[] {1,2,3,4,5,6,7,8};
            if (path.Length > x)
            {
                currentStep = x;
                currentStep = x + 1;
                currentStep = + x;
            }

        }

        public static void TwoDimensionalSpaceAllPermutations()
        {
            int[,] array2D = new int[,] { 
                { 1, 2, 3 }, 
                { 4, 5, 6 }, 
                { 7, 8, 9 }, 
                { 10, 11, 12 }
            };

            var rowCount = array2D.GetLength(0);
            var colCount = array2D.GetLength(1);

            for (int row = 0; row < rowCount; row++)
            {
                for (int col = 0; col < colCount; col++)
                    Debug.Write($"{array2D[row, col]}\t");
               
            }
        }

        public static char ConvertKeyPad(string numberToConvert, int num)
        {
            List<Button> buttons = new List<Button>();
            
            buttons.Add(new Button()
            {
                ButtonName = '1',
                AlphaNames = new char[] { 'A','B','C'}
            });

            foreach (var button in buttons)
            {
                if(button.ButtonName == '1')
                    Debug.WriteLine(button.AlphaNames.ToString());
                break;
                //..and so on...
            }


            char value = '\0';
            switch (num)
            {
                case 1:
                    value =  'A';
                break;
            }

            return value;
        }

        public static string PhoneNumbersMassage(string phone, char[] disallowed)
        {
            //
            char start;
            char end;            
            //compare each to validate if two adjacent
            //characters are the same 

            for (int i = 0; i < phone.Length; i++)
            {
                if (phone[i] > 0)
                {
                    int first = i + 1;
                    start = phone[first];
                    end = phone[i];
                    Debug.WriteLine($"start:{start},end:{end}");
                    if (start != end)
                    {
                        //create all variations

                    }
                }
            }
            return string.Empty;
        }


        public static string MassageAlphaNumerics(string alphanumerics)
        {
            //A program removes all non-numeric characters
            char[] arr = alphanumerics.ToCharArray();

            arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))));

            return new string(arr);
        }



        //todo
        public static void TwoDimensionalGame()
        {

        }

        public static bool ValidatePassword(string passUsed, string actualPass, char keyNotWorking)
        {
            StringBuilder sb = new StringBuilder();
            //remove key not working
            foreach (var t in actualPass)
            {
                if (t != keyNotWorking)
                {
                    sb.Append(t);
                }
            }
            if(passUsed.Equals(sb.ToString()))
            {
                return true;
            }
            return false;
        }

        public static void PrintDesirable(String op, int start, int N)
        {
            if (N == 0)
            {
                Debug.WriteLine(op);
                return;
            }

            for (int i = start; i < 10; i++)
            {
                String initial = op;
                op += i;
                PrintDesirable(op, i + 1, N - 1);
                op = initial;
            }
        }

        public static void BinaryTree(string epic)
        {
            BinaryTree tree = new BinaryTree();
            Node root = new Node();
            foreach (char c in epic)
            {
                tree.Insert(c);
            }
            //tree.Insert(4);
            //tree.Insert(2);
            //tree.Insert(5);
            //tree.Insert(1);
            //tree.Insert(3);
            tree.DisplayTree();
        }

        public static double ClimbTime(double hillHeight)
        {
            if (hillHeight < 3.0)
            {
                return hillHeight / 3.0;
            }

            return 1.0 + (hillHeight - 3.0);
        }

        public static double ComputeTime(double height)
        {

            if (height % 3 == 0)
            {
                return (height - 3) + 1;
            }
            else
            {
                return (height / 3 + 1);
            }

        }

        public static void BearClimb()
        {
            double TotalLongHill = 60.5;
            int oneMinuteFt = 3;
            int fallDownFt = 2;
            int total = oneMinuteFt / fallDownFt;

        }

        public static void PeopleMeet()
        {
            //Person A = building 1
            //Person B = building 106
            //If A crosses 5 offices in a minute
            //and B crosses 10 offices in a minute
            //1 to 106 
            //A=5,   10, 15, 20, 25, 30, 35, 40
            //  1    2   3   4   5   6   7   8
            //B=106, 96, 86, 76, 66, 56, 46, 36
            //  1    2   3   4   5   6   7   8
            int t = 0;
            int a = 5 * t + 1;
            int b = -10 * t + 106;
            //5(0) + 1 = -10(0) + 106;
            //15(t) = 105;
            //t = 7;
            //Meet at 36 building

        }

        public static void SelectTheMountainPoint()
        {
            int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };

        }

        public static void OrderFromLeftToRight()
        {
            //should eval to 20 + 8 = 28 - 9 = 19
            int total = 3 * 4 + 8 - 9;
            Debug.WriteLine(total);
        }

        //Write an efficient program to find the sum of contiguous subarray within
        //a one-dimensional array of numbers which has the largest sum.
        public static int LargestSumContigousSubArray(int[] arr)
        {
            //Kadane’s Algorithm:
            //Initialize:
            //max_so_far = 0
            //max_ending_here = 0

            //Loop for each element of the array
            //    (a) max_ending_here = max_ending_here + a[i]
            //(b) if(max_ending_here< 0)
            //    max_ending_here = 0
            //        (c) if(max_so_far<max_ending_here)
            //max_so_far = max_ending_here
            //return max_so_far
            int max_so_far = 0;
            int max_ending_here = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                max_ending_here = max_ending_here + arr[i];
                if (max_ending_here < 0)
                {
                    max_ending_here = 0;
                }
                if (max_so_far < max_ending_here)
                {
                    max_so_far = max_ending_here;
                }
            }
            return max_so_far;
        }


        public static void GenerateAllPossibleCharSequences(int digit)
        {
            char[] keystokes;
            switch (digit)
            {
                case 0:
                    GenerateCharSequence(digit, null);
                break;
                case 1:
                   GenerateCharSequence(digit, "vtfrq");
                    break;
            }
        }

        public static void GenerateCharSequence(int digit, string keystrokes)
        {
            var len = keystrokes.Length;
            permute(keystrokes, 0, len - 1);
        }
        public static bool TestValidPhoneNumbers(string phoneNumber, int[] disallowed)
        {
            for(int i = 0; i < phoneNumber.Length; i++)
            {
                if(phoneNumber.Contains("4"))
                {
                    if (phoneNumber[0] != '4')
                        return false;
                }
                //no consecutive numbers
                //int f = phoneNumber[i];
                //if(phoneNumber[i] <= phoneNumber.Length - 1)
                //{
                //    int last = phoneNumber[i+1];
                //    if(last-1 == phoneNumber[i])
                //    {
                //        //They are consective... 
                //        return false;
                //    }
                //}
                if (i > 1 && (Convert.ToInt32(phoneNumber[i]) != Convert.ToInt32(phoneNumber[i - 1]) + 1))
                {
                    Console.WriteLine("Not Consecutive");
                    break;
                }
                if (i == phoneNumber.Length - 1)
                {
                    Console.WriteLine("Consecutive");
                }
            }
            //disallowed
            for (int i = 0; i < disallowed.Length; i++)
            {
                if (phoneNumber.Contains(i.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        public static string TestSubstringAddition(int total, int[] arr)
        {
            //so 1, 3, 5, 7 = 16 print out all the numbers 
            var message = string.Empty;
            int totalling = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                Debug.Write(arr[i]);
                totalling = totalling + arr[i];
                sb.Append(arr[i]+",");
                if(totalling == total)
                {
                    message = string.Format("Numbers to add up to total: {0}, {1}",total,   sb.ToString());
                    break;
                }
                Debug.WriteLine(totalling);
            }
            return message;
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

        public static void SubstringAddition(string str)
        {

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

        public static void TestPermutation(string str)
        {
            Debug.WriteLine("TestPermutations################# for string:"+str);
            int n = str.Length;
            permute(str, 0, n - 1);
        }
        /** 
        * permutation function 
        * @param str string to  
            calculate permutation for 
        * @param l starting index 
        * @param r end index 
        */
        private static void permute(String str,
                                    int l, int r)
        {
            if (l == r)
                Debug.WriteLine(str);
            else
            {
                for (int i = l; i <= r; i++)
                {
                    str = swap(str, l, i);
                    permute(str, l + 1, r);
                    str = swap(str, l, i);
                }
            }
        }

        private static String swap(String a,
                              int i, int j)
        {
            char temp;
            char[] charArray = a.ToCharArray();
            temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
            string s = new string(charArray);
            return s;
        }

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
