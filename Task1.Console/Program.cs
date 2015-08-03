namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] first =
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            int[,] second =
            {
                {1, 2, 3},
                {2, 5, 6},
                {3, 6, 9}
            };
            int[,] third =
            {
                {1, 0, 0},
                {0, 5, 0},
                {0, 0, 9}
            };
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            SquareMatrix<int> lol1 = new SquareMatrix<int>(first);
            SymmetricMatrix<int> lol2 = new SymmetricMatrix<int>(second);
            DiagonalMatrix<int> lol3 = new DiagonalMatrix<int>(third);
            matrix.MatrixChange += ShowChanges;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    matrix[i, j] = i*j;
            System.Console.ReadLine();
        }

        public static void ShowChanges(object obj, MatrixChangeEventArgs args)
        {
            System.Console.WriteLine("Changed value in matrix on position [{0},{1}]", args.I, args.J);
        }
    }
}
