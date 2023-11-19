using System;

internal class Program
{
    static void Main()
    {
        int boardSize = int.Parse(Console.ReadLine());
        char[,] board = ReadInitialBoardPositions(boardSize);
        int removedKnights = 0;

        for (int threatLevel = 8; threatLevel > 0; threatLevel--)
            for (int row = 0; row < boardSize; row++)
                for (int col = 0; col < boardSize; col++)
                    if (board[row, col] == 'K')
                    {
                        int knightThreat = CalculateKnightThreat(row, col, board);
                        if (knightThreat == threatLevel)
                        {
                            board[row, col] = '0';
                            removedKnights++;
                        }
                    }
        Console.WriteLine(removedKnights);
    }

    static char[,] ReadInitialBoardPositions(int boardSize)
    {
        char[,] board = new char[boardSize, boardSize];
        for (int row = 0; row < boardSize; row++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int col = 0; col < boardSize; col++)
                board[row, col] = line[col];
        }
        return board;
    }

    static int CalculateKnightThreat(int row, int col, char[,] board)
    {
        int knightThreat = 0;
        if (ThereIsAnotherKnightHere(row + 2, col - 1, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row + 2, col + 1, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row - 2, col - 1, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row - 2, col + 1, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row - 1, col + 2, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row + 1, col + 2, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row - 1, col - 2, board)) knightThreat++;
        if (ThereIsAnotherKnightHere(row + 1, col - 2, board)) knightThreat++;
        return knightThreat;
    }

    static bool ThereIsAnotherKnightHere(int rowIndex, int colIndex, char[,] board)
    {
        int size = board.GetLength(0);
        if (rowIndex < 0 || rowIndex >= size || colIndex < 0 || colIndex >= size)
            return false;
        if (board[rowIndex, colIndex] != 'K')
            return false;
        return true;
    }
}