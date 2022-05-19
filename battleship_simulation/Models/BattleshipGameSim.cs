using System.Collections.Generic;

namespace battleship_simulation
{    /* class containing data to transport to the frontend */
    public class BattleshipGameSim
    {
        public string[][] PlayerOneBoard { get; set; }
        public string[][] PlayerTwoBoard { get; set; }
        public List<string> events { get; set; }
    }
}
