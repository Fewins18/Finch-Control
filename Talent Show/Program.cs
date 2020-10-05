using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using FinchAPI;

namespace Talent_Show
{
    //
    // *************************************************************
    //  Title: Finch Control
    //  Application type: Console
    //  Descrpition: This is to test the controls of the Finch bot 
    //               using menus and options
    //  Author: Fewins, Dylon P
    //  Date Created: 9/30/2020
    //  Last Modified: 10/4/2020
    //
    class Program
    {
        ///  <summary>
        ///  first method run when the app starts up
        ///  </summary>
        ///  <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }
        ///  <summary>
        ///  setup Console theme
        ///  </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Gray;
        }
        ///  <summary>
        ///  ***************
        ///  *  Main Menu  *
        ///  ***************
        ///  </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchBot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                //  User menu
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Alarm System");
                Console.WriteLine("\te) User Program");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tg) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                //  using user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchBot);
                        break;

                    case "b":
                        DisplayTalentShowMenuScreen(finchBot);
                        break;

                    case "c":
                        DisplayDataRecorderMenuScreen(finchBot);
                        break;

                    case "d":
                        DisplayAlarmSystemMenuScreen(finchBot);
                        break;

                    case "e":
                        DisplayUserProgrammingMenuScreen(finchBot);
                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchBot);
                        break;

                    case "g":
                        DisplayDisconnectFinchRobot(finchBot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }

        /// <summary>
        /// ************************
        /// *  Data Recorder Menu  *
        /// ************************
        /// </summary>
        static void DisplayDataRecorderMenuScreen(Finch finchBot)
        {
            Console.CursorVisible = true;

            DisplayScreenHeader("Data Recorder Menu");

            Console.WriteLine("This module is underdevelopment");
            DisplayContinuePrompt();
        }

        ///  <summary>
        ///  ***********************
        ///  *  Alarm System Menu  *
        ///  ***********************
        ///  </summary>
        static void DisplayAlarmSystemMenuScreen(Finch finchbot)
        {
            Console.CursorVisible = true;

            DisplayScreenHeader("Alarm System Menu");

            Console.WriteLine("This module is underdevelopment");
            DisplayContinuePrompt();
        }

        ///  <summary>
        ///  ***************************
        ///  *  User Programming Menu  *
        ///  ***************************
        ///  </summary>
        static void DisplayUserProgrammingMenuScreen(Finch finchbot)
        {
            Console.CursorVisible = true;

            DisplayScreenHeader("User Programming Menu");

            Console.WriteLine("This module is underdevelopment");
            DisplayContinuePrompt();
        }

        #region  TALENT SHOW

        ///  <summary>
        ///  **********************
        ///  *  Talent Show Menu  *
        ///  **********************
        ///  </summary>
        static void DisplayTalentShowMenuScreen(Finch finchBot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                //  User menu
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing It Up");
                Console.WriteLine("\td) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                //  using user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayLightAndSound(finchBot);
                        break;

                    case "b":
                        DisplayDance(finchBot);
                        break;

                    case "c":
                        DisplayMixingItUp(finchBot);
                        break;

                    case "d":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;

                }
            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *************************************
        /// *  Talent Show --> Light and Sound  *
        /// *************************************
        /// </summary>
        /// <param name="finchBot"></param>
        static void DisplayLightAndSound(Finch finchBot)
        {
            Console.CursorVisible = true;

            

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will now show off its glowing talent!");
            DisplayContinuePrompt();

            //
            //  Code for sound and lights
            //
            for (int green =0; green < 250; green = green + 10)
            {
                finchBot.setLED(0, green, 200);
                finchBot.wait(200);
            }
            for (int blue =25; blue < 255; blue = blue + 5)
            {
                finchBot.setLED(175, 75, blue);
                finchBot.wait(100);
            }
            finchBot.noteOn(494);
            finchBot.wait(1000);
            finchBot.noteOn(440);
            finchBot.wait(1000);
            finchBot.noteOn(392);
            finchBot.wait(1000);
            finchBot.noteOn(494);
            finchBot.wait(1000);
            finchBot.noteOn(440);
            finchBot.wait(1000);
            finchBot.noteOn(392);
            finchBot.wait(1000);
            finchBot.noteOff();
            

            DisplayMenuPrompt("Talent Show Menu");
        }

        /// <summary>
        /// ***************************
        /// *  Talent Show --> Dance  *
        /// ***************************
        /// </summary>
        /// <param name="finchBot"></param>
        static void DisplayDance(Finch finchBot)
        {
            Console.CursorVisible = true;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now do a dance!");
            DisplayContinuePrompt();

            //  
            //  The little dance
            //
            finchBot.setMotors(100, 100);
            finchBot.wait(1000);
            finchBot.setMotors(-100, 100);
            finchBot.wait(1000);
            finchBot.setMotors(-100, -100);
            finchBot.wait(1000);
            finchBot.setMotors(100, -100);
            finchBot.wait(1000);
            finchBot.setMotors(100, 100);
            finchBot.wait(1000);
            finchBot.setMotors(-100, 100);
            finchBot.wait(1000);
            finchBot.setMotors(-100, -100);
            finchBot.wait(1000);
            finchBot.setMotors(100, -100);
            finchBot.wait(1000);
            finchBot.setMotors(0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }

        ///  <summary>
        ///  **********************************
        ///  *  Talent Show --> Mixing It Up  *
        ///  **********************************
        ///  </summary>
        ///  <parm name="finchBot"></parm>
        static void DisplayMixingItUp(Finch finchBot)
        {
            Console.CursorVisible = true;

            string userResponse;
            bool color;
            bool movement;
            bool sound;

            DisplayScreenHeader("Mixing It Up");

            Console.WriteLine("Would you like color, true or false?");
            userResponse = Console.ReadLine();
            color = Convert.ToBoolean(userResponse);
            Console.WriteLine("Would you like sound, true or false?");
            userResponse = Console.ReadLine();
            movement = Convert.ToBoolean(userResponse);
            Console.WriteLine("Would you like movement, true or false?");
            userResponse = Console.ReadLine();
            sound = Convert.ToBoolean(userResponse);
            Console.WriteLine();

            Console.WriteLine("\tThe Finch robot will mix it up!");
            DisplayContinuePrompt();

            if (color && movement && sound)
            {
                Console.WriteLine("So all three");

                finchBot.noteOn(494);
                finchBot.setLED(0, 0, 255);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(440);
                finchBot.setLED(0, 255, 0);
                finchBot.setMotors(-100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(392);
                finchBot.setLED(255, 0, 0);
                finchBot.setMotors(-100, -100);
                finchBot.wait(1000);
                finchBot.noteOn(494);
                finchBot.setLED(150, 150, 0);
                finchBot.setMotors(100, -100);
                finchBot.wait(1000);
                finchBot.noteOn(440);
                finchBot.setLED(0, 150, 150);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(392);
                finchBot.setLED(150, 0, 150);
                finchBot.setMotors(0, 0);
                finchBot.wait(1000);
                finchBot.noteOff();
            }

             if (color && movement)
            {
                finchBot.setLED(0, 0, 255);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.setLED(0, 255, 0);
                finchBot.setMotors(-100, 100);
                finchBot.wait(1000);
                finchBot.setLED(255, 0, 0);
                finchBot.setMotors(-100, -100);
                finchBot.wait(1000);
                finchBot.setLED(150, 150, 0);
                finchBot.setMotors(100, -100);
                finchBot.wait(1000);
                finchBot.setLED(0, 150, 150);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.setLED(150, 0, 150);
                finchBot.setMotors(0, 0);
                finchBot.wait(1000);
            } 

             if (sound && movement)
            {
                finchBot.noteOn(494);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(440);
                finchBot.setMotors(-100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(392);
                finchBot.setMotors(-100, -100);
                finchBot.wait(1000);
                finchBot.noteOn(494);
                finchBot.setMotors(100, -100);
                finchBot.wait(1000);
                finchBot.noteOn(440);
                finchBot.setMotors(100, 100);
                finchBot.wait(1000);
                finchBot.noteOn(392);
                finchBot.setMotors(0, 0);
                finchBot.wait(1000);
                finchBot.noteOff();
            }
             
             else
            {
                Console.WriteLine("There is another place to find that.");
            }

            finchBot.setLED(0, 0, 0);

            DisplayMenuPrompt("Talent Show Menu");
        }
        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// ********************************
        /// *  Disconnect the Finch Robot  *
        /// ********************************
        /// </summary>
        /// <param name="finchBot"></param>
        static void DisplayDisconnectFinchRobot(Finch finchBot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot");
            DisplayContinuePrompt();

            finchBot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnected.");

            DisplayMenuPrompt("Main Menu");
        }

        ///  <summary>
        ///  *****************************
        ///  *  Connect the Finch Robot  *
        ///  *****************************
        ///  </summary>
        ///  <param name="finchBot"></param>
        static bool DisplayConnectFinchRobot(Finch finchBot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchBot.connect();

            while (robotConnected == false)
            {
                Console.WriteLine();
                Console.WriteLine("Please try again to connect");
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("Connection was a success");
            Console.WriteLine();

            //
            //  Confromation on connection
            //
            finchBot.setLED(255, 0, 0);
            finchBot.wait(500);
            finchBot.setLED(100, 100, 0);
            finchBot.wait(500);
            finchBot.setLED(0, 255, 0);
            finchBot.wait(1000);
            finchBot.noteOn(220);
            finchBot.wait(200);

            DisplayMenuPrompt("Main Menu");

            //
            //  Reset Finch 
            //
            finchBot.setLED(0, 0, 0);
            finchBot.noteOff();

            return robotConnected;
        }
        #endregion

        #region USER INTERFACE

        ///  <summary>
        ///  ********************
        ///  *  Welcome Screen  *
        ///  ********************
        ///  </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();
            Console.WriteLine("Welcome User");
            Console.WriteLine();
            Console.WriteLine("This application provides uses for the Finch robot");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        ///  <summary>
        ///  ********************
        ///  *  Closing Screen  *
        ///  ********************
        ///  </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        ///  <summary>
        ///  display continue prompt
        ///  </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        ///  <summary>
        ///  display menu prompt 
        ///  </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        ///  <summary>
        ///  display screen header
        ///  </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }
        #endregion


    }
}
