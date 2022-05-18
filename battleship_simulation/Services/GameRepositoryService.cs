using battleship_simulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_simulation.Services
{
    public class GameRepository : IGameRepository
    {
        public string[][] playerOneGameBoard = new string[10][];
        public string[][] playerTwoGameBoard = new string[10][];
        List<string> players = new();
        List<string> events = new();

        public string[][] GetFirst()
        {
            return playerOneGameBoard;
        }

        public string[][] GetSecond()
        {
            return playerTwoGameBoard;
        }

        public List<string> GetEvents()
        {
            return events;
        }

        public void Add()
        {
            Game game = new();
            List<Ship> playerOneShips = game.createPlayerShips();

            List<Ship> playerTwoShips = game.createPlayerShips();
            

            Board board = new();
            board.createBoard(playerOneGameBoard);
            board.createBoard(playerTwoGameBoard);
            game.placeShipsOnBoard(board, playerOneShips, playerOneGameBoard);
            game.placeShipsOnBoard(board, playerTwoShips, playerTwoGameBoard);
            game.gameSimulation(playerOneGameBoard, playerOneShips, playerTwoGameBoard, playerTwoShips, players, events);

        }
    }
}
