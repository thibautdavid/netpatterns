using System.Collections.Generic;

namespace Pediatre.Training.NetPatterns.Builder
{
    public class State : Dictionary<string,int>
    {
        private State(){}
        public static State Instance { get; } = new State();
    }
}
