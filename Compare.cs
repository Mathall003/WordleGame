using System.Linq;

namespace WordleGame
{
    class Compare
    {
        //main function to create lists of correctspots, and incorrect spots for writing with color
        public static void CompareGuessToAnswer(string? guess, string? word, out List<int> correctSpot, out List<int> incorrectSpot)
        {
            char[] guessArr = guess!.ToCharArray();
            char[] wordArr = word!.ToCharArray();
            correctSpot = new List<int>();
            incorrectSpot = new List<int>();

            for (int i = 0; i < wordArr.Length; i++) 
            {
                if (guessArr[i] == wordArr[i]) //checks if the samespot in each word has the same character
                {
                    correctSpot.Add(i);
                }
            }
            for (int i = 0; i < wordArr.Length; i++) 
            {
                if (!correctSpot.Contains(i)) //checks if place is already confirmed as correct spot
                {
                    if (wordArr.Contains(guessArr[i])) //checks if the letter is somewhere in the word
                    {
                            int letterCountInWord = 0;
                            foreach (var character in wordArr)
                            {
                                if (character == guessArr[i]) //gets the total amount of the letterin a word
                                {
                                    letterCountInWord++;
                                }
                            }
                            int letterCountInGuess = 0;
                            foreach (var place in incorrectSpot)
                            {
                                if (guessArr[place] == guessArr[i]) //gets the total amount of the letter in a guess
                                {
                                    letterCountInGuess++;
                                }
                            }
                            int correctLetters = 0;
                            foreach (var place in correctSpot)
                            {
                                if (guess[place] == guess[i]) //gets the total amount of correctletters in a guess
                                {
                                    correctLetters++;
                                }
                            }
                            int lettersNeeded = letterCountInWord-(letterCountInGuess + correctLetters); //calculates how many letters are needed to be put in incorrect spot list
                            if (lettersNeeded >= 1)
                            {
                                incorrectSpot.Add(i);
                            }
                        }
                    }
                }
            }
        }
    }
