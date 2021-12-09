using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using Sudoku_Games.Model;
using Sudoku_Games.Features;
using Sudoku_Games.View;

namespace Sudoku_Games.ViewModels
{
    public class ViewModel_MainPage
    {
        private MainWindow view;
        private const int cote = 9;
        //private GameGrid gameArea_UserControl;
        private ViewModel_GameArea vmGameArea;
        private CommandInvoker invoker;
        //private CommandInvoker invoker = CommandInvoker.Instance;
        //private GridOfCells gameArea_UserControl ;
        //private IList<CellOfGrid> selectedCells = new List<CellOfGrid>();

        public ViewModel_MainPage(MainWindow view, GridOfCells gridOfCells)
        {
            this.view = view;

            vmGameArea = gridOfCells.getVmGameArea();
            invoker = CommandInvoker.Instance;
        }

        public bool getValueMode()
        {
            return vmGameArea.getValueMode();
        }
        public bool getPnMode()
        {
            return vmGameArea.getPnMode();
        }
        public bool getColorMode()
        {
            return vmGameArea.getColorMode();
        }
        public bool getSelectMode()
        {
            return vmGameArea.getSelectMode();
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

        public void ColorSelectedCell(String color)
        {
            vmGameArea.ColorSelectedCell(color);
            invoker.Execute();
        }

        public void DrawBoard()
        {
            vmGameArea.DrawBoard();
            ////ViewModel_GameArea test = new ViewModel_GameArea(new GridOfCells());
            //var temp = vmGameArea.GetCellOfGrids();
            ////CellOfGrid tempCoG;
            ////Cell tempCell;
            ////vmGameArea = new ViewModel_GameArea(new GridOfCells());
            //for (int i = 0; i < cote; i++)
            //{
            //    for (int j = 0; j < cote; j++)
            //    {
            //        temp[i, j].FillMeWithCell(board.getGrid()[i, j]);
            //        //vmGameArea = new ViewModel_GameArea(new GridOfCells());
            //        //tempCoG = vmGameArea.GetCellOfGrids()[i, j];
            //        //tempCoG.Clear();
            //        //tempCell = board.getGrid()[i, j];

            //        //tempCoG.SetCell(tempCell);
            //        //tempCoG.setCellValueTxtBx("" + tempCell.getValue());
            //        //if(tempCell.HasPn() && tempCell.getValue() == 0)
            //        //    tempCoG.FillPnWithCellPN(tempCell);

            //        //tempCoG.ChangeBackgroundColor(tempCell.getColorValue());

            //    }
            //}
            ////MainWindow.setMP(this);
            ////vmGameArea = test;
        }

        public void NewGame()
        {
            //DrawBoard(new C);
        }
        public void SaveBoard()
        {
            SaveAndLoad.SaveGame(Board.Instance());
        }

        public void LoadBoard()
        {
            SaveAndLoad.LoadGame();
            DrawBoard();
        }


    }

}
