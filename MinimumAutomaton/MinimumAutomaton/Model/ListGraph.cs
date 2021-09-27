using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    class ListGraph<T,V,U> : IGraph<T,V,U> where T : IComparable<T> where V : IComparable<V> where U : IComparable<U>
    {
        private List<T> verticesNumbers;
        private Dictionary<T,VertexADJ<T,V,U>> vertices;

        public ListGraph()
        {
            vertices = new Dictionary<T, VertexADJ<T, V,U>>();
            verticesNumbers = new List<T>();
        }


        public void AddVertex(T vertex, V output)//adds a new vertex and its output
        {
            if (!vertices.ContainsKey(vertex))
            {
                VertexADJ<T,V,U> newVertex = new VertexADJ<T,V,U>(vertex, output);
                vertices.Add(vertex, newVertex);
                verticesNumbers.Add(vertex);
            }
            else
            {
                //tirar excepcion
            }
            
        }
        public void addEdge(T vertex, T edge, U input)
        {
            if (vertices.ContainsKey(vertex) && vertices.ContainsKey(edge))
            {
                vertices[vertex].addEdge(edge, input);

            }
            else 
            { 
                //tirar excepcion de que alguno de ellos no existe
            }
            
        }

        public void addEdge(T vertex, T edge, U input, int weight)
        {
            if (vertices.ContainsKey(vertex) && vertices.ContainsKey(edge))
            {
                vertices[vertex].addEdge(edge, input,weight);

            }
            else
            {
                //tirar excepcion de ue alguno de ellos no existe
            }
        }

        public void deleteVertex(T vertex)
        {
            if (vertices.ContainsKey(vertex))
            {
                vertices.Remove(vertex);
                verticesNumbers.Remove(vertex);
            }
        }

        public int[][] floydWarshall()
        {
            //este es para implementarlo luegos
            return null;
        }
    }
}
