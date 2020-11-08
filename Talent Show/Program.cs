using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http.Headers;
using FinchAPI;
using System.IO;

namespace Finch_Control
{
    /// <summary>
    /// User Conmands
    /// </summary>
    public enum Command
    {
        none,
        moveforward,
        movebackward,
        stopmotors, 
        wait, 
        turnright,
        turnleft,
        ledon, 
        ledoff,
        gettemperature,
        done

    }

    //
    // *************************************************************
    //  Title: Finch Control
    //  Application type: Console
    //  Descrpition: This is to test the controls of the Finch bot 
    //               using menus and options
    //  Author: Fewins, Dylon P
    //  Date Created: 9/30/2020
    //  Last Modified: 10/18/2020
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

            DisplayLoginRegister();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        #region LOGIN
        /// <summary>
        /// ********************
        /// *  Login Register  *
        /// ********************
        /// </summary>
        static void DisplayLoginRegister()
        {
            DisplayScreenHeader("Login/Register");

            Console.WriteLine("\tAre you a registered user? [yes | no]");
            if (Console.ReadLine().ToLower() == "yes")
            {
                DisplayLogin();
            }
            else
            {
                DisplayRegisterUser();
                DisplayLogin();
            }
        }


        /// <summary>
        /// *********************
        /// *  Register Screen  *
        /// *********************
        /// </summary>
        static void DisplayRegisterUser()
        {
            string userName;
            string password;

            DisplayScreenHeader("Register");

            Console.WriteLine("\tEnter your username:");
            userName = Console.ReadLine();
            Console.WriteLine("\tEnter your password:");
            password = Console.ReadLine();

            WriteLoginInfoData(userName, password);

            Console.WriteLine();
            Console.WriteLine("\tThe information that has been entered will now be saved for later.");
            Console.WriteLine($"\tUsername: {userName}");
            Console.WriteLine($"\tPassword: {password}");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// write login info into the file
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        static void WriteLoginInfoData(string userName, string password)
        {
            string datapath = @"Data/Data.txt";
            string loginInfoText;

            loginInfoText = userName + "," + password;

            File.AppendAllText(datapath, loginInfoText);
        }

        /// <summary>
        /// ******************
        /// *  Login Screen  *
        /// ******************
        /// </summary>
        static void DisplayLogin()
        {
            string userName;
            string password;
            bool validLogin;

            do
            {
                DisplayScreenHeader("Login");

                Console.WriteLine();
                Console.WriteLine("\tEnter your username:");
                userName = Console.ReadLine();
                Console.WriteLine("\tEnter your password:");
                password = Console.ReadLine();

                validLogin = IsValidLoginInfo(userName, password);

                Console.WriteLine();
                if (validLogin)
                {
                    Console.WriteLine("\tYou are now logged in.");
                }
                else
                {
                    Console.WriteLine("\tYour password or username is incorrect");
                    Console.WriteLine("Please try again");
                }
                DisplayContinuePrompt();
            } while (!validLogin);
        }

        /// <summary>
        /// Confirms the use of current password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>true if valid user</returns>
        static bool IsValidLoginInfo(string userName, string password)
        {
            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string password)>();
            bool validUser = false;

            registeredUserLoginInfo = ReadLoginInfoData();

            //
            // Run through the list using tuples
            //
            foreach ((string userName, string password) userLoginInfo in registeredUserLoginInfo)
            {
                if ((userLoginInfo.userName == userName) && (userLoginInfo.password == password))
                {
                    validUser = true;
                    break;
                }
            }

            return validUser;
        }


        /// <summary>
        /// reading from the data file
        /// </summary>
        /// <returns>list of a tuple</returns>
        static List<(string userName, string password)> ReadLoginInfoData()
        {
            string datapath = @"Data/Data.txt";

            string[] loginInfoArray;
            (string userName, string password) loginInfoTuple;

            List<(string userName, string password)> registeredUserLoginInfo = new List<(string userName, string)>();

            loginInfoArray = File.ReadAllLines(datapath);

            //
            // run through array 
            // split into a tuple
            // add the tuple into the list
            //
            foreach (string loginInfoText in loginInfoArray)
            {
                //
                // use a split to keep the username and password apart
                //
                loginInfoArray = loginInfoText.Split(',');

                loginInfoTuple.userName = loginInfoArray[0];
                loginInfoTuple.password = loginInfoArray[1];

                registeredUserLoginInfo.Add(loginInfoTuple);
            }

            return registeredUserLoginInfo;
        }

