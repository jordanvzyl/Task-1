using System;

namespace Jordan_van_Zyl_GADE1B_A1
{
    // MeleeUnit class inherits from Unit class
    class MeleeUnit : Unit
    {
        Map map;

        // MeleeUnit class constructor that inherits from Unit class
        public MeleeUnit(int pos_X, int pos_Y, int health, int speed, int attack, int attackRange, string team, string symbol) : base(pos_X, pos_Y, health, speed, attack, attackRange, team, symbol)
        {

        }

        // Accessor methods for the properties of the MeleeUnit class
        public int Pos_X { get => pos_X; set => pos_X = value; }
        public int Pos_Y { get => pos_Y; set => pos_Y = value; }
        public int Health { get => health; set => health = value; }
        public int Speed { get => speed; set => speed = value; }
        public int Attack { get => attack; set => attack = value; }
        public int AttackRange { get => attackRange; set => attackRange = value; }
        public string Team { get => team; set => team = value; }
        public string Symbol { get => symbol; set => symbol = value; }

        // Overrride method to set a new position of the unit
        public override void newPosition(int pos_X, int pos_Y, int new_X, int new_Y)
        {
            if (new_X <= 19 && Pos_X == pos_X)
            {
                Pos_X = new_X;
            }
            if (pos_Y <= 19 && Pos_Y == pos_Y)
            {
                Pos_Y = new_Y;
            }
        }

        // Override method to handle the combat with another unit
        public override void combat(Unit[] unit, int pos_X, int pos_Y)
        {
            for (int i = 0; i < unit.Length; i++)
            {
                if (unit[i].Team != Team && unit[i].Pos_X == pos_X && unit[i].Pos_Y == pos_Y)
                {
                    unit[i].Health -= Attack;
                    if (unit[i].Health <= 0)
                    {
                        string type = map.ArrUnit[i].GetType().ToString();
                        string[] splitType = type.Split('.');
                        type = splitType[splitType.Length - 1];
                        map.ArrMap[unit[i].Pos_Y, unit[i].Pos_X] = ".";
                    }
                }
            }
        }

        // Override method to determine whether another unit is within range
        public override bool withinAtkRange(int enemy_X, int enemy_Y)
        {
            int distance_X = Math.Abs(Pos_X - enemy_X);
            int distance_Y = Math.Abs(Pos_Y - enemy_Y);

            int totalDistance = distance_X + distance_Y;

            if (totalDistance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        // Override method to return closest unit's position
        public override string closestUnit(Unit[] unit)
        {
            int closest_X = 1000;
            int closest_Y = 1000;

            int enemy_X;
            int enemy_Y;

            if (team != "Hero")
            {
                for (int i = 0; i < unit.Length; i++)
                {
                    if (unit[i].Team != team)
                    {
                        enemy_X = unit[i].Pos_X;
                        enemy_Y = unit[i].Pos_Y;

                        if (enemy_X != Pos_X && enemy_Y != Pos_Y)
                        {
                            int dist_X = Math.Abs(Pos_X - enemy_X);
                            int dist_Y = Math.Abs(Pos_Y - enemy_Y);

                            if (dist_X < closest_X)
                            {
                                closest_X = enemy_X;
                            }
                            if (dist_Y < closest_Y)
                            {
                                closest_Y = enemy_Y;
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < unit.Length; i++)
                {
                    enemy_X = unit[i].Pos_X;
                    enemy_Y = unit[i].Pos_Y;

                    if (enemy_X != Pos_X && enemy_Y != Pos_Y)
                    {
                        int dist_X = Math.Abs(Pos_X - enemy_X);
                        int dist_Y = Math.Abs(Pos_Y - enemy_Y);

                        if (dist_X < closest_X)
                        {
                            closest_X = enemy_X;
                        }
                        if (dist_Y < closest_Y)
                        {
                            closest_Y = enemy_Y;
                        }
                    }
                }
            }
            string coordinates = closest_X + ";" + closest_Y;
            return coordinates;
        }

        // Method to handle death of unit
        ~MeleeUnit()
        {
            Health = 0;
        }

        // Override method to return a ToString
        public override string ToString()
        {
            string meleeUnit = "";
            meleeUnit += "X-Position: " + "\t" + Pos_X + "\n";
            meleeUnit += "Y-Position: " + "\t" + Pos_Y + "\n";
            meleeUnit += "Health: " + "\t" + Health + "HP" + "\n";
            meleeUnit += "Speed: " + "\t" + Speed + "\n";
            meleeUnit += "Attack: " + "\t" + Attack + "\n";
            meleeUnit += "Attack range: " + "\t" + AttackRange + "\n";
            meleeUnit += "Team: " + "\t" + Team + "\n";
            meleeUnit += "Symbol: " + "\t" + Symbol + "\n";
            return meleeUnit;
        }
    }
}
