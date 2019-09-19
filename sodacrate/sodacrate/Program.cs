using System;

namespace sodacrate
{
    class Sodacrate
    {

        private Soda[] crate = new Soda[24]; //Vektorn crate erhåller platser för drickabacken att fylla med drickor.
        private int amountOfBottles = 0; // Håller koll på hur många drickor som är i backen.
        private Soda[] stock = new Soda[8]
        {
            new Soda("CocaCola", DrinkType.Softdrink.ToString(), 14.99m),
            new Soda("Fanta", DrinkType.Softdrink.ToString(), 14.99m),
            new Soda("Sprite", DrinkType.Softdrink.ToString(), 14.99m),
            new Soda("Loka", DrinkType.Mineralwater.ToString(), 8.99m),
            new Soda("Ramlösa", DrinkType.Mineralwater.ToString(), 9.99m),
            new Soda("Carlsberg", DrinkType.Beer.ToString(), 12.59m),
            new Soda("Brewdog", DrinkType.Beer.ToString(), 15.59m),
            new Soda("Staropramen", DrinkType.Beer.ToString(), 12.59m),
        }; //Vektor som håller information om vilka drickor som finns att köpa.
        enum DrinkType { Beer, Softdrink, Mineralwater } // Håller koll på olika typer av dricka. Vill man ändra flera drickors läsktyp är det enklast här då slipper man ändra dem manuellt.
        struct Soda //Dricka struktur som används för att skapa olika sorts drycker.
        {
            public string name;
            public string type;
            public decimal price;

