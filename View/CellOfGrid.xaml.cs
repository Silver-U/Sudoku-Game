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

namespace Sudoku_Games.View
{
    /// <summary>
    /// Interaction logic for Cell.xaml
    /// </summary>
    public partial class CellOfGrid : UserControl
    {
        private Cell cell;
        private TextBlock[] textblockSync;
        private TextBox cellValues;
        private bool ValueMode = ButtonView.getInsertValueMode();
        private bool pnMode = true;


        public CellOfGrid()
        {
            InitializeComponent();
            cell = new Cell();
            textblockSync = initNoteSync();
            cellValues = CellValue;
            //TurnOfPNModeCell();
            //TurnOfPNModeLine();

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
            if(!cell.getEditable())
            {
                cellValues.IsReadOnly = true;
            }
        }

        public Cell GetCell()
        {
            return cell;
        }
        public string getCellValue()
        {
            return CellValue.Text;
        }

        public void setCellValue(string value)
        {
            //CellValue.Text = value;
            if(value.Equals(""))
            {
                cell.setValue(0);
            }
            else
            {
                cell.setValue(int.Parse(value));
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

        public void addPN(String pn)
        {
            for(int i = 1; i < textblockSync.Length; i++)
            {
                if(textblockSync[i].Text.Equals("") || textblockSync[i].Text.Equals("0"))
                {                   
                    if(!cell.getPotentialValue().Contains(int.Parse(pn)))
                    {
                        textblockSync[i].Text = pn;
                        cell.AddPotentialValue(int.Parse(pn));
                    }
                    break;
                }
            }
        }

        public void Clear()
        {
            foreach (TextBlock textBlock in textblockSync)
                textBlock.Text = "";
            cellValues.Text = "";
            cell = new Cell();
        }

        private void CellValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(cellValues == null)
            {
                
            }
            else
            {
                //if (textBoxSync == null)
                //{
                //    textBoxSync = InitTextBoxSync();
                //}
                if (ValueMode)
                {
                    //TurnOfPNModeCell();
                    setCellValue(CellValue.Text);
                    HideCellValue0();
                }
                if (pnMode)
                {
                    CellValue.Text = "";                    
                    // TurnOfValueMode();
                }
            }
        }

        private void TurnOfPNModeCell()
        {
            for (int i = 1; i < textblockSync.Length; i++)
            {
                textblockSync[i].IsEnabled = false;
            }
        }

        private void TurnOfPNModeLine()
        {
            textblockSync[0].IsEnabled = false;
        }

        private void TurnOfValueMode()
        {
            cellValues.IsEnabled = false;
        }

        public String getNameTextBox()
        {
            return CellValue.Name;
        }


        private void CellValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.A)
            {
                Clear();
                MessageBox.Show("delete");
            }
            else
            {
                if (pnMode)
                {
                    //MessageBox.Show("yo");
                    addPN(e.Key.ToString().Last().ToString());
                    //CellValue.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
