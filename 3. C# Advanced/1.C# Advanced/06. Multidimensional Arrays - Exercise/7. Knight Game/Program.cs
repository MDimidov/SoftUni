using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Knight_Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            char[,] matrix = new char[size, size];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charArray = Console.ReadLine()
                    .ToCharArray();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }
            int totalMovements = 0;
            while (true)
            {
                int maxMovements = 0;
                int maxRow = -1;
                int maxCol = -1;
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int currMovements = 0;
                        if (char.ToUpper(matrix[row, col]) == 'K')
                        {
                            if (IsValid(matrix, row, col, "UpLeft"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row - 2, col - 1] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "UpRight"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row - 2, col + 1] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "RightUp"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row - 1, col + 2] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "RightDown"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row + 1, col + 2] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "DownRight"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row + 2, col + 1] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "DownLeft"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row + 2, col - 1] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "LeftDown"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row + 1, col - 2] = '0';
                                //continue;
                            }
                            if (IsValid(matrix, row, col, "LeftUp"))
                            {
                                currMovements++;
                                //matrix[row, col] = 'K';
                                //matrix[row - 1, col - 2] = '0';
                                //continue;
                            }
                            if(maxMovements < currMovements)
                            {
                                maxMovements = currMovements;
                                maxRow = row;
                                maxCol = col;
                            }
                        }
                    }
                }
                if(maxMovements != 0)
                {
                    matrix[maxRow, maxCol] = '0';
                    totalMovements++;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(totalMovements);

        }

        static bool IsValid(char[,] matrix, int row, int col, string dirrection)
        {
            if (char.ToUpper(matrix[row, col]) == 'K')
            {
                if (dirrection == "UpLeft")
                {
                    if (row - 2 >= 0 && col - 1 >= 0
                        && row - 2 < matrix.GetLength(0) && col - 1 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row - 2, col - 1]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "UpRight")
                {
                    if (row - 2 >= 0 && col + 1 >= 0
                        && row - 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row - 2, col + 1]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "RightUp")
                {
                    if (row - 1 >= 0 && col + 2 >= 0
                        && row - 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row - 1, col + 2]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "RightDown")
                {
                    if (row + 1 >= 0 && col + 2 >= 0
                        && row + 1 < matrix.GetLength(0) && col + 2 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row + 1, col + 2]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "DownRight")
                {
                    if (row + 2 >= 0 && col + 1 >= 0
                        && row + 2 < matrix.GetLength(0) && col + 1 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row + 2, col + 1]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "DownLeft")
                {
                    if (row + 2 >= 0 && col - 1 >= 0
                        && row + 2 < matrix.GetLength(0) && col - 1 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row + 2, col - 1]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "LeftDown")
                {
                    if (row + 1 >= 0 && col - 2 >= 0
                        && row + 1 < matrix.GetLength(0) && col - 2 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row + 1, col - 2]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
                else if (dirrection == "LeftUp")
                {
                    if (row - 1 >= 0 && col - 2 >= 0
                        && row - 1 < matrix.GetLength(0) && col - 2 < matrix.GetLength(1)
                        && char.ToUpper(matrix[row - 1, col - 2]) == 'K')
                    {
                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
    }
}
