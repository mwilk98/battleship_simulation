namespace battleship_simulation
{
    public class Board
    {
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
}
