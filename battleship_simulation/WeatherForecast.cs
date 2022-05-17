using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    public class WeatherForecast
    {
        public string[][] Board { get; set; }
        public string[][] Board2 { get; set; }
    }

    public interface IGameRepository
    {
        string[][] GetAll();

        void Add();
    }

    public class GameRepository: IGameRepository
    {
        public string[][] gameBoard = new string[10][];

        public GameRepository()
        {

        }

        public string[][] GetAll()
        {
            return gameBoard;
        }

        public void Add()
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                gameBoard[i] = new string[10];
            }

            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    gameBoard[i][j] = "f";
                }
            }
        }
    }
}
