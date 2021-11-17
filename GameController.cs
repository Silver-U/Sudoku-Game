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
        public Board grid { get; }

        public GameController(MainWindow view, Board grid)
        {
            this.grid = grid;
            this.view = view;
        }

       public Board Grid => grid;
    }
}
