//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

class player
    {
        double userID;
        string firstName;
        string lastName;
        double cnic;
        int won;
        int draw;
        int lost;

        public double userIDProperty
        {
            get{    return userID;  }
            set{    userID = value; }
        }
        public string firstNameProperty
        {
            get{    return firstName;   }
            set{    firstName = value;  }
        }
        public string lastNameProperty
        {
            get{    return lastName;    }
            set{    lastName = value;   }
        }
        public double cnicProperty
        {
            get{    return cnic;    }
            set{    cnic = value;   }
        }
        public int wonProperty
        {
            get{    return won;     }
            set{    won = value;    }
        }
        public int drawProperty
        {
            get {   return draw;    }
            set {   draw = value;   }
        }
        public int lostProperty
        {
            get{    return lost;    }
            set{    lost = value;   }
        }
        public player()
        {
            won = 0;
            draw = 0;
            lost = 0;
        }
        public string fullName(double id) //function that returns concatenation of firstname and lastname
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list

            for (int i = 0; i < playerList.Count; i++) //checks each user in list
            {
                if ((playerList[i] as player).userID == id) //checks for the required user
                {
                    return ((playerList[i] as player).firstName + " " + (playerList[i] as player).lastName); //returns concatenation of firstname and lastname
                }
            }
            return (""); //if user not found
        }
        public bool createNewPlayer(double userID ,string firstName, string lastName, double cnic)
        {
            if (searchUniqueUserID(userID)) //not unique
            {
                return false;
            }
            else
            {
                this.userIDProperty = userID;
                this.firstNameProperty = firstName;
                this.lastNameProperty = lastName;
                this.cnicProperty = cnic;
                writePlayerFile(this); //appends the new player in player file
                return true;
            }
        }
        public bool searchUniqueUserID(double id) //before creating new user this methods checks either the userID is already taken or not
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list

            for (int i = 0; i < playerList.Count; i++)  //checks each user in list
            {
                if ((playerList[i] as player).userID == id) //checks either userID is already taken or not
                {
                    return true;
                }
            }
            return false;
        }
        public bool searchPlayer(string phrase, int type) //to search a specific user in the system
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list
            
            if(type == 1) //search by userID
            {
                double ID = double.Parse(phrase);

                for (int i = 0; i < playerList.Count; i++) //checks each user in list
                {
                    if ((playerList[i] as player).userID == ID) //checks for the requied userID
                    {
                        this.userIDProperty = (playerList[i] as player).userIDProperty;
                        this.firstNameProperty = (playerList[i] as player).firstNameProperty;
                        this.lastNameProperty = (playerList[i] as player).lastNameProperty;
                        this.cnicProperty = (playerList[i] as player).cnicProperty;
                        this.wonProperty = (playerList[i] as player).wonProperty;
                        this.drawProperty = (playerList[i] as player).drawProperty;
                        this.lostProperty = (playerList[i] as player).lostProperty;
                        return true;
                    }
                }
            }
            if (type == 2) //search by name
            {
                for (int i = 0; i < playerList.Count; i++) //checks each user in list
                {
                    if (((playerList[i] as player).firstName + " " + (playerList[i] as player).lastName) == phrase) //checks for the requied name(firstName + lastName)
                    {
                        this.userIDProperty = (playerList[i] as player).userIDProperty;
                        this.firstNameProperty = (playerList[i] as player).firstNameProperty;
                        this.lastNameProperty = (playerList[i] as player).lastNameProperty;
                        this.cnicProperty = (playerList[i] as player).cnicProperty;
                        this.wonProperty = (playerList[i] as player).wonProperty;
                        this.drawProperty = (playerList[i] as player).drawProperty;
                        this.lostProperty = (playerList[i] as player).lostProperty;
                        return true;
                    }
                }
            }
            if (type == 3) //search by cnic
            {
                double num = double.Parse(phrase);

                for (int i = 0; i < playerList.Count; i++) //checks each user in list
                {
                    if ((playerList[i] as player).cnic == num) //check for the required cnic
                    {
                        this.userIDProperty = (playerList[i] as player).userIDProperty;
                        this.firstNameProperty = (playerList[i] as player).firstNameProperty;
                        this.lastNameProperty = (playerList[i] as player).lastNameProperty;
                        this.cnicProperty = (playerList[i] as player).cnicProperty;
                        this.wonProperty = (playerList[i] as player).wonProperty;
                        this.drawProperty = (playerList[i] as player).drawProperty;
                        this.lostProperty = (playerList[i] as player).lostProperty;
                        return true;
                    }
                }
            }
            return false;
        }
        public void displayAllPlayers() //to display all players statistics
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list
            Console.Write("--------------------------------------------------------------------------------");
            Console.WriteLine( "DISPLAY ALL PLAYERS STATISTICS:");
            Console.Write("--------------------------------------------------------------------------------");

            for ( int i = 0; i < playerList.Count; i++ ) //checks each user in list
            {
                Console.WriteLine();
                Console.WriteLine("----------------------");
                Console.WriteLine("Player - " + (i+1) + " Statistics:");
                Console.WriteLine("----------------------" );
                Console.WriteLine("User ID:     " + (playerList[i] as player).userID);
                Console.WriteLine("Name:        " + (playerList[i] as player).firstName + " " + (playerList[i] as player).lastName);
                Console.WriteLine("CNIC:        " + (playerList[i] as player).cnic);
                int gamesPlayed = ((playerList[i] as player).won + (playerList[i] as player).draw + (playerList[i] as player).lost); //number of games played
                Console.WriteLine("SCORE:");
                Console.WriteLine("------");
                Console.WriteLine("Won:         " + (playerList[i] as player).won);
                Console.WriteLine("Draw:        " + (playerList[i] as player).draw);
                Console.WriteLine("Lost:        " + (playerList[i] as player).lost);
                Console.WriteLine("----------------------");
                Console.WriteLine("Total Games: " + gamesPlayed);
                Console.WriteLine("----------------------");
            }
        }
        public ArrayList readPlayerFile() //reads player file and returns ArrayList which containts all players data
        {
            ArrayList playerList = new ArrayList(); //to display all players statistics
            StreamReader readPlayerFile = new StreamReader("Players.txt"); //reading file to list 
            player p;

            while (!readPlayerFile.EndOfStream) //reading file till end
            {
                p = new player();
                p.userID = double.Parse(readPlayerFile.ReadLine());
                p.firstName = readPlayerFile.ReadLine();
                p.lastName = readPlayerFile.ReadLine();
                p.cnic = double.Parse(readPlayerFile.ReadLine());
                p.won = int.Parse(readPlayerFile.ReadLine());
                p.draw = int.Parse(readPlayerFile.ReadLine());
                p.lost = int.Parse(readPlayerFile.ReadLine());
                playerList.Add( p );
            }
            readPlayerFile.Close();
            return playerList; //returning ArrayList which contains all players data
        }
        public void writePlayerFile(player p) //to add new player to the file
        {
            StreamWriter writePlayerFile = new StreamWriter("Players.txt", true); //appending the player file

            writePlayerFile.WriteLine( p.userID );
            writePlayerFile.WriteLine( p.firstName );
            writePlayerFile.WriteLine( p.lastName );
            writePlayerFile.WriteLine( p.cnic );
            writePlayerFile.WriteLine( p.won );
            writePlayerFile.WriteLine( p.draw );
            writePlayerFile.WriteLine( p.lost );

            writePlayerFile.Close();
        }
        public void writePlayerFileList(ArrayList playerList) //to write modified/updated data to file -> modify/update -> game Win/Loss
        {
            StreamWriter writePlayerFile = new StreamWriter("Players.txt"); //not opened in appended mode because all modified/updated data is to write to file -> modify/update -> game Win/Loss

            for (int i = 0; i < playerList.Count; i++) //checks each user in list
            {
                writePlayerFile.WriteLine((playerList[i] as player ).userIDProperty);
                writePlayerFile.WriteLine((playerList[i] as player).firstNameProperty);
                writePlayerFile.WriteLine((playerList[i] as player).lastNameProperty);
                writePlayerFile.WriteLine((playerList[i] as player).cnicProperty);
                writePlayerFile.WriteLine((playerList[i] as player).wonProperty);
                writePlayerFile.WriteLine((playerList[i] as player).drawProperty);
                writePlayerFile.WriteLine((playerList[i] as player).lostProperty);
            }
            writePlayerFile.Close();
        }
        public void playerWon(double id) //takes userID and updates user's won games
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list

            for (int i = 0; i < playerList.Count; i++) //checks each user in list
            {
                if ((playerList[i] as player).userIDProperty == id)
                {
                    (playerList[i] as player).wonProperty = 1 + (playerList[i] as player).wonProperty; //increments in user's won games
                }
            }
            writePlayerFileList(playerList);
        }
        public void playerLost(double id) //takes userID and updates user's won games
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list

            for (int i = 0; i < playerList.Count; i++) //checks each user in list
            {
                if ((playerList[i] as player).userIDProperty == id) //checks if required user is found
                {
                    (playerList[i] as player).lostProperty = 1 + (playerList[i] as player).lostProperty; //increments in user's won games
                }
            }
            writePlayerFileList(playerList);
        }
        public void playerDraw(double id1, double id2) //takes userIDs of player1 and player2 and updates both user's draw games
        {
            ArrayList playerList = new ArrayList(); //player list
            playerList = readPlayerFile(); //reading file to list

            for (int i = 0; i < playerList.Count; i++) //checks each user in list
            {
                if ((playerList[i] as player).userIDProperty == id1)
                {
                    (playerList[i] as player).drawProperty = 1 + (playerList[i] as player).drawProperty; //increments player's draw games
                }
                if ((playerList[i] as player).userIDProperty == id2)
                {
                    (playerList[i] as player).drawProperty = 1 + (playerList[i] as player).drawProperty; //increments player's draw games
                }
            }
            writePlayerFileList( playerList );
        }
    }
//by Muhammad Anas Baig-(01-134152-037)-BS(CS)-5A-VP