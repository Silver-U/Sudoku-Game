using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku_Games.Model
{
    public class Cell
    {
        private int value;
        private bool editable = true;
        private Colors colorValue = Colors.ffffff;
        private HashSet<int> potentialValues = new HashSet<int>();

        public Cell()
        {
            value = 0;
        }

        public Cell(int value)
        {
            if (value == 0)
                editable = false;

            this.value = value;
        }

        public Cell(int value, string colorValue)
        {
            if (value == 0)
                editable = false;

            this.colorValue = (Colors)Enum.Parse(typeof(Colors), colorValue);
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is Cell cell && value == cell.value;
        }
        
        public int getValue()
        {
            return value;
        }
        public bool getEditable()
        {
            return editable;
        }

        public HashSet<int> getPotentialValue()
        {
            return potentialValues;
        }

        public bool HasPn()
        {
            return !(potentialValues.Count() == 0 || potentialValues == null);
        }
        public string getColorValue()
        {
            return colorValue.ToString();
        }

        public void setColorValue(string color)
        {
            colorValue = this.colorValue = (Colors)Enum.Parse(typeof(Colors), color);
        }

        public void setValue(int value)
        {
            this.value = value;
        }
        public void setEditable(bool editable)
        {
            this.editable = editable;
        }

        public void ClearPotentialValue()
        {
            potentialValues = new HashSet<int>();
        }

        public void AddPotentialValue(int pv)
        {
            potentialValues.Add(pv);
        }

    }
}
