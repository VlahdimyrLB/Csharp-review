﻿
namespace Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            // How to READ and WRITE
            // Programs are sets of instructions that the computer gonna follow
            // C# executes programs line by line, ORDER MATTERS.

            Console.WriteLine("#1 READ and WRITE");
            Console.WriteLine("   /|");
            Console.WriteLine("  / |");
            Console.WriteLine(" /  |");
            Console.WriteLine("/___|");
            Console.WriteLine();


            // VARIABLES - a container use to store data or value
            // use camelCase for variable naming.

            string charName = "Vlahdimyr"; // direct assignment
            int charAge; // declare
            charAge = 21; // assign

            Console.WriteLine("#2 VARIABLES");
            Console.WriteLine("There's once was a man named " + charName); // append/concant using + sign
            Console.WriteLine("He was " + charAge + " years old.");


            // DATA TYPES
            Console.WriteLine("#3 DATA TYPES");

            string phrase = "Hello World"; // use double quote
            char grade = 'A'; // single quote - strictly 1 letter
            int day = 12; // whole number positive and negative
            bool isMale = true; // true or false value only

            // for numbers with decimal places
            float fl = 1.2f; // least accurate USE f keyword
            double gwa = 1.51; // middle - most use case
            decimal dec = 123.1234m; // most accurate - for precision(money) USE m keyword

            Console.WriteLine("string, char, int, bool, double");
            Console.WriteLine();


            // STRINGS
            Console.WriteLine("#4 STRINGS");

            string name = "Kurumi Tokisaki";
            Console.WriteLine("Kurumi\nTokisaki"); // \n - new line
            Console.WriteLine("Name count: " + name.Length); // Length - get count
            /* We can also use Methods
            just add . to any strings and it will show the available methods that we can use
            REMEBER use () since its a method */
            Console.WriteLine("Name toUpper() method: " + name.ToUpper());
            Console.WriteLine("Name Contains(param) method: " + name.Contains("saki")); // parameterized method
            Console.WriteLine("Access using letter using brackets [0]: " + name[0]); // bracket notation - INDEX STARTS AT 0
            Console.WriteLine("Access if it contains the parameter and its index IndexOf(param): " + name.IndexOf("saki"));
            Console.WriteLine("Grab part of of string using Substring(param1, param2): " + name.Substring(11, 4)); // params (index, how many)
            Console.WriteLine();

            Console.ReadLine(); 
             


        }
    }
}
