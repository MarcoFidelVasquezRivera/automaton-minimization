using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    class MealyMachine : IAutomaton
    {
        public String[,] transitions;
        public List<string> states;
        public String[,] outputs;

        public MealyMachine(List<String> states, String[,] transitions, String[,] outputs)
        {
            this.transitions = transitions;
            this.states = states;
            this.outputs = outputs;

        }

        public void GetAccesibleStates(Dictionary<string, int> minimumStates, int state = 1)
        {
            string currentState = states[state];

            if (!minimumStates.ContainsKey(currentState))
            {
                minimumStates.Add(currentState, 1);
                Console.WriteLine(transitions.GetLength(1));
                List<string> accesibleStates = new List<string>();

                for (int i = 0; i < transitions.GetLength(1); i++)
                {
                    accesibleStates.Add(transitions[state, i]);
                }

                foreach (string accesibleState in accesibleStates)
                {
                    int index = states.IndexOf(accesibleState);
                    GetAccesibleStates(minimumStates, index);
                }
            }
        }

        public void DeleteNotAccesibleStates()
        {
            Dictionary<string, int> accesibleStates = new Dictionary<string, int>();
            GetAccesibleStates(accesibleStates, 0);//gets the accesible states from the initial state


            List<string> newStates = new List<string>(accesibleStates.Keys);

            int nRows = newStates.Count;
            int nColumns = transitions.GetLength(1);
            string[,] newTransitions = new string[nRows, nColumns];//creates a new matrix for transitions using the count of the accesible states
                                                                   //for the number of rows and the number of columns in the original matrix for its number of columns
            string[,] newOutputs = new string[nRows, nColumns];


            for (int i = 0; i < nRows; i++)
            {
                for (int j = 0; j < nColumns; j++)
                {
                    newTransitions[i, j] = transitions[i, j];
                    newOutputs[i, j] = outputs[i, j];
                }
            }

            transitions = newTransitions;
            outputs = newOutputs;
            states = newStates;
        }
        public List<List<string>> GeneratePartitions()
        {
            throw new NotImplementedException();
        }

        public void GenerateMinimumEquivalentAutomaton()
        {
            throw new NotImplementedException();
        }
    }
}
