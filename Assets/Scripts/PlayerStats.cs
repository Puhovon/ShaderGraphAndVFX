namespace DefaultNamespace
{
    public struct PlayerStats
    {
        public int health;
        public int damage;
        public int level;
        public int armor;
        public int spellResist;

        public PlayerStats(int health, int damage, int level, int armor, int spellResist)
        {
            this.health = health;
            this.damage = damage;
            this.level = level;
            this.armor = armor;
            this.spellResist = spellResist;
        }
    }
}