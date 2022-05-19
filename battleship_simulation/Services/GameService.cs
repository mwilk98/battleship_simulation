using battleship_simulation.Interfaces;
using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    /* class implementing game interface, processing game data */
    public class GameService : IGameService
    {
        /* method checking ship list, if there ate ships alive */
        public bool checkShips(List<Ship> playerShips)
        {
            List<bool> destroyedShips = new();
            foreach (var ship in playerShips)
            {
                if (ship.isDestroyed)
                {
                    destroyedShips.Add(true);
                }
                if (destroyedShips.Count == 5)
                {
                    return false;
                }
            }
            return true;
        }

        /* method creating list of the ships */
        public List<Ship> createPlayerShips()
        {
            List<Ship> playerShips = new List<Ship> {
            new("Carrier", "c", 5),
            new("Battleship", "b", 4),
            new("Destroyer", "d", 3),
            new("Submarine", "s", 3),
            new("Patrol Boat", "p", 2),
        };

            return playerShips;
        }

        /* method returing list of random numbers */
        public List<int> getRandomIntList()
        {
            Random random = new Random();
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 6; i++)
            {
                do
                {
                    number = random.Next(10);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }

            return listNumbers;
        }

        /* method placing ships on the board*/
        public void placeShipsOnBoard(BoardService board, List<Ship> playerShips, string[][] gameBoard)
        {
            Random random = new Random();
            List<int> listNumbers = getRandomIntList();
            int number;
            int index = 0;
            foreach (var ship in playerShips)
            {
                do
                {
                    number = random.Next(2);
                } while (!board.tryPlaceShip(ship, 1, listNumbers[index], number, gameBoard));
                board.placeShip(ship, 1, listNumbers[index], number, gameBoard);
                index++;
            }
        }

        /* method processing shot by player in simulation */
        public void playerShot(List<Ship> playerShips, string[][] gameBoard, string playerName, List<string> events)
        {
            Random random = new Random();
            int col;
            int rows;
            do
            {
                col = random.Next(10);
                rows = random.Next(10);
            } while (gameBoard[col][rows] == "m" ||gameBoard[col][rows] == "h");

            foreach (var ship in playerShips)
            {
                if (gameBoard[col][rows] == ship.symbol)
                {
                    ship.hit(playerName,events);
                    gameBoard[col][rows] = "h";
                }
            }
            if (gameBoard[col][rows] == "h")
            {
                gameBoard[col][rows] = "h";
            }
            else
            {
                gameBoard[col][rows] = "m";
                events.Insert(0, playerName + " Missed!");

            }
        }

        /* method running the simulation */
        public void gameSimulation(string[][] gameBoard, List<Ship> playerOneShips, string[][] gameBoard2, List<Ship> playerTwoShips, List<string> players, List<string> events)
        {
            string player1 = "Player 1";
            string player2 = "Player 2";
            players.Add(player1);
            players.Add(player2);
            events.Clear();
            do
            {

                playerShot(playerOneShips, gameBoard, players[0], events);
                System.Threading.Thread.Sleep(1000);

                playerShot(playerTwoShips, gameBoard2, players[1], events);
                System.Threading.Thread.Sleep(1000);

            } while (checkShips(playerOneShips) && checkShips(playerTwoShips));

            if (!checkShips(playerOneShips))
                events.Insert(0, "Player 2 won!");
            if (!checkShips(playerTwoShips))
                events.Insert(0, "Player 1 won!");
            else
                events.Insert(0, "Draw!");
        }
    }
}
