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
                    outputs.Add(matrix[i, 0], matrix[i, matrix.GetLength(1) - 1]);
                }

                for (int rows = 1; rows < matrix.GetLength(0); rows++) 
                {
                    for (int columns = 1; columns < matrix.GetLength(1)-1; columns++) 
                    {
                        transitions[rows-1, columns - 1] = matrix[rows, columns];
                    }
                }

                machine = new MooreMachine(states, transitions, outputs);
                machine.DeleteNotAccesibleStates();
                machine.GeneratePartitions();
                machine.GenerateMinimumEquivalentAutomaton();
            }
            else {



                string[,] transitions = new string[matrix.GetLength(0), matrix.GetLength(1) - 1];
                string[,] outputs = new string[matrix.GetLength(0), matrix.GetLength(1) - 1];
                List<string> states = new List<string>();
                

                for (int i = 1; i < matrix.GetLength(0); i++)
                {              
                    states.Add(matrix[i, 0]);
                }

                for (int rows = 1; rows < matrix.GetLength(0); rows++)
                {
                    for (int columns = 1; columns < matrix.GetLength(1); columns++)
                    {
                        string[] split = matrix[rows, columns].Split(','); // Separo la celda de la matriz en transition/output.
                        transitions[rows - 1, columns - 1] = split[0]; //Pongo la transicion
                        outputs[rows - 1, columns - 1] = split[1];//Pongo el output
                    }
                }

                PrintValues(transitions);
                PrintValues(outputs);
                machine = new MealyMachine(states, transitions, outputs);

            }
        
        
        
        }

        public void PrintValues(string[,] matrix)
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


        public string GetMachineType()
        {
            return machineType;

        }

        public string[,] GetValues()
        {
            return machine.ReturnMatrix();
        }
    }
}
