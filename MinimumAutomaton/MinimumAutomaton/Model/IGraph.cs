using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public interface IGraph <T> where T:IComparable//<T extends Comparable<T>>
    {
		void AddVertex(T vertex);
		void addEdge(T vertex, T edge);
		void addEdge(T vertex, T edge, int weight);
		void deleteVertex(T vertex); //Throws VertexDoesntExistException
		int[][] floydWarshall(); //to find the non accesible vertex
		//public IGraph<T> kruskal();
	}
}
