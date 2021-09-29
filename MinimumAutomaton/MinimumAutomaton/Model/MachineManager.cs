using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public class MachineManager
    {
        private IAutomaton machine;
        private String[,] matrix;
        private String machineType;

        public MachineManager(String[,] matrix, String machineType) 
        {
            this.matrix = matrix;
            this.machineType = machineType;

            getValues();
        }


        public void getValues()
        {
            if (matrix != null && machineType != null)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(string.Format("{0} ", matrix[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }

                Console.WriteLine(machineType);
            }
        }

    }
}