            public Soda(string label, string drinkType, decimal basePrice)
            {
                name = label;
                type = drinkType;
                price = basePrice;
            }
        }
        public void Run() // Metod för att köra själva programmet.
        {
            Console.WriteLine(stock[1].price);
            bool exit = false; // Boolean som håller koll på om användaren vill avsluta programmet.
            do
            {
                Console.Clear();
                Console.WriteLine("\n Welcome to the awesome Sodacrate-simulator\n");
                Console.WriteLine(" Please choose one of the following options.\n" + //Valbar Meny.
                    "   1: Start adding drinks to the crate\n" +
                    "   2: View your crate\n" +
                    "   3: Check the total cost of the crate\n" +
                    "   4: Search drinks\n" +
                    "   5: Sort your crate\n" +
                    "   9: Help\n" +
                    "   0: Exit\n");
                Console.Write(" input: ");

                int choice; //Sparar vilket val användaren vill göra i menyn.
                try //Testar användarens input efter en siffra.
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine(" Please Choose an option from the menu.\n" + //Om talet är något annat än en siffra skrivs meddelandet ut.
                        "  Press Enter to try again.");
                    Console.ReadLine();
                    continue;
                }

                switch (choice) //Switch-sats med de olika menyvalen.
                {
                    case 1:
                        Console.Clear();
                        AddSoda();
                        break;
                    case 2:
                        Console.Clear();
                        PrintCrate();
                        break;
                    case 3:
                        Console.Clear();
                        CalcTotal();
                        break;
                    case 4:
                        Console.Clear();
                        FindSoda();
                        break;
                    case 5:
                        Console.Clear();
                        SortSodas();
                        break;
                    case 9:
                        Help();
                        break;
                    case 0:
                        exit = true; 
                        break;
                    default:
                        Console.WriteLine(" Please Choose an option from the menu.\n" + //Om input var en siffra men inte en siffra i menyn skrivs meddelandet ut.
                        "  Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            } while (!exit); //Om användaren valde 0 för att avsluta avbryts loopen och vi avslutar programmet.
        }

        public void AddSoda() //Metod för att lägga till en dryck i drickabacken.
        {
            bool exit = false;
            for (int i = 0; i < crate.Length; i++) //Loop som går igenom varje position i drickabacken.
            {
                
                if (crate[i].name == null) //Kollar om positionen i backen är tom.
                {
                    Console.Clear();
                    Console.WriteLine( //Menyval.
                        "\n Choose a drink you want to add.\n" +
                        "   1: Cocacola\n" +
                        "   2: Fanta\n" +
                        "   3: Sprite\n" +
                        "   4: Loka\n" +
                        "   5: Ramlösa\n" +
                        "   6: Carlsberg\n" +
                        "   7: Brewdog\n" +
                        "   8: Staropramen\n" +
                        "   9: Add a random drink\n" +
                        "   0: Exit\n"
                    );
                    Console.Write(" input: ");
                    int choice = 0;
                    bool correct = false;
                    do
                    {
                        try //Testar användarens input efter en siffra.
                        {
                            choice = int.Parse(Console.ReadLine()); //Sparar vilket val användaren vill göra i menyn.
                            correct = true; //Avslutar loopen om choice är en siffra.
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine(" Please Choose an option from the menu.\n");//Om choice är tomt skriver vi ut meddelandet.
                            Console.Write(" New Input:");
                        }
                        catch
                        {
                            Console.WriteLine(" Please Choose an option from the menu.\n");//Om choice är något annat än tom eller en siffra skrivs meddelandet ut.
                            Console.Write(" New Input:");
                        }
                    } while (!correct);

                    Console.WriteLine(stock[1].price);
                    Console.WriteLine();
                    switch (choice) //Switch-sats med de olika menyvalen.
                    {
                        case 1:
                            crate[i] = stock[0]; //Lägger till dricka från vektorn sodas.
                            AddedBottleMessage(i); //Metod som skriver ut vilken dricka som lagts till och antal drickor i backen.
                            break;
                        case 2:
                            crate[i] = stock[1];
                            AddedBottleMessage(i);
                            break;
                        case 3:
                            crate[i] = stock[2];
                            AddedBottleMessage(i);
                            break;
                        case 4:
                            crate[i] = stock[3];
                            AddedBottleMessage(i);
                            break;
                        case 5:
                            crate[i] = stock[4];
                            AddedBottleMessage(i);
                            break;
                        case 6:
                            crate[i] = stock[5];
                            AddedBottleMessage(i);
                            break;
                        case 7:
                            crate[i] = stock[6];
                            AddedBottleMessage(i);
                            break;
                        case 8:
                            crate[i] = stock[7];
                            AddedBottleMessage(i);
                            break;
                        case 9:
                            crate[i] = RandomSoda();
                            AddedBottleMessage(i);
                            break;
                        case 0:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine(" Please Choose an option from the menu.\n" + //Om input var en siffra men inte en siffra i menyn skrivs meddelandet ut.
                            "  Press Enter to try again.");
                            Console.ReadLine();
                            break;
                    }
                    if (exit)
                        break;
                }
                else 
                {
                    if (amountOfBottles >= 24)//Om ingen position i backen är tom skrivs det ut att backen är full.
                    {
                        Console.Clear();
                        Console.WriteLine(" The crate is full.");
                        Console.ReadLine();
                        break;
                    }

                }
            } 
        }

        public void PrintCrate() //Metod som skriver ut innehållet i backen med namn, pris och typ.
        {
            Console.WriteLine("  {0,-20} {1,5} {2,15:N3}\n", "Soda", "Price", "Type");
            for (int i = 0; i < crate.Length; i++)
            {
                if (crate[i].name != null)
                {
                    Console.WriteLine("  {0,-20} {1,5:N1}kr {2,15:N3}", crate[i].name, crate[i].price.ToString(), crate[i].type);
                } else
                {
                    Console.WriteLine("  Empty");
                }
            }
            Console.WriteLine("  Press Enter to continue.");
            Console.ReadLine();
        }

        public void CalcTotal() //Beräknar totalpriset av alla drickorna och skriver ut det till användaren.
        {
            if (crate[0].name == null)
            {
                Console.WriteLine("\n Crate is Empty");
                Console.ReadLine();
            } else
            {
                decimal sum = 0;
                for (int i = 0; i < crate.Length; i++)
                {
                    if (crate[i].name != null)
                        sum += Math.Round(crate[i].price);
                }
                Console.WriteLine("\n Your crate is gonna cost " + sum + "kr");
                Console.ReadLine();
            }
            
        }

        public void FindSoda() //Metod som låter användaren söka efter en dricka finns i lager.
        {
            //Loopar igenom sodas och jämför användarinput.
            Console.WriteLine("\n Please type in the name of a drink to see if we have it in stock!");
            Console.Write(" Input: ");
            string search = Console.ReadLine();
            bool inStock = false;
            foreach (Soda soda in stock)
            {
                if (soda.name.ToLower() == search.ToLower())
                {
                    inStock = true;
                    break;
                }
            }
            //Skriver ut om drickan finns i lager eller inte.
            if (inStock)
            {
                Console.WriteLine("\n That soda is in stock!");
                Console.ReadLine();
            } else
            {
                Console.WriteLine("\n Sorry we currently don't have that soda!");
                Console.ReadLine();
            }
        }

        public void SortSodas() //Metod som sorterar listan på drickor i bokstavsordning med hjälp av bubbelsortering.
        {
            //Denna loopen kollar av hur många drickor det finns i vektorn
            int amountOfSodas = -1;
            foreach (Soda drink in crate)
            {
                if (drink.name != null)
                    amountOfSodas += 1;
            }
            //Denna algoritmen sorterar drickorna efter bokstavsordning genom bubbelsortering.
            int max = amountOfSodas - 1;
            for (int i = 0; i < max; i++)
            {
                int nrleft = amountOfSodas - i;
                for (int j = 0; j < nrleft; j++)
                {
                    //Här sparar jag första bokstaven i de två drickorna och jämför dem.
                    char rightFirstLetter = crate[j].name[0];
                    char leftFirstLetter = crate[j + 1].name[0];
                    char rightSecondLetter = crate[j].name[1];
                    char leftSecondLetter = crate[j + 1].name[1];

                    //Här kollar jag ifall första bokstaven i vänster är efter högra i alfabetet eller samma.
                    if (rightFirstLetter > leftFirstLetter || rightFirstLetter == leftFirstLetter)
                    {
                        //Byter plats på bokstäverna.
                        Soda temp = crate[j];
                        crate[j] = crate[j + 1];
                        crate[j + 1] = temp;
                        //Här kollar jag om första bokstäverna är samma och andra bokstaven i vänstra är före den högra bokstaven.
                        if (rightFirstLetter == leftFirstLetter && rightSecondLetter < leftSecondLetter)
                        {
                            //Byter plats på bokstäverna igen.
                            Soda temp2 = crate[j];
                            crate[j] = crate[j + 1];
                            crate[j + 1] = temp2;
                        }
                    }
                }
            }
            Console.WriteLine("\n Your crate has been sorted!!\n" +
                "  Press Enter to continue.");
            Console.ReadLine();
        }
        public void Help()
        {
            Console.WriteLine("Help");
            Console.ReadKey();
        }
        private Soda RandomSoda() //Returnerar en slumpad dricka till drickabacken.
        {
            Random rand = new Random();
            return stock[rand.Next(0, stock.Length)];
        }
        public void AddedBottleMessage(int pos) //Metod som skriver ut vilken dricka som lagts till och antal drickor i backen.
        {
            Console.WriteLine("   You added " + crate[pos].name + " to the crate!\n");
            amountOfBottles++;
            if (amountOfBottles == 1)
            {
                Console.WriteLine("  There is now " + amountOfBottles + " bottle in the crate!\n");
            }
            else
            {
                Console.WriteLine("  There is now " + amountOfBottles + " bottles in the crate!\n");
            }
            Console.WriteLine(" Press enter to add another drink");
            Console.ReadLine();
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            //Ändrar utseendet på konsolen.
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            //Skapar en ny objekt i form av en drickaback.
            var sodacrate = new Sodacrate();
            sodacrate.Run();
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
}

