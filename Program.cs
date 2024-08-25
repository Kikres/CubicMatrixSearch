using System.Diagnostics.Metrics;

namespace MatrixSearch
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
            for (var x = 0; x < matrixBase; x++)
            {
                for (var y = 0; y < matrixBase; y++)
                {
                    counter = matrix[x, y] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, x, y);
                    WinCheck(counter, searchLength);
                }
            };
            visualMatrix = (string[,])matrix.Clone();

            // Vertical scan
            counter = 0;
            for (var y = 0; y < matrixBase; y++)
            {
                for (var x = 0; x < matrixBase; x++)
                {
                    counter = matrix[x, y] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, x, y);
                    WinCheck(counter, searchLength);
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
                    counter = matrix[xy, xy + m] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, xy, xy + m);
                    WinCheck(counter, searchLength);
                }
                counter = 0;

                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    counter = matrix[xy + m, xy] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, xy + m, xy);
                    WinCheck(counter, searchLength);
                }
                counter = 0;

                visualMatrix = (string[,])matrix.Clone();

                // Diagonal /
                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    counter = matrix[(matrixBase - 1) - xy, xy + m] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, (matrixBase - 1) - xy, xy + m);
                    WinCheck(counter, searchLength);
                }
                counter = 0;

                for (int xy = 0; xy < matrixBase - m; xy++)
                {
                    counter = matrix[(matrixBase - 1) - xy - m, xy] == ofIntrest ? counter + 1 : 0;
                    print(visualMatrix, (matrixBase - 1) - xy - m, xy);
                    WinCheck(counter, searchLength);
                }
                counter = 0;
            }
        }

        private static void WinCheck(int counter, int searchLength)
        {
            if (counter == searchLength) Console.Write("WIN");
        }

        private static void print(string[,] visualMatrix, int x, int y)
        {
            visualMatrix[x, y] = " ";
            var boardBase = Math.Sqrt(visualMatrix.Length);
            int viewSpeed = 50;
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
