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
    public partial class MachineDefinition : UserControl
    {

        public MachineDefinition()
        {
            InitializeComponent();
        }

        public String ReturnInfo()
        {
            string machineType = "";
            string values = "";
            if (Mealy.Checked == true)
            {
                machineType = "Mealy";
            }
            else if (Moore.Checked == true)
            {
                machineType = "Moore";
            }
                
            
            values = machineType + "," + numberOfStates.Text + "," + alphaLength.Text;


            return values;
        }
        
    }
}
