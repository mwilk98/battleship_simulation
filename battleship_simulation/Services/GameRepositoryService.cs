using battleship_simulation.Interfaces;
using System.Collections.Generic;

namespace battleship_simulation.Services
{
    /* service implementing game interface, processing data of simulation of the game */
    public class GameRepository : IGameRepository
    {
        public string[][] playerOneGameBoard = new string[10][];
        public string[][] playerTwoGameBoard = new string[10][];
        List<string> players = new();
        List<string> events = new();
        bool started = false;

        /* method returning game board of player 1 to frontend */
        public string[][] GetFirst()
        {
            return playerOneGameBoard;
        }

        /* method returning game board of player 2 to frontend */
        public string[][] GetSecond()
        {
            return playerTwoGameBoard;
        }

        /* method returning array of events to frontend */
        public List<string> GetEvents()
        {
            return events;
        }

        /* method starting simulation of the game */
        public void Add()
        {
            if (!started)
            {
                started = true;
                GameService game = new();
                List<Ship> playerOneShips = game.createPlayerShips();

                List<Ship> playerTwoShips = game.createPlayerShips();


                BoardService board = new();
                board.createBoard(playerOneGameBoard);
                board.createBoard(playerTwoGameBoard);
                game.placeShipsOnBoard(board, playerOneShips, playerOneGameBoard);
                game.placeShipsOnBoard(board, playerTwoShips, playerTwoGameBoard);
                game.gameSimulation(playerOneGameBoard, playerOneShips, playerTwoGameBoard, playerTwoShips, players, events);
            }
        }
    }
}
