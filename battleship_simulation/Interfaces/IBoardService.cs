using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_simulation.Interfaces
{
    /* interface describing board service */
    public interface IBoardService
    {
        void createBoard(string[][] gameBoard);

        bool tryPlaceShip(Ship ship, int start, int place, int direction, string[][] gameBoard);

        void placeShip(Ship ship, int start, int place, int direction, string[][] gameBoard);
    }
}
