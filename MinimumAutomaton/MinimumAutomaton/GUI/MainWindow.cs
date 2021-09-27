using MinimumAutomaton.GUI;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void CreateTable(object sender, EventArgs e)
        {
            String val = machineDefinition1.ReturnInfo();
            String[] values = val.Split(',');

            DataTable data = new DataTable();
            data.Rows.Clear();

            if (values[0] == "Moore") 
            {
                data.Columns.Add();
               
            }

            for(int i = 0; i<int.Parse(values[1]); i++)
            {
                data.Rows.Add();
            }

            for (int i = 0; i < int.Parse(values[2]); i++)
            {
                data.Columns.Add();
            }

            data.Columns.Add();
            StateTable st = new StateTable(data, values[0]);

            machineDefinitionButton.Hide();
            panel1.Controls.Clear();


            panel1.Controls.Add(st);
        
        }
    }


}
