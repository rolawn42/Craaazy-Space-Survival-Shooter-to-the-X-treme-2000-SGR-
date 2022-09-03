namespace Craaazy_Space_Survival_Shooter_to_the_X_treme_2000
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stuff
            Random rand = new Random();

            //Events
            //Ship
            bool b_ship = false;
            string s_ship = " ship ";
            int i_ship = 70;
            int shipNo = 1;
            List<int> shipList = new List<int>();

            //Weapons Upgrade
            bool b_weaponsUpgrade = false;
            string s_weaponsUpgrade = " weapons upgrade ";
            int i_weaponsUpgrade = 16;

            //Missiles (missles are a little different, the int is the quantity purchased not the amount it costs
            bool b_missiles = false;
            string s_missiles = " missiles ";
            int i_missiles = 3;
            const int missileCost = 4;

            //Aliens (same as above, measures quantity not number of resources)
            bool b_aliens = false;
            string s_aliens = " aliens ";
            int i_aliens = 7;
            const int alienDefeatedReward = 5;
            int alienAttackOccurs = 50;

            //Stolen Goods Recieved
            bool b_stolenGoods = false;
            string s_stolenGoods = " stolen goods ";
            int i_stolenGoods = 112;

            //Hanger Rental
            bool b_hangerRental = false;
            string s_hangerRental = " hanger rental ";
            int i_hangerRental = 20;
            string hangerPlanet = "Xylew";
            string[] a_planets = { "Krypton", "Arrakis", "Xylew", "Arth", 
                "Dagobah", "Tatooine", "Coruscant", "Mustafar", "Ego", 
                "Hoth", "Caladan", "Gallifrey"};

            //XenoMorph Clan

            const int x_initialNumbers = 1000;
            int x_numbers = x_initialNumbers;

            //Yautja Clan

            const int y_initialNumbers = 10000;
            int y_numbers = y_initialNumbers;

            //Mr.PoopyButthole Clan

            const int z_initialNumbers = 1000;
            int z_numbers = z_initialNumbers;

            //Loop Control
            bool xenomorphClanDefeated = false;
            bool yautjaClanDefeated = false;
            bool _MrPoopyButtholeClanDefeated = false;
            bool allDefeated = false;
            int i = 0;

            //Start

            Console.WriteLine("STARWARS INTRO--");

            Console.WriteLine("You're about to begin a new life \nAnd the first thing you'll need is a name");
            string characterName = Console.ReadLine();
            const int startingResources = 100;
            int currentResources = startingResources;

            while (i < 5)
            {
                if (i == 0)
                {
                    Console.WriteLine("Ships carry your resources, which you need to carry to other planets to trade for more resources " +
                        "\nShips will automatically choose to travel to planets which have beneficial trades");
                    Console.WriteLine("1: Buy Ship (70 Resources)");
                    AlienAttack(i);
                } else if (i == 1)
                {
                    Console.WriteLine("Your ships will be intercepted and attacked by other Alien ships for your resources" +
                        "\nWeapon Upgrades will make your ships stronger than other ships" +
                        "\nAnd if they can pilfer you... you can pilfer them");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources");
                }
                else if (i == 2)
                {
                    Console.WriteLine("Your Ship is gonna need somewhere to land and repair any damages now that you've left the lot " +
                        "\nSo you need you need to rent yourself a hanger");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)");
                }
                else if (i == 3)
                {
                    Console.WriteLine("You've planted this empire, now it's your time to water it from afar" +
                        "\nYou need to buy your ship a crew");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)" +
                        "\n4: Hire Crew (2 Resources Per Turn)");
                } else
                {
                    Console.WriteLine("1: Buy Ship (70 Resources) \n2: Buy Weapons Upgrade (16 Resources) " +
                        "\n3: Buy Hanger (20 Resources) \n4: Hire Crew \n5: End Turn");

                    foreach (int ship in shipList)
                    {
                        if (alienAttackOccurs < rand.NextInt64(99))
                        {
                            AlienAttack(i, ship);
                        }
                    }
                }

                //Reads your key input
                ConsoleKeyInfo keyEntered = Console.ReadKey();

                //Found in Stack Overflow (Title: C# Check if ConsoleKeyInfo.KeyChar is a number)
                int inputNumber;
                if (Int32.TryParse(keyEntered.KeyChar.ToString(), out inputNumber))
                {
                    Console.WriteLine("You pressed {0}", inputNumber);
                    KeyEntered(inputNumber);
                    
                } else
                {
                    //I will take this out at the end, but for now I'm using it for testing
                    Console.WriteLine("Unable to parse");
                }

                if (xenomorphClanDefeated == true && yautjaClanDefeated == true && _MrPoopyButtholeClanDefeated == true)
                {
                    allDefeated = true;
                }

                //Print currentResources
                Console.WriteLine(">> Current Resources: " + currentResources);

                //increment
                i++;
            }

            void KeyEntered(int inputNumber)
            {
                if (inputNumber > 5 || inputNumber == 0)
                {
                    Console.WriteLine("That is not a valid input");
                } 
                else
                {
                    if (inputNumber == 1)
                    {
                        Ship();
                    }
                }
            }
            void Ship()
            {
                if (currentResources - i_ship != Math.Abs(currentResources - i_ship))
                {
                    Console.WriteLine("You don't have enough Resources");
                } else
                {
                    shipList.Add(1);
                    Console.WriteLine("Here is your current fleet:");
                    foreach (int ship in shipList)
                    {
                        Console.WriteLine("Ship No. {0} \t Current Upgrade: {1} \t", shipNo, ship);
                        currentResources = currentResources - i_ship;
                    }
                }
                
            }
            void Allocate()
            {
                
            }
            void WeaponsUpgrades()
            {

            }
            void Hangers()
            {

            }
            void AlienAttack(int i, int ship)
            {
                Int64 l_alienAttackStrength = i + rand.NextInt64(20);
                if (1*10 >= l_alienAttackStrength)
                {
                    Console.WriteLine("Your ship defeated an Alien ship");
                    int i_alienAttackStrength = Convert.ToInt32(l_alienAttackStrength);
                    currentResources = currentResources + (i_alienAttackStrength * 5);
                } else
                {
                    Console.WriteLine("You ship was defeated by an alien ship");
                    int i_alienAttackStrength = Convert.ToInt32(l_alienAttackStrength);
                    currentResources = currentResources - ((i_alienAttackStrength-1*10) * 5);
                    if (currentResources != Math.Abs(currentResources))
                    {
                        currentResources = 0;
                    }
                }
            }
            void StolenGoods()
            {

            }
            void Debt()
            {

            }
            void Crew()
            {

            }
        }
    }
}