using Sudoku_Games.Model;
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

        public static CommandInvoker Instance
        {
            get
            {
                if (instance == null)
                    instance = new CommandInvoker();

                return instance;
            }
        }

        private Stack<Board> UndohistoryBoard = new Stack<Board>();
        private Stack<Board> RedohistoryBoard = new Stack<Board>();


        private CommandInvoker() { }


        public void Execute(ICommandUR command, Board board)
        {
            UndohistoryBoard.Push(board);
            command.Execute();
        }

        public void Undo()
        {
            RedohistoryBoard.Push(UndohistoryBoard.Pop()); 
        }

        public void Redo()
        {
            UndohistoryBoard.Push(RedohistoryBoard.Pop());
        }
    }
}
