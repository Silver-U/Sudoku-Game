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

namespace Sudoku_Games.View
{
    /// <summary>
    /// Interaction logic for ButtonView.xaml
    /// </summary>
    public partial class ButtonView : UserControl
    {
        public static bool insertValueMode = true;
        private bool insertPNMode = false;
        private bool insertColorMode = false;
        private bool selectionMode = false;

        public ButtonView()
        {
            InitializeComponent();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void finalValue_Click(object sender, RoutedEventArgs e)
        {
            insertValueMode = true;
            insertPNMode = false;
            insertColorMode = false;
            selectionMode = false;
            MessageBox.Show("insertValueMode" + insertValueMode);
        }

        private void mayValue_Click(object sender, RoutedEventArgs e)
        {
            insertValueMode = false;
            insertPNMode = true;
            insertColorMode = false;
            selectionMode = false;

            MessageBox.Show("insertPNMode" + insertPNMode);
        }

        private void color_Click(object sender, RoutedEventArgs e)
        {
            insertValueMode = false;
            insertPNMode = false;
            insertColorMode = true;
            selectionMode = false;
            MessageBox.Show("insertColorMode" + insertColorMode);
        }

        private void selection_Click(object sender, RoutedEventArgs e)
        {
            insertValueMode = false;
            insertPNMode = false;
            insertColorMode = false;
            selectionMode = true;
        }

        public static bool getInsertValueMode()
        {
            return insertValueMode;
        }


    }
}
