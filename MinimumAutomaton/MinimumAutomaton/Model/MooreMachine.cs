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
            Dictionary<string, List<string>> initialPartitions = new Dictionary<string, List<string>>();

            for (int i=0; i<states.Count;i++)//crea las particiones basadas en lo outputs
            {
                string key = outputs[states[i]];
                if (!initialPartitions.ContainsKey(key))
                {
                    initialPartitions.Add(key,new List<string>());
                }
                initialPartitions[key].Add(states[i]);
            }

            List<List<string>> partitions = new List<List<string>>();

            foreach (string key in initialPartitions.Keys)//pasa las listas del diccionario a otra lista
            {
                partitions.Add(initialPartitions[key]);
            }

            int initialLength = partitions.Count;
            int currentLength = initialLength;

            do
            {
                for (int i = 0; i < partitions.Count; i++)
                {
                    List<string> partition = partitions[i];
                    List<int> representativeIndexes = new List<int>();//indices de las particiones a las que apunta el estado representante
                    List<string> nonEquivalentStates = new List<string>();

                    int row = states.IndexOf(partition[0]);//me va a dar el indice del estado que representa a la particion

                    foreach (string currentState in partition)
                    {
                        row = states.IndexOf(currentState);
                        for (int j = 0; j < transitions.GetLength(1); j++)//saco los indices de las particiones a las que se puede acceder desde el estado representante
                        {
                            string accesibleState = transitions[row, j];
                            foreach (List<string> currentPartition in partitions)
                            {
                                if (currentPartition.Contains(accesibleState))
                                {
                                    if (currentState.Equals(partition[0]))
                                    {
                                        representativeIndexes.Add(partitions.IndexOf(currentPartition));
                                    }
                                    else if(!representativeIndexes.Contains(partitions.IndexOf(currentPartition)))
                                    {
                                        nonEquivalentStates.Add(currentState);
                                    }
                                }
                            }
                        }
                    }

                    foreach(string currentState in nonEquivalentStates){//elimino los estdos no equivalentes de la particion
                        partition.Remove(currentState);
                    }

                    partitions.Add(nonEquivalentStates);//añado lo estados no equivalentes como una nueva partición
                }
                currentLength = partitions.Count;

            } while (initialLength < currentLength);

        }

        public void GenerateMinimumEquivalentAutomaton()
        {
            throw new NotImplementedException();
        }


    }
}
