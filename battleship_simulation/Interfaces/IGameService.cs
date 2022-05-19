using System.Collections.Generic;

namespace battleship_simulation.Interfaces
{
    /* interface describing game service */
    interface IGameService
    {
        bool checkShips(List<Ship> playerShips);
        public List<Ship> createPlayerShips();
        public List<int> getRandomIntList();
        void placeShipsOnBoard(BoardService board, List<Ship> playerShips, string[][] gameBoard);
        void playerShot(List<Ship> playerShips, string[][] gameBoard, string playerName, List<string> events);
        void gameSimulation(string[][] gameBoard, List<Ship> playerOneShips, string[][] gameBoard2, List<Ship> playerTwoShips, List<string> players, List<string> events);
    }
}
