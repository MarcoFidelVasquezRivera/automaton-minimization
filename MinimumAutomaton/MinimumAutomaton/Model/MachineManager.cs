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

        }

        public void CreateMachine() 
        {
            if (machineType.Equals("Moore"))
            {
                List<string> states = new List<string>();
                Dictionary<string, string> outputs = new Dictionary<string, string>();
                string[,] transitions = new string[matrix.GetLength(0),matrix.GetLength(1)-2];
                

                for (int i = 1; i < matrix.GetLength(0); i++) 
                {
                    states.Add(matrix[i, 0]);
                    Console.WriteLine("Added state" + matrix[i, 0]);

                    outputs.Add(matrix[i, 0], matrix[i, matrix.GetLength(1) - 1]);
                    Console.WriteLine("Added output" + matrix[i, matrix.GetLength(1) - 1]);
                }

                for (int rows = 1; rows < matrix.GetLength(0); rows++) 
                {
                    for (int columns = 1; columns < matrix.GetLength(1)-1; columns++) 
                    {
                        transitions[rows-1, columns - 1] = matrix[rows, columns];
                        Console.Write("Added transition" + transitions[rows - 1, columns - 1]);
                    }
                    Console.WriteLine();
                }

                IAutomaton machine = new MooreMachine(states, transitions, outputs);
                machine.DeleteNotAccesibleStates();
                machine.GeneratePartitions();

            }
            else {

                Console.WriteLine("No implementado ja");
            
            }
        
        
        
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
