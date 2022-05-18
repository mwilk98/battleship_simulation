using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    public class Ship
    {
        public string name;
        public string symbol;
        public int lives;
        public bool isDestroyed = false;

        public Ship(String name, String symbol, int lives)
        {
            this.name = name;
            this.symbol = symbol;
            this.lives = lives;
        }

        public void setState()
        {
            isDestroyed = !isDestroyed;
        }
        public bool checkState()
        {
            return isDestroyed;
        }

        public void hit(string playerName, List<string> events)
        {
            if (!checkState())
            {
                lives--;
                events.Insert(0, playerName + " " + name + " hit! Remaning lives: " + lives);
                if (lives == 0)
                {
                    events.Insert(0, playerName + " " + name + " sunk!");
                    setState();
                }
            }
        }
    }
}
