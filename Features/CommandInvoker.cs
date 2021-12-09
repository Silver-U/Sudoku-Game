using Sudoku_Games.Model;
using Sudoku_Games.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games.Features
{
    sealed class CommandInvoker
    {
        private static CommandInvoker instance;
        private const int cote = 9;
        Board board = Board.Instance();


        public static CommandInvoker Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandInvoker();

                return instance;
            }
        }

        private Stack<Cell[,]> HistoryBoard = new Stack<Cell[,]>();
        private Stack<Cell[,]> redohistoryBoard = new Stack<Cell[,]>();

        private CommandInvoker() 
        {
            HistoryBoard.Push(CopyWithoutReference(board.getGrid()));
            //HistoryBoard.Pop();
        }


        public void Execute()
        {
            //Cell[,] cells = board.getGrid();

            //Console.WriteLine("pn board " + board.getGrid()[0, 0].getPotentialValue().ToString() + "    pn history " + HistoryBoard.Peek()[0, 0].getPotentialValue().ToString());
            if (!ViewModel_GameArea.getDrawingState())
                HistoryBoard.Push(CopyWithoutReference(board.getGrid()));
            //HistoryBoard.Pop();
            Console.WriteLine("pn board " + board.getGrid()[0, 0].getPotentialValue().ToString() + "    pn history " + HistoryBoard.Peek()[0, 0].getPotentialValue().ToString());


            //undohistoryBoard.Push((Cell[,])board.getGrid().Clone());
            //command.Execute();
        }
        public void Nothing()
        {

        }

        public void Undo()
        {
            if(HistoryBoard.Count == 1)
            {
                board.setGrid(HistoryBoard.Peek());
            }

            if (HistoryBoard.Count > 1)
            {
                redohistoryBoard.Push(CopyWithoutReference(HistoryBoard.Pop()));
                board.setGrid(HistoryBoard.Peek());
            }            
        }

        public void Redo()
        {
            if(redohistoryBoard.Count != 0)
            {   
                board.setGrid(redohistoryBoard.Peek());
                HistoryBoard.Push(CopyWithoutReference(redohistoryBoard.Pop()));
            }
        }
        
        //public void Undo()
        //{
        //    //board.SeTCellValue(0, 0, 8);
        //    if (undohistoryBoard.Count != 0)
        //    {
        //        Console.WriteLine(redohistoryBoard.Count + "    " + undohistoryBoard.Count);

        //        redohistoryBoard.Push(board.getGrid());
        //        board.setGrid(undohistoryBoard.Pop());

        //        //return undohistoryBoard.Pop();
        //    }
        //    //return undohistoryBoard.Pop();
        //    //redohistoryBoard.Push(board.getGrid());
        //    //board.setGrid(undohistoryBoard.Pop());
        //}

        //public void Redo()
        //{
        //    Console.WriteLine(redohistoryBoard.Count + "    " + undohistoryBoard.Count);

        //    if (redohistoryBoard.Count != 0)
        //    {
        //        var hy = undohistoryBoard.Peek() == redohistoryBoard.Peek();
        //        Console.WriteLine(redohistoryBoard.Count + "    " + undohistoryBoard.Count);
        //        undohistoryBoard.Push(board.getGrid());
        //        board.setGrid(redohistoryBoard.Pop());
        //    }

        //}

        private Cell[,] CopyWithoutReference(Cell[,] cells)
        {
            Cell[,] copy = new Cell[cote, cote];

            for(int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    copy[i, j] = new Cell(cells[i, j]);
                }
            }
            return copy;
        }
    }
}
