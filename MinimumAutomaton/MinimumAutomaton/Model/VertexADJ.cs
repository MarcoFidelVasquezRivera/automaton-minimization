using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public class VertexADJ<T,V> : Vertex<T> where T:IComparable<T> where V:IComparable<V>
    {
        public List<T> edges { get; } //states that can be accesses by this state
        public V output { get; set; } //the output created by the state

        public VertexADJ(T name) : base(name)
        {
            edges = new List<T>();
        }

        //in case we already has its output
        public VertexADJ(T name, V output) : base(name)
        {
            edges = new List<T>();
            this.output = output;
        }

        public void addEdge(T edge)
        {
            edges.Add(edge);
        }

        public void deleteEdge(T edge)
        {
            edges.Remove(edge);
        }

    }
}
