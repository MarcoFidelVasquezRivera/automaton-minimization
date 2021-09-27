using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public class VertexADJ<T,V> : Vertex<T> where T:IComparable<T> where V:IComparable<V>
    {
        public List<T> edges { get; } //vertices that can be accessed by this vertex
        public V output { get; set; } //the output created by the state
        private Dictionary<T, int> weights;//weight of the path to the different vertices that can be accessed by this vertex

        public VertexADJ(T name) : base(name)
        {
            edges = new List<T>();
            weights = new Dictionary<T, int>();
        }

        //in case we already has its output
        public VertexADJ(T name, V output, int weight) : base(name)
        {
            edges = new List<T>();
            this.output = output;
            weights = new Dictionary<T, int>();
        }

        public void addEdge(T edge)
        {
            edges.Add(edge);
            this.weights[edge] = 1;
        }

        public void addEdge(T edge, int weight)
        {
            edges.Add(edge);
            this.weights[edge] = weight;
        }

        public void deleteEdge(T edge)
        {
            edges.Remove(edge);
            weights.Remove(edge);
        }
    }
}
