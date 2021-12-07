using Sudoku_Games.Model;
using Sudoku_Games.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Sudoku_Games.ViewModels
{
    public class ViewModel_GameArea
    {
        private GridOfCells gameArea;
        private Board board;
        private const int cote = 9;
        private static IList<CellOfGrid> selectedCells;
        private bool ValueMode;
        private bool pnMode;
        private bool colorMode;
        private bool selectMode;

        public ViewModel_GameArea(GridOfCells gridOfCells)
        {
            board = new Board();
            selectedCells = new List<CellOfGrid>();
            gameArea = gridOfCells;
            TurnOnVAlueMode();
            //        ValueMode = true;
            //        pnMode = false;
            //        selectMode = false;
            //        colorMode = false;
        }

        //public void ColorCellThatChangeValue()
        //{
        //    for (int i = 0; i < cote; i++)
        //    {
        //        for (int j = 0; j < cote; j++)
        //        {
        //            if (!board.CheckIfCellValide(i, j))
        //            {
        //                cellsofGrid[i, j].cellBorder.Background = Brushes.BlueViolet;
        //            }
        //            else
        //            {
        //                cellsofGrid[i, j].cellBorder.Background = Brushes.Transparent;
        //            }

        //        }

        //    }
        ////}

        public static void AddCellToSelection(CellOfGrid cellOfGrid)
        {
            selectedCells.Add(cellOfGrid);
        }
        public Board GetBoard()
        {
            return board;
        }
        
        public CellOfGrid[,] GetCellOfGrids()
        {
            return gameArea.GetCellOfGrids();
        }

        public IList<CellOfGrid> getSelectedCells()
        {
            return selectedCells;
        }

        public void UpdateValueOfSelectedCells(string cellValue)
        {
            foreach (CellOfGrid cellOfGrid in selectedCells)
            {
                cellOfGrid.CellValue.Text = cellValue;
                cellOfGrid.setCellValue(cellValue);
            }
            ClearSelection();
        }
        private void ClearSelection()
        {
            selectedCells = new List<CellOfGrid>();
        }

        public void TurnOnVAlueMode()
        {
            ValueMode = true;
            pnMode = false;
            selectMode = false;
            colorMode = false;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnValueMode();
            }
        }

        public void TurnOnColorMode()
        {
            ValueMode = false;
            pnMode = false;
            selectMode = false;
            colorMode = true;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnColorMode();
            }
        }

        public void TurnOnPNMode()
        {
            ValueMode = false;
            pnMode = true;
            selectMode = false;
            colorMode = false;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnPNMode();
            }
        }

        public void TurnOnSelectMode()
        {
            ValueMode = false;
            pnMode = false;
            selectMode = true;
            colorMode = false;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnSelectMode();
            }
        }

        public bool getValueMode()
        {
            return ValueMode;
        }
        public bool getPnMode()
        {
            return pnMode;
        }
        public bool getColorMode()
        {
            return colorMode;
        }
        public bool getSelectMode()
        {
            return selectMode;
        }

        public void ShareBackgroundColorToAllCell(string color)
        {
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.setColor(color);
            }
        }

        public void ColorSelectedCell(String color)
        {
            foreach (CellOfGrid cellOfGrid in selectedCells)
            {
                cellOfGrid.ChangeBackgroundColor(color);
            }
            selectedCells = new List<CellOfGrid>();
        }

        public void LoadBoard(Board board)
        {
            this.board = board;
            gameArea.setBoard(board);
            var temp = gameArea.GetCellOfGrids();

            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    temp[i, j].FillMeWithCell(this.board.getGrid()[i, j]);
                }
            }
        }
    }
}
