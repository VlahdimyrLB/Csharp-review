﻿namespace BasicsPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Better Calculator
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
            Console.WriteLine("#13 SWITCH STATEMENTS");
            Console.WriteLine(GetDay(0));
            Console.WriteLine();



            // WHILE LOOPS
            Console.WriteLine("#14 WHILE LOOPS");

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
            Console.WriteLine("#15 GUESSING GAME ");

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
                Console.Write("Guess Limit, You Lose");
            } else
            {
                Console.Write("You Win");
            }
            Console.WriteLine();




            Console.ReadLine();
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
    }
}