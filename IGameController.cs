using Sudoku_Games.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games
{
    public interface IGameController
    {
        Board Grid {get; }
    }
}
