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
    public partial class StateTable : UserControl
    {
        private DataTable data;
        private String machineType;
        private MachineManager manager;

        public StateTable(DataTable data, String machineType, MachineManager manager)
        {
            InitializeComponent();
            this.data = data;
            this.machineType = machineType;
            this.manager = manager;
            populateTable();
        }

        public void populateTable() 
        {
            stateTable1.DataSource = data;
            data.Columns[0].ColumnName = "States";

            if (machineType == "Moore")
            {
                data.Columns[data.Columns.Count - 1].ColumnName = "Outputs";

                for (int i = 1; i < data.Columns.Count - 1; i++)
                {
                    int unicode = 64 + i;
                    char character = (char)unicode;
                    data.Columns[i].ColumnName = character.ToString();

                }
            }
            else 
            {

                for (int i = 1; i < data.Columns.Count; i++)
                {
                    int unicode = 64 + i;
                    char character = (char)unicode;
                    data.Columns[i].ColumnName = character.ToString();

                }

            }

           

            for (int i = 0; i < data.Rows.Count; i++) 
            {
                String[] row = new string[] {"q" + i};
                data.Rows[i].ItemArray = row;
            
            }

        }

        private void stateTable1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                this.stateTable1.Tag = this.stateTable1.CurrentCell.Value;

            }

        }

        private void saveStates_Click(object sender, EventArgs e)
        {
            String[,] matrix = new string[data.Rows.Count+1,data.Columns.Count];
            
            for (int i = 0; i < data.Columns.Count; i++)
            {
                matrix[0, i] = data.Columns[i].ColumnName;

            }



            for(int column = 0; column < data.Columns.Count; column++) 
            { 
                for (int row = 0; row < data.Rows.Count; row++)
                {
                    matrix[row+1,column] = Convert.ToString(data.Rows[row].ItemArray[column]);
                }
            }

            Console.WriteLine(machineType);
            manager = new MachineManager(matrix, machineType);
            manager.CreateMachine();
        }
    }
}
