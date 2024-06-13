namespace BasicsPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            // IF STATEMENT
            Console.WriteLine("#12 IF STATEMENT");

            bool isFemale = false;
            bool isTall = true;

            if (isFemale && isTall)
            {
                Console.WriteLine("Tall Female");
            }
            else if (isFemale && !isTall)
            {
                Console.WriteLine("Short Female");
            }
            else if (!isFemale && isTall)
            {
                Console.WriteLine("Tall Male");
            }
            else
            {
                Console.WriteLine("Short Male");
            }
            Console.WriteLine();



            // MORE COMPLEX IF STATEMENT
            Console.WriteLine("#13 COMPLEX IF STATEMENTS");

            // refer to the GetMax() method below
            Console.WriteLine(GetMax(2, 10, 40));
            Console.WriteLine();



            // CALCULATOR
            Console.WriteLine("CALCULATOR");

            Console.Write("Enter a Number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Operator: ");
            string op = Console.ReadLine();

            Console.Write("Enter another Number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            if (op == "+")
            {
                Console.Write(num2 + num1);
            }
            else if (op == "-")
            {
                Console.Write(num2 - num1);
            } else if (op == "*")
            {
                Console.Write(num2 * num1);
            } else if(op == "/")
            {
                Console.Write(num2 / num1);
            } else
            {
                Console.WriteLine("Invalid Input or Operator");
            }
            Console.WriteLine();



            // SWITCH STATEMENTS
            Console.WriteLine("#14 SWITCH STATEMENTS");
            Console.WriteLine(GetDay(0));
            Console.WriteLine();



            // WHILE LOOPS
            Console.WriteLine("#15 WHILE LOOPS");

            int index = 1;
            while (index <= 5)
            {
                Console.WriteLine(index);
                index++;
            }
            Console.WriteLine();



            // WHILE LOOPS
            Console.WriteLine("#15 DO-WHILE LOOPS");

            int index2 = 6;
            do
            {
                Console.WriteLine(index);
                index2++;
            } while (index2 <= 5);
            Console.WriteLine();



            // GUESSING GAME 
            Console.WriteLine("#16 GUESSING GAME ");

            string secretWord = "giraffe";
            string guess = "";
            int guessCount = 0;
            int guessLimit = 3;
            bool outOfGuesses = false;

            while (guess != secretWord && !outOfGuesses)
            {
                if (guessCount < guessLimit)
                {
                    Console.Write("Guess the animal: ");
                    guess = Console.ReadLine();
                    guessCount++;
                } else
                {
                    outOfGuesses = true;
                }
                
            }
            
            if(outOfGuesses == true)
            {
                Console.WriteLine("Guess Limit, You Lose");
                Console.WriteLine();
            } else
            {
                Console.WriteLine("You Win");
                Console.WriteLine();
            }        



            // FOR LOOP
            Console.WriteLine("#17 FOR LOOP ");

            int[] luckyNumbers = { 4, 8, 15, 18, 21 };

            // (variable; loop condition; increment)
            for (int i = 0; i < luckyNumbers.Length; i++)
            {
                Console.WriteLine(luckyNumbers[i]);
            }
            Console.WriteLine();



            // EXPONENT FUNCTION
            Console.WriteLine("#18 EXPONENT FUNCTION ");
            // refer to GetPow method below
            Console.WriteLine(GetPow(5, 2));
            Console.WriteLine();



            // 2D ARRAY
            Console.WriteLine("#19 TWO DIMENSIONAL ARRAY");

            int[,] numberGrid = {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9},
            };

            //declare
            int[,] myArray = new int[2, 3];

            Console.WriteLine(numberGrid[0, 2]);




            Console.ReadLine();
        }

        /*
         * OTHER METHODS
         * OTHER METHODS
         * OTHER METHODS
         */
       

        // For the COMPLEX IF STATEMENT example
        static int GetMax(int num1, int num2, int num3)
        {
            int result;

            // with comparison operators
            if (num1 >= num2 && num1 >= num3)
            {
                result = num1;
            }
            else if (num2 >= num1 && num2 >= num3)
            {
                result = num2;
            }
            else
            {
                result = num3;
            }

            return result;
        }

        // method for the SWITCH example
        static string GetDay(int dayNum)
        {
            string dayName;

            switch (dayNum)
            {
                case 0:
                    dayName = "Monday";
                    break;
                case 1:
                    dayName = "Tuesday";
                    break;
                case 2:
                    dayName = "Wednesday";
                    break;
                case 3:
                    dayName = "Thursday";
                    break;
                case 4:
                    dayName = "Friday";
                    break;
                case 5:
                    dayName = "Saturday";
                    break;
                case 6:
                    dayName = "Sunday";
                    break;
                default:
                    dayName = "Invalid Number Should be 0-6";
                    break;
            }

            return dayName;
        }

        static int GetPow(int baseNum, int powNum)
        {
            int result = 1;

            for (int i = 0; i < powNum; i++)
            { 
                result *= baseNum;
            }


            return result;
        }
    }
}
