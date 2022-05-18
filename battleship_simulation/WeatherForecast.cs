using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    public class Board
    {
        public string[][] gameBoard = new string[10][];

        public void createBoard(string[][] gameBoard)
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new string[10];
            }

            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    gameBoard[i][j] = "e";
                }
            }
        }
        public bool tryPlaceShip(Ship ship, int start, int place, int direction, string[][] gameBoard)
        {
            bool test = true;
            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (direction == 0)
                    {
                        if (i >= start && i < start + ship.lives && j == place)
                        {
                            if (gameBoard[i][j] != "e")
                            {
                                test = false;
                            }
                        }
                    }
                    if (direction == 1)
                    {
                        if (j >= start && j < start + ship.lives && i == place)
                        {
                            if (gameBoard[i][j] != "e")
                            {
                                test = false;
                            }
                        }
                    }

                }
            }
            return test;
        }

        public string[][] returnBoard()
        {
            return gameBoard;
        }
        public void placeShip(Ship ship, int start, int place, int direction, string[][] gameBoard)
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    if (direction == 0)
                    {
                        if (i >= start && i < start + ship.lives && j == place)
                        {
                            if (gameBoard[i][j] == "e")
                            {
                                gameBoard[i][j] = ship.symbol;
                            }
                        }
                    }
                    if (direction == 1)
                    {
                        if (j >= start && j < start + ship.lives && i == place)
                        {
                            if (gameBoard[i][j] == "e")
                            {
                                gameBoard[i][j] = ship.symbol;
                            }
                        }
                    }

                }
            }
        }
    }
    public class WeatherForecast
    {
        public string[][] Board { get; set; }
        public string[][] Board2 { get; set; }
    }

    public interface IGameRepository
    {
        string[][] GetFirst();

        string[][] GetSecond();

        void Add();
    }

    public class GameRepository: IGameRepository
    {
        public string[][] gameBoard = new string[10][];
        public string[][] gameBoard2 = new string[10][];

        public GameRepository()
        {

        }

        public string[][] GetFirst()
        {
            return gameBoard;
        }

        public string[][] GetSecond()
        {
            return gameBoard2;
        }

        public void Add()
        {
            Game game = new();
            List<Ship> playerOneShips = game.createPlayerShips();

            List<Ship> playerTwoShips = game.createPlayerShips();

            Board board = new();
            board.createBoard(gameBoard);
            board.createBoard(gameBoard2);
            game.placeShipsOnBoard(board, playerOneShips,gameBoard);
            game.placeShipsOnBoard(board, playerTwoShips, gameBoard2);
            game.gameSimulation(gameBoard,playerOneShips, gameBoard2, playerTwoShips);

        }
    }
}
