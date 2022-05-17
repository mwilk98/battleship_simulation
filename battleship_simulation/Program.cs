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

        public string[][] placeShipsOnBoard(Board board, List<Ship> playerShips, string[][] gameBoard)
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
            return board.gameBoard;
        }

        public void playerShot(List<Ship> playerShips, string[][] gameBoard)
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
                    ship.hit();
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
                Console.WriteLine("Miss!");
            }
        }

        public string[][] gameSimulation(string[][] gameBoard, List<Ship> playerOneShips)
        {
            int time = 0;
            do
            {

                playerShot(playerOneShips, gameBoard);

                System.Threading.Thread.Sleep(1000);
                time++;

            } while (true);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //Game game = new();
            //List<Ship> playerOneShips = game.createPlayerShips();

            //List<Ship> playerTwoShips = game.createPlayerShips();

            //Board board = new();
            //Board board2 = new();
            //board.createBoard();
            //board2.createBoard();
            //game.placeShipsOnBoard(board, playerOneShips);
            //game.placeShipsOnBoard(board2, playerTwoShips);


            //Console.Clear();
            //board.printBoard();
            //Console.WriteLine("time: 0");
            //board2.printBoard();

            //game.gameSimulation(board, board2, playerOneShips, playerTwoShips);
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
