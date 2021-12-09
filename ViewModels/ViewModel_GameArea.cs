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
        private const int cote = 9;
        private static IList<CellOfGrid> selectedCells;
        private static bool drawingState;
        private bool ValueMode;
        private bool pnMode;
        private bool colorMode;
        private bool selectMode;
        private bool selectModeForPN;


        public ViewModel_GameArea(GridOfCells gridOfCells)
        {
            drawingState = false;
            selectedCells = new List<CellOfGrid>();
            gameArea = gridOfCells;
            TurnOnVAlueMode();
        }



        public static void AddCellToSelection(CellOfGrid cellOfGrid)
        {
            cellOfGrid.ChangeBorder();
            selectedCells.Add(cellOfGrid);
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
                cellOfGrid.ClearBorder();
            }
            ClearSelection();
        }

        public void UpdatePnOfSelectedCells(string pn)
        {
            foreach (CellOfGrid cellOfGrid in selectedCells)
            {
                cellOfGrid.addPN(pn);
                cellOfGrid.ClearBorder();
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
            selectModeForPN = false;
            selectMode = false;
            colorMode = false;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnValueMode();
            }
        }

        public void ChangeDisplaypn()
        {
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.ChangeDisplaypn();
            }
        }

        public void TurnOnColorMode()
        {
            ValueMode = false;
            pnMode = false;
            selectMode = false;
            selectModeForPN = false;
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
            selectModeForPN = false;
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
            selectModeForPN = false;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnSelectMode();
            }
        }

        public void TurnOnSelectModeForPN()
        {
            ValueMode = false;
            pnMode = false;
            selectMode = false;
            colorMode = false;
            selectModeForPN = true;
            foreach (CellOfGrid cellOfGrid in gameArea.GetCellOfGrids())
            {
                cellOfGrid.TurnOnSelectModeForPN();
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

        public bool getselectModeForPN()
        {
            return selectModeForPN;
        }

        public static bool getDrawingState()
        {
            return drawingState;
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

        public void DrawBoard()
        {
            drawingState = true;
            //Board.Instance().setGrid(cells);
            //gameArea.setBoard(board);
            var temp = gameArea.GetCellOfGrids();

            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    temp[i, j].FillMeWithCell(Board.Instance().getGrid()[i, j]);
                }
            }
            gameArea.CheckValue();
            drawingState = false;
        }

    }
}
