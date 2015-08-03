using System;

namespace Task1
{
    public class SquareMatrix<T>
    {
        #region Private fields

        protected T[][] SquareArray;

        #endregion

        #region Ctors

        public SquareMatrix(int side)
        {
            SquareArray = new T[side][];
            for (int i = 0; i < side; i++)
                SquareArray[i] = new T[side];
            Size = side;
            Size = side;
        }

        public SquareMatrix(T[,] matrix)
        {
            if (matrix == null)
                throw new ArgumentNullException();
            if (!IsValid(matrix))
                throw new ArgumentException();
            Size = matrix.GetLength(0);
            Size = Size;
            SquareArray = new T[Size][];
            for (int i = 0; i < Size; i++)
            {
                SquareArray[i] = new T[Size];
                for (int j = 0; j < Size; j++)
                    SquareArray[i][j] = matrix[i, j];
            }
        }

        protected SquareMatrix()
        {
            
        }

        #endregion

        #region Properties and events

        public event EventHandler<MatrixChangeEventArgs> MatrixChange = delegate { };
        public void OnMatrixChange(object obj, MatrixChangeEventArgs args) { MatrixChange(obj, args); }

        public int Size { get; protected set; }

        public virtual T this[int first, int second]
        {
            get
            {
                if (first > Size || first < 0 || second > Size || second < 0)
                    throw new ArgumentException();
                return SquareArray[first][second];
            }
            set
            {
                if (first > Size || first < 0 || second > Size || second < 0)
                    throw new ArgumentException();
                SquareArray[first][second] = value;
                OnMatrixChange(this, new MatrixChangeEventArgs(first, second));
            }
        }

        #endregion

        #region Private methods

        private bool IsValid(T[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
                return true;
            return false;
        }

        #endregion

    }
}
