using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoChess.Classes
{
   
        public class Board
        {
            public int Rows { get; }
            public int Columns { get; }
            public Unit[,] Grid { get; }

            public Board(int rows = 8, int columns = 8)
            {
                Rows = rows;
                Columns = columns;
                Grid = new Unit[rows, columns];
            }

            public void PlaceUnit(Unit unit, int row, int column)
            {
                if (row >= 0 && row < Rows && column >= 0 && column < Columns)
                {
                    if (Grid[row, column] == null)
                    {
                        Grid[row, column] = unit;
                        unit.Position = (row, column);
                        Console.WriteLine($"{unit.Name} placed at ({row}, {column})");
                    }
                    else
                    {
                        Console.WriteLine($"Cell ({row}, {column}) is already occupied!");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid position ({row}, {column})!");
                }
            }

            public void MoveUnit(int startRow, int startColumn, int endRow, int endColumn)
            {
                if (startRow >= 0 && startRow < Rows && startColumn >= 0 && startColumn < Columns &&
                    endRow >= 0 && endRow < Rows && endColumn >= 0 && endColumn < Columns)
                {
                    if (Grid[startRow, startColumn] != null && Grid[endRow, endColumn] == null)
                    {
                        Grid[endRow, endColumn] = Grid[startRow, startColumn];
                        Grid[startRow, startColumn].Position = (endRow, endColumn);
                        Grid[startRow, startColumn] = null;
                        Console.WriteLine($"Unit moved from ({startRow}, {startColumn}) to ({endRow}, {endColumn})");
                    }
                    else
                    {
                        Console.WriteLine("Invalid move or destination cell is occupied!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }
            }

            public Unit GetUnitAtPosition(int row, int column)
            {
                if (row >= 0 && row < Rows && column >= 0 && column < Columns)
                {
                    return Grid[row, column];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid position!");
                }
            }

            public void PrintBoard()
            {
                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        if (Grid[i, j] != null)
                        {
                            Console.Write($"{Grid[i, j].Name} ");
                        }
                        else
                        {
                            Console.Write("Empty ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    

}
