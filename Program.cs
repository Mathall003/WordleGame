

namespace WordleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            
            bool keepProfile = true;
            while (keepProfile) //starts main loop of application
            {
                Data.InitiateDataFile(out User user);
                keepProfile = true;

                bool play = true;
                while (play) //starts the loop of that specific users profile
                {
                    WriteOptions(user);

                    string? choiceMenu = Console.ReadLine();

                    Console.Clear();
                    switch (choiceMenu) //logic for each of the options in the menu
                    {
                        case "1": //actual Game option
                            bool keepPlaying = true;
                            while (keepPlaying) //starts "want to play again" loop
                            {
                                WordleGame.StartGame(user);

                                bool needAnswer = true;
                                
                                System.Console.Write("Options:\n(1)-");
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("Play");
                                Console.ResetColor();
                                Console.Write(" Again\n(2)-Go back to the ");
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write("Menu\n");
                                Console.ResetColor();
                                                            
                                while (needAnswer) //checks to make sure that answer is 1 or 2
                                { 

                                    string? choicePlayAgain = Console.ReadLine();
                                    
                                    switch (choicePlayAgain)
                                    {
                                        case "1": //keeps playing
                                            needAnswer = false;
                                            Console.Clear();
                                            break;
                                        case "2": //goes back to the menu
                                            needAnswer = false;
                                            keepPlaying = false;
                                            break;
                                        default:
                                            System.Console.WriteLine("Please make sure you input a valid option!\nPress any key to go clear this message. . .");
                                            Console.ReadKey();
                                            ClearLine();
                                            Thread.Sleep(1);
                                            ClearLine();
                                            Thread.Sleep(1);
                                            ClearLine();
                                            break;
                                    }
                                }
                            }

                            break;
                        case "2": //show statictics option
                            user.GetUserInfo(user);
                            Console.ReadKey();
                            break;
                        case "3": //breaks out of play loop to change profiles
                            play = false;
                            break;
                        case "4": //breaks out of both loops to end the game
                            play = false;
                            keepProfile = false;
                            break;
                        default:
                            System.Console.WriteLine("Please make sure you input a valid option!\nPress any key to go back to options. . .");
                            Console.ReadKey();
                            break;
                    }
                    Console.Clear();
                    user.UpdateFileFromUserInfo();
                }
            }
                
                Console.WriteLine("Press any key to exit. . .");
                Console.ReadKey();
        }
        
        static void ClearLine() //clears the last written line
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth)); 
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        public static string GetName() //asks for username, and confirms that it is a valid name
        {
            while (true)
            {
                Console.WriteLine("What is your name? (case sensitive)");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !input.All(char.IsLetterOrDigit))
                {
                    Console.WriteLine("Please make sure that the name only contains letters or digits!");
                    continue;
                }
                Console.Clear();
                return input;
            }
        }
        static void WriteOptions(User user) //writes all the options in color
        {
                System.Console.WriteLine($"Wordle:\tWelcome {user.Username}\n\nOptions:");
                Console.Write("(1)-");

                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write("Play ");
                Console.ResetColor();
                System.Console.Write("the game\n(2)-See your ");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Statistics");
                Console.ResetColor();
                System.Console.Write("\n(3)-Change your ");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Profile");
                Console.ResetColor();
                System.Console.Write("\n(4)-");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Exit ");
                Console.ResetColor();
                System.Console.Write("the game\n");
        }
    }
}