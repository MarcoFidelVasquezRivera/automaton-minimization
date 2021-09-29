using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    class MooreMachine : IAutomaton
    {
        public List<string> states;
        public string[,] transitions;
        public Dictionary<string,string> outputs;

        public MooreMachine(List<string> states, string[,] transitions, Dictionary<string, string> outputs)
        {
            this.states = states;
            this.transitions = transitions;
            this.outputs = outputs;
        }

        public void GetAccesibleStates(Dictionary<string, int> minimumStates, int state = 0)
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
                    GetAccesibleStates(minimumStates,index);
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
            for (int i=0; i<nRows; i++)
            {
                for (int j=0;j<nColumns;j++)
                {
                    newTransitions[i,j] = transitions[i,j];
                }
            }

            foreach (string key in outputs.Keys)
            {
                if (!newStates.Contains(key))
                {
                    outputs.Remove(key);
                }
            }

            states = newStates;
            transitions = newTransitions;
        }

        public void GeneratePartitions()
        {
            throw new NotImplementedException();
        }

        public void GenerateMinimumEquivalentAutomaton()
        {
            throw new NotImplementedException();
        }


    }
}
