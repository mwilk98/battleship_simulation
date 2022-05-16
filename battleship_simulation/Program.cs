using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleship_simulation
{
    public class Board
    {
        public string[][] gameBoard = new string[10][];

        public void createBoard()
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

        public void printBoard()
        {
            for (int i = 0; i < gameBoard.Length; i++)
            {
                for (int j = 0; j < gameBoard[i].Length; j++)
                {
                    Console.Write("{0} ", gameBoard[i][j]);
                }
                Console.WriteLine();
            }
        }

        public bool tryPlaceShip(Ship ship, int start, int place, int direction)
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
        public void placeShip(Ship ship, int start, int place, int direction)
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

    public class Ship
    {
        public String name;
        public string symbol;
        public int lives;
        public bool isDestroyed = false;

        public Ship(String name, String symbol, int lives)
        {
            this.name = name;
            this.symbol = symbol;
            this.lives = lives;
        }

        public void setState()
        {
            isDestroyed = !isDestroyed;
        }
        public bool checkState()
        {
            return isDestroyed;
        }

        public void hit()
        {
            if (!checkState())
            {
                lives--;
                Console.WriteLine(name + " hit! Remaning lives:" + lives);
                if (lives == 0)
                {
                    Console.WriteLine(name + " sunk!");
                    setState();
                }
            }
        }
    }
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

        public void placeShipsOnBoard(Board board, List<Ship> playerShips)
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
                } while (!board.tryPlaceShip(ship, 1, listNumbers[index], number));
                board.placeShip(ship, 1, listNumbers[index], number);
                index++;
            }
        }

        public void playerShot(Board board, List<Ship> playerShips)
        {
            Random random = new Random();
            int col;
            int rows;
            do
            {
                col = random.Next(10);
                rows = random.Next(10);
            } while (board.gameBoard[col][rows] == "m" || board.gameBoard[col][rows] == "t");

            foreach (var ship in playerShips)
            {
                if (board.gameBoard[col][rows] == ship.symbol)
                {
                    ship.hit();
                    board.gameBoard[col][rows] = "t";
                }
            }
            if (board.gameBoard[col][rows] == "t")
            {
                board.gameBoard[col][rows] = "t";
            }
            else
            {
                board.gameBoard[col][rows] = "m";
                Console.WriteLine("Miss!");
            }
        }

        public void gameSimulation(Board board, Board board2, List<Ship> playerOneShips, List<Ship> playerTwoShips)
        {
            int time = 0;
            do
            {
                Console.Clear();
                board.printBoard();
                Console.WriteLine("time: " + time);
                board2.printBoard();

                playerShot(board, playerOneShips);

                System.Threading.Thread.Sleep(1000);
                time++;

                Console.Clear();
                board.printBoard();
                Console.WriteLine("time: " + time);
                board2.printBoard();

                playerShot(board2, playerTwoShips);


                System.Threading.Thread.Sleep(1000);
                time++;


                if (!checkShips(playerOneShips))
                {
                    Console.WriteLine("Player 2 Won!");
                }

                if (!checkShips(playerTwoShips))
                {
                    Console.WriteLine("Player 1 Won!");
                }
            } while (checkShips(playerOneShips) && checkShips(playerTwoShips));
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            Game game = new();
            List<Ship> playerOneShips = game.createPlayerShips();

            List<Ship> playerTwoShips = game.createPlayerShips();

            Board board = new();
            Board board2 = new();
            board.createBoard();
            board2.createBoard();
            game.placeShipsOnBoard(board, playerOneShips);
            game.placeShipsOnBoard(board2, playerTwoShips);


            Console.Clear();
            board.printBoard();
            Console.WriteLine("time: 0");
            board2.printBoard();

            game.gameSimulation(board, board2, playerOneShips, playerTwoShips);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
