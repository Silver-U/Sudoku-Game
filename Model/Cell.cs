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
        private bool editable;
        private Colors colorValue;
        private HashSet<int> potentialValues;

        public Cell()
        {
            value = 0;
            editable = true;
            colorValue = Colors.ffffff;
            potentialValues = new HashSet<int>();
        }

        public Cell(int value)
        {
            this.value = value;
            editable = true;
            colorValue = Colors.ffffff;
            potentialValues = new HashSet<int>();
        }

        public Cell(int value, string colorValue)
        {
            this.value = value;
            editable = true;
            potentialValues = new HashSet<int>();
            this.colorValue = (Colors)Enum.Parse(typeof(Colors), colorValue);
        }

        public Cell(Cell cell)
        {
            this.value = cell.getValue();
            this.editable = cell.getEditable();
            this.potentialValues = new HashSet<int>(cell.getPotentialValue());
            this.colorValue = (Colors)Enum.Parse(typeof(Colors), cell.getColorValue());
        }


        public Cell(int value, string colorValue, HashSet<int> potentialValues, bool editable)
        {
            this.value = value;
            this.editable = editable;
            this.potentialValues = new HashSet<int>(potentialValues);
            this.colorValue = (Colors)Enum.Parse(typeof(Colors), colorValue);
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

        public string PnToString()
        {
            if (potentialValues == null)
                return " ";
            return string.Join("", potentialValues);
        }
        public void AddPotentialValue(int pv)
        {
            potentialValues.Add(pv);
        }

    }
}
