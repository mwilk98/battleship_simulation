using battleship_simulation.Interfaces;
using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    public class BattleshipGameSim
    {
        public string[][] PlayerOneBoard { get; set; }
        public string[][] PlayerTwoBoard { get; set; }
        public List<string> events { get; set; }
}
}
