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
            Width = side;
            Heigth = side;
        }

        public SquareMatrix(T[,] matrix)
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
                SquareArray[i] = new T[Width];
                for (int j = 0; j < Width; j++)
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

        public int Width { get; protected set; }
        public int Heigth { get; protected set; }

        public virtual T this[int first, int second]
        {
            get
            {
                if (first > Heigth || first < 0 || second > Width || second < 0)
                    throw new ArgumentException();
                return SquareArray[first][second];
            }
            set
            {
                if (first > Heigth || first < 0 || second > Width || second < 0)
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
