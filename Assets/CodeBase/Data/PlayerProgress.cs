namespace CodeBase.Data
{
    public class PlayerProgress
    {
        public readonly string CurrentLevel;
        public readonly State HeroState;

        public PlayerProgress(string initialLevel)
        {
            CurrentLevel = initialLevel;
            HeroState = new State();
        }
    }
}