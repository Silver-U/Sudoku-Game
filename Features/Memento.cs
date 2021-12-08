using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sudoku_Games.Model;
using System.Threading.Tasks;

namespace Sudoku_Games.Features
{
    public class Memento
    {
        private Stack<Cell[,]> undohistoryBoard = new Stack<Cell[,]>();
        private Stack<Cell[,]> redohistoryBoard = new Stack<Cell[,]>();
        private static Memento instance;

        private Memento(Cell[,] cells)
        {
            undohistoryBoard.Push(cells);
        }

        public static Memento Instance()
        {
            if (instance == null)
                instance = new Memento(Board.Instance().getGrid());
            return instance;
        }

        public void SaveMemento()
        {
            undohistoryBoard.Push(Board.Instance().getGrid());
        }

        public Cell[,] LoadMemento()
        {
            return undohistoryBoard.Pop();
        }



    }
}
