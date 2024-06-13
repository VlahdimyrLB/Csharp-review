
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
            REMEMBER use () since its a method */
            Console.WriteLine("Name toUpper() method: " + name.ToUpper());
            Console.WriteLine("Name Contains(param) method: " + name.Contains("saki")); // parameterized method
            Console.WriteLine("Access using letter using brackets [0]: " + name[0]); // bracket notation - INDEX STARTS AT 0
            Console.WriteLine("Access if it contains the parameter and its index IndexOf(param): " + name.IndexOf("saki"));
            Console.WriteLine("Grab part of of string using Substring(param1, param2): " + name.Substring(11, 4)); // params (index, how many)
            Console.WriteLine();


            // NUMBERS
            Console.WriteLine("#5 NUMBERS");

            int num = 10;
            num++; // to increment or -- for decrement

            Console.WriteLine(num); // we can write numbers inside of this
            Console.WriteLine(10 + 5); // or even do math operations
            Console.WriteLine(Math.Abs(-40)); // we can also call math methods Pow, Sqrt, Max/Min, Round etc.
            Console.WriteLine();


            // GET USER INPUT
            Console.WriteLine("#6  GET USER INPUT");

            Console.Write("Enter you name: ");
            string myName = Console.ReadLine();
            Console.WriteLine("Hello " + myName);
            Console.WriteLine();


            // CONVERTERS
            Console.WriteLine("#7 CONVERTERS");

            int numConvert = Convert.ToInt32("21");
            Console.WriteLine(numConvert + 10); // this will work because the datatype is converted to int

            // sample calculator
            Console.WriteLine("Calculate the Sum of two numbers :)");
            Console.Write("Enter #1: ");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter #2: ");
            double num2 = Convert.ToDouble(Console.ReadLine()); ;
            Console.WriteLine("The sum of   two numbers is = " + (num1 + num2));
            Console.WriteLine();


            // Madlibs
            Console.WriteLine("#8 Madlibs Game");

            string color, pluralNoun, celebrity;
            Console.Write("Enter a Color: ");
            color = Console.ReadLine();
            Console.Write("Enter a Plural Noun: ");
            pluralNoun = Console.ReadLine();
            Console.Write("Enter a Celebrity: ");
            celebrity = Console.ReadLine();

            Console.WriteLine("Roses are " + color);
            Console.WriteLine(pluralNoun + " are Blue");
            Console.WriteLine("I Love " + celebrity);
            Console.WriteLine();


            // ARRAYS
            Console.WriteLine("#9 ARRAYS");

            int[] luckyNumbers = { 9, 21, 12, 10, 17, 56, 101 };
            string[] friends = new string[3]; // declare without elements but assign how many will be the elements

            luckyNumbers[0] = 1; // change the value of first element

            // populate the array
            friends[0] = "John";
            friends[1] = "Bern";
            friends[2] = "Mar";

            Console.WriteLine(luckyNumbers[0]); // access by index
            Console.WriteLine();


            // METHODS
            Console.WriteLine("#10 METHODS");

            // the method is below
            SayHi("Vlahd"); // call/invoke the method
            Console.WriteLine();


            // RETURN
            Console.WriteLine("#11 RETURN");

            // the method with return type is below
            Console.WriteLine(cube(3));
            Console.WriteLine();


            


            Console.ReadLine();
        }


        // METHODS - block of code to perform specific task
        // void - to specify that the method doesn't return a value.
        // void - operations that do not need to send any data back to the caller.
        static void SayHi(string name)
        {
            Console.WriteLine("Hello " + name);
        }


        // RETURN - method with return type
        // when the method needs to process data and provide a result back to the caller.
        static int cube(int num)
        {
            int result = num * num * num;
            return result;
        }
    }
}
