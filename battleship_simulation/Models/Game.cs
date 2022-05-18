using System;
using System.Collections.Generic;

namespace battleship_simulation
{
    public class Game
    {
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

        public void placeShipsOnBoard(Board board, List<Ship> playerShips, string[][] gameBoard)
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

        public void playerShot(List<Ship> playerShips, string[][] gameBoard, string playerName, List<string> events)
        {
            Random random = new Random();
            int col;
            int rows;
            do
            {
                col = random.Next(10);
                rows = random.Next(10);
            } while (gameBoard[col][rows] == "m" ||gameBoard[col][rows] == "t");

            foreach (var ship in playerShips)
            {
                if (gameBoard[col][rows] == ship.symbol)
                {
                    ship.hit(playerName,events);
                    gameBoard[col][rows] = "t";
                }
            }
            if (gameBoard[col][rows] == "t")
            {
                gameBoard[col][rows] = "t";
            }
            else
            {
                gameBoard[col][rows] = "m";
                events.Insert(0, playerName + " Missed!");

            }
        }

        public void gameSimulation(string[][] gameBoard, List<Ship> playerOneShips, string[][] gameBoard2, List<Ship> playerTwoShips, List<string> players, List<string> events)
        {
            int time = 0;;
            string player1 = "Player 1";
            string player2 = "Player 2";
            players.Add(player1);
            players.Add(player2);
            events.Clear();
            do
            {

                playerShot(playerOneShips, gameBoard, players[0], events);

                System.Threading.Thread.Sleep(1000);
                time++;

                playerShot(playerTwoShips, gameBoard2, players[1], events);

                System.Threading.Thread.Sleep(1000);
                time++;

            } while (checkShips(playerOneShips) && checkShips(playerTwoShips));
        }
    }
}
