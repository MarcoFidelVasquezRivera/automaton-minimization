using MinimumAutomaton.Model;
using MinimumAutomaton;
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
            Boolean validInput = true;
            int stateExists = 0;

            for (int column = 0; column < data.Columns.Count && validInput; column++) 
            {
                for (int row = 0; row < data.Rows.Count && validInput; row++)
                {
                    if(Convert.ToString(data.Rows[row].ItemArray[column]).Equals("") || Convert.ToString(data.Rows[row].ItemArray[column]) == null)
                    {
                       MessageBox.Show("Ningun campo puede estar vacio", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       validInput = false;
                    }

                }
            }

            List<string> states = new List<string>();

            for (int row = 0; row < data.Rows.Count && validInput; row++)
            {

                states.Add(Convert.ToString(data.Rows[row].ItemArray[0]));

            }

            int size = 0;
            if (machineType.Equals("Moore"))
            {
                
                for (int column = 1; column < data.Columns.Count-1; column++)
                {
                    for (int row = 0; row < data.Rows.Count; row++)
                    {
                        size++;
                        for(int i = 0; i < states.Count; i++) 
                        {
                            if (states[i].Equals(Convert.ToString(data.Rows[row].ItemArray[column])))
                            {

                                stateExists++;

                            }
                        }
                    }
                }
            }
            else if (machineType.Equals("Mealy"))
            {

                for (int column = 1; column < data.Columns.Count; column++)
                {
                    for (int row = 0; row < data.Rows.Count; row++)
                    {
                        size++;
                        string[] split = Convert.ToString(data.Rows[row].ItemArray[column]).Split(',');
                        for (int i = 0; i < states.Count; i++)
                        {
                            if (states[i].Equals(split[0]))
                            {

                                stateExists++;

                            }
                        }
                    }
                }
            }

            if (stateExists<size) 
            {
                MessageBox.Show("Los campos deben concordar con los estados", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (validInput && stateExists==size)
            {
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    matrix[0, i] = data.Columns[i].ColumnName;

                }



                for (int column = 0; column < data.Columns.Count; column++)
                {
                    for (int row = 0; row < data.Rows.Count; row++)
                    {
                        matrix[row + 1, column] = Convert.ToString(data.Rows[row].ItemArray[column]);
                    }
                }

                manager = new MachineManager(matrix, machineType);
                manager.CreateMachine();
                Form1 form = (Form1)this.FindForm();
                form.ShowReducedTable(manager);
            }
        }
    }
}