        #endregion

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
                        TalentShowDisplayMenuScreen(finchBot);
                        break;

                    case "c":
                        DataRecorderDisplayMenuScreen(finchBot);
                        break;

                    case "d":
                        AlarmSystemDisplayMenuScreen(finchBot);
                        break;

                    case "e":
                        UserProgrammingDisplayMenuScreen(finchBot);
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

        #region  ALARM SYSTEM

        ///  <summary>
        ///  ***********************
        ///  *  Alarm System Menu  *
        ///  ***********************
        ///  </summary>
        static void AlarmSystemDisplayMenuScreen(Finch finchBot)
        {
            Console.CursorVisible = true;

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValueLight = 0;
            int minMaxThresholdValueTemperature = 0;
            int timeToMonitor = 0;

            bool quitLightAlarmMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                //  User menu
                //
                Console.WriteLine("\ta) Set Sensors to Monitor");
                Console.WriteLine("\tb) Set Range Type");
                Console.WriteLine("\tc) Maximum/Minimum Light Threshold Value");
                Console.WriteLine("\td) Maximum/Minimum Temperature Threshold Value");
                Console.WriteLine("\te) Set Time to Monitor");
                Console.WriteLine("\tf) Set Alarm");
                Console.WriteLine("\tg) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                //  using user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        sensorsToMonitor = AlarmSystemDisplaySetSensorsToMointor();
                        break;

                    case "b":
                        rangeType = AlarmSystemDisplaySetRangeType();
                        break;

                    case "c":
                        minMaxThresholdValueLight = AlarmSystemDisplayMinMaxThresholdValue(rangeType, finchBot);
                        break;

                    case "d":
                        minMaxThresholdValueTemperature = AlarmSystemDisplayMinMaxTemperatureThresholdValue(rangeType, finchBot);
                        break;

                    case "e":
                        timeToMonitor = AlarmSystemDisplayTimeToMonitor();
                        break;

                    case "f":
                        AlarmSystemDisplaySetAlarm(finchBot, sensorsToMonitor, rangeType, minMaxThresholdValueLight, timeToMonitor, minMaxThresholdValueTemperature);
                        break;

                    case "g":
                        quitLightAlarmMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;

                }
            } while (!quitLightAlarmMenu);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *************************************************
        /// *  Alarm System --> Temperatrue Threshold Menu  *
        /// *************************************************
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchBot"></param>
        /// <returns></returns>
        static int AlarmSystemDisplayMinMaxTemperatureThresholdValue(string rangeType, Finch finchBot)
        {
            int minMaxThresholdValueTemperature;
            bool validResponse = false;

            DisplayScreenHeader("Threshold Value of Temp");

            Console.WriteLine($"\tRoom's current Temperature: {finchBot.getTemperature()}");
            Console.WriteLine();

            do
            {
                Console.Write("\tEnter the {0} light sensor value:", rangeType);
                int.TryParse(Console.ReadLine(), out minMaxThresholdValueTemperature);

                //
                //  Validation
                //
                if (minMaxThresholdValueTemperature <= -20)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a temperature above -20");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine($"\tThe {rangeType} will be set at {minMaxThresholdValueTemperature.ToString("n2")}.");

            DisplayMenuPrompt("Light Alarm");

            return minMaxThresholdValueTemperature;
        }

        /// <summary>
        /// ******************************************
        /// *  Alarm System Menu --> Set Alarm Menu  *
        /// ******************************************
        /// </summary>
        /// <param name="finchBot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValueLight"></param>
        /// <param name="minMaxThresholdValueTemperature"></param>
        /// <param name="timeToMonitor"></param>
        static void AlarmSystemDisplaySetAlarm(
            Finch finchBot, 
            string sensorsToMonitor, 
            string rangeType, 
            int minMaxThresholdValueLight, 
            int timeToMonitor,
            int minMaxThresholdValueTemperature)
        {
            int secondsElapsed = 0;
            int currentLightSensorValue = 0;
            int[] lights = new int[timeToMonitor];
            double currentTemperatureSensorValue;
            bool thresholdExceeded = false;

            DisplayScreenHeader("Set Alarm Menu");

            Console.WriteLine($"\tSensor to be Monitored: {sensorsToMonitor}");
            Console.WriteLine($"\tRange Type: {rangeType}");
            Console.WriteLine($"\t{rangeType} Light Value: {minMaxThresholdValueLight}");
            Console.WriteLine($"\t{rangeType} Temperature Value: {minMaxThresholdValueTemperature}");
            Console.WriteLine($"\tTime to be Monitored: {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin monitoring");
            Console.ReadKey();
            Console.WriteLine();

            //
            //  Data Collection
            //
            while ( (secondsElapsed < timeToMonitor) && !thresholdExceeded)
            {
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = finchBot.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = finchBot.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (finchBot.getLeftLightSensor() + finchBot.getRightLightSensor()) / 2;
                        break;
                }

                currentTemperatureSensorValue = finchBot.getTemperature();

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValueLight || currentTemperatureSensorValue < minMaxThresholdValueTemperature)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValueLight || currentTemperatureSensorValue > minMaxThresholdValueTemperature)
                        {
                            thresholdExceeded = true;
                        }
                        break;
                }
                finchBot.wait(1000);
                Console.WriteLine($"The temperature is {finchBot.getTemperature().ToString("n2")} and the {sensorsToMonitor} sensor is " +
                    $"{currentLightSensorValue}.");
                Console.WriteLine();
                secondsElapsed++;
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"\tThe {rangeType} of {minMaxThresholdValueLight} was exceeded during the test " +
                    $"while the light sensor value became {currentLightSensorValue}.");

                //
                //  play the song hot cross buns
                //
                DisplaySongHotCrossBuns(finchBot);
            }
            else
            {
                Console.WriteLine($"the {rangeType} of {minMaxThresholdValueLight} was not exceeded, but the " +
                    $"{timeToMonitor} seconds have passed.");
                Console.WriteLine($"the current light sensor value is {currentLightSensorValue}." );
            }

            for (int index = 0; index < timeToMonitor; index++)
            {
                lights[index] = finchBot.getRightLightSensor();
            }

            DisplayLightDataTable(lights);

            DisplayMenuPrompt("Light Alarm");
        }

        /// <summary>
        ///   Shows a data from light array 
        /// </summary>
        /// <param name="lights"></param>
        static void DisplayLightDataTable(int[] lights)
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
        ///   Desined to play a song when the threshold is passed
        /// </summary>
        /// <param name="finchBot"></param>
        static void DisplaySongHotCrossBuns(Finch finchBot)
        {
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
            finchBot.wait(1950);
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
        }

        /// <summary>
        /// ************************************
        /// *  Alarm System --> Set Time Menu  *
        /// ************************************
        /// </summary>
        /// <returns></returns>
        static int AlarmSystemDisplayTimeToMonitor()
        {
            int timeToMonitor;
            bool validResponse = false;

            DisplayScreenHeader("Set Time Menu");


            do
            {
                Console.Write("\tHow many seconds would you like the monitor to run?");
                int.TryParse(Console.ReadLine(), out timeToMonitor);

                //
                //  Validation
                //
                if (timeToMonitor <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a postive time interval");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine("The Finch will monitor the light for {0} seconds.", timeToMonitor);


            DisplayMenuPrompt("Light Alarm");

            return timeToMonitor;
        }

            /// <summary>
            /// *************************************
            /// *  Alarm System --> Threshold Menu  *
            /// *************************************
            /// </summary>
            /// <param name="rangeType"></param>
            /// <param name="finchBot"></param>
            /// <returns></returns>
            static int AlarmSystemDisplayMinMaxThresholdValue(string rangeType, Finch finchBot)
            {
                int minMaxThresholdValueLight;
                bool validResponse = false;

                DisplayScreenHeader("Threshold Value");

                Console.WriteLine($"\tLeft light sensor ambient value: {finchBot.getLeftLightSensor()}");
                Console.WriteLine($"\tRight light sensor ambient value: {finchBot.getRightLightSensor()}");
                Console.WriteLine();

                do
                {
                    Console.Write("\tEnter the {0} light sensor value:", rangeType);
                    int.TryParse(Console.ReadLine(), out minMaxThresholdValueLight);

                    //
                    //  Validation
                    //
                    if (minMaxThresholdValueLight <= 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a number response from 0 to 255");
                    }
                    else
                    {
                        validResponse = true;
                    }
                } while (!validResponse);

                Console.WriteLine("\tThe {0} will be set at {1}.", rangeType, minMaxThresholdValueLight);

                DisplayMenuPrompt("Light Alarm");

                return minMaxThresholdValueLight;
            }

        /// <summary>
        /// ***************************************
        /// *  Alarm System --> Set Sensors Menu  *
        /// ***************************************
        /// </summary>
        /// <returns></returns>
        static string AlarmSystemDisplaySetSensorsToMointor()
        {
            string sensorsToMonitor;
            bool validResponse = false;

            DisplayScreenHeader("Sensors to Monitor");


            //
            // Validation block
            //
            do
            {

                Console.Write("\tWhich sensors on the Finch would you like to monitor? [right, left, both] ");
                sensorsToMonitor = Console.ReadLine();

                if (sensorsToMonitor != "right" && sensorsToMonitor != "left" && sensorsToMonitor != "both")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a given option");
                }

                else
                {
                    validResponse = true;
                }



            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine("\tThe {0} sensor will be monitored", sensorsToMonitor);

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;
        }

        /// <summary>
        /// *************************************
        /// *  Alarm System --> Set Range Menu  *
        /// *************************************
        /// </summary>
        /// <returns></returns>
        static string AlarmSystemDisplaySetRangeType()
        {
            string setRangeType;
            bool validResponse = false;

            DisplayScreenHeader("Range Type");


            //
            // Validation block
            //
            do
            {

                Console.Write("\tWhat would you like the range to be? [minimum, maximum] ");
                setRangeType = Console.ReadLine();

                if (setRangeType != "minimum" && setRangeType != "maximum")
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a given option");
                }

                else
                {
                    validResponse = true;
                }



            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine("The Range will have a {0}", setRangeType);

            DisplayMenuPrompt("Light Alarm");

            return setRangeType;
        }

        #endregion

        #region USER PROGRAMMING
        ///  <summary>
        ///  ***************************
        ///  *  User Programming Menu  *
        ///  ***************************
        ///  </summary>
        static void UserProgrammingDisplayMenuScreen(Finch finchbot)
        {
            Console.CursorVisible = true;

            DisplayScreenHeader("User Programming Menu");

            string menuChoice;
            bool quitUserProgrammingMenu = false;

            //
            // tuple vairbles
            //
            (int motorSpeed, int ledBrightness, double waitSeconds) imfromation;
            imfromation.motorSpeed = 0;
            imfromation.ledBrightness = 0;
            imfromation.waitSeconds = 0;

            List<Command> commands = new List<Command>();

            do
            {
                DisplayScreenHeader("Light Alarm Menu");

                //
                //  User menu
                //
                Console.WriteLine("\ta) Set Command Parameters");
                Console.WriteLine("\tb) Add Commands");
                Console.WriteLine("\tc) View Comands");
                Console.WriteLine("\td) Execute Commands");
                Console.WriteLine("\te) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                //  using user's choice
                //
                switch (menuChoice)
                {
                    case "a":
                        imfromation = UserProgrammingDisplaySetCommandParameters();
                        break;

                    case "b":
                        UserProgrammingDisplayGetFinchCommands(commands);
                        break;

                    case "c":
                        UserProgrammingDisplayFinchCommands(commands);
                        break;

                    case "d":
                        UserProgrammingDisplayExecuteFinchCommands(finchbot, commands, imfromation);
                        break;

                    case "e":
                        quitUserProgrammingMenu = true;
                        break;


                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter from the menu choice.");
                        DisplayContinuePrompt();
                        break;

                }
            } while (!quitUserProgrammingMenu);


            DisplayContinuePrompt();
        }

        /// <summary>
        /// ***********************************
        /// *  User Programming --> Excution  *
        /// ***********************************
        /// </summary>
        /// <param name="finchbot"></param>
        /// <param name="commands"></param>
        /// <param name="imfromation"></param>
        static void UserProgrammingDisplayExecuteFinchCommands(Finch finchbot, List<Command> commands, (int motorSpeed, int ledBrightness, double waitSeconds) imfromation)
        {
            int motorSpeed = imfromation.motorSpeed;
            int ledBrightness = imfromation.ledBrightness;
            int waitMilliSeconds = (int)(imfromation.waitSeconds*1000);
            string commandFeedBack = "";
            const int TURNING_MOTOR_SPEED = 100;

            DisplayScreenHeader("Excute Screen");

            Console.WriteLine("\tThe Finch is ready to go");
            DisplayContinuePrompt();

            foreach(Command command in commands)
            {
                switch (command)
                {
                    case Command.none:
                        break;

                    case Command.moveforward:
                        finchbot.setMotors(motorSpeed, motorSpeed);
                        commandFeedBack = Command.moveforward.ToString();
                        break;

                    case Command.movebackward:
                        finchbot.setMotors(-motorSpeed, -motorSpeed);
                        commandFeedBack = Command.movebackward.ToString();
                        break;

                    case Command.stopmotors:
                        finchbot.setMotors(0, 0);
                        commandFeedBack = Command.stopmotors.ToString();
                        break;

                    case Command.wait:
                        finchbot.wait(waitMilliSeconds);
                        commandFeedBack = Command.wait.ToString();
                        break;

                    case Command.turnright:
                        finchbot.setMotors(TURNING_MOTOR_SPEED, -TURNING_MOTOR_SPEED);
                        commandFeedBack = Command.turnright.ToString();
                        break;

                    case Command.turnleft:
                        finchbot.setMotors(-TURNING_MOTOR_SPEED, TURNING_MOTOR_SPEED);
                        commandFeedBack = Command.turnleft.ToString();
                        break;

                    case Command.ledon:
                        finchbot.setLED(ledBrightness, ledBrightness, ledBrightness);
                        commandFeedBack = Command.ledon.ToString();
                        break;

                    case Command.ledoff:
                        finchbot.setLED(0, 0, 0);
                        commandFeedBack = Command.ledoff.ToString();
                        break;

                    case Command.gettemperature:
                        commandFeedBack = $"Temperature: {finchbot.getTemperature().ToString("n2")}\n";
                        break;

                    case Command.done:
                        commandFeedBack = Command.done.ToString();
                        break;

                    default:

                        break;
                }
                Console.WriteLine($"\t{commandFeedBack}");
            }

            DisplayMenuPrompt("User Programming");
        }


        /// <summary>
        /// **********************************
        /// *  User Programming --> Display  *
        /// **********************************
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayFinchCommands(List<Command> commands)
        {
            DisplayScreenHeader("Finch Robot Commands");

            foreach (Command command in commands)
            {
                Console.WriteLine($"\t{command}");
            }

            DisplayMenuPrompt("User Programming");
        }


        /// <summary>
        /// **************************************
        /// *  User Programming --> Asking User  *
        /// **************************************
        /// </summary>
        /// <param name="commands"></param>
        static void UserProgrammingDisplayGetFinchCommands(List<Command> commands)
        {
            Command command = Command.none;

            DisplayScreenHeader("Finch Robot Command");

            //
            // list 
            //
            int commandCount = 1;
            Console.WriteLine("\tList of Commands");
            Console.WriteLine();
            foreach (string commandName in Enum.GetNames(typeof(Command)))
            {
                Console.Write($"-{commandName} -");
                if (commandCount % 5 == 0) Console.Write("-\n\t");
                commandCount++;
            }
            Console.WriteLine();

            while (command != Command.done)
            {
                Console.Write("\tEnter Command: ");

                if (Enum.TryParse(Console.ReadLine().ToLower(), out command))
                {
                    commands.Add(command);
                }
                else
                {
                    Console.WriteLine("\tPlease Enter a Given Option");
                }
            }

            DisplayMenuPrompt("User Programming");
        }

        /// <summary>
        /// ***************************************
        /// *  User Programming --> Set Commands  *
        /// ***************************************
        /// </summary>
        /// <returns>tuples of imformation</returns>
        static (int motorSpeed, int ledBrightness, double waitSeconds) UserProgrammingDisplaySetCommandParameters()
        {
            DisplayScreenHeader("Command Parameters");

            (int motorSpeed, int ledBrightness, double waitSeconds) imformation;
            imformation.motorSpeed = 0;
            imformation.ledBrightness = 0;
            imformation.waitSeconds = 0;

            string userResponse;
            bool validResponse = false;

            do
            {
                Console.Write("\tEnter Motor Speed [1-255]:");
                userResponse = Console.ReadLine();
                int.TryParse(userResponse, out imformation.motorSpeed);

                //
                //  Validation
                //
                if (imformation.motorSpeed <= 1 || imformation.motorSpeed >= 255)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a number on the domain");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            do
            {
                Console.Write("\tEnter LED Brightness [1-255]:");
                userResponse = Console.ReadLine();
                int.TryParse(userResponse, out imformation.ledBrightness);
                validResponse = false;

                //
                //  Validation
                //
                if (imformation.ledBrightness <= 1 || imformation.ledBrightness >= 255)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a number on the domain");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            do
            {
                Console.Write("\tEnter Wait in Seconds:");
                userResponse = Console.ReadLine();
                double.TryParse(userResponse, out imformation.waitSeconds);
                validResponse = false;

                //
                //  Validation
                //
                if (imformation.waitSeconds <= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("\tPlease enter a number on the domain");
                }
                else
                {
                    validResponse = true;
                }
            } while (!validResponse);

            Console.WriteLine();
            Console.WriteLine($"\tMotor Speed: {imformation.motorSpeed}");
            Console.WriteLine($"\tLED Brightness: {imformation.ledBrightness}");
            Console.WriteLine($"\tEnter Wait in Seconds: {imformation.waitSeconds}");

            DisplayMenuPrompt("User Programming");


            return imformation;
        }

        #endregion

        #region  TALENT SHOW

        ///  <summary>
        ///  **********************
        ///  *  Talent Show Menu  *
        ///  **********************
        ///  </summary>
        static void TalentShowDisplayMenuScreen(Finch finchBot)
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
                        TalentShowDisplayLightAndSound(finchBot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchBot);
                        break;

                    case "c":
                        TalentShowDisplayMixingItUp(finchBot);
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
        static void TalentShowDisplayLightAndSound(Finch finchBot)
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
        static void TalentShowDisplayDance(Finch finchBot)
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
        static void TalentShowDisplayMixingItUp(Finch finchBot)
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
        static void DataRecorderDisplayMenuScreen(Finch finchBot)
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
                        numberOfDataPoints = DataRecorderDisplayGetNumberofDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = DataRecorderDisplayGetFrequencyofDataPoints();
                        break;

                    case "c":
                        lights = DataRecorderDisplaySetLights(numberOfDataPoints, dataPointFrequency, finchBot);
                        break;

                    case "d":
                        temperatures = DataRecorderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchBot);
                        break;

                    case "e":
                        DataRecorderDisplayShowData(temperatures, lights);
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

        static int[] DataRecorderDisplaySetLights(int numberOfDataPoints, double dataPointFrequency, Finch finchBot)
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
        static void DataRecorderDisplayShowData(double[] temperatures, int[] lights)
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
                DataRecorderDisplayDataRecorderTable(temperatures);
            }

            Console.WriteLine();
            DisplayContinuePrompt();
            DisplayScreenHeader("Light Table");

            DataRecorderDisplayDataRecorderLights(lights);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Gives data about the lights
        /// </summary>
        /// <param name="lights"></param>
        static void DataRecorderDisplayDataRecorderLights(int[] lights)
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
        static void DataRecorderDisplayDataRecorderTable(double[] temperatures)
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
        static double[] DataRecorderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchBot)
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
        static double DataRecorderDisplayGetFrequencyofDataPoints()
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
        static int DataRecorderDisplayGetNumberofDataPoints()
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
