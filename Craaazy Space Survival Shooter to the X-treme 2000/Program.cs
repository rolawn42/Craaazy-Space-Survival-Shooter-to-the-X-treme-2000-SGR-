using System.Collections.Generic;

namespace Craaazy_Space_Survival_Shooter_to_the_X_treme_2000
{
    internal class Program
    {
        public struct Ships
        {
            public int shipNumber;
            public int shipHealth;
            public int weaponUpgrade;
            public int shipResources;
            public int turnCreated;
            public bool crew;
            public Ships(int shipNumber, int shipHealth, int weaponUpgrade, int shipResources, int turnCreated, bool crew)
            {
                this.shipNumber = shipNumber;
                this.shipHealth = shipHealth;
                this.weaponUpgrade = weaponUpgrade;
                this.shipResources = shipResources;
                this.turnCreated = turnCreated;
                this.crew = crew;
            }
            
        }

        static void Main(string[] args)
        {
            Ships ship0 = new Ships();
            ship0.shipNumber = 0;

            //Stuff
            Random rand = new Random();
            bool alreadyInShambles = false;

            //Events
            //Ship
            bool b_ship = false;
            string s_ship = " ship ";
            int i_ship = 70;
            int shipNo = 1;
            List<Ships> shipList = new List<Ships>();
            const double resourceIncreaseRate = 0.02;

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
            const int alienAttackOccurs = 50;

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

            //Debt
            int currentDebt = 0;
            double principal = 0;
            const double rate = 0.05;
            double turnsPassed = 0;
            bool debtCountStart = false;

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
                    AlienAttackChance(i);
                }
                else if (i == 1 && currentResources < 16)
                {
                    Console.WriteLine("Your ships will be intercepted and attacked by other Alien ships for your resources" +
                        "\nWeapon Upgrades will make your ships stronger than other ships" +
                        "\nAnd if they can pilfer you... you can pilfer them");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources");
                }
                else if (i == 1 && currentResources >= 16)
                {
                    Console.WriteLine("Your ships will be intercepted and attacked by other Alien ships for your resources" +
                        "\nWeapon Upgrades will make your ships stronger than other ships" +
                        "\nAnd if they can pilfer you... you can pilfer them");
                    Console.WriteLine("I can see you don't quite have enough resources to get the weapon's upgrade \n" +
                        "So instead, you should probably get yourself some more moohlah \n" +
                        "And take on some debt \n" +
                        "But be careful, the more debt you have, the more quickly what you owe back will increase");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources" +
                        "\n5: Take On Debt");
                    alreadyInShambles = true;
                }
                else if (i == 2 && alreadyInShambles == false)
                {
                    Console.WriteLine("Your Ship is gonna need somewhere to land and repair any damages now " +
                        "that you've left the lot " +
                        "\nSo you need you need to rent yourself a hanger");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)");
                }
                else if (i == 2 && alreadyInShambles == true)
                {
                    Console.WriteLine("Your Ship is gonna need somewhere to land and repair any damages now " +
                        "that you've left the lot " +
                        "\nSo you need you need to rent yourself a hanger");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)" +
                        "\n5: Take On Debt");
                }
                else if (i == 3 && alreadyInShambles == false)
                {
                    Console.WriteLine("You've planted this empire, now it's your time to water it from afar" +
                        "\nYou need to buy your ship a crew");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)" +
                        "\n4: Hire Crew (2 Resources Per Turn)");
                }
                else if (i == 3 && alreadyInShambles == true)
                {
                    Console.WriteLine("You've planted this empire, now it's your time to water it from afar" +
                        "\nYou need to buy your ship a crew");
                    Console.WriteLine("1: Buy Ship (70 Resources)" +
                        "\n2: Buy Weapons Upgrade (16 Resources)" +
                        "\n3: Rent Hanger (2 Resources Per Turn)" +
                        "\n4: Hire Crew (2 Resources Per Turn)" +
                        "\n5: Take On Debt");
                } else if (i == 4 && alreadyInShambles == false)
                {
                    Console.WriteLine("Oh... almost forgot\n" +
                        "If you ever need some more moohlah\n" +
                        "You can always take on some debt\n" +
                        "But be careful, the more debt you have, the more quickly what you owe back will increase");
                    Console.WriteLine("1: Buy Ship (70 Resources) \n2: Buy Weapons Upgrade (16 Resources) " +
                        "\n3: Buy Hanger (2 Resources Per Turn) \n4: Hire Crew (2 Resources Per Turn) \n5: Take On Debt \n6: End Turn");
                }
                else
                {
                    Console.WriteLine("1: Buy Ship (70 Resources) \n2: Buy Weapons Upgrade (16 Resources) " +
                        "\n3: Buy Hanger (2 Resources Per Turn) \n4: Hire Crew (2 Resources Per Turn) \n" +
                        "5: Take On Debt \n6: Pay Off Debt\n 7: Allocate Resources\n 8: End Turn");
                }

                for (int n = 0; n < shipList.Count(); n++)
                {
                    double thisShipsResources = Convert.ToDouble(shipList[n].shipResources);
                    double thisShipsTime = Convert.ToDouble(i - shipList[n].turnCreated);

                    /*
                     * shipList[n] ??= new Ships();
                     * shipList[n].shipResources = 0; // (int) (value)
                     * 
                     */
                    Ships temp = shipList[n];
                    temp.shipResources = Convert.ToInt32(thisShipsResources*(1 + thisShipsTime*resourceIncreaseRate));
                    shipList[n] = temp;
                }

                if (debtCountStart == true)
                {
                    turnsPassed++;
                    currentDebt = Convert.ToInt32(principal * (1 + (rate * turnsPassed)));
                }

                //Reads your key input
                ConsoleKeyInfo keyEntered = Console.ReadKey();

                //Found in Stack Overflow (Title: C# Check if ConsoleKeyInfo.KeyChar is a number)
                int inputNumber;
                if (Int32.TryParse(keyEntered.KeyChar.ToString(), out inputNumber))
                {
                    Console.WriteLine("");
                    Console.WriteLine("You pressed {0}", inputNumber);
                    KeyEntered(inputNumber, i);
                    
                } 
                else
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

            void KeyEntered(int inputNumber, int i)
            {
                if (inputNumber > 5 || inputNumber == 0)
                {
                    Console.WriteLine("That is not a valid input");
                } 
                else
                {
                    if (inputNumber == 1)
                    {
                        NewShip(i);
                    } 
                    else if (inputNumber == 2)
                    {
                        WeaponsUpgrades();
                    }
                }
            }
            void NewShip(int i)
            {
                if (currentResources - i_ship != Math.Abs(currentResources - i_ship))
                {
                    Console.WriteLine("You don't have enough Resources");
                } 
                else
                {
                    shipList.Add(new Ships(shipNo, 100, 0, 0, i, false));
                    shipNo++;
                    currentResources = currentResources - i_ship;
                    CurrentFleet();
                }
                
            }
            void CurrentFleet()
            {
                Console.WriteLine("Here is your current fleet:");
                for (int k = 0; k < shipList.Count(); k++)
                {
                    Console.WriteLine("Ship No. {0} \t Current Upgrade: {1} \t Current Health: {2} \t Current Resources: {3} " +
                        "\t Has Crew: {4} ", shipList[k].shipNumber, shipList[k].shipHealth, shipList[k].weaponUpgrade,
                        shipList[k].shipResources, shipList[k].crew);

                }
            }
            void Allocate()
            {
                
            }
            void WeaponsUpgrades()
            {
                Console.WriteLine("What ship would you like to upgrade?");
                string s_shipNoEntered = Console.ReadLine();
                int i_shipNoEntered = Convert.ToInt32(s_shipNoEntered);
                Console.WriteLine("You entered: {0}", i_shipNoEntered);
                for (int l = 0; l < shipList.Count(); l++)
                {
                    if(i_shipNoEntered == shipList[l].shipNumber)
                    {
                        Ships temp = shipList[l];
                        temp.weaponUpgrade = 2;
                        shipList[l] = temp;

                        currentResources = currentResources - i_weaponsUpgrade;

                        CurrentFleet();

                    } 
                    else
                    {
                        Console.WriteLine("That ship does not exist");
                    }
                }

            }
            void Hangers()
            {

            }
            void AlienAttackChance(int i)
            {
                if (i != 1)
                {

                    for (int m = 0; m < shipList.Count(); m++)
                    {
                        if (alienAttackOccurs < i + rand.NextInt64(99))
                        {
                            Int64 l_alienAttackStrength = i + rand.NextInt64(20);
                            int i_alienAttackStrength = Convert.ToInt32(l_alienAttackStrength);
                            int currentShipStrength = shipList[m].weaponUpgrade;
                            AlienAttack(i, i_alienAttackStrength, currentShipStrength);
                        }
                    }

                }
            }
            void AlienAttack(int i, int i_alienAttackStrength, int currentShipStrength)
            {
                if (currentShipStrength*5 >= i_alienAttackStrength)
                {
                    Console.WriteLine("Your ship defeated an Alien ship");
                    currentResources = currentResources + (i_alienAttackStrength * 5);
                } 
                else
                {
                    Console.WriteLine("You ship was defeated by an alien ship");
                    currentResources = currentResources - ((i_alienAttackStrength - currentShipStrength * 10) * 5);
                    if (currentResources != Math.Abs(currentResources))
                    {
                        currentResources = 0;
                    }
                }
            }
            void TakeDebt()
            {
                Console.WriteLine("How much would you like to take on?");
                string s_debtAmountEntered = Console.ReadLine();
                int i_debtAmountEntered = Convert.ToInt32(s_debtAmountEntered);
                Console.WriteLine("You entered: {0}", i_debtAmountEntered);
                if (turnsPassed == 0)
                {
                    debtCountStart = true;
                }
                principal = principal + i_debtAmountEntered;
                currentDebt = Convert.ToInt32(principal);

            }
            void PayDebt()
            {
                Console.WriteLine("How much would you like to remove?");
                string s_reductionAmountEntered = Console.ReadLine();
                int i_reductionAmountEntered = Convert.ToInt32(s_reductionAmountEntered);
                Console.WriteLine("You entered: {0}", i_reductionAmountEntered);
                if (i_reductionAmountEntered < currentResources)
                {
                    Console.WriteLine("You don't have that many resources");
                }
                else
                {
                    currentResources = currentResources - i_reductionAmountEntered;
                    principal = principal - i_reductionAmountEntered;
                    if (principal != Math.Abs(principal))
                    {
                        Console.WriteLine("Umm... you entered more than you owed, we'll just give that back to you\n " +
                            "Look, we're not THAT greedy");
                        currentResources = currentResources + Convert.ToInt32(Math.Abs(principal));
                        principal = 0;
                    }
                    if (principal == 0)
                    {
                        turnsPassed = 0;
                        debtCountStart = false;
                    }
                }
            }
            void Crew()
            {

            }
        }
    }
}