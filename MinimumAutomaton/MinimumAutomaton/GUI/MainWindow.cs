using MinimumAutomaton.GUI;
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

namespace MinimumAutomaton
{

    public partial class Form1 : Form
    {
        private MachineManager manager;
        private StateTable st;

        public Form1()
        {
            InitializeComponent();
            manager = new MachineManager(null,null);
        }

        private void CreateTable(object sender, EventArgs e)
        {
            String val = machineDefinition1.ReturnInfo();

            String[] values = val.Split(',');

                if (values[0] != "")
                {
                    DataTable data = new DataTable();
                    data.Rows.Clear();

                    if (values[0] == "Moore")
                    {
                        data.Columns.Add();

                    }

                    try
                    {
                        for (int i = 0; i < int.Parse(values[1]); i++)
                        {
                            data.Rows.Add();
                        }

                        for (int i = 0; i < int.Parse(values[2]); i++)
                        {
                            data.Columns.Add();
                        }


                        data.Columns.Add();
                        StateTable st = new StateTable(data, values[0], manager);

                        machineDefinitionButton.Hide();
                        panel1.Controls.Clear();
                        goBackButton.Show();

                        panel1.Controls.Add(st);
                    }
                    catch(FormatException) 
                    {
                        MessageBox.Show("Los campos ingresados deben ser numeros", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else 
                {

                    MessageBox.Show("Debe seleccionar una maquina", "Invalido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
         
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            machineDefinitionButton.Show();
            panel1.Controls.Add(machineDefinition1);
            goBackButton.Hide();

        }

        public void ShowReducedTable(MachineManager manager)
        {
            panel1.Controls.Clear();
            ReducedTable rt = new ReducedTable(manager);
            panel1.Controls.Add(rt);
        }
    }


}
