using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public interface IGraph <T,V,U> where T:IComparable<T> where V : IComparable<V> where U : IComparable<U>//<T extends Comparable<T>>
	{
		void AddVertex(T vertex, V output);
		void addEdge(T vertex, T edge, U input);
		void addEdge(T vertex, T edge, U input, int weight);
		void deleteVertex(T vertex); //Throws VertexDoesntExistException
		int[][] floydWarshall(); //to find the non accesible vertex
		//public IGraph<T> kruskal();
	}
}
