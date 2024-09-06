using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace Zoo
{
    public abstract class Animal
    {
        protected int Age;
        protected string Name;
        protected string Breed;
        protected bool Hungry = false;
        protected string Fav_food;
        Ball fav_ball = new Ball("blue"); //declare generic favourite colour of ball

        protected Animal(int _Age, string _Name, string _Breed, string _favfood)
        {
            Age = _Age;
            Name = _Name;
            Breed = _Breed;
            Fav_food = _favfood;
        }

        /* Var noggranna med att ni vet innebörden av virtual. */
        public virtual void Eat(string food)

        {
            if (Fav_food == food)
            {
                Console.WriteLine("{0} is happy with {1} and full now!", Name, Fav_food);
            }
            else
            {
                Hungry_Animal();
            }
        }
        public string GetName()
        {
            return Name;
        }

        public virtual void Fetch(Ball ball)
        {
            Console.WriteLine(ball.quality);
            if (ball.quality != 0)// as long as the ball quality is not zero, we will have respective interactions with the animal
            {
                if (ball.colour == fav_ball.colour)
                {
                    Console.WriteLine("{0} is spinning happily with {1} ball", Name, fav_ball.colour);
                    Hungry = true;
                }
                else if (Hungry)
                {
                    Hungry_Animal();
                    Console.WriteLine("{0} chews on the {1} ball hard.", Name, ball.colour);
                    ball.LowerQuality(2); //it will lower the ball quality by 2 instead 1.
                }
                else if (ball.colour != fav_ball.colour)
                {
                    Console.WriteLine("{0} plays and occasinally bite the {1} ball.", Name, ball.colour);
                    Hungry = true;
                }
            }
            else
            {
                Console.WriteLine("The {0} ball is too damaged to play with. Please select another ball.", ball.colour);
            }

        }

        public virtual void Interact()
        {
            if (!Hungry)
            {
                Console.WriteLine("{0} wants to cuddle with you.", Name);
                Hungry = true;
            }
            else
            {
                Hungry_Animal();
            }
        }

        public virtual void Hungry_Animal() // method that displays that animal is hungry
        {
            Console.WriteLine("{0} complains.", Name);
        }

        public override string ToString()
        {
            String message = Name + " " + Age + " years old " + Breed;
            return message;
            /*Skapa en lämplig utskrift här för när vi skriver ut ett objekt.*/
        }

    }
    class tiger : Animal
    {
        Ball fav_ball;
        public tiger(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
            Fav_food = _favfood;
            fav_ball = new Ball("red"); //declare favourite ball
        }
      

        public override void Fetch(Ball ball)
        {
                
            if (ball.quality != 0)
            {

                if (ball.colour == fav_ball.colour)
                {
                    Console.WriteLine("{0} is playing happily with {1} ball", Name, fav_ball.colour);
                    Hungry = true;
                }
                else if (Hungry)
                {
                    Console.WriteLine("{0} is a bit hungry to play with {1} ball",Name, ball.colour);
                    Hungry_Animal();
                }
                else if (ball.colour != fav_ball.colour)
                {
                    Console.WriteLine("{0} plays and occasinally bite the {1} ball.",Name, ball.colour);
                    ball.LowerQuality(1);
                    Hungry = true;
                }
            }
            else
            {
                Console.WriteLine("The {0} ball is too damaged to play with. Please select another ball.", ball.colour);
            }

        }

        public override void Interact()
        {
            if (!Hungry)
            {
                Console.WriteLine("{0} purrs.", Name);
                Hungry = true;
            }
            else
            {
                Hungry_Animal();
            }
        }
        public override void Eat(string food)
        {
            if (Hungry)
            {
                if (food == Fav_food)
                {
                    Console.WriteLine("{0} happily chews on {1}",Name, Fav_food);
                    Hungry = false;
                }
                else
                {
                    Console.WriteLine("{0} is still hungry.",Name);
                    Hungry_Animal();
                }
            }
            else
            {
                Console.WriteLine("{0} is not hungry. Its satisfied.",Name);
            }
        }

        public override void Hungry_Animal()
        {
            Random random = new Random();
            int randomNumber = random.Next(0, 2);

            Console.WriteLine("{0} is running to you to get more food",Name);
            Console.WriteLine("Please enter to see if you give {0} more food. 50/50 chance", Name);

            Console.ReadKey(true);
            Console.Clear();

            if (randomNumber == 1)
            {
                Console.WriteLine("You fed {0}! He is full.",Name);
                Hungry = false;

            }
            else
            {
                Console.WriteLine("{0} did not get food this time and is still hungry.", Name);
            }
        }
    }

    class lynx : tiger
    {
        private int Age;
        private string Name;

        public lynx(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
        }

        public override string ToString() //display string variables
        {
            String message = Name + " " + Age + " years old " + Breed;
            return message;
        }
    }

    class wolf : Animal
    {
        Ball fav_ball = new Ball("green"); //declare favourite colour of ball

        public wolf(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
            Fav_food = _favfood;
        }
        public override void Interact()
        {
            if (!Hungry)
            {
                Console.WriteLine("{0} looks at you.", Name);
                Hungry = true;
            }
            else
            {
                Hungry_Animal();
            }
        }

    }
    class dog : wolf
    {
        private int Months;
        private string Name;

        public dog(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Months = _Age;
            Name = _Name;
        }

        public override string ToString()
        {
            String message = Name + " " + Months + " months " + Breed;
            return message;
        }
    }

    class gorilla : Animal
    {
        private int Age;
        private string Name;
        Ball fav_ball;
        public gorilla(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
            Fav_food = _favfood;
            fav_ball = new Ball("yellow"); //declare favourite ball
        }


    }

    class monkey : gorilla 
    {
        private int Age;
        private string Name;

        public monkey(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
        }

        public override string ToString()
        {
            String message = Name + " " + Age + " years old " + Breed;
            return message;
            /*Skapa en lämplig utskrift här för när vi skriver ut ett objekt.*/
        }
    }

    class panda : Animal
    {
        Ball fav_ball;
        private int Months;
        private string Name;
        public panda(int _Age, string _Name, string _Breed, string _favfood) : base(_Age, _Name, _Breed, _favfood)
        {
            Age = _Age;
            Name = _Name;
            Fav_food = _favfood;
        }

        public override string ToString()
        {
            String message = Name + " " + Age + " years old " + Breed;
            return message;
            /*Skapa en lämplig utskrift här för när vi skriver ut ett objekt.*/
        }
    }

    public class Ball // Class of ball
    {
        public string colour;
        public int quality = 20;

        public Ball(string colour)
        {
            this.colour = colour;
        }

        public void LowerQuality(int damage) //method for lowering quality of the ball 
        {
            quality -= damage;
        }
    }
    class Visitor
    {
        // Data about passenger
        private int age;
        //create properties
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private int childAgeLimit = 17;
        private int adultAgeLimit = 18;

        private string ageGroup;
        public string AgeGroup
        {
            get { return ageGroup; }
            set { ageGroup = value; }
        }

        public Visitor(int age)//constructor
        {
            Age = age;
            Determine_Group(Age);
        }


        public void Determine_Group(int age) //method for determining age group
        {
            if (age > 0 && age <= childAgeLimit)
            {
                AgeGroup = "CHILD";
            }
            //return AgeGroup;
            if (age >= adultAgeLimit)
            {
                AgeGroup = "ADULT";
            }
            //return ageGroup;
        }

    }
    class zookeeper
    {

        private Animal[] djur = new Animal[7]; // instantiate the object
        private Ball[] ownedBall; // object of Ball
        private int chosenBall;

        int maxAgeLimitVisitor = 100;
        
        Visitor[] visitors = new Visitor[100]; //maximum visitors
        public int maxNumberLimitVisitor = 100; //create variable with same amount as array 
        public int visitorOnBoard = 0;

        int childPrice = 50;
        int adultPrice = 75;
        int childLimit = 17;
        int adultLimit = 18;

        public zookeeper()
        {

            //declare object "djur"
            djur[0] = new tiger(4, "Kunkon", "Tiger", "Meat");
            djur[1] = new lynx(6, "Taigo", "Lynx", "Fishball");
            djur[2] = new wolf(2, "Woofy", "Wolf", "Deermeat");
            djur[3] = new dog(2, "Selma", "Dog", "Carrot");
            djur[4] = new gorilla(4, "Minky", "Gorilla", "Guava");
            djur[5] = new monkey(5, "Tayo", "Monkey", "Banana");
            djur[6] = new panda(3, "Pubao", "Panda", "Bamboo");

            //declare object "ownedBall"
            ownedBall = new Ball[4]
            {
                new Ball("red"),
                new Ball("blue"),
                new Ball("green"),
                 new Ball("yellow")
            };
        }
        public void Run()
        {
            int startHour = 14;
            int endHour = 18;

            DateTime currentTime = DateTime.Now;    //declare current time

            int userPosition = 0;
            Console.WriteLine("Welcome to the Everland zoo!");
            Console.WriteLine("Before you enter, We want to know who you are! ");
            Console.WriteLine("1.Visitor");
            Console.WriteLine("2.Zoo keeper");
            try //error handling in case of mistype
            {
                Console.Write("Type : ");
                userPosition = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (userPosition == 1)
                {
                    string menuChoice = null;
                    while (true)
                    {
                        //We only allow visitors to enter the zoo during opening hours
                        if (currentTime.Hour < startHour || currentTime.Hour >= endHour)
                        {
                            Console.WriteLine("Sorry! Please come back during opening hours. Zoo is open between {0} AM and {1} PM.", startHour, endHour);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else
                        {   //menu display for visitors
                            Console.WriteLine("Choose your option.");
                            Console.WriteLine("[P]Price");
                            Console.WriteLine("[B]Buy tickets");
                            Console.WriteLine("[L]List of animals");
                            Console.WriteLine("[E]Exit the program");
                            Console.Write("Type : ");
                            menuChoice = Console.ReadLine().ToUpper();
                            Console.WriteLine();

                            switch (menuChoice)
                            {
                                case "P":

                                    Console.WriteLine("==== Prices for the ZOO ====\n" +
                                                     childPrice + "kr for visitors of age between 0 and " + childLimit);
                                    Console.WriteLine(adultPrice + "kr for visitors of age over " + adultLimit);
                                    Console.WriteLine("============================\n" +
                                          "Press any key to continue...");
                                    Console.ReadKey(true);
                                    break;
                                case "B":
                                    AddVisitors();
                                    break;
                                case "L":
                                    print_animals();
                                    break;
                                case "E":
                                    Console.WriteLine("Bye See you again!");
                                    Environment.Exit(0);
                                    break;
                                default:
                                    Console.WriteLine("Something went wrong, try again . . .");
                                    break;
                            }

                            Console.Clear();
                        }
                    }

                }
                else if (userPosition == 2)
                {
                    string menuChoice = null;
                    while (true)
                    {   //menu display for zookeeper
                        Console.WriteLine("Choose your option.");
                        Console.WriteLine("[P]Play with animals");
                        Console.WriteLine("[F]Feed animals");
                        Console.WriteLine("[S]Show animals");
                        Console.WriteLine("[E]Exit the program");
                        Console.Write("Type : ");
                        menuChoice = Console.ReadLine().ToUpper();
                        Console.WriteLine();

                        switch (menuChoice)
                        {
                            case "P":
                                play();
                                break;
                            case "F":
                                feed();
                                break;
                            case "S":
                                print_animals();
                                break;
                            case "E":
                                Console.WriteLine("Bye See you again!");
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Something went wrong, try again . . .");
                                break;
                        }

                        Console.Clear();
                    }
                }
                else { Console.WriteLine("Sorry we could not verify you.Please try again."); }

            }
            catch { Console.WriteLine("Invalid"); }

        }


        public void AddVisitors()
        {
            int newAge = 0;

            Console.Clear();
            Console.WriteLine("=== Ticket purchase ===");
            // Input age
            if (visitorOnBoard < maxNumberLimitVisitor)
            {
                while (true)
                {
                try
                 {
                    Console.Write("Visitor age: ");
                    newAge = Convert.ToInt32(Console.ReadLine());
                    if (newAge > maxAgeLimitVisitor)
                    {
                        Console.WriteLine("Please write a smaller integer.");
                    }
                    else if (newAge < 0)
                    { // I've never heard of anyone under the age of 0.
                        Console.WriteLine("Please write a bigger integer.");
                    }
                    else
                    {
                        break;  // Successful input
                    }
                 }
                catch (FormatException)
                {
                    Console.WriteLine("Please write an integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            // Linear search
            for (int i = 0; i < visitors.Length - 1; i++)
            {
                if (visitors[i] == null)
                {

                    visitors[i] = new Visitor(newAge);
                    Prices(visitors[i].AgeGroup);
                    break;
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine();
            }
            else { Console.WriteLine("Sorry the zoo is full!"); }
           
        }

        private void Prices(string AgeGroup) //Method for calculating price
        {
            // Adults
            if (AgeGroup == "ADULT")
            {
                Console.WriteLine("Welcome! It will cost you {0}kr", adultPrice);
            }

            else if (AgeGroup == "CHILD")
            {
                Console.WriteLine("Greetings friend! It will cost you {0}kr", childPrice);

            }

            Console.WriteLine("============================\n" +
                              "Press any key to continue...");
            Console.ReadKey(true);
        }

        public void print_animals()
        {
            int count = 1;
            foreach (var animal in djur)
            {
                Console.WriteLine($"#{count} : {animal}");
                count++;
            }
            Console.WriteLine("\nPress any button to go back to the menu.");
            Console.ReadKey();
            Console.Clear();
        }

        public void feed()
        {
            Console.WriteLine("Which animal do you want to feed? ");
            int count = 1;
            foreach (var animal in djur) //display animals
            {
                Console.WriteLine($"#{count} : {animal}");
                count++;
            }
            Console.Write("\nType the number : ");
            int numberAnimal = int.Parse(Console.ReadLine());

            switch (numberAnimal)
            {
                case 1:
                    Console.WriteLine("You have chosen {0} to feed.", djur[0]);
                    Console.Write("Type the food you want to feed : ");
                    string food = Console.ReadLine();
                    djur[0].Eat(food); //sending food as parameter into the "eat" method
                    break;
                case 2:
                    Console.WriteLine("You have chosen {0} to feed.", djur[1]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[1].Eat(food);
                    break;
                case 3:
                    Console.WriteLine("You have chosen {0} to feed.", djur[2]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[2].Eat(food);
                    break;
                case 4:
                    Console.WriteLine("You have chosen {0} to feed.", djur[3]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[3].Eat(food);
                    break;
                case 5:
                    Console.WriteLine("You have chosen {0} to feed.", djur[4]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[4].Eat(food);
                    break;
                case 6:
                    Console.WriteLine("You have chosen {0} to feed.", djur[5]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[5].Eat(food);
                    break;
                case 7:
                    Console.WriteLine("You have chosen {0} to feed.", djur[6]);
                    Console.Write("Type the food you want to feed : ");
                    food = Console.ReadLine();
                    djur[6].Eat(food);
                    break;
            }
            Console.WriteLine("\nPress any button to go back to the menu.");
            Console.ReadKey();
            Console.Clear();

            /*I denna metod kan petowner mata djur genom att anropa ett djurs metod "eat"
             * Maten man skickar med som argument ska testas mot djurets favoritmat
             Man kan anropa en metod typ djur[1].eat("köttbullar");
             */
        }



        public void play()
        {
            string playChoice = null;
            Console.WriteLine("Choose your options.");
            Console.WriteLine("[C]Check ball");
            Console.WriteLine("[P]Play");
            Console.Write("Type : ");
            playChoice = Console.ReadLine().ToUpper();
            switch (playChoice)
            {
                case "C": 
                    CheckBall();
                    Console.ReadKey();
                    break;
                case "P":
                    {
                        Console.WriteLine("\nWhich animal you want to play with? ");
                        int count = 1;
                        foreach (var animal in djur) // display animals
                        {
                            Console.WriteLine($"#{count} : {animal}");
                            count++;
                        }
                        try//error handling
                        {
                            Console.Write("\nType the number : ");
                            int numberAnimal = int.Parse(Console.ReadLine());

                            switch (numberAnimal)
                            {
                                case 1:
                                    Console.WriteLine("You have chosen {0} to play.", djur[0]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no"); // We ask if player wants to play with ball or not. if not player will only interact with animal.
                                    string ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++) // display of balls
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[0].Fetch(ownedBall[chosenBall - 1]); //pass the index of balls into the "fetch method" within animal class
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[0].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("You have chosen {0} to play.", djur[1]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());
                                        djur[1].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[1].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 3:
                                    Console.WriteLine("You have chosen {0} to play.", djur[2]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[2].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[2].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("You have chosen {0} to play.", djur[3]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[3].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[3].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 5:
                                    Console.WriteLine("You have chosen {0} to play.", djur[4]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[4].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[4].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 6:
                                    Console.WriteLine("You have chosen {0} to play.", djur[5]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[5].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[5].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                case 7:
                                    Console.WriteLine("You have chosen {0} to play.", djur[6]);
                                    Console.WriteLine("Do you want to play with ball ? yes / no");
                                    ownerAnswer = Console.ReadLine().ToLower();
                                    if (ownerAnswer == "yes")
                                    {
                                        Console.WriteLine("Choose a ball to play");
                                        for (int i = 0; i < ownedBall.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {ownedBall[i].colour}");
                                        }
                                        Console.Write("Type : ");
                                        chosenBall = int.Parse(Console.ReadLine());

                                        djur[6].Fetch(ownedBall[chosenBall - 1]);
                                    }
                                    else if (ownerAnswer == "no")
                                    {
                                        djur[6].Interact();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid input!");
                                    }
                                    break;
                                    /*I denna metod kan petowner leka med djur genom att anropa ett djurs metod "interact"*/
                                    /*Om djuret leker så blir det sedan hungrigt*/
                            }
                        }
                        catch (Exception ex)
                        { Console.WriteLine(ex.Message); }

                        Console.WriteLine("\nPress any button to go back to the menu.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    break;
                     default:
                     Console.WriteLine("Please choose something in the menu");
                     break;
                
            }
        }

        public void CheckBall() // method for checking ball quality
        {
            Console.WriteLine("Check your ball qualities:");
            foreach (Ball ball in ownedBall)
            {
                Console.WriteLine("-----------------------------------------");
                Console.WriteLine($"BALL: {ball.colour} - Quality: {ball.quality}");
            }
            Console.WriteLine("-----------------------------------------");
            Console.ReadKey();
        }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            zookeeper zookeeper = new zookeeper();

            zookeeper.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}

