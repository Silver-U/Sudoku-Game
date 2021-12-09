using Sudoku_Games.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games
{
    public class GameController : IGameController
    {
        private MainWindow view;
        public Board board = Board.Instance();

        public GameController(MainWindow view, Board board)
        {
            this.board = board;
            this.view = view;
        }

        public Board GetBoard()
        {
            return board;
        }

        public void setCellValue(int row, int col, int value)
        {
            board.getGrid().SetValue(row, col, value);
        }
       public Board Grid => board;
    }
}
