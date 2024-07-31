namespace WordleGame
{
    public class WordSelector
    {
        public static string? PickSpecificWord(int lineNum) //uses an int parameter to pick specifically from the word list
        {
            return File.ReadLines("wordlist.txt").Skip(lineNum-1).Take(1).First();
        }
        public static string? PickRandomWord() //uses a random to select from the word list
        {
            Random rnd = new Random();
            return File.ReadLines("wordlist.txt").Skip(rnd.Next(0,2309)-1).Take(1).FirstOrDefault();
        }
    }
}