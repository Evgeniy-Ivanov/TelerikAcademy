using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MineSweeper
{
	public class Mines
	{
        public const int BoardRows = 5;
        public const int BoardColumns = 10;
      
		public class ScoreBoard
		{
			public string PlayerName { get; set; }
            
            public int PlayerPoints { get; set; }
           
			public ScoreBoard(string name, int points)
			{
				this.PlayerName = name;
				this.PlayerPoints = points;
			}
		}

		public static void Main(string[] arguments)
		{
			string command = string.Empty;
			char[,] gameBoard = CreateBoard();
			char[,] gameCells = SpreadMines();
			int playerScore = 0;
			bool isExploded = false;
		    List<ScoreBoard> champions = new List<ScoreBoard>(6);
			int row = 0;
			int column = 0;
			bool isStarting = true;
			const int MaximalScore = 35;
			bool isWinner = false;
			do
			{
				if (isStarting)
				{
                    Console.WriteLine("Let\'s play “MineSweeper”. Try to find fields without mines." +
					    " Command 'top' shows the ranking, 'restart' starts new game, 'exit' game over!");
					RefreshBoard(gameBoard);
					isStarting = false;
				}
				
                Console.Write("Type row and column: ");
				command = Console.ReadLine().Trim();
				if (command.Length >= 3)
				{
					if (int.TryParse(command[0].ToString(), out row) &&
					int.TryParse(command[2].ToString(), out column) &&
						row <= gameBoard.GetLength(0) && column <= gameBoard.GetLength(1))
					{
						command = "turn";
					}
				}
				
                switch (command)
				{
					case "top":
						GetScore(champions);
						break;
					case "restart":
						gameBoard = CreateBoard();
						gameCells = SpreadMines();
						RefreshBoard(gameBoard);
						isExploded = false;
						isStarting = false;
						break;
					case "exit":
                        Console.WriteLine("Bye, bye!");
						break;
					case "turn":
                        try
                        {
                                if (gameCells[row, column] != '*')
						    {
							    if (gameCells[row, column] == '-')
							    {
								    SetCell(gameBoard, gameCells, row, column);
								    playerScore++;
							    }

							    if (MaximalScore == playerScore)
							    {
								    isWinner = true;
							    }
							    else
							    {
								    RefreshBoard(gameBoard);
							    }
						    }
						    else
						    {
							    isExploded = true;
						    }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Your rows and columns are out of range.", e);
                        }
						
                        break;
					default:
						Console.WriteLine("\nError! Invalid command.\n");
						break;
				}
				
                if (isExploded)
				{
					RefreshBoard(gameCells);
					Console.Write("\nSorry! You died with {0} points. " + "Please write your name: ", playerScore);
					string playerName = Console.ReadLine();
					ScoreBoard playerRank = new ScoreBoard(playerName, playerScore);
					if (champions.Count < 5)
					{
						champions.Add(playerRank);
					}
					else
					{
						for (int i = 0; i < champions.Count; i++)
						{
                            if (champions[i].PlayerPoints < playerRank.PlayerPoints)
							{
								champions.Insert(i, playerRank);
								champions.RemoveAt(champions.Count - 1);
								break;
							}
						}
					}
                   
                    champions.Sort((ScoreBoard r1, ScoreBoard r2) => r2.PlayerName.CompareTo(r1.PlayerName));
                    champions.Sort((ScoreBoard r1, ScoreBoard r2) => r2.PlayerPoints.CompareTo(r1.PlayerPoints));
					GetScore(champions);
					gameBoard = CreateBoard();
					gameCells = SpreadMines();
					playerScore = 0;
					isExploded = false;
					isStarting = true;
				}
				
                if (isWinner)
				{
                    Console.WriteLine("\nBravo! You opened 35 cells without losing a drop of blood.");
					RefreshBoard(gameCells);
					Console.WriteLine("Please write your name: ");
					
                    string playerName = Console.ReadLine();
					ScoreBoard rankPosition = new ScoreBoard(playerName, playerScore);
					champions.Add(rankPosition);
					GetScore(champions);
					gameBoard = CreateBoard();
					gameCells = SpreadMines();
					playerScore = 0;
					isWinner = false;
					isStarting = true;
				}
			}
			while (command != "exit");
			Console.WriteLine("The game is over!");
			Console.WriteLine("Try again.");
			Console.Read();
		}

		private static void GetScore(List<ScoreBoard> points)
		{
			Console.WriteLine("\nScoreboard:");
			if (points.Count > 0)
			{
				for (int i = 0; i < points.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} points", i + 1, points[i].PlayerName, points[i].PlayerPoints);
				}
				
                Console.WriteLine();
			}
			else
			{
                Console.WriteLine("Empty Scoreboard!\n");
			}
		}

		private static void SetCell(char[,] board, char[,] mines, int row, int column)
		{
			char mine = GetMines(mines, row, column);
			mines[row, column] = mine;
			board[row, column] = mine;
		}

		private static void RefreshBoard(char[,] board)
		{
			int columnsNumber = board.GetLength(0);
			int rowsNumber = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < columnsNumber; i++)
			{
				Console.Write("{0} | ", i);
			    for (int j = 0; j < rowsNumber; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				
                Console.Write("|");
				Console.WriteLine();
			}
			
            Console.WriteLine("   ---------------------\n");
		}

		private static char[,] CreateBoard()
		{
			char[,] board = new char[BoardRows, BoardColumns];
			for (int i = 0; i < BoardRows; i++)
			{
				for (int j = 0; j < BoardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] SpreadMines()
		{
			char[,] board = new char[BoardRows, BoardColumns];
			for (int i = 0; i < BoardRows; i++)
			{
				for (int j = 0; j < BoardColumns; j++)
				{
					board[i, j] = '-';
				}
			}

			List<int> minedCells = new List<int>();
			while (minedCells.Count < 15)
			{
				Random randomNumber = new Random();
				int minedCell = randomNumber.Next(50);
				if (!minedCells.Contains(minedCell))
				{
					minedCells.Add(minedCell);
				}
			}

			foreach (int minedCell in minedCells)
			{
				int cellColumn = minedCell / BoardColumns;
				int cellRow = minedCell % BoardColumns;
				if (cellRow == 0 && minedCell != 0)
				{
					cellColumn--;
					cellRow = BoardColumns;
				}
				else
				{
					cellRow++;
				}
				
                board[cellColumn, cellRow - 1] = '*';
			}

			return board;
		}

       	private static char GetMines(char[,] board, int row, int column)
		{
			int index = 0;
			int rows = board.GetLength(0);
			int columns = board.GetLength(1);
			if (row - 1 >= 0)
			{
				if (board[row - 1, column] == '*')
				{ 
					index++; 
				}
			}
			
            if (row + 1 < rows)
			{
				if (board[row + 1, column] == '*')
				{ 
					index++; 
				}
			}
			
            if (column - 1 >= 0)
			{
				if (board[row, column - 1] == '*')
				{ 
					index++;
				}
			}
			
            if (column + 1 < columns)
			{
				if (board[row, column + 1] == '*')
				{ 
					index++;
				}
			}
			
            if ((row - 1 >= 0) && (column - 1 >= 0))
			{
				if (board[row - 1, column - 1] == '*')
				{ 
					index++; 
				}
			}
			
            if ((row - 1 >= 0) && (column + 1 < columns))
			{
				if (board[row - 1, column + 1] == '*')
				{ 
					index++; 
				}
			}
			
            if ((row + 1 < rows) && (column - 1 >= 0))
			{
				if (board[row + 1, column - 1] == '*')
				{ 
					index++; 
				}
			}
			
            if ((row + 1 < rows) && (column + 1 < columns))
			{
				if (board[row + 1, column + 1] == '*')
				{ 
					index++; 
				}
			}
			
            return char.Parse(index.ToString());
		}
	}
}
