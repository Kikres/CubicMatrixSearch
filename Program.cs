﻿namespace CubicMatrixSearch
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[,] matrix = {
                { "0", "0", "0", "1", "0", "0"},
                { "0", "1", "1", "0", "0", "0"},
                { "0", "0", "1", "0", "0", "0"},
                { "0", "0", "1", "1", "0", "0"},
                { "0", "0", "1", "1", "0", "0"},
                { "0", "0", "0", "0", "0", "0"},
            };
            string[,] visualMatrix = (string[,])matrix.Clone();

            var searchLength = 3;
            var matrixBase = (int)Math.Sqrt(matrix.Length);
            var ofIntrest = "1";
            var counter = 0;

            // Horizontal scan
            for (var x = 0; x < Math.Sqrt(matrix.Length); x++)
            {
                for (var y = 0; y < Math.Sqrt(matrix.Length); y++)
                {
                    counter = matrix[x, y] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, x, y);
                    if (counter == searchLength) Console.Write("WIN");
                }
            };
            visualMatrix = (string[,])matrix.Clone();

            // Vertical scan
            counter = 0;
            for (var y = 0; y < Math.Sqrt(matrix.Length); y++)
            {
                for (var x = 0; x < Math.Sqrt(matrix.Length); x++)
                {
                    counter = matrix[x, y] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, x, y);
                    if (counter == searchLength) Console.Write("WIN");
                }
            };
            visualMatrix = (string[,])matrix.Clone();

            // Diagonal scan
            counter = 0;
            for (int m = 0; m < matrixBase; m++)
            {
                // Diagonal \
                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    print(visualMatrix, xy, xy + m);
                    if (counter == searchLength) Console.Write("WIN");
                }
                counter = 0;
                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    print(visualMatrix, xy + m, xy);
                    if (counter == searchLength) Console.Write("WIN");
                }

                counter = 0;
                visualMatrix = (string[,])matrix.Clone();

                // Diagonal /
                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    print(visualMatrix, (matrixBase - 1) - xy, xy + m);
                    if (counter == searchLength) Console.Write("WIN");
                }
                counter = 0;
                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    print(visualMatrix, (matrixBase - 1) - xy - m, xy);
                    if (counter == searchLength) Console.Write("WIN");
                }

                counter = 0;
            }
        }

        private static void print(string[,] visualMatrix, int x, int y)
        {
            visualMatrix[x, y] = " ";
            var boardBase = Math.Sqrt(visualMatrix.Length);
            int viewSpeed = 100;
            for (int xv = 0; xv < boardBase; xv++)
            {
                Console.WriteLine();
                for (int yv = 0; yv < boardBase; yv++)
                {
                    Console.Write($"[{visualMatrix[xv, yv]}]");
                }
            }
            Thread.Sleep(viewSpeed);
            Console.Clear();
        }
    }
}