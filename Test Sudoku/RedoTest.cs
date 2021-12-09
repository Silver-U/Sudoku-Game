using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Sudoku_Games.Model;
using Sudoku_Games.Features;

namespace Test_Sudoku
{
    [TestClass]
    public class RedoTest
    {
        private Board board;
        private CommandInvoker invoker;
        Cell cell;

        [TestInitialize]
        public void Setup()
        {
            cell = new Cell(9, "ff1aff");
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
            invoker = CommandInvoker.Instance;

        }

        [TestMethod]
        public void Test()
        {
            board.SeTCell(0, 0, cell);
            invoker.Execute();
            invoker.Undo();
            invoker.Redo();
            Assert.AreEqual(board.GetCell(0, 0), cell);
            Assert.AreEqual(board.GetCell(0, 0).getColorValue(), cell.getColorValue());
        }
    }
}
