//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment1
{
    class consoleMenu
    {
        public void printConsoleMenu() //method to print console menu
        {
            int choice; //variable to store user choices
            do //loop to display after every operation
            {
                Console.Write("--------------------------------------------------------------------------------");
                Console.WriteLine( "MENU:" );
                Console.Write("--------------------------------------------------------------------------------");
                Console.WriteLine("1. Register New Player.");
                Console.WriteLine("2. Search Player.");
                Console.WriteLine("3. Display All Players Statistics.");
                Console.WriteLine("4. Assign Table to One Player.");
                Console.WriteLine("5. Assign Table to Two Players.");
                Console.WriteLine("6. Submit Table Results.");
                Console.WriteLine("7. Display All Tables Status.");
                Console.WriteLine("8. Add New Table to System.");
                Console.WriteLine("9. Display Game Log History.");
                Console.WriteLine("10.Exit." );
                Console.Write("--------------------------------------------------------------------------------");
                Console.WriteLine( "SELECT DESIRED OPERATION:" );
                Console.Write("--------------------------------------------------------------------------------");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    player p = new player();
                    p.createNewPlayer(); //to register new player in the system
                }
                else if (choice == 2)
                {
                    player p = new player();
                    p.searchPlayer(); //to search player in the system
                }
                else if (choice == 3)
                {
                    player p = new player();
                    p.displayAllPlayers(); //to display all players statistics
                }
                else if (choice == 4)
                {
                    table t = new table();
                    Console.Write("--------------------------------------------------------------------------------");
                    Console.WriteLine("ASSIGN TABLE TO ONE PLAYER:");
                    Console.Write("--------------------------------------------------------------------------------");
                    player p = new player();
                    int userID;
                    do //checks either the userID assigning to the table exists or not
                    {
                        Console.WriteLine("Enter Player User-ID:");
                        userID = int.Parse(Console.ReadLine());
                        if (!p.searchUniqueUserID(userID)) //checks either the userID assigning to the table exists or not
                        {
                            Console.WriteLine("ERROR! User-ID not found, please try again.");
                        }
                    }
                    while (!p.searchUniqueUserID(userID)); //checks either the userID assigning to the table exists or not
                    if (!t.assignNewTable(userID)) //checks that all tables are filled or not, if table is partially filled then it will be assigned to that player
                    {
                        Console.WriteLine("PLEASE WAIT! All tables are filled.");
                    }
                }
                else if ( choice == 5 )
                {
                    table t = new table();
                    Console.Write("--------------------------------------------------------------------------------");
                    Console.WriteLine("ASSIGN TABLE TO TWO PLAYERS:");
                    Console.Write("--------------------------------------------------------------------------------");
                    player p = new player();
                    int userOneID;
                    int userTwoID;
                    do //checks either the userID assigning to the table exists or not
                    {
                        Console.WriteLine("Enter Player-1 User-ID:");
                        userOneID = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Player-2 User-ID:");
                        userTwoID = int.Parse(Console.ReadLine());
                        if (!p.searchUniqueUserID(userOneID) && !p.searchUniqueUserID(userTwoID)) //checks either the userID assigning to the table exists or not
                        {
                            Console.WriteLine("ERROR! User-ID not found, please try again.");
                        }
                    }
                    while (!p.searchUniqueUserID(userOneID) && !p.searchUniqueUserID(userTwoID)); //checks either the userID assigning to the table exists or not
                    if (!t.assignNewTable(userOneID, userTwoID)) //checks that all tables are filled or not and then assign table to players
                    {
                        Console.WriteLine("PLEASE WAIT! All tables are filled.");
                    }
                }
                else if (choice == 6)
                {
                    table t = new table();
                    t.submitTableResults(); //to submit results of the table
                }
                else if (choice == 7)
                {
                    table t = new table();
                    t.displayTableList(); //to display all tables status
                }
                else if (choice == 8)
                {
                    table t = new table();
                    t.createNewTable(); //to add new table to system
                }
                else if (choice == 9)
                {
                    table t = new table();
                    t.displayGameLogFile(); //to display game history
                }
                else
                {
                    Console.WriteLine("ERROR! Invalid Input.");
                }
            }
            while (choice != 10); //loop to display after every operation
        }
    }
}
//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP