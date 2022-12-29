namespace lab_2
{
    public class GameAccount
    {
        public string UserName { get; set; }
        public virtual int CurrentRating
        {
            get
            {
                int rating = 100;

                foreach (var game in allGames)
                {
                    rating += game.Rating;
                }

                return rating;
            }
        }
        public int GamesCount
        {
            get
            {
                return allGames.Count;
            }
        }

        protected List<GameHistory> allGames = new List<GameHistory>();

        public GameAccount(string userName)
        {
            UserName = userName;
        }

        public virtual void WinGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            GameHistory game = new GameHistory(idOfTheMatch, this, Opponent, rating, "Win", gameType);
            allGames.Add(game);
        }

        public virtual void LoseGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            if (CurrentRating - rating <= 0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            GameHistory game = new GameHistory(idOfTheMatch, this, Opponent, -rating, "Lose", gameType);
            allGames.Add(game);
        }

        public string GetStats()
        {
            var report = new System.Text.StringBuilder();
            report.AppendLine("Id\tType\tAgainst\t\tResult\tRating");
            foreach (var game in allGames)
            {
                report.AppendLine($"{game.GameId}\t{game.GameType}\t{game.Opponent.UserName}\t\t{game.Result}\t{game.Rating}");
            }
            return report.ToString();
        }
    }

    public class PremiumGameAccount : GameAccount
    {
        public PremiumGameAccount(string userName) : base(userName)
        {
            UserName = userName;
        }

        public override void WinGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            GameHistory game = new GameHistory(idOfTheMatch, this, Opponent, Convert.ToInt32(rating * 1.4), "Win", gameType);
            allGames.Add(game);
        }

        public override void LoseGame(GameAccount Opponent, int rating, int idOfTheMatch, string gameType)
        {
            if (rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rating), "Rating should be positive");
            }
            if (CurrentRating - rating <= 0)
            {
                throw new InvalidOperationException("A Rating is bigger that a rating of the player");
            }
            GameHistory game = new GameHistory(idOfTheMatch, this, Opponent, Convert.ToInt32(-rating * 0.6), "Lose", gameType);
            allGames.Add(game);
        }
    }

    public class UpgradedGameAccount : GameAccount
    {
        public UpgradedGameAccount(string userName) : base(userName)
        {
            UserName = userName;
        }


        public override int CurrentRating
        {
            get
            {
                int rating = 100;
                int streak = 0;
                foreach (var game in allGames)
                {
                    if (String.Equals(game.Result, "Win"))
                    {
                        streak++;
                    }
                    if (streak == 3)
                    {
                        rating += 10;
                        streak = 0;
                    }
                    rating += game.Rating;
                }

                return rating;
            }
        }
    }
    
    //Створення класу, у якому буде історія про користувача
    public class GameHistory
    {
        public int GameId { get; }
        public GameAccount Player { get; }
        public GameAccount Opponent { get; }
        public int Rating { get; }
        public string Result { get; }
        public string GameType { get; }

        public GameHistory(int id, GameAccount player, GameAccount opponent, int rating, string result, string gameType)
        {
            GameId = id;
            GameType = gameType;
            Player = player;
            Opponent = opponent;
            Result = result;
            Rating = rating;
        }
    }
}

