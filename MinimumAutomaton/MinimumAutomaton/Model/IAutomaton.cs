using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public interface IAutomaton
    {
        void GetAccesibleStates(Dictionary<string, int> minimumStates, int state = 1);
        void DeleteNotAccesibleStates();
        List<List<string>> GeneratePartitions();
        void GenerateMinimumEquivalentAutomaton();

        string[,] ReturnMatrix();
    }
}
