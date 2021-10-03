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

        public void GetAccesibleStates(Dictionary<string, int> minimumStates, int state = 0)//obtiene los estados a los que se puede acceder desde el estado inicial
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

        public void DeleteNotAccesibleStates()//elimina los estados que no son accesibles
        {
            Dictionary<string, int> accesibleStates = new Dictionary<string, int>();
            GetAccesibleStates(accesibleStates, 0);//gets the accesible states from the initial state

            
            List<string> newStates = new List<string>(accesibleStates.Keys);

            int nRows = newStates.Count;
            int nColumns = transitions.GetLength(1);
            string[,] newTransitions = new string[nRows, nColumns];//creates a new matrix for transitions using the count of the accesible states
                                                                  //for the number of rows and the number of columns in the original matrix for its number of columns
            for(int i = 0; i < nRows; i++) 
            {
                int row = states.IndexOf(newStates[i]);
                for (int j = 0; j < nColumns; j++)
                {
                   newTransitions[i, j] = transitions[row, j];
                }
            }


            List<string> nonAccesibleOutputs = new List<string>();
            foreach (string key in outputs.Keys)
            {
                if (!newStates.Contains(key))
                {
                    nonAccesibleOutputs.Add(key);
                }
            }

            foreach (string key in nonAccesibleOutputs)
            {
                outputs.Remove(key);
            }

            states = newStates;
            transitions = newTransitions;

            for (int i = 0; i < states.Count; i++) {
                Console.Write("States   " + states[i]);
                for (int j = 0; j < transitions.GetLength(1); j++)
                {
                    Console.Write(" Transitions " + transitions[i,j]);
                    
                }

                Console.WriteLine(" Outputs " + outputs[states[i]]);
            }

        }

        public List<List<string>> GeneratePartitions()//pone los estados en particiones, rpresentando esto con una lista de listas
        {//siendo cada lista una particion, luego de cada partición elige un representante y saca de la particion a todos los
            //estados que no apuntan al mismo lugar del representante y hace una nueva particion con ellos
            //este proceso se repite una y otra vez con todas las particiones hasta que no se crea ninguna nueva
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
                List<string> currentPar = new List<string>();
                foreach (string value in initialPartitions[key])
                {
                    currentPar.Add(value);
                }
                partitions.Add(currentPar);
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
                    List<int> currentIndexes = new List<int>();

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
                                    else
                                    {
                                        currentIndexes.Add(partitions.IndexOf(currentPartition));
                                    }
                                }
                            }
                        }
                        //primero debo sacar todos los incides y luego compararlos
                        bool flag = true;
                        for (int j = 0; j < currentIndexes.Count && flag; j++)//mira si los indices del representante son los mimos que el de el estado actual
                        {
                            bool representativeCointains = representativeIndexes.Contains(currentIndexes[j]);
                            bool currentContains = currentIndexes.Contains(representativeIndexes[j]);
                            if (!(representativeCointains && currentContains))
                            {
                                nonEquivalentStates.Add(currentState);
                                flag = false;
                            }
                        }
                        currentIndexes.Clear();
                        
                    }

                    foreach (string currentState in nonEquivalentStates){//elimino los estdos no equivalentes de la particion
                        partition.Remove(currentState);
                    }

                    if (nonEquivalentStates.Count > 0)
                    {
                        partitions.Add(nonEquivalentStates);//añado lo estados no equivalentes como una nueva partición
                    }
                    
                }

                initialLength = currentLength;
                currentLength = partitions.Count;
                

            } while (initialLength < currentLength);

            foreach (List<string> par in partitions) 
            {
                Console.Write("{");
                foreach (string value in par) 
                {
                    Console.Write(value + ",");
                
                }
                Console.WriteLine("}");
            }
            return partitions;
        }

        public void GenerateMinimumEquivalentAutomaton()//generates th minimum equivalent automaton for the automaton
        {
            List<List<string>> newPartitions = GeneratePartitions();
            List<List<string>> partitions = new List<List<string>>();

            partitions.Add(newPartitions[0]);

            newPartitions.RemoveAt(0);//reverses the partition to have it ordered because GeneratePartitions reverses its order
            newPartitions.Reverse();

            foreach (List<string> partition in newPartitions)
            {
                partitions.Add(partition);
            }


            List<string> newStates = new List<string>();


            for (int i = 0; i < partitions.Count; i++)
            {
                newStates.Add("q"+i);
            }

            int nRows = newStates.Count;
            int nColumns = transitions.GetLength(1);
            string[,] newTransitions = new string[nRows, nColumns];//creates a new matrix for transitions using the count of the accesible states
                                                                   //for the number of rows and the number of columns in the original matrix for its number of column

            Dictionary<string, string> newOutputs = new Dictionary<string, string>();
            for (int i = 0; i<nRows; i++)
            {
                newOutputs.Add(newStates[i],outputs[partitions[i][0]]);
            }


            for (int i=0; i< nRows; i++)
            {
                int row = states.IndexOf(partitions[i][0]);
                for (int j = 0; j < nColumns; j++)//saco los indices de las particiones a las que se puede acceder desde el estado representante
                {
                    string accesibleState = transitions[row, j];
                    foreach (List<string> currentPartition in partitions)
                    {
                        if (currentPartition.Contains(accesibleState))
                        {
                            string transition = newStates[partitions.IndexOf(currentPartition)];//saco la transicion del estado actual en j
                            newTransitions[i, j] = transition;//le pongo la transicion a la nueva matriz de transiciones
                        }
                    }
                }
            }

            //changes the previous automaton for the new one
            states = newStates;
            transitions = newTransitions;
            outputs = newOutputs;

            for (int i = 0; i < states.Count; i++)
            {
                Console.Write("States   " + states[i]);
                for (int j = 0; j < transitions.GetLength(1); j++)
                {
                    Console.Write(" Transitions " + transitions[i, j]);

                }

                Console.WriteLine(" Outputs " + outputs[states[i]]);
            }

        }


        public string[,] ReturnMatrix() //returns the automaton represented as a matrix
        {
            string[,] matrix = new string[transitions.GetLength(0), transitions.GetLength(1) + 2];

           for(int i = 0; i < matrix.GetLength(0); i++) 
           {
                matrix[i, 0] = states[i];
                matrix[i, matrix.GetLength(1)-1] = outputs[states[i]];
           }

           for (int rows = 0; rows < transitions.GetLength(0); rows++)
           {
               for (int columns = 0; columns < transitions.GetLength(1); columns++)
               {
                    matrix[rows, columns + 1] = transitions[rows, columns];
               }
           }


            return matrix;
        }
 
    }
}
