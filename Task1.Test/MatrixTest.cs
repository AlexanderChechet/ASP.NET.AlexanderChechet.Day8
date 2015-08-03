using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task1.Test
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareMatrix_CtorException()
        {
            var first = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6}
            };
            var lol = new SquareMatrix<int>(first);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SquareMatrix_IndexException()
        {
            var first = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var lol = new SquareMatrix<int>(first);
            var integer = lol[-1, 2];
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SquareMatrix_AdditionException()
        {
            var first = new int[,]
            {
                {1, 2, 3},
                {4, 5, 6},
                {7, 8, 9}
            };
            var second = new int[,]
            {
                {1, 2},
                {4, 5}
            };
            var lolFirst = new SquareMatrix<int>(first);
            var lolSecond = new SquareMatrix<int>(second);
            var lolThird = lolFirst.Add(lolSecond);
        }

    }
}
