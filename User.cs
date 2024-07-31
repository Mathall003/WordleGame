
namespace WordleGame

    {
    class User(string? username)
    {
        public string? Username
        {
            get => username;
            set => username = !string.IsNullOrEmpty(value) ? value : "Invalid name!";
        }
        public int gamesPlayed;
        public decimal averageScore;
        public int gamesWon;
        public int gamesLost;

        //writes users statistics
        public void GetUserInfo(User user)
        {
            Console.WriteLine($"{user.Username}'s Statistics:");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("\nGames Played: ");
            Console.ResetColor();
            Console.Write($"{user.gamesPlayed}");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nAverage Score: ");
            Console.ResetColor();
            Console.Write($"{Math.Round(user.averageScore,3):G29}");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nGames Won: ");
            Console.ResetColor();
            Console.Write($"{user.gamesWon}");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nGames Lost: ");
            Console.ResetColor();
            Console.Write($"{user.gamesLost}\n");

            Console.Write("\nPress any key to go back to the menu. . .");

        }

        //Takes the users stats from data file and puts it into the users object
        public void UpdateUserInfoFromFile()
        {
            List<string> lines = File.ReadAllLines(Data.fileLocation).ToList();
            Data.FindName(Username!, out int lineNum);

            //Splits lines to separate int value from 
            gamesPlayed = Convert.ToInt32(lines[lineNum + 1].Split(' ')[1]);
            averageScore = Convert.ToDecimal(lines[lineNum + 2].Split(' ')[1]);
            gamesWon = Convert.ToInt32(lines[lineNum + 3].Split(' ')[1]);
            gamesLost = Convert.ToInt32(lines[lineNum + 4].Split(' ')[1]);

        }

        //takes the User properties and rewrites the file with updated properties
        public void UpdateFileFromUserInfo()
        {
            List<string> lines = File.ReadAllLines(Data.fileLocation).ToList();
            Data.FindName(Username!, out int lineNum);

            LineChanger($"gamesPlayed: {gamesPlayed}", lineNum+1);
            LineChanger($"averageScore: {averageScore}", lineNum+2);
            LineChanger($"gamesWon: {gamesWon}", lineNum+3);
            LineChanger($"GamesLost: {gamesLost}", lineNum+4);
        }

        //rewrites a line given the text to update, and line number
        static void LineChanger(string newText, int lineToEdit)
        {
            string[] lineArr = File.ReadAllLines(Data.fileLocation);
            lineArr[lineToEdit] = newText;
            File.WriteAllLines(Data.fileLocation, lineArr);
        }

        public void UpdateUserGameAverage(int newScore)
        {
            averageScore = ((averageScore * (gamesPlayed - 1)) + newScore) / gamesPlayed;
        }

        public void AddUserGamesLost()
        {
            gamesLost++;
            AddUserGamesPlayed();
            UpdateUserGameAverage(7);
        }

        public void AddUserGamesPlayed()
        {
            gamesPlayed++;
        }

        public void AddUserGamesWon(int score)
        {
            gamesWon++;
            AddUserGamesPlayed();
            UpdateUserGameAverage(score);
        }
    }
}
