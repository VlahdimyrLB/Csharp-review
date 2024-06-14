namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXCEPTION HANDLING
            Console.WriteLine("EXCEPTION HANDLING");
            try
            {
                Console.Write("Enter a number: ");
                double num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter a another number: ");
                double num2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(num1 / num2);
            }
            catch (DivideByZeroException ex) // we can define specific exception
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            catch (FormatException) // we can also define multiple catch blocks
            {
                // We can throw custom error
                Console.WriteLine("ERROR: Invalid Format, Please Enter a Number"); 
            }
            catch (Exception ex) // all-in-one exception
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
            finally // this will ALWAYS GET EXECUTED (optional block)
            {
                Console.WriteLine(".....");
            }
            Console.WriteLine();



            // CLASSES AND OBJECTS
            Console.WriteLine("CLASSES AND OBJECTS");
            // refer to Book class

            // create a book using Book Class
            // we now create an OBJECT (is an instance of a class)
            // were creating the actual book

            // INSTANTIATE book 
            
            Book book1 = new Book(); // this is the book object
            book1.title = "Atomic Habits";
            book1.author = "James Clear";
            book1.pages = 320;
            Console.WriteLine(book1.title); 
            
            // Above code commented because of constructor example has parameters
            Console.WriteLine();



            // CONSTRUCTORS - special method that always get called when we create an object of a class
            Console.WriteLine("CONSTRUCTORS");

            // We can use CONSTRUCTOR to create multiple objects easily
            Book book2 = new Book("Atomic Habit", "James Clear", 320);
            Console.WriteLine("Title: " + book2.title);

            // we can access and edit this way
            book2.title = "Atomic Habits"; 
            Console.WriteLine("Updated Title: " + book2.title);
            Console.WriteLine();



            // OBJECT METHODS
            Console.WriteLine("OBJECT METHODS");

            // refer to STUDENT class
            Student student1 = new Student("John", "Accounting", 2.8);
            Student student2 = new Student("Vlahd", "Technology", 4.5);

            Console.WriteLine("Student 1 has honor: " + student1.HasHonors());
            Console.WriteLine("Student 2 has honor: " + student2.HasHonors());
            Console.WriteLine();



            // GET and SETTERS - use to control access to attributes of a class
            Console.WriteLine("GET and SETTERS");

            // refer to MOVIE class
            Movie movie1 = new Movie("The Avengers", "Joss Wesdon", "Dog");
            Movie movie2 = new Movie("SHREK", "Adam Adamson", "PG");

            Console.WriteLine(movie1.Rating); // we get NR because DOG is not a valid rating
            Console.WriteLine(movie2.Rating);
            Console.WriteLine();



            // STATIC ATTRIBUTES - shared by all objects, contained in class itself
            Console.WriteLine("STATIC ATTRIBUTES");
            // refer Song class

            Song holiday = new Song("Holiday", "Green Day", 200);
            Song kashmir = new Song("Kashmir", "Led Zepplin", 150);

            // can be accessed directly using the class because its static 
            // songCount belongs to the class itself
            Console.WriteLine(Song.songCount); 

            Console.WriteLine(holiday.getSongCount()); // access using individual object
            Console.WriteLine();



            // STATIC METHOD & CLASSES
            // static method - method that belongs to the actual class
            Console.WriteLine("STATIC METHOD & CLASSES");
            // we dont have to create an actual instance of the Math class
            Console.WriteLine(Math.Sqrt(144));

            // example: access the method directly without instantiating the method
            UsefulTools.SayHi("Vlahd");
            Console.WriteLine();


            // INHERITANCE - inherit functionality of another class
            // concept 1: inherit all functionality of super class
            // concept 2: extending the functionality of sub class by having its own functions
            // concept 3: override one of the functions of super class
            Console.WriteLine("INHERITANCE");
            
            // refer to Chef class
            Chef chef = new Chef();
            chef.MakeSpecialDish();
            chef.MakeChicken();

            // refer to Italian Chef
            ItalianChef italianChef = new ItalianChef();
            italianChef.MakeSpecialDish();
            italianChef.MakePasta();

            Console.WriteLine();


            Console.ReadLine();
        }
    }
}