//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Assignment1
{
    class table
    {
        int tableID; //stores tableID
        int gameStatus; //stores game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
        DateTime startTime;
        DateTime endTime;
        public player playerOne = new player(); //player1 on table
        public player playerTwo = new player(); //player2 on table

        public int tableIDProperty
        {
            get { return tableID; }
            set { tableID = value; }
        }
        public int gameStatusProperty
        {
            get { return gameStatus; }
            set { gameStatus = value; }
        }
        public double playerOneProperty
        {
            get { return playerOne.userIDProperty; }
            set { playerOne.userIDProperty = value; }
        }
        public double playerTwoProperty
        {
            get { return playerTwo.userIDProperty; }
            set { playerTwo.userIDProperty = value; }
        }
        public DateTime startTimeProperty
        {
            get { return startTime; }
            set { startTime = value; }
        }
        public DateTime endTimeProperty
        {
            get { return endTime; }
            set { endTime = value; }
        }
        public bool searchUniqueTableID(int id) //while creating new table checks either the tableID in already assigned or not
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            tableList = readTableFileList(); //reads tables from file to list

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if ((tableList[i] as table).tableID == id) //checks for the required tableID
                {
                    return true;
                }
            }
            return false;
        }
        public void createNewTable() //to add new table to system
        {
            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine("ADD NEW TABLE TO SYSTEM:");
            Console.Write("--------------------------------------------------------------------------------");

            do
            {
                Console.WriteLine("Enter New Table-ID:");
                this.tableID = int.Parse(Console.ReadLine());
                if (searchUniqueTableID(this.tableID)) //while creating new table checks either the tableID in already assigned or not
                {
                    Console.WriteLine("ERROR! Table-ID already assigned, kindly choose another.");
                }
            }
            while (searchUniqueTableID(this.tableID));

            gameStatusProperty = 0; //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
            playerOneProperty = 0;
            playerTwoProperty = 0;
            startTimeProperty = DateTime.Now;
            endTimeProperty = DateTime.Now;
            Console.WriteLine("Table Successfully Created.");

            writeAddTableFile(this); //appends new to table to table file
        }
        public ArrayList readTableFileList() //reads table file to list and then returns list
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            StreamReader readTableFile = new StreamReader("Tables.txt"); //read file 
            table t;

            while (!readTableFile.EndOfStream) //reads table file till end
            {
                t = new table();
                t.tableIDProperty = int.Parse(readTableFile.ReadLine());
                t.gameStatusProperty = int.Parse(readTableFile.ReadLine());
                t.startTime = DateTime.Parse(readTableFile.ReadLine());
                t.endTime = DateTime.Parse(readTableFile.ReadLine());
                t.playerOneProperty = double.Parse(readTableFile.ReadLine());
                t.playerTwoProperty = double.Parse(readTableFile.ReadLine());
                tableList.Add(t);
            }
            readTableFile.Close();
            return tableList;
        }
        public void writeAddTableFile(table t) //to add new table to the sysem by appending 
        {
            StreamWriter writeTableFile = new StreamWriter("Tables.txt", true); //appending table file

            writeTableFile.WriteLine(t.tableIDProperty);
            writeTableFile.WriteLine(t.gameStatusProperty);
            writeTableFile.WriteLine(t.startTimeProperty);
            writeTableFile.WriteLine(t.endTimeProperty);
            writeTableFile.WriteLine(t.playerOneProperty);
            writeTableFile.WriteLine(t.playerTwoProperty);

            writeTableFile.Close();
        }
        public void writeTableFileList(ArrayList tableList) //to write modified/updated data to file -> modify/update -> table status
        {
            StreamWriter writeTableFile = new StreamWriter("Tables.txt"); //not opened in appended mode because all modified/updated data is to write to file -> modify/update -> table status

            for (int i = 0; i < tableList.Count; i++)
            {
                writeTableFile.WriteLine((tableList[i] as table).tableIDProperty);
                writeTableFile.WriteLine((tableList[i] as table).gameStatusProperty);
                writeTableFile.WriteLine((tableList[i] as table).startTimeProperty);
                writeTableFile.WriteLine((tableList[i] as table).endTimeProperty);
                writeTableFile.WriteLine((tableList[i] as table).playerOneProperty);
                writeTableFile.WriteLine((tableList[i] as table).playerTwoProperty);
            }
            writeTableFile.Close();
        }
        public bool assignNewTable(double playerOneUserID) //to assign new table if one player comes
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            tableList = readTableFileList(); //reads tables from file to list

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if ((tableList[i] as table).gameStatus == 0) //if table is empty
                {
                    (tableList[i] as table).gameStatusProperty = 1; //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                    (tableList[i] as table).startTimeProperty = DateTime.Now;
                    (tableList[i] as table).endTimeProperty = DateTime.Now;
                    (tableList[i] as table).playerOneProperty = playerOneUserID;
                    (tableList[i] as table).playerTwoProperty = 0;
                    writeTableFileList(tableList); //write again to file
                    Console.WriteLine("Table Successfully Assigned.");
                    return true;
                }
                else if ((tableList[i] as table).gameStatus == 1) //if table has 1 playyer then assign the new player to this table
                {
                    (tableList[i] as table).gameStatusProperty = 2; //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                    (tableList[i] as table).startTimeProperty = DateTime.Now;
                    (tableList[i] as table).endTimeProperty = DateTime.Now;
                    (tableList[i] as table).playerTwoProperty = playerOneUserID;
                    writeTableFileList(tableList); //write again to file
                    Console.WriteLine("Table Successfully Assigned.");
                    return true;
                }
            }
            return false;
        }
        public bool assignNewTable(double playerOneUserID, double playerTwoUserID) //to assign new table if two players come
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            tableList = readTableFileList(); //reads tables from file to list

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if ((tableList[i] as table).gameStatus == 0) //if table is empty then assign to them 
                {
                    (tableList[i] as table).gameStatusProperty = 2; //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                    (tableList[i] as table).startTimeProperty = DateTime.Now;
                    (tableList[i] as table).endTimeProperty = DateTime.Now;
                    (tableList[i] as table).playerOneProperty = playerOneUserID;
                    (tableList[i] as table).playerTwoProperty = playerTwoUserID;
                    writeTableFileList(tableList); //write again to file
                    Console.WriteLine("Table Successfully Assigned.");
                    return true;
                }
            }
            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if ((tableList[i] as table).gameStatus == 1) //as no full table is empty so now it will check table where one player is assigned so that they can start game immediately
                {
                    (tableList[i] as table).gameStatusProperty = 2; //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                    (tableList[i] as table).startTimeProperty = DateTime.Now;
                    (tableList[i] as table).endTimeProperty = DateTime.Now;
                    (tableList[i] as table).playerOneProperty = playerOneUserID;
                    (tableList[i] as table).playerTwoProperty = playerTwoUserID;
                    writeTableFileList(tableList);
                    Console.WriteLine("Table Successfully Assigned.");
                    return true;
                }
            }
            return false;
        }
        public void displayTableList() //to display all tables status
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            tableList = readTableFileList(); //reads tables from file to list

            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine("DISPLAY ALL TABLES STATUS:");
            Console.Write("--------------------------------------------------------------------------------");

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine("Table-ID: " + (tableList[i] as table).tableID);
                Console.WriteLine("----------------------");
                if ((tableList[i] as table).gameStatus == 0) //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                {
                    Console.WriteLine("0 Players Assigned.");
                }
                else if ((tableList[i] as table).gameStatus == 1) //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                {
                    player p = new player();
                    Console.WriteLine("1 Player Assigned.");

                    string playerOneName = p.fullName((tableList[i] as table).playerOneProperty);
                    Console.WriteLine("1. Player-1 (ID-" + (tableList[i] as table).playerOneProperty + ") " + playerOneName);
                    Console.WriteLine("Start Time:" + (tableList[i] as table).startTimeProperty);
                }
                if ((tableList[i] as table).gameStatus == 2) //game status i.e. 0->Empty Table, 1->One Player Assigned, 2->Two Players Assigned
                {
                    player p = new player();
                    Console.WriteLine("2 Players Assigned.");

                    string playerOneName = p.fullName((tableList[i] as table).playerOneProperty);
                    string playerTwoName = p.fullName((tableList[i] as table).playerTwoProperty);
                    Console.WriteLine("1. Player-1 (ID-" + (tableList[i] as table).playerOneProperty + ") " + playerOneName);
                    Console.WriteLine("2. Player-2 (ID-" + (tableList[i] as table).playerTwoProperty + ") " + playerTwoName);
                    Console.WriteLine("Start Time:" + (tableList[i] as table).startTimeProperty);
                }
            }
        }
        public void submitTableResults() //to submit game results and clear table status
        {
            ArrayList tableList = new ArrayList(); //ArrayList to store list of tables
            tableList = readTableFileList(); //reads tables from file to list

            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine("SUBMIT TABLE RESULTS:");
            Console.Write("--------------------------------------------------------------------------------");

            Console.WriteLine("Enter Table-ID:");
            int id = int.Parse(Console.ReadLine());

            for (int i = 0; i < tableList.Count; i++) //checks each table
            {
                if ((tableList[i] as table).tableID == id) //checks for the required table
                {
                    player p = new player();
                    Console.WriteLine("Select Won User:"); //asks for the won user
                    string playerOneName = p.fullName((tableList[i] as table).playerOneProperty);
                    string playerTwoName = p.fullName((tableList[i] as table).playerTwoProperty);
                    Console.WriteLine("1. Player-1 (ID-" + (tableList[i] as table).playerOneProperty + ") " + playerOneName);
                    Console.WriteLine("2. Player-2 (ID-" + (tableList[i] as table).playerTwoProperty + ") " + playerTwoName);
                    Console.WriteLine("3. Game Draw.");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        p.playerWon((tableList[i] as table).playerOneProperty); //updates won status of player1
                        p.playerLost((tableList[i] as table).playerTwoProperty); //updates lost status of player2
                    }
                    else if (choice == 2)
                    {
                        p.playerWon((tableList[i] as table).playerTwoProperty); //updates won status of player2
                        p.playerLost((tableList[i] as table).playerOneProperty); //updates lost status of player1
                    }
                    else if (choice == 3)
                    {
                        p.playerDraw((tableList[i] as table).playerOneProperty, (tableList[i] as table).playerTwoProperty); //updates draw status of both users
                    }
                    else
                    {
                        Console.WriteLine("ERROR!!! Invalid Input.");
                    }
                    (tableList[i] as table).endTimeProperty = DateTime.Now;

                    StreamWriter writeGameLogFile = new StreamWriter("GameLog.txt", true);
                    writeGameLogFile.WriteLine((tableList[i] as table).tableIDProperty);
                    writeGameLogFile.WriteLine((tableList[i] as table).playerOneProperty);
                    writeGameLogFile.WriteLine((tableList[i] as table).playerTwoProperty);
                    writeGameLogFile.WriteLine((tableList[i] as table).startTimeProperty);
                    writeGameLogFile.WriteLine((tableList[i] as table).endTimeProperty);
                    writeGameLogFile.Close();

                    (tableList[i] as table).gameStatus = 0; //clears table status to empty
                    (tableList[i] as table).playerOneProperty = 0; //clears table player1 to empty
                    (tableList[i] as table).playerTwoProperty = 0; //clears table player2 to empty
                    writeTableFileList(tableList);
                    return;
                }
            }
        }
        public void displayGameLogFile() //to display game history
        {
            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine("DISPLAY GAME LOG HISTORY:");
            Console.Write("--------------------------------------------------------------------------------");

            double id;
            double player1ID;
            double player2ID;
            DateTime start;
            DateTime end;

            StreamReader readGameLogFile = new StreamReader("GameLog.txt");
            while (!readGameLogFile.EndOfStream) //reads game log file till end
            {
                id = double.Parse(readGameLogFile.ReadLine());
                player1ID = double.Parse(readGameLogFile.ReadLine());
                player2ID = double.Parse(readGameLogFile.ReadLine());
                start = DateTime.Parse(readGameLogFile.ReadLine());
                end = DateTime.Parse(readGameLogFile.ReadLine());

                Console.WriteLine("T-ID:" + id + " | P1-ID:" + player1ID + " | P2-ID:" + player2ID + " | START:" + start + " | END:" + end);
            }
        }
    }
}
//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP