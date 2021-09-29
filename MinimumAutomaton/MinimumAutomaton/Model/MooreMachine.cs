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
        public List<string> outputs;

        public MooreMachine(List<string> states, string[,] transitions, List<string> outputs)
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
