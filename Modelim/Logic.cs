using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelim
{
    internal class Logic
    {
        public static bool DFA(String str, State state)
        {
            if(str == null) return false;
            if (str.Length == 0)
            {
                return state.isFinal();
            }
            State? nextState = null;
            foreach(Transition transition in new List<Transition>(state.OutgoingTransitions()))
            {
                Console.WriteLine(transition.ToString());
                if (transition.doesAcceptFA(str.ToCharArray()[0]))
                {
                    nextState = transition.getDestination();
                    break;
                }
            }
            if (nextState == null) return false;
            return DFA(str.Substring(1), nextState);
        }
        public static bool FA(String str, State state)
        {
            if (str == null) return false;
            if (str.Length == 0)
            {
                return state.isFinal();
            }
            bool output = false;
            foreach (Transition transition in new List<Transition>(state.OutgoingTransitions()))
            {
                if (transition.doesAcceptFA(str.ToCharArray()[0]))
                {
                    output = output || FA(str.Substring(1), transition.getDestination());
                }
            }
            return output;
        }

        public static bool DSTACK(String str, State state, Stack<char> stack)
        {
            if (str == null) return false;
            if (str.Length == 0)
            {
                return state.isFinal() && stack.Count == 0;
            }
            State? nextState = null;
            foreach (Transition transition in new List<Transition>(state.OutgoingTransitions()))
            {
                if (transition.doesAcceptSTACK(str.ToCharArray()[0], stack))
                {
                    nextState = transition.getDestination();
                    break;
                }
            }
            if (nextState == null) return false;
            return STACK(str.Substring(1), nextState, stack);
        }
        public static bool STACK(String str, State state, Stack<char> stack)
        {
            if (str == null) return false;
            if (str.Length == 0)
            {
                return state.isFinal() && stack.Count == 0;
            }
            bool output = false;
            foreach (Transition transition in new List<Transition>(state.OutgoingTransitions()))
            {
                Stack<char> temp = new Stack<char>(stack);
                if (transition.doesAcceptSTACK(str.ToCharArray()[0], temp))
                {
                    output = output || STACK(str.Substring(1), transition.getDestination(), temp);
                }
            }
            return output;
        }
        public static bool DTURING(State state, TuringStrip turingStrip)
        {
            State? nextState = null;
            foreach (Transition transition in new List<Transition>(state.OutgoingTransitions()))
            {
                if (transition.doesAcceptTURING(turingStrip))
                {
                    nextState = transition.getDestination();
                    break;
                }
            }
            if(nextState == null)
            {
                return state.isFinal();
            }
            return DTURING(nextState, turingStrip);
        }
    }
}
