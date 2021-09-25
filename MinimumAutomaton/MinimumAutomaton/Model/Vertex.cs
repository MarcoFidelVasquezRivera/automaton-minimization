using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public class Vertex<T> where T:IComparable<T>
    {
        public T VertexName { get; set; }

        public Vertex(T vertexName)
        {
            this.VertexName = vertexName;
        }
    }
}
