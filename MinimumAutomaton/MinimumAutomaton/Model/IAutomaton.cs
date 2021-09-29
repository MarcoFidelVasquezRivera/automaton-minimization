using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    public interface IAutomaton
    {
        void DeleteNotAccesibleStates(Dictionary<string, int> minimumStates, int state = 1);
        void GeneratePartitions();
        void GenerateMinimumEquivalentAutomaton();
    }
}
