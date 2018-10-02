using System;
using System.Diagnostics;
using System.Threading;

namespace Jordan_van_Zyl_GADE1B_A1
{
    class GameEngine
    {
        // Declared the required objects from various classes
        Map map = new Map();

        // Declare a random object
        Random rnd = new Random();

        // Method to update the map
        public string updateMap()
        {
            string closest = "";

            string toString = "";
            for (int i = 0; i < map.ArrUnit.Length; i++)
            {
                // Get the team of the unit
                string team = map.ArrUnit[i].Team;

                // Get the type of unit
                string unitType = map.ArrUnit[i].GetType().ToString();
                string[] arrType = unitType.Split('.');
                unitType = arrType[arrType.Length - 1];

                // If the unit type is a RangedUnit
                if (unitType == "RangedUnit")
                {
                    closest = map.R_Unit.closestUnit(map.ArrUnit);

                    string[] closestPos = closest.Split(';');
                    int closest_X = Convert.ToInt32(closestPos[0]);
                    int closest_Y = Convert.ToInt32(closestPos[1]);

                    int current_X = map.ArrUnit[i].Pos_X;
                    int current_Y = map.ArrUnit[i].Pos_Y;

                    int moveDistanceX = current_X - closest_X;
                    int absoluteX = Math.Abs(moveDistanceX);
                    int moveDistanceY = current_Y - closest_Y;
                    int absoluteY = Math.Abs(moveDistanceY);

                    map.updatePosition(unitType, map.R_Unit.Symbol, map.R_Unit.Pos_X, map.R_Unit.Pos_Y, closest_X, closest_Y, map.R_Unit.Speed);

                    // Determining if the unit is within the attack range
                    if (map.R_Unit.withinAtkRange(closest_X, closest_Y) == true)
                    {
                        // If it is within the attack range then go into combat (but don't move)
                        map.R_Unit.combat(map.ArrUnit, closest_X, closest_Y);

                        // If health is less than 25 then run in random direction
                        if (map.R_Unit.Health < 25)
                        {
                            int rndMove = rnd.Next(1, 5);
                            switch (rndMove)
                            {
                                // move right
                                case 1:
                                    {
                                        map.updatePosition(unitType, map.R_Unit.Symbol, map.R_Unit.Pos_X, map.R_Unit.Pos_Y, map.R_Unit.Pos_X + 1, map.R_Unit.Pos_Y, map.R_Unit.Speed);
                                    }
                                    break;
                                // move left
                                case 2:
                                    {
                                        map.updatePosition(unitType, map.R_Unit.Symbol, map.R_Unit.Pos_X, map.R_Unit.Pos_Y, map.R_Unit.Pos_X - 1, map.R_Unit.Pos_Y, map.R_Unit.Speed);
                                    }
                                    break;
                                // move up
                                case 3:
                                    {
                                        map.updatePosition(unitType, map.R_Unit.Symbol, map.R_Unit.Pos_X, map.R_Unit.Pos_Y, map.R_Unit.Pos_X, map.R_Unit.Pos_Y + 1, map.R_Unit.Speed);
                                    }
                                    break;
                                // move down
                                case 4:
                                    {
                                        map.updatePosition(unitType, map.R_Unit.Symbol, map.R_Unit.Pos_X, map.R_Unit.Pos_Y, map.R_Unit.Pos_X, map.R_Unit.Pos_Y - 1, map.R_Unit.Speed);
                                    }
                                    break;
                            }
                        }
                    }
                }
                // If the unit type is a MeleeUnit
                else
                {
                    int current_X = map.ArrUnit[i].Pos_X;
                    int current_Y = map.ArrUnit[i].Pos_Y;

                    closest = map.M_Unit.closestUnit(map.ArrUnit);

                    string[] closestPos = closest.Split(';');
                    int closest_X = Convert.ToInt32(closestPos[0]);
                    int closest_Y = Convert.ToInt32(closestPos[1]);

                    int moveDistanceX = current_X - closest_X;
                    int absoluteX = Math.Abs(moveDistanceX);
                    int moveDistanceY = current_Y - closest_Y;
                    int absoluteY = Math.Abs(moveDistanceY);

                    map.updatePosition(unitType, map.M_Unit.Symbol, map.M_Unit.Pos_X, map.M_Unit.Pos_Y, closest_X, closest_Y, map.M_Unit.Speed);

                    // Determining if the unit is within the attack range
                    if (map.M_Unit.withinAtkRange(closest_X, closest_Y) == true)
                    {
                        // If it is within the attack range then go into combat (but don't move)
                        map.M_Unit.combat(map.ArrUnit, closest_X, closest_Y);

                        // If health is less than 25 then run in random direction
                        if (map.M_Unit.Health < 25)
                        {
                            int rndMove = rnd.Next(1, 5);
                            switch (rndMove)
                            {
                                // move right
                                case 1:
                                    {
                                        map.updatePosition(unitType, map.M_Unit.Symbol, map.M_Unit.Pos_X, map.M_Unit.Pos_Y, map.M_Unit.Pos_X + 1, map.M_Unit.Pos_Y, map.M_Unit.Speed);
                                    }
                                    break;
                                // move left
                                case 2:
                                    {
                                        map.updatePosition(unitType, map.M_Unit.Symbol, map.M_Unit.Pos_X, map.M_Unit.Pos_Y, map.M_Unit.Pos_X - 1, map.M_Unit.Pos_Y, map.M_Unit.Speed);
                                    }
                                    break;
                                // move up
                                case 3:
                                    {
                                        map.updatePosition(unitType, map.M_Unit.Symbol, map.M_Unit.Pos_X, map.M_Unit.Pos_Y, map.M_Unit.Pos_X, map.M_Unit.Pos_Y + 1, map.M_Unit.Speed);
                                    }
                                    break;
                                // move down
                                case 4:
                                    {
                                        map.updatePosition(unitType, map.M_Unit.Symbol, map.M_Unit.Pos_X, map.M_Unit.Pos_Y, map.M_Unit.Pos_X, map.M_Unit.Pos_Y - 1, map.M_Unit.Speed);
                                    }
                                    break;
                            }
                        }
                    }

                    // Commented out code - was the old movement method

                    /* if (closest_X > current_X)
                    {
                        if(countX <= absoluteX && countX < 20)
                        {
                            countX++;
                            if(map.ArrUnit[i].Team == "Hero")
                            {
                                map.moveSpecific(unitType, current_X, current_Y, current_X + countX, current_Y);
                                map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X + countX, current_Y);
                            }
                        }
                    }
                    else
                    {
                        if(countX <= absoluteX && current_X <= 19)
                        {
                            countX++;
                            if(map.ArrUnit[i].Team == "Hero")
                            {
                                map.moveSpecific(unitType, current_X, current_Y, current_X - countX, current_Y);
                                map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X - countX, current_Y);
                            }
                        }
                    }
                    if(countX == absoluteX)
                    {
                        if(closest_Y < current_Y && current_Y <= 19)
                        {
                            if(countY < absoluteY)
                            {
                                countY++;
                                if (map.ArrUnit[i].Team == "Hero")
                                {
                                    map.moveSpecific(unitType, current_X, current_Y, current_X, current_Y + countY);
                                    map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X, current_Y + countY);
                                }
                            }
                        }
                        else
                        {
                            if (countY < absoluteY && current_Y <= 19)
                            {
                                countY++;
                                if (map.ArrUnit[i].Team == "Hero")
                                {
                                    map.moveSpecific(unitType, current_X, current_Y, current_X, current_Y - countY);
                                    map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X, current_Y - countY);
                                }
                            }
                        }
                    }

                    toString += map.redraw();
                        // toString += "Hero unit at: " + current_X + ";" + current_Y + " has closest Villain unit at: " + closest + "\n";
                }
                
                else
                {
                    int current_X = map.ArrUnit[i].Pos_X;
                    int current_Y = map.ArrUnit[i].Pos_Y;

                    closest = map.M_Unit.closestUnit(map.ArrUnit, map.ArrUnit[i].Team, current_X, current_Y);

                    string[] closestPos = closest.Split(';');
                    int closest_X = Convert.ToInt32(closestPos[0]);
                    int closest_Y = Convert.ToInt32(closestPos[1]);

                    int moveDistanceX = current_X - closest_X;
                    int absoluteX = Math.Abs(moveDistanceX);
                    int moveDistanceY = current_Y - closest_Y;
                    int absoluteY = Math.Abs(moveDistanceY);

                    int countX = 0;
                    int countY = 0;
                    if (closest_X > current_X)
                    {
                        if (countX <= absoluteX && current_X <= 19)
                        {
                            countX++;
                            if (map.ArrUnit[i].Team == "Villain")
                            {
                                map.moveSpecific(unitType, current_X, current_Y, current_X + countX, current_Y);
                                map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X + countX, current_Y);
                            }
                        }
                    }
                    else
                    {
                        if (countX <= absoluteX && current_X <= 19)
                        {
                            countX++;
                            if (map.ArrUnit[i].Team == "Villain")
                            {
                                map.moveSpecific(unitType, current_X, current_Y, current_X - countX, current_Y);
                                map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X - countX, current_Y);
                            }
                        }
                    }
                    if (countX == absoluteX)
                    {
                        if (closest_Y < current_Y && current_Y <= 19)
                        {
                            if (countY < absoluteY)
                            {
                                countY++;
                                if (map.ArrUnit[i].Team == "villain")
                                {
                                    map.moveSpecific(unitType, current_X, current_Y, current_X, current_Y + countY);
                                    map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X, current_Y + countY);
                                }
                            }
                        }
                        else
                        {
                            if (countY < absoluteY && current_Y <= 19)
                            {
                                countY++;
                                if (map.ArrUnit[i].Team == "Villain ")
                                {
                                    map.moveSpecific(unitType, current_X, current_Y, current_X, current_Y - countY);
                                    map.updatePosition(unitType, map.ArrUnit[i].Symbol, current_X, current_Y, current_X, current_Y - countY);
                                }
                            }
                        }
                    }
                    toString += map.redraw();

                    // toString += "Villain unit at: " + current_X + ";" + current_Y + " has closest Villain unit at: " + closest + "\n";
                }
                */
                }
                //return toString;
            }
            toString += map.redraw();
            return toString;
        }

        // Return number of units in Unit array
        public int UnitSize()
        {
            int size = 0;
            size = map.ArrUnit.Length;
            return size;
        }

        // Add string of unit i to the combo box
        public string Units(int i)
        {
            return map.ArrUnit[i].ToString();
        }
    }
}
