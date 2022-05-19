using System.Collections.Generic;

namespace battleship_simulation
{
    /* class describing data of the ship object and methotds setting and checking its state */
    public class Ship
    {
        public string name { get; set; }
        public string symbol { get; set; }
        public int lives { get; set; }
        public bool isDestroyed = false;

        public Ship(string name, string symbol, int lives)
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
