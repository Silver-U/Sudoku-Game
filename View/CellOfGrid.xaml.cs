using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Sudoku_Games.Model;
using Sudoku_Games.ViewModels;

namespace Sudoku_Games.View
{
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    /// 
    public partial class CellOfGrid : UserControl
    {
        /// <summary>
        /// Question pour le prof, comment faire pour que delete soit considerer si curseur derriere chiffre
        /// </summary>
        private Cell cell;
        private TextBlock[] textblockSync;
        private TextBox cellValue;
        private bool ValueMode ;
        private bool pnMode ;
        private bool colorMode ;
        private bool selectMode ;
        private string color;


        public CellOfGrid()
        {
            InitializeComponent();
            cell = new Cell();
            textblockSync = initNoteSync();
            cellValue = CellValue;
            //TurnOfPNModeCell();
            //TurnOfPNModeLine();
            TurnOnValueMode();

        }


        public TextBlock[] initNoteSync()
        {
            TextBlock[] temp = new TextBlock[10];

            temp[0] = ligneOfPn;
            temp[1] = pn0;
            temp[2] = pn1;
            temp[3] = pn2;
            temp[4] = pn3;
            temp[5] = pn4;
            temp[6] = pn5;
            temp[7] = pn6;
            temp[8] = pn7;
            temp[9] = pn8;

            return temp;
        }
        public void HideCellValue0()
        {
            if (CellValue.Text.Equals("0"))
                CellValue.Text = "";
        }

        public void Editable()
        {
            if (!cell.getEditable())
            {
                cellValue.IsReadOnly = true;
            }
        }

        public Cell GetCell()
        {
            return cell;
        }

        public void SetCell(Cell cell)
        {
            this.cell = cell;
        }
        public string getCellValue()
        {
            return CellValue.Text;
        }

        public void setCellValue(string value)
        {
            if (value.Equals(""))
            {
                cell.setValue(0);
            }
            else
            {
                cell.setValue(int.Parse(value));
            }
        }

        public void setCellValueTxtBx(string value)
        {
            if (value.Equals("0"))
            {
                cellValue.Text = "";
            }
            else
            {
                cellValue.Text = value;
            }
        }

        public String getPNString()
        {
            return String.Join("", getPNHashset());
        }

        public HashSet<int> getPNHashset()
        {
            return cell.getPotentialValue();
        }

        private void addPN(String pn)
        {
            for (int i = 1; i < textblockSync.Length - 1; i++)
            {
                if (textblockSync[i].Text.Equals("") || textblockSync[i].Text.Equals("0"))
                {
                    if (!cell.getPotentialValue().Contains(int.Parse(pn)))
                    {
                        textblockSync[i].Text = pn;
                        cell.AddPotentialValue(int.Parse(pn));
                    }
                    break;
                }
            }
        }

        public void FillPnWithCellPN(Cell cell)
        {
            int j = 0;
            int i = 1;
            var TempPnHS = cell.getPotentialValue().ToList();
            while (j < TempPnHS.Count || i < textblockSync.Length - 1)
            {
                textblockSync[i].Text = "" + TempPnHS[j];
                i++;
                j++;
            }        
        }

        private void Clear()
        {
            ChangeBackgroundColor("ffffff");
            foreach (TextBlock textBlock in textblockSync)
                textBlock.Text = "";
            cellValue.Text = "";
            cell = new Cell();
        }

        private void ClearPn()
        {
            cell.ClearPotentialValue();
            foreach (TextBlock textBlock in textblockSync)
                textBlock.Text = "";
        }

        private void CellValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cellValue == null)
            {

            }
            else
            {
                if (ValueMode)
                {
                    if (cell.HasPn())
                        ClearPn();
                    setCellValue(CellValue.Text);
                    HideCellValue0();
                }

                if (pnMode)
                {
                    CellValue.Text = "";
                }
            }
        }

        public void TurnOnPNMode()
        {
            ValueMode = false;
            pnMode = true;
            colorMode = false;
            selectMode = false;
        }

        public void TurnOnColorMode()
        {
            ValueMode = false;
            pnMode = false;
            colorMode = true;
            selectMode = false;
        }

        public void TurnOnValueMode()
        {
            ValueMode = true;
            pnMode = false;
            colorMode = false;
            selectMode = false;
        }

        public void TurnOnSelectMode()
        {
            ValueMode = false;
            pnMode = false;
            colorMode = false;
            selectMode = true;
        }


        public String getNameTextBox()
        {
            return CellValue.Name;
        }


        private void CellValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A)
            {
                Clear();
            }
            else
            {
                if (pnMode)
                {
                    if(CellValue.Text.Equals(""))
                        addPN(e.Key.ToString().Last().ToString());
                }
            }
        }

        public void setColor(string color)
        {
            this.color = color;
        }

        public void ChangeBackgroundColor(string color)
        {
            if(color.Equals("ffffff"))
            {
                cellBorder.Background = Brushes.Transparent;
            }
            else
            {
                cellBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + color));
            }

            cell.setColorValue(color);
        }

        private void CellValue_GotFocus(object sender, RoutedEventArgs e)
        {
            if (colorMode)
                ChangeBackgroundColor(color);

            if (selectMode)
            {
                //GridOfCells.getVmGameArea().AddCellToSelection(this);
                ViewModel_GameArea.AddCellToSelection(this);
            }

            //if (ek.Key == Key.Back || ek.Key == Key.Delete)
            //{
            //    Clear();
            //    //MessageBox.Show("delete");
            //}
        }
        //if (colorMode)
        //        ChangeBackgroundColor(color);
    }
}
