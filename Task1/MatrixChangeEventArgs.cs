using System;

namespace Task1
{
    public class MatrixChangeEventArgs : EventArgs
    {
        public MatrixChangeEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }

        public int I { get; private set; }
        public int J { get; private set; }
    }
}
