using MinimumAutomaton.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinimumAutomaton.GUI
{
    public partial class ReducedTable : UserControl
    {
        private MachineManager manager;
        public ReducedTable(MachineManager manager)
        { 
            InitializeComponent();
            this.manager = manager;
            populateTable();
        }

        private void populateTable()
        {
            DataTable table = new DataTable();
            string[,] matrix = manager.GetValues();

            for(int i = 0; i<matrix.GetLength(0); i++) 
            {
                table.Rows.Add();
            }

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                table.Columns.Add();
            }
            table.Columns[0].ColumnName = "States";
            table.Columns[1].ColumnName = "q0";

            for (int i = 1; i < table.Columns.Count - 1; i++)
            {
                table.Columns[i].ColumnName = "q" + (i - 1);

            }

            if (manager.GetMachineType().Equals("Moore"))
            {

                table.Columns[table.Columns.Count-1].ColumnName = "Outputs";

            }

            
            table.Rows.Clear();
            
               
            for (int rows = 0; rows < matrix.GetLength(0); rows++) 
            {
                DataRow dr = table.NewRow();
                for (int columns = 0; columns < matrix.GetLength(1); columns++)
                {
                    dr[columns] = matrix[rows, columns];
                }
                table.Rows.Add(dr);
            }

            manager.PrintValues(manager.GetValues());

            stateTable1.DataSource = table;
        }
    }
}
