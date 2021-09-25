using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumAutomaton.Model
{
    interface IAutomaton
    {
        void DeleteNotAccesibleStates();
        void GeneratePartitions();
        void GenerateMinimumEquivalentAutomaton();
    }
}
