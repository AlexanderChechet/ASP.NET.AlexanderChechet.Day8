using System;

namespace Task1
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        #region Ctors

        public SymmetricMatrix(int side)
        {
            SquareArray = new T[side][];
            for (int i = 0; i < side; i++)
                SquareArray[i] = new T[i + 1];

        }

        public SymmetricMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (!IsValid(matrix))
                throw new ArgumentException();
            Width = matrix.GetLength(0);
            Heigth = Width;
            SquareArray = new T[Heigth][];
            for (int i = 0; i < Heigth; i++)
            {
                SquareArray[i] = new T[i + 1];
                for (int j = 0; j < i + 1; j++)
                    SquareArray[i][j] = matrix[i, j];
            }
        }

        #endregion

        #region Properties

        public override T this[int first, int second]
        {
            get
            {
                if (first > Heigth || first < 0 || second > Width || second < 0)
                    throw new ArgumentException();
                if (second > first)
                    return SquareArray[second][first];
                return SquareArray[first][second];
            }
            set
            {
                if (first > Heigth || first < 0 || second > Width || second < 0)
                    throw new ArgumentException();
                if (second > first)
                    SquareArray[second][first] = value;
                else
                    SquareArray[first][second] = value;
                OnMatrixChange(this, new MatrixChangeEventArgs(second, first));
                OnMatrixChange(this, new MatrixChangeEventArgs(first, second));
            }
        }

        #endregion

        #region private methods

        private bool IsValid(T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return false;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < i + 1; j++)
                    if (!Equals(matrix[i,j], matrix[j,i]))
                        return false;
            return true;
        }

        #endregion
    }
}
