using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public class VertexADJ<T,V,U> : Vertex<T> where T:IComparable<T> where V:IComparable<V> where U : IComparable<U>
    {
        public List<T> edges { get; } //vertices that can be accessed by this vertex
        public V output { get; set; } //the output created by the state
        public Dictionary<Tuple<T, U>, int> weights { get; }//weight of the path to the different vertices that can be accessed by this vertex

        public VertexADJ(T name) : base(name)
        {
            edges = new List<T>();
            weights = new Dictionary<Tuple<T, U>, int>();
        }

        //in case we already has its output
        public VertexADJ(T name, V output) : base(name)
        {
            edges = new List<T>();
            this.output = output;
            weights = new Dictionary<Tuple<T, U>, int>();
        }

        public void addEdge(T edge,U input)
        {
            edges.Add(edge);
            Tuple<T, U> inputToEdge = new Tuple<T, U>(edge, input);
            this.weights[inputToEdge] = 1;
        }

        public void addEdge(T edge, U input, int weight)
        {
            edges.Add(edge);
            Tuple<T, U> inputToEdge = new Tuple<T, U>(edge, input);
            this.weights[inputToEdge] = weight;
        }

        public void deleteEdge(T edge, U input)
        {
            Tuple<T, U> inputToEdge = new Tuple<T, U>(edge, input);
            if (weights.ContainsKey(inputToEdge))
            {
                weights.Remove(inputToEdge);
            }

            bool tStillEdge = false;
            foreach (Tuple<T, U> key in weights.Keys)//checks if edge is still edge to this vertex via another input
            {
                if (key.Item1.Equals(edge))
                {
                    tStillEdge = true;
                    break;
                }

            }

            if (!tStillEdge)
            {
                edges.Remove(edge);
            } 
        }
    }
}
