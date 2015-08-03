using System;

namespace Task1
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        #region Ctors

        public DiagonalMatrix(int side)
        {
            SquareArray = new T[1][];
            SquareArray[0] = new T[side];
        }

        public DiagonalMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (!IsValid(matrix))
                throw new ArgumentException();
            Size = matrix.GetLength(0);
            Size = Size;
            SquareArray = new T[1][];
            SquareArray[0] = new T[Size];
            for (int i = 0; i < Size; i++)
            {
                SquareArray[0][i] = matrix[i, i];
            }
        }

        #endregion

        #region Properties

        public override T this[int first, int second]
        {
            get
            {
                if (first > Size || first < 0 || second > Size || second < 0)
                    throw new ArgumentException();
                if (first == second)
                    return SquareArray[0][first];
                return default(T);
            }
            set
            {
                if (first != second || first > Size || first < 0 || second > Size || second < 0)
                    throw new ArgumentException();
                SquareArray[0][first] = value;
                OnMatrixChange(this, new MatrixChangeEventArgs(first, first));
            }
        }

        #endregion 

        #region Private methods

        private bool IsValid(T[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                return false;
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(0); j++)
                    if (i != j)
                        if (!Equals(matrix[i, j], default(T)))
                            return false;
            return true;
        }
        #endregion
    }
}
