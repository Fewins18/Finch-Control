using System;
using System.Collections.Generic;
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
    //  Last Modified: 10/11/2020
    //  ************************************************************    
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

            //
            //  The song hot cross buns
            finchBot.noteOn(988);
            finchBot.wait(1000);
            finchBot.noteOn(880);
            finchBot.wait(1000);
            finchBot.noteOn(784);
            finchBot.wait(2000);
            finchBot.noteOn(988);
            finchBot.wait(1000);
            finchBot.noteOn(880);
            finchBot.wait(1000);
            finchBot.noteOn(784);
            finchBot.wait(2000);

            finchBot.noteOn(784);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(784);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(784);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(784);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);

            finchBot.noteOn(880);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(880);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(880);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);
            finchBot.noteOn(880);
            finchBot.wait(450);
            finchBot.noteOff();
            finchBot.wait(50);

            finchBot.noteOn(988);
            finchBot.wait(1000);
            finchBot.noteOn(880);
            finchBot.wait(1000);
            finchBot.noteOn(784);
            finchBot.wait(2000);

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
            Console.WriteLine("Would you like movement, true or false?");
            userResponse = Console.ReadLine();
            movement = Convert.ToBoolean(userResponse);
            Console.WriteLine("Would you like sound, true or false?");
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

        #region DATA RECORDER


        /// <summary>
        /// ************************
        /// *  Data Recorder Menu  *
        /// ************************
        /// </summary>
        static void DisplayDataRecorderMenuScreen(Finch finchBot)
        {
            Console.CursorVisible = true;

            string menuChoice;

            bool quitDataRecorderMenu=false;

            int numberOfDataPoints=0;
            double dataPointFrequency=0;
            double[] temperatures = null;
            int[] lights = null;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");
                //
                //  User menu
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Sense Lights");
                Console.WriteLine("\td) Get Temperature");
                Console.WriteLine("\te) Show Data");
                Console.WriteLine("\tf) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                //  using user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        numberOfDataPoints = DisplayGetNumberofDataPoints();
                        break;

                    case "b":
                        dataPointFrequency =DisplayGetFrequencyofDataPoints();
                        break;

                    case "c":
                        lights = DisplaySetLights(numberOfDataPoints, dataPointFrequency, finchBot);
                        break;

                    case "d":
                        temperatures = DisplayGetData(numberOfDataPoints, dataPointFrequency, finchBot);
                        break;

                    case "e":
                        DisplayShowData(temperatures, lights);
                        break;

                    case "f":
                        quitDataRecorderMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;

                }
            } while (!quitDataRecorderMenu);

        }

        private static int[] DisplaySetLights(int numberOfDataPoints, double dataPointFrequency, Finch finchBot)
        {
            int[] lights = new int[numberOfDataPoints];

            DisplayScreenHeader("Sense Lights");

            Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"\tFrequency of Data Points: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot is now ready to being sensing the lights");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                lights[index] = finchBot.getRightLightSensor();
                Console.WriteLine($"\tReading {index + 1} : {lights[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchBot.wait(waitInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("\tThe data has been gathered");

            DisplayContinuePrompt();

            return lights;
        }

        /// <summary>
        /// *********************************
        /// *  Data Recorder --> Show Data  *
        /// *********************************
        /// </summary>
        /// <param name="temperatures"></param>
        static void DisplayShowData(double[] temperatures, int[] lights)
        {
            DisplayScreenHeader("Show Data");

            bool validResponse = false;
            string userResponse;

            //
            // Answer Validation
            //
            do
            {
                Console.WriteLine("\tWould you like your your table in Fahrenheit or Celsius?");
                userResponse = Console.ReadLine().ToLower();
                
                if (userResponse != "fahrenheit" && userResponse != "celsius")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a given option");
                }

                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            if (userResponse == "fahrenheit")
            {
                DisplayFahrenheitTable(temperatures);
            }

            else
            {
                DisplayDataRecorderTable(temperatures);
            }

            Console.WriteLine();
            DisplayContinuePrompt();
            DisplayScreenHeader("Light Table");

            DisplayDataRecorderLights(lights);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Gives data about the lights
        /// </summary>
        /// <param name="lights"></param>
        static void DisplayDataRecorderLights(int[] lights)
        {
            //
            //  Table Header
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Lights".PadLeft(15)
                );

            Console.WriteLine(
                "------------".PadLeft(15) +
                "------------".PadLeft(15)
                );

            //
            //  Table Display
            //
            for (int index = 0; index < lights.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                lights[index].ToString("n2").PadLeft(15)
                );
            }   
        }
        /// <summary>
        /// Give an alternate Option for user
        /// </summary>
        /// <param name="temperatures"></param>
        static void DisplayFahrenheitTable(double[] temperatures)
        {
            double celsiusTemp;
            double fahrenheitTemp;

            //
            //  Table Header
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temperature".PadLeft(15)
                );

            Console.WriteLine(
                "------------".PadLeft(15) +
                "------------".PadLeft(15)
                );

            //
            //  Table Display
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                celsiusTemp = temperatures[index];
                fahrenheitTemp = ConvertCelsiusToFahrenheit(celsiusTemp);
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                fahrenheitTemp.ToString("n2").PadLeft(15)
                );
            }
        }
        /// <summary>
        /// A simple conversion operator
        /// </summary>
        /// <param name="celsiusTemp"></param>
        /// <returns></returns>
        static double ConvertCelsiusToFahrenheit(double celsiusTemp)
        {
            double fahrenheitTemp;
            const double CELSIUS_TO_FAHRENHEIT = 1.8;
            fahrenheitTemp = celsiusTemp * CELSIUS_TO_FAHRENHEIT + 32;

            return fahrenheitTemp;
        }

        /// <summary>
        /// Shows values that are recorder from Get Data in celsius
        /// </summary>
        /// <param name="temperatures"></param>
        static void DisplayDataRecorderTable(double[] temperatures)
        {
            //
            //  Table Header
            //
            Console.WriteLine(
                "Recording #".PadLeft(15) +
                "Temperature".PadLeft(15)
                );

            Console.WriteLine(
                "------------".PadLeft(15) +
                "------------".PadLeft(15)
                );

            //
            //  Table Display
            //
            for (int index = 0; index < temperatures.Length; index++)
            {
                Console.WriteLine(
                (index + 1).ToString().PadLeft(15) +
                temperatures[index].ToString("n2").PadLeft(15)
                );
            }
        }

        /// <summary>
        /// ******************************************
        /// *  Data Recorder --> Gather Data Points  *
        /// ******************************************
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchBot"></param>
        /// <returns></returns>
        static double[] DisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchBot)
        {
            double[] temperatures = new double[numberOfDataPoints];

            DisplayScreenHeader("Get Data");

            Console.WriteLine($"\tNumber of Data Points: {numberOfDataPoints}");
            Console.WriteLine($"\tData Point Frequency: {dataPointFrequency}");
            Console.WriteLine();
            Console.WriteLine("\tThe Finch Robot is now ready to being reading the Temepature");
            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {
                temperatures[index] = finchBot.getTemperature();
                Console.WriteLine($"\tReading {index +1} : {temperatures[index].ToString("n2")}");
                int waitInSeconds = (int)(dataPointFrequency * 1000);
                finchBot.wait(waitInSeconds);
            }

            Console.WriteLine();
            Console.WriteLine("\tThe data has been gathered");

            DisplayContinuePrompt();

            return temperatures;
        }

        /// <summary>
        /// ************************************************
        /// *  Data Recorder --> Frequency of Data Points  *
        /// ************************************************
        /// </summary>
        /// <returns>Frequency of Data Points</returns>
        static double DisplayGetFrequencyofDataPoints()
        {
            double dataPointFrequency;
            string userResponse;
            bool validResponse = false;

            DisplayScreenHeader("Frequency of Data Points");

            do
            {
                Console.Write("\tFrequency of Data Points:");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out dataPointFrequency);

                //
                //  Validation
                //
                if (dataPointFrequency <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a postive interval");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine("\tA data point will be collected at every {0} second(s)", dataPointFrequency);

            DisplayContinuePrompt();

            return dataPointFrequency;
        }

        /// <summary>
        /// *********************************************
        /// *  Data Recorder --> Number of Data Points  *
        /// *********************************************
        /// </summary>
        /// <returns>Number of Data Points</returns>
        static int DisplayGetNumberofDataPoints()
        {
            int numberOfDataPoints;
            bool validResponse =false;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                Console.Write("\tNumber of Data Points:");
                int.TryParse(Console.ReadLine(), out numberOfDataPoints);

                //
                //  Validation
                //
                if (numberOfDataPoints <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a postive integer");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine("\tThere will be {0} data points", numberOfDataPoints);

            DisplayContinuePrompt();

            return numberOfDataPoints;
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
