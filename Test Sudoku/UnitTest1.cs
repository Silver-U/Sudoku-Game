using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku_Games.Model;
using Sudoku_Games.Features;
using System;
using System.Collections.Generic;

namespace Test_Sudoku
{
    [TestClass]
    public class UnitTest1
    {
        private Board board;
        private CommandInvoker invoker;
        Cell cell;

        [TestInitialize]
        public void Setup()
        {
            cell = new Cell(9, "ff1aff");
            invoker = CommandInvoker.Instance;
            board = Board.Instance();
            Cell[,] cells = {{new Cell(5), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(5), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(3), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(8), new Cell()},
                             {new Cell(1), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(3), new Cell(), new Cell(), new Cell(), new Cell()}};

            

            board.setGrid(cells);
        }

        [TestMethod]
        public void TestCellValideFalseCase11()
        {
            Assert.IsFalse(board.CheckIfCellValide(0, 0));
        }

        [TestMethod]
        public void TestCellValideFalseCase12()
        {
            Assert.IsFalse(board.CheckIfCellValide(0, 6));
        }

        [TestMethod]
        public void TestCellValideFalseCase21()
        {
            Assert.IsFalse(board.CheckIfCellValide(2, 4));
        }

        [TestMethod]
        public void TestCellValideFalseCase22()
        {
            Assert.IsFalse(board.CheckIfCellValide(8, 4));
        }

        [TestMethod]
        public void TestCellValideFalseCase31()
        {
            Assert.IsFalse(board.CheckIfCellValide(6, 0));
        }

        [TestMethod]
        public void TestCellValideFalseCase32()
        {
            Assert.IsFalse(board.CheckIfCellValide(8, 2));
        }

        [TestMethod]
        public void TestCellValideTrue()
        {
            Assert.IsTrue(board.CheckIfCellValide(5, 7));
        }

        [TestMethod]
        public void EdgeCaseFromUITest()
        {
            Cell[,] _cells = {{new Cell(1), new Cell(1), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(1)},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(5), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(1), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(1), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(1)}};
            board.setGrid(_cells);
            Assert.IsTrue(board.CheckIfCellValide(1, 4));
        }


        [TestMethod]
        public void SaveGameTest()
        {
            var ts = new HashSet<int>();
            ts.Add(2);
            ts.Add(5);
            Cell[,] _cells = {{new Cell(1), new Cell(ts), new Cell(0, "ff1a1a"), new Cell(5), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()}};
            board.setGrid(_cells);

            var stringOfBoard = "";

            foreach (string s in SaveAndLoad.BoardToString(board))
            {
                stringOfBoard += s;
                Console.WriteLine(stringOfBoard);
            }

            Console.WriteLine(stringOfBoard);

            var test = stringOfBoard.Clone();
            string expecteString = "1#ffffff##True0#ffffff#25#True0#ff1a1a##True5#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True";

            Assert.AreEqual(stringOfBoard, expecteString);

        }

        public void LoadGameTest()
        {
            var ts = new HashSet<int>();
            ts.Add(2);
            ts.Add(5);
            Cell[,] _cells = {{new Cell(1), new Cell(ts), new Cell(0, "ff1a1a"), new Cell(5), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()},
                             {new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell(), new Cell()}};
            board.setGrid(_cells);

            var stringOfBoard = "";

            foreach (string s in SaveAndLoad.BoardToString(board))
            {
                stringOfBoard += s;
                Console.WriteLine(stringOfBoard);
            }

            Console.WriteLine(stringOfBoard);

            var test = stringOfBoard.Clone();
            string expecteString = "1#ffffff##True0#ffffff#25#True0#ff1a1a##True5#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True0#ffffff##True";

            Assert.AreEqual(stringOfBoard, expecteString);

        }




    }
    
}
