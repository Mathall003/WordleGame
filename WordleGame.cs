using System.Windows;
using System.Media;

namespace WordleGame
{
    class WordleGame
    {
        public decimal averageScore = 0;
        public int gamesPlayed = 0;
        public static void StartGame(User user) //plays the main game
        {
            Guess guess = new Guess
            {
                //for testing
                //Word = WordSelector.PickSpecificWord() //<-line number in wordlist goes here  

                //for game
                Word = WordSelector.PickRandomWord()
            };
            bool hasWon = false;
            int guessNumber = 0;
            while (!hasWon && guessNumber <= 7) //starts guessing loop
            {
                switch (guessNumber) 
                {
                    /*
                    case x:
                        writes the users guess to guess.guess(x+1)
                        checks if that guess is the same as the word
                        if so it sets hasWon to true, and plays the Won method
                    */
                    case 0:
                        guess.Guess1 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess1 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber, guess, user);
                        }
                        break;
                    case 1:
                        guess.Guess2 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess2 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber, guess, user);
                        }
                        break;
                    case 2:
                        guess.Guess3 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess3 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber, guess, user);
                        }
                        break;
                    case 3:
                        guess.Guess4 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess4 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber, guess, user);
                        }
                        break;
                    case 4:
                        guess.Guess5 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess5 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber, guess, user);
                        }
                        break;
                    case 5:
                        guess.Guess6 = GetGuess(guessNumber,guess, user);
                        if (guess.Guess6 == guess.Word)
                        {
                            hasWon = true;
                            Won(guessNumber,guess,user);
                        }
                        break;
                    case 6:
                        WriteTemplate(guessNumber+1, guess, true, user);
                        break;
                }
                guessNumber++;
            }
            if (!hasWon) //plays if user loses
            {
                user.AddUserGamesLost();
                Thread.Sleep(500);
                System.Console.Write($"\n\nSorry the word was ");
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.Write($"{guess.Word!.ToUpper()}");
                Console.ResetColor();
                System.Console.Write(", better luck next time!\n");
            }


        }
        //based on the guess number, writes the previous guesses, and the start of current guess
        static void WriteTemplate(int guessNum, Guess guess, bool firstTime, User user) 
        {
            switch (guessNum)
            {   
                case 0:
                    break;
                case 1:
                    System.Console.Write("\n(1/6)-");
                    WriteWithColor(guess.Guess1, guess.Word, firstTime);
                    break;
                case 2:
                    WriteTemplate(1,guess,false, user);
                    System.Console.Write("\n(2/6)-");
                    WriteWithColor(guess.Guess2, guess.Word, firstTime);
                    break;
                case 3:
                    WriteTemplate(2,guess,false, user);
                    System.Console.Write("\n(3/6)-");
                    WriteWithColor(guess.Guess3, guess.Word,firstTime);
                    break;
                case 4:
                    WriteTemplate(3,guess,false, user);
                    System.Console.Write("\n(4/6)-");
                    WriteWithColor(guess.Guess4, guess.Word,firstTime);
                    break;
                case 5:
                    WriteTemplate(4,guess,false, user);
                    System.Console.Write("\n(5/6)-");
                    WriteWithColor(guess.Guess5, guess.Word,firstTime);
                    break;
                case 6:
                    WriteTemplate(5,guess,false, user);
                    System.Console.Write("\n(6/6)-");
                    WriteWithColor(guess.Guess6, guess.Word,firstTime);
                    break;
                case 7:
                    System.Console.WriteLine($"Wordle-\t{user.Username}");
                    WriteTemplate(6, guess, true, user);
                    Thread.Sleep(500);
                    break;
                default:
                    break;
            }
        }
        static string? GetGuess(int guessNum, Guess guessObj, User user) //writes users guess to string, as well check to make sure its a valid guess
        {
            while(true)
            {
                System.Console.WriteLine($"Wordle-\t{user.Username}");
                WriteTemplate(guessNum, guessObj, true, user);
                Console.Write($"\n({guessNum+1}/6)-");
                string? guess = Console.ReadLine()!.ToLower();

                if(!CheckIfValidGuess(guess))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Invalid Guess!");
                    Console.ResetColor();
                    System.Console.WriteLine("Press Any Key to try again. . .");
                    Console.ReadKey();
                    Console.Clear();
                }
                else 
                {
                    
                    Console.Clear();
                    return guess;
                }
            }
        }
        static bool CheckIfValidGuess(string? guess) //checks to see if the guess is in the word list file
        {
            if(guess!.Length != 5 || !FindGuessInFile(guess)) //checks to make sure word is 5 letters and in file
            {
                return false;
            }
                return true;
        }
        static bool FindGuessInFile(string? guess) //uses the first letter to quickly find if the word is in final
        {
            char firstChar = guess!.ToLower()[0];
            return firstChar switch
            {
                'a' => CheckAgainstFile(1, 868, guess),
                'b' => CheckAgainstFile(868, 1871, guess),
                'c' => CheckAgainstFile(1871, 2841, guess),
                'd' => CheckAgainstFile(2841, 3576, guess),
                'e' => CheckAgainstFile(3576, 3906, guess),
                'f' => CheckAgainstFile(3906, 4552, guess),
                'g' => CheckAgainstFile(4552, 5237, guess),
                'h' => CheckAgainstFile(5237, 5769, guess),
                'i' => CheckAgainstFile(5769, 5950, guess),
                'j' => CheckAgainstFile(5950, 6174, guess),
                'k' => CheckAgainstFile(6174, 6603, guess),
                'l' => CheckAgainstFile(6603, 7228, guess),
                'm' => CheckAgainstFile(7228, 8179, guess),
                'n' => CheckAgainstFile(8179, 8647, guess),
                'o' => CheckAgainstFile(8645, 8999, guess),
                'p' => CheckAgainstFile(8999, 10129, guess),
                'q' => CheckAgainstFile(10129, 10232, guess),
                'r' => CheckAgainstFile(10232, 11027, guess),
                's' => CheckAgainstFile(11027, 12693, guess),
                't' => CheckAgainstFile(12693, 13575, guess),
                'u' => CheckAgainstFile(13575, 13793, guess),
                'v' => CheckAgainstFile(13793, 14076, guess),
                'w' => CheckAgainstFile(14076, 14510, guess),
                'x' => CheckAgainstFile(14510, 14528, guess),
                'y' => CheckAgainstFile(14528, 14733, guess),
                'z' => CheckAgainstFile(14733, 14855, guess),
                _ => false
            };
        }
        static bool CheckAgainstFile(int startLine, int endLine, string? guess) // checks to see if a string is in a file, between a start and end line
        {
            for (int i = startLine-1; i < endLine; i++)
            {
                if (File.ReadLines("acceptedwords.txt").Skip(i).Take(1).First() == guess!.ToLower())
                {
                    return true;
                }
            }
            return false;
        }
        static void WriteWithColor(string? guess, string? word, bool firstTime)//takes the list of spots and uses them to write the guess in correct color
        {
            char[] guessArr = guess!.ToCharArray();
            Compare.CompareGuessToAnswer(guess, word, out List<int> correctSpot, out List<int> incorrectSpot);

            for (int i = 0; i < guessArr.Length; i++)
            {
                if (firstTime)
                {
                    Thread.Sleep(200);
                }
                    
                if (correctSpot.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(guessArr[i].ToString().ToUpper());
                    Console.ResetColor();
                }
                else if (incorrectSpot.Contains(i))
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(guessArr[i].ToString().ToUpper());
                    Console.ResetColor(); 
                }
                else
                {
                    Console.Write(guessArr[i].ToString().ToUpper());
                }
            }
        }
        static void Won(int guessNumber, Guess guess, User user) //plays win function
        {
            user.AddUserGamesWon(guessNumber+1);
            System.Console.WriteLine($"Wordle-\t{user.Username}");
            WriteTemplate(guessNumber+1, guess, true, user);
            Thread.Sleep(500);
            System.Console.Write("\n\nCongratulations on guessing the correct word: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{guess.Word!.ToUpper()}");
            Console.ResetColor();
            Console.Write("!\n");

        }
    }
}