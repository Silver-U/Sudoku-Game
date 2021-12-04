using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Sudoku_Games.Model;
using Sudoku_Games.View;

namespace Sudoku_Games.ViewModels
{
    public class ViewModel_MainPage
    {
        private MainWindow view;
        private const int cote = 9;
        //private GameGrid gameArea_UserControl;
        private ViewModel_GameArea vmGameArea;
        //private GridOfCells gameArea_UserControl ;
        //private IList<CellOfGrid> selectedCells = new List<CellOfGrid>();

        public ViewModel_MainPage(MainWindow view, GridOfCells gridOfCells)
        {
            this.view = view;

            vmGameArea = gridOfCells.getVmGameArea();
        }

        public void TurnOnVAlueMode()
        {
            vmGameArea.TurnOnVAlueMode();
        }

        public void TurnOnColorMode()
        {
            vmGameArea.TurnOnColorMode();
        }

        public void TurnOnPNMode()
        {
            vmGameArea.TurnOnPNMode();
        }

        public void TurnOnSelectMode()
        {
            vmGameArea.TurnOnSelectMode();
        }

        public void ShareBackgroundColorToAllCell(string color)
        {
            vmGameArea.ShareBackgroundColorToAllCell(color);
        }

        public void LoadBoard(Board board)
        {
            ViewModel_GameArea test = new ViewModel_GameArea(new GridOfCells());
            var temp = test.GetCellOfGrids();
            CellOfGrid tempCoG;
            Cell tempCell;
            for (int i = 0; i < cote; i++)
            {
                for (int j = 0; j < cote; j++)
                {
                    tempCoG = temp[i, j];
                    tempCell = board.getGrid()[i, j];

                    tempCoG.SetCell(tempCell);
                    tempCoG.setCellValueTxtBx("" + tempCell.getValue());
                    if(tempCell.HasPn() && tempCell.getValue() == 0)
                        tempCoG.FillPnWithCellPN(tempCell);

                    tempCoG.ChangeBackgroundColor(tempCell.getColorValue());

                }
            }

            vmGameArea = test;
        }

        //public void DisableTextboxes()
        //{
        //    foreach (CellOfGrid cellOfGrid in gameArea_UserControl.GetCellOfGrids())
        //    {
        //        cellOfGrid.CellValue.IsEnabled = false;
        //    }
        //}

    }

}
