using System.Collections.Generic;

namespace Craaazy_Space_Survival_Shooter_to_the_X_treme_2000
{
    internal class Program
    {
        //TODO: Finish the resources allocation system, update the KeyEntered slot
        //(or just do it after finishing the Hanger and Crew methods idc)
        public struct Ships
        {
            public int shipNumber;
            public int shipHealth;
            public int weaponUpgrade;
            public int shipResources;
            public int turnCreated;
            public bool hasCrew;
            public bool shipBroken;
            public Ships(int shipNumber, int shipHealth, int weaponUpgrade, int shipResources, int turnCreated, bool hasCrew, bool shipBroken) {
                this.shipNumber = shipNumber;
                this.shipHealth = shipHealth;
                this.weaponUpgrade = weaponUpgrade;
                this.shipResources = shipResources;
                this.turnCreated = turnCreated;
                this.hasCrew = hasCrew;
                this.shipBroken = shipBroken;
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
            int shipNoEntered;
            int i_giveOrTake;
            bool b_giveOrTake;


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
            String s_alienRaceEngaged = "Initial";
            int i_alienRaceEngaged = 0;
            int clanBasePopulation = 1000;
            int yautjaClanPopulation = clanBasePopulation;
            int xenomorphClanPopulation = clanBasePopulation;
            int _MrPoopyButtholeClanPopulation = clanBasePopulation;
            bool raceDefeated = false;
            int currentShipIndex;
            int shipDamageSustained = 0;

            //XenoMorph Clan

            const int x_initialNumbers = 1000;
            int x_numbers = x_initialNumbers;

            //Yautja Clan

            const int y_initialNumbers = 10000;
            int y_numbers = y_initialNumbers;

            //Mr.PoopyButthole Clan

            const int z_initialNumbers = 1000;
            int z_numbers = z_initialNumbers;

            //Hanger Rental
            bool b_hangerRental = false;
            string s_hangerRental = " hanger rental ";
            int numberOfHangers = 0;
            string[] a_planets = { "Krypton", "Arrakis", "Xylew", "Arth", 
                "Dagobah", "Tatooine", "Coruscant", "Mustafar", "Ego", 
                "Hoth", "Caladan", "Gallifrey"};
            int i_buyOrSell;
            bool b_buyOrSell = false;

            //Debt
            int currentDebt = 0;
            double principal = 0;
            const double rate = 0.05;
            double turnsPassed = 0;
            bool debtCountStart = false;

            //Main Loop Control
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
            
            while (allDefeated == false)
            {
                if (i < 5)
                {
                    Tutorial(i);
                }
                else
                {
                    Console.WriteLine("1: Buy Ship (70 Resources) \n2: Buy Weapons Upgrade (16 Resources) " +
                        "\n3: Buy Hanger (2 Resources Per Turn) \n4: Hire Crew (2 Resources Per Turn) \n" +
                        "5: Take On Debt \n6: Pay Off Debt\n 7: Allocate Resources\n 8: End Turn");
                }

                //Increases each ships resources each turn
                ShipResourceManagement(i);

                //Calculates your debt if you have any
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
            void Tutorial(int i)
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
                }
                else if (i == 4 && alreadyInShambles == false)
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
            }
            void AlienClans(int i_alienRaceEngaged, int i_alienAttackStrength)
            {
                switch (i_alienRaceEngaged)
                {
                    case 0:
                        yautjaClanPopulation = yautjaClanPopulation - i_alienAttackStrength;
                        if (yautjaClanPopulation <= 0)
                        {
                            yautjaClanPopulation = 0;
                            yautjaClanDefeated = true;
                            Console.WriteLine("The Yautja Clan has been obliterated");
                        }
                        break;
                    case 1:
                        xenomorphClanPopulation = xenomorphClanPopulation - i_alienAttackStrength;
                        if (xenomorphClanPopulation <= 0)
                        {
                            xenomorphClanPopulation = 0;
                            xenomorphClanDefeated = true;
                            Console.WriteLine("The Xenomorphs have been obliterated");
                        }
                        break;
                    case 2:
                        _MrPoopyButtholeClanPopulation = _MrPoopyButtholeClanPopulation - i_alienAttackStrength;
                        if (_MrPoopyButtholeClanPopulation <= 0)
                        {
                            _MrPoopyButtholeClanPopulation = 0;
                            _MrPoopyButtholeClanDefeated = true;
                            Console.WriteLine("The MrPoopyButthole cultists have been obliterated");
                        }
                        break;
                }
                if (xenomorphClanDefeated == true && yautjaClanDefeated == true && _MrPoopyButtholeClanDefeated == true)
                {
                    allDefeated = true;
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
                    shipList.Add(new Ships(shipNo, 100, 0, 0, i, false, false));
                    shipNo++;
                    currentResources = currentResources - i_ship;
                    CurrentFleet();
                }
                
            }
            void ShipResourceManagement(int i)
            {
                //This manages the resource returns each ship give you as it continues its operation
                for (int n = 0; n < shipList.Count(); n++)
                {
                    double thisShipsResources = Convert.ToDouble(shipList[n].shipResources);
                    //Originally I had it increase per turn but then I realized that could get really busted overtime
                    //double thisShipsTime = Convert.ToDouble(i - shipList[n].turnCreated);

                    /*
                     * shipList[n] ??= new Ships();
                     * shipList[n].shipResources = 0; // (int) (value)
                     * 
                     */
                    if (shipList[n].shipBroken == false)
                    {
                        Ships temp = shipList[n];
                        temp.shipResources = Convert.ToInt32(thisShipsResources * resourceIncreaseRate);
                        shipList[n] = temp;
                    }
                    
                }
                //This removes the resources for your crew
                for (int p = 0; p < shipList.Count(); p++)
                {
                    if (shipList[p].hasCrew == true)
                    {
                        currentResources = currentResources - 2;
                    }
                }
                //This removes resources for the number of hangers you own
                currentResources = currentResources - (numberOfHangers * 2);

                //This heals ships based on the number of hangers you have
                for(int r = 0; r < (1+numberOfHangers); r++)
                {
                    int min = 100;
                    int minShipIndex = 0;
                    for(int s = 0; s < shipList.Count(); s++)
                    {
                        if(min > shipList[s].shipHealth)
                        {
                            min = shipList[s].shipHealth;
                            minShipIndex = s;
                        }
                    }
                    Ships temp = shipList[minShipIndex];
                    temp.shipHealth = 100;
                    temp.shipBroken = false;
                    shipList[minShipIndex] = temp;
                }
            }
            int ShipPicker()
            {
                string s_shipNoEntered = Console.ReadLine();
                int i_shipNoEntered = Convert.ToInt32(s_shipNoEntered);
                Console.WriteLine("You entered: {0}", i_shipNoEntered);
                return i_shipNoEntered;
            }
            void CurrentFleet()
            {
                Console.WriteLine("Here is your current fleet:");
                for (int k = 0; k < shipList.Count(); k++)
                {
                    Console.WriteLine("Ship No. {0} \t Current Upgrade: {1} \t Current Health: {2} \t Current Resources: {3} " +
                        "\t Has Crew: {4} \t Has Hanger {5} ", shipList[k].shipNumber, shipList[k].shipHealth, shipList[k].weaponUpgrade,
                        shipList[k].shipResources, shipList[k].hasCrew, shipList[k].shipBroken);
                }
            }
            void Allocate()
            {
                Console.WriteLine("What ship would you like to allocate resources with?");
                shipNoEntered = ShipPicker();
                for(int o = 0; o < shipList.Count(); o++)
                {
                    if (shipList[o].shipNumber == shipNoEntered)
                    {
                        Console.WriteLine("Would you like to give or take resources (1 / 2)");

                        i_giveOrTake = ShipPicker();
                        if (i_giveOrTake != 1 && i_giveOrTake != 2)
                        {
                            Console.WriteLine("That is not a valid input");
                        } 
                        else
                        {
                            switch(i_giveOrTake) {
                                case 1:
                                    b_giveOrTake = true;
                                    break;
                                case 2:
                                    b_giveOrTake = false;
                                    break;
                            }
                        }
                        if (b_giveOrTake = true)
                        {
                            Console.WriteLine("How many resources would you like to give to this ship?");
                            int transactionAmount = ShipPicker();
                            currentResources = currentResources - transactionAmount;

                            Ships temp = shipList[o];
                            temp.shipResources = temp.shipResources + transactionAmount;
                            shipList[o] = temp;

                        }
                        else if (b_giveOrTake = false)
                        {
                            Console.WriteLine("How many resources would you like to take from this ship?");
                            int transactionAmount = ShipPicker();
                            currentResources = currentResources + transactionAmount;

                            Ships temp = shipList[o];
                            temp.shipResources = temp.shipResources - transactionAmount;
                            shipList[o] = temp;
                        }
                    }
                }

            }
            void WeaponsUpgrades()
            {
                Console.WriteLine("What ship would you like to upgrade?");
                shipNoEntered = ShipPicker();
                for (int l = 0; l < shipList.Count(); l++)
                {
                    if(shipNoEntered == shipList[l].shipNumber)
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
            void buyHanger()
            {
                Console.WriteLine("Would you like to buy or sell a hanger?(1 / 2)");
                i_buyOrSell = ShipPicker();
                if (i_buyOrSell != 1 && i_buyOrSell != 2)
                {
                    Console.WriteLine("That is not a valid input");
                }
                else
                {
                    switch (i_buyOrSell)
                    {
                        case 1:
                            b_buyOrSell = true;
                            break;
                        case 2:
                            b_buyOrSell = false;
                            break;
                    }
                    if (b_buyOrSell == true)
                    {
                        numberOfHangers = numberOfHangers + 1;
                    } 
                    else if (b_buyOrSell == false) 
                    {
                        numberOfHangers = numberOfHangers - 1;
                    }
                }

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
                            currentShipIndex = m;
                            AlienAttack(i, currentShipIndex, i_alienAttackStrength, currentShipStrength, yautjaClanPopulation, xenomorphClanPopulation, _MrPoopyButtholeClanPopulation);
                        }
                    }

                }
            }
            void AlienAttack(int i, int currentShipIndex, int i_alienAttackStrength, int currentShipStrength, int yautjaClanPopulation, int xenomorphClanPopulation, int _MrPoopyButtholeClanPopulation)
            {
                do
                {
                    i_alienRaceEngaged = rand.Next(2);
                    raceDefeated = false;
                    switch (i_alienRaceEngaged)
                    {
                        case 0:
                            if (yautjaClanPopulation == 0)
                            {
                                raceDefeated = true;
                                break;
                            }
                            s_alienRaceEngaged = "Yautja";
                            break;
                        case 1:
                            if (xenomorphClanPopulation == 0)
                            {
                                raceDefeated = true;
                                break;
                            }
                            s_alienRaceEngaged = "Xenomorph";
                            break;
                        case 2:
                            if (_MrPoopyButtholeClanPopulation == 0)
                            {
                                raceDefeated = true;
                                break;
                            }
                            s_alienRaceEngaged = "MrPoopyButthole";
                            break;
                    }
                }
                while (raceDefeated == true);
                if (currentShipStrength*5 >= i_alienAttackStrength)
                {
                    Console.WriteLine("Your ship defeated an Alien ship of the {0} clan", s_alienRaceEngaged);
                    currentResources = currentResources + (i_alienAttackStrength * 5);
                    shipDamageSustained = i_alienAttackStrength - 5;
                    AlienClans(i_alienRaceEngaged, i_alienAttackStrength);
                } 
                else
                {
                    Console.WriteLine("You ship was defeated by an alien ship");
                    currentResources = currentResources - ((i_alienAttackStrength - currentShipStrength * 10) * 5);
                    if (currentResources != Math.Abs(currentResources))
                        shipDamageSustained = i_alienAttackStrength;
                    {
                        currentResources = 0;
                    }
                }
                for (int t = 0; t < shipList.Count(); t++)
                {
                    if (currentShipIndex == t)
                    {
                        Ships temp1 = shipList[t];
                        temp1.shipHealth = temp1.shipHealth - shipDamageSustained;
                        shipList[t] = temp1;
                        if (Math.Abs(shipList[t].shipHealth) != shipList[t].shipHealth || shipList[t].shipHealth == 0)
                        {
                            Ships temp2 = shipList[t];
                            temp2.shipHealth = 0;
                            temp2.shipBroken = true;
                            shipList[t] = temp2;
                            
                        }
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
                Console.WriteLine("What ship would you like to give a crew?");
                shipNoEntered = ShipPicker();
                for (int q = 0; q < shipList.Count(); q++)
                {
                    if (shipList[q].shipNumber == shipNoEntered)
                    {
                        if (shipList[q].hasCrew == true )
                        {
                            Console.WriteLine("This ship already has a crew");
                        } 
                        else if (shipList[q].hasCrew == true)
                        {
                            Ships temp = shipList[q];
                            temp.hasCrew = true;
                            shipList[q] = temp;
                            Console.WriteLine("This ship now has a crew");
                        }
                    }
                }
            }
        }
    }
}