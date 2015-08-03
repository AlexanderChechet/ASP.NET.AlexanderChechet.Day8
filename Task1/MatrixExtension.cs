using System;

namespace Task1
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> main, SquareMatrix<T> additional)
        {
            if (additional == null)
                throw new ArgumentNullException();
            if (main.Size != additional.Size)
                throw new InvalidOperationException();
            int size = main.Size;
            var result = new T[size, size];
            try
            {
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++)
                        result[i, j] = Add<T>(main[i, j], additional[i, j]);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("add exception",e);
            }
            return new SquareMatrix<T>(result);
        }


        private static dynamic Add<TResult>(dynamic first, dynamic second)
        {
            return (TResult) (first + second);
        }
    }
}
