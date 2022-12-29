namespace lab_2
{
    public abstract class Start
    {
        protected static int Id = 0;

        protected Random random = new Random();

        public abstract string GameType { get; }

        protected abstract int GenerateRating();



        public virtual void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(1, 3);
            if (winnerSide == 1)
            {
                firstPlayer.WinGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, rating, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, rating, Id, this.GameType);
            }
            Id++;
        }
    }

    public class BasicStart : Start
    {
        public override string GameType
        {
            get
            {
                return "Basic";
            }
        }

        protected override int GenerateRating()
        {
            return 0;
        }
    }

    public class RankedStart : Start
    {
        public override string GameType
        {
            get
            {
                return "Ranked";
            }
        }

        protected override int GenerateRating()
        {
            return random.Next(10, 15);
        }
    }

    public class SafeStart : Start
    {
        public override string GameType
        {
            get
            {
                return "Safe";
            }
        }

        protected override int GenerateRating()
        {
            return random.Next(10, 15);
        }

        public override void PlayGame(GameAccount firstPlayer, GameAccount secondPlayer)
        {
            int rating = this.GenerateRating();
            int winnerSide = random.Next(1, 3);
            if (winnerSide == 1)
            {
                firstPlayer.WinGame(secondPlayer, rating, Id, this.GameType);
                secondPlayer.LoseGame(firstPlayer, 0, Id, this.GameType);
            }
            else
            {
                firstPlayer.LoseGame(secondPlayer, 0, Id, this.GameType);
                secondPlayer.WinGame(firstPlayer, rating, Id, this.GameType);
            }
            Id++;
        }
    }
    class GameType
    {
        public Start getBasicGame()
        {
            return new BasicStart();
        }

        public Start getRankedGame()
        {
            return new RankedStart();
        }

        public Start getSafeGame()
        {
            return new SafeStart();
        }
    }
}
