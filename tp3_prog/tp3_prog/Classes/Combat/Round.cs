namespace tp3_prog
{
    internal class Round : Fight
    {
        public Round(Party heroes, EnemyGroup enemies) : base(heroes)
        {
            Heroes_Party = heroes;
            Enemies_Party = enemies;
        }

        public Party Heroes_Party { get; set; }
        public EnemyGroup Enemies_Party { get; set; }

        // Fonctions that will deal with everything around the combat system,
        // Using the buttons, you can attack and the function will be here.

    }
}
