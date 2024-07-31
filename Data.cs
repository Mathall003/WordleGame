
namespace WordleGame
{
    class Data
    {
        public static string fileLocation = "wordledata.txt";

        //checks for data file, if found, finds username, if not found, creates file
        public static void InitiateDataFile(out User user)
        {
            user = new User(Program.GetName());
            
            var defaultUserString = $"Username: {user.Username}\ngamesPlayed: 0\naverageScore: 0\ngamesWon: 0\ngamesLost: 0\n";
            if (TestForDataFile())
            {
                if(FindName(user.Username!, out int lineNum))
                {
                    user.UpdateUserInfoFromFile();
                }
                else
                {
                    File.AppendAllText(fileLocation, defaultUserString);
                }
            }
            else
            {
                File.WriteAllText(fileLocation, defaultUserString);
            }
        }

        //checks data file for specificed username ,and returns linenum
        public static bool FindName(string name, out int lineNum)
        {
            List<string> lines = File.ReadAllLines(fileLocation).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Equals($"Username: {name}"))
                {
                    lineNum = i;
                    return true;

                }
            }
            lineNum = -1;
            return false;
        }
        //Tests to see if user has needed data file
        public static bool TestForDataFile() => File.Exists(fileLocation);
    }
}