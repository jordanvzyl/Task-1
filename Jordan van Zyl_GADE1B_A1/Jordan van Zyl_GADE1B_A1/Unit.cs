namespace Jordan_van_Zyl_GADE1B_A1
{
    abstract class Unit
    {
        // Protected variables for the unit class
        protected int pos_X;
        protected int pos_Y;
        protected int health;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected string team;
        protected string symbol;

        // Accessor methods for the properties of the MeleeUnit class
        public int Pos_X { get => pos_X; set => pos_X = value; }
        public int Pos_Y { get => pos_Y; set => pos_Y = value; }
        public int Health { get => health; set => health = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Attack { get => attack; set => attack = value; }
        public int AttackRange { get => attackRange; set => attackRange = value; }
        public string Team { get => team; set => team = value; }
        public string Symbol { get => symbol; set => symbol = value; }

        // Unit class constructor to read in values to the base class
        public Unit(int pos_X, int pos_Y, int health, int speed, int attack, int attackRange, string team, string symbol)
        {
            this.pos_X = pos_X;
            this.pos_Y = pos_Y;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
            this.symbol = symbol;
        }

        // Method to move the unit to a new position
        public abstract void newPosition(int pos_X, int pos_Y, int new_X, int new_Y);

        // Method use to handle combat with another unit
        public abstract void combat(Unit[] unit, int pos_X, int pos_Y);

        // Method used to determine whether unit is within attacking range
        public abstract bool withinAtkRange(int enemy_X, int enemy_Y);

        // Method to return the position of the closest unit
        public abstract string closestUnit(Unit[] unit);

        // Method to handle death/destruction of the unit
        ~Unit()
        {

        }

        // ToString method to display all unit's information
        public abstract string ToString();
    }
}
