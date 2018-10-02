using System;

namespace Jordan_van_Zyl_GADE1B_A1
{
    class Map
    {
        // Array to store map of battlefield and units on the battlefield
        string[,] arrMap = new string[20, 20];

        // Declare both unit type objects as well as a type Unit array to store them
        MeleeUnit m_Unit;
        RangedUnit r_Unit;
        Unit[] arrUnit;

        // Get methods
        public Unit[] ArrUnit { get => arrUnit; set => arrUnit = value; }
        public RangedUnit R_Unit { get => r_Unit; set => r_Unit = value; }
        public MeleeUnit M_Unit { get => m_Unit; set => m_Unit = value; }
        public string[,] ArrMap { get => arrMap; set => arrMap = value; }

        // Random object rnd declared
        Random rnd = new Random();

        int numUnits;

        public Map()
        {
            // Populate the arrMap array with the battlefield
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    ArrMap[i, j] = ".";
                }
            }

            // Randomly generate a number of units to placed on the map and instantiate the arrunit array
            numUnits = rnd.Next(1, 51);
            ArrUnit = new Unit[numUnits];

            // Add the units to the map
            int unitCount = 0;
            while (unitCount < numUnits)
            {
                // Generate random properties for each unit
                int pos_X = rnd.Next(0, 20);
                int pos_Y = rnd.Next(0, 20);
                int health = 100;
                int speed = rnd.Next(1, 3);
                int attack = rnd.Next(1, 5);
                int atkRange = rnd.Next(1, 11);
                string team = "";
                string symbol = "";

                // Randomise the unit type that will be added to the array
                int unitType = rnd.Next(1, 3);
                int typeteam = rnd.Next(1, 3);

                // Add a Melee unit to the map array
                if (unitType == 1)
                {
                    if (typeteam == 1)
                    {
                        team = "Hero";
                        symbol = "M";
                        M_Unit = new MeleeUnit(pos_X, pos_Y, health, speed, attack, 1, team, symbol);

                        if (ArrMap[pos_Y, pos_X] == ".")
                        {

                            ArrUnit[unitCount] = M_Unit;
                            ArrMap[pos_Y, pos_X] = symbol;
                            unitCount++;
                        }
                    }
                    else
                    {
                        team = "Villain";
                        symbol = "m";
                        M_Unit = new MeleeUnit(pos_X, pos_Y, health, speed, attack, 1, team, symbol);

                        if (ArrMap[pos_Y, pos_X] == ".")
                        {

                            ArrUnit[unitCount] = M_Unit;
                            ArrMap[pos_Y, pos_X] = symbol;
                            unitCount++;
                        }
                    }
                }
                // Add a Ranged unit to the map array
                else
                {
                    if (typeteam == 1)
                    {
                        team = "Hero";
                        symbol = "R";
                        R_Unit = new RangedUnit(pos_X, pos_Y, health, speed, attack, atkRange, team, symbol);

                        if (ArrMap[pos_Y, pos_X] == ".")
                        {
                            ArrUnit[unitCount] = R_Unit;
                            ArrMap[pos_Y, pos_X] = symbol;
                            unitCount++;
                        }
                    }
                    else
                    {
                        team = "Villain";
                        symbol = "r";
                        R_Unit = new RangedUnit(pos_X, pos_Y, health, speed, attack, atkRange, team, symbol);

                        if (ArrMap[pos_Y, pos_X] == ".")
                        {
                            ArrUnit[unitCount] = R_Unit;
                            ArrMap[pos_Y, pos_X] = symbol;
                            unitCount++;
                        }
                    }
                }
            }

        }

        // Method to move a unit to a specific position
        public void moveSpecific(string type, int pos_X, int pos_Y, int new_X, int new_Y)
        {
            if(type == "MeleeUnit")
            {
                M_Unit.newPosition(pos_X, pos_Y, new_X, new_Y);
            }
            else
            {
                R_Unit.newPosition(pos_X, pos_Y, new_X, new_Y);
            }
        }

        // Method to update the position of a specific unit
        public void updatePosition(string type, string symbol, int pos_X, int pos_Y, int newPos_X, int newPos_Y, int speed)
        {
            int count_X = 0;
            int count_Y = 0;
            /*
            if(count_Y != newPos_Y)
            {
                if(count_X != newPos_X)
                {
                    count_X++;
                    if(newPos_X > pos_X && pos_X + count_X <= 19)
                    {
                        if (type == "MeleeUnit")
                        {
                            arrMap[pos_Y, pos_X + count_X] = symbol;
                            arrMap[pos_Y, pos_X] = ".";
                            m_Unit.newPosition(pos_X, pos_Y, pos_X + count_X, pos_Y);
                        }
                        else
                        {
                            arrMap[pos_Y, pos_X + count_X] = symbol;
                            arrMap[pos_Y, pos_X] = ".";
                            r_Unit.newPosition(pos_X, pos_Y, pos_X + count_X, pos_Y);
                        }
                    }
                    else
                    {
                        if(pos_X - count_X >= 0)
                        {
                            if (type == "MeleeUnit")
                            {
                                arrMap[pos_Y, pos_X - count_X] = symbol;
                                arrMap[pos_Y, pos_X] = ".";
                                m_Unit.newPosition(pos_X, pos_Y, pos_X - count_X, pos_Y);
                            }
                            else
                            {
                                arrMap[pos_Y, pos_X - count_X] = symbol;
                                arrMap[pos_Y, pos_X] = ".";
                                r_Unit.newPosition(pos_X, pos_Y, pos_X - count_X, pos_Y);
                            }
                        }
                    }
                }
                count_Y++;
                if(newPos_Y > pos_Y && pos_Y + count_Y <= 19)
                {
                    if (type == "MeleeUnit")
                    {
                        arrMap[pos_Y + count_Y, pos_X] = symbol;
                        arrMap[pos_Y, pos_X] = ".";
                        m_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y + count_Y);
                    }
                    else
                    {
                        arrMap[pos_Y + count_Y, pos_X] = symbol;
                        arrMap[pos_Y, pos_X] = ".";
                        r_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y + count_Y);
                    }
                }
                else
                {
                    if(pos_Y - count_Y >= 0)
                    {
                        if (type == "MeleeUnit")
                        {
                            arrMap[pos_Y - count_Y, pos_X] = symbol;
                            arrMap[pos_Y, pos_X] = ".";
                            m_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y - count_Y);
                        }
                        else
                        {
                            arrMap[pos_Y - count_Y, pos_X] = symbol;
                            arrMap[pos_Y, pos_X] = ".";
                            r_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y - count_Y);
                        }
                    }
                }
            }
            */
            string movement = "";

            if(count_X != newPos_X)
            {
                if(count_X < newPos_X)
                {
                    movement = "right";
                    if(speed > 1)
                    {
                        if(speed > Math.Abs(pos_X - newPos_X))
                        {
                            count_X = Math.Abs(pos_X - newPos_X);
                        }
                        else
                        {
                            count_X += speed;
                        }
                    }
                    else
                    {
                        count_X++;
                    }
                }
                else
                {
                    movement = "left";
                    if (speed > 1)
                    {
                        if (speed > Math.Abs(pos_X - newPos_X))
                        {
                            count_X = Math.Abs(pos_X - newPos_X);
                        }
                        else
                        {
                            count_X += speed;
                        }
                    }
                    else
                    {
                        count_X++;
                    }
                }
            }
            if(count_Y < newPos_Y)
            {
                if(count_Y < newPos_Y)
                {
                    movement = "up";
                    if (speed > 1)
                    {
                        if (speed > Math.Abs(pos_Y - newPos_Y))
                        {
                            count_Y = Math.Abs(pos_Y - newPos_Y) - 1;
                        }
                        else
                        {
                            count_Y += speed;
                        }
                    }
                    else
                    {
                        count_Y++;
                    }
                }
                else
                {
                    movement = "down";
                    if (speed > 1)
                    {
                        if (speed > Math.Abs(pos_Y - newPos_Y))
                        {
                            count_Y = Math.Abs(pos_Y - newPos_Y) - 1;
                        }
                        else
                        {
                            count_Y += speed;
                        }
                    }
                    else
                    {
                        count_Y++;
                    }
                }
            }

            if(type == "MeleeUnit")
            {
                switch(movement)
                {
                    case "right":
                        {
                            if(pos_X + count_X <= 19)
                            {
                                M_Unit.newPosition(pos_X, pos_Y, pos_X + count_X, pos_Y);
                                ArrMap[pos_Y, pos_X + count_X] = symbol;
                                ArrMap[pos_Y, pos_X] = ".";
                            }
                        }
                        break;
                    case "left":
                        {
                            if(pos_X - count_X >= 0)
                            {
                                M_Unit.newPosition(pos_X, pos_Y, pos_X - count_X, pos_Y);
                                ArrMap[pos_Y, pos_X - count_X] = symbol;
                                ArrMap[pos_Y, pos_X] = ".";
                            }
                        }
                        break;
                    case "up":
                        {
                            if(pos_Y + count_Y <= 19)
                            {
                                M_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y + count_Y);
                                ArrMap[pos_Y + count_Y, pos_X] = symbol;
                                ArrMap[pos_Y, pos_X] = ".";
                            }
                        }
                        break;
                    case "down":
                        {
                            if(pos_Y - count_Y >= 0)
                            {
                                M_Unit.newPosition(pos_X, pos_Y, pos_X, pos_Y - count_Y);
                                ArrMap[pos_Y - count_Y, pos_X] = symbol;
                                ArrMap[pos_Y, pos_X] = ".";
                            }
                        }
                        break;
                }
            }
        }

        // String for the combobox
        public string comboInfo(int i)
        {
            string unitInfo = "";
            unitInfo += ArrUnit[i].ToString();
            return unitInfo;
        }

        // test output
        public string redraw()
        {
            string s = "";
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 20; j++)
                {
                    s += ArrMap[i, j];
                }
                s += "\n";
            }
            return s;
        }

    }
}
