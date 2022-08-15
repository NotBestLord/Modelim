using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelim
{
    public class State
    {
        private List<Transition> incomingTransitions = new List<Transition>();
        private List<Transition> outgoingTransitions = new List<Transition>();
        private Rectangle rectangle;
        private bool final;
        public State(int x, int y, int width, int height, bool final)
        {
            this.final = final;
            rectangle = new Rectangle(x, y, width, height);
        }
        public List<Transition> IncomingTransitions()
        {
            return incomingTransitions;
        }
        public List<Transition> OutgoingTransitions()
        {
            return outgoingTransitions;
        }
        public Rectangle GetRectangle() { return rectangle; }
        public bool isFinal() { return final; }

        public void setFinal(bool final) { this.final = final; }
        public void cleanup()
        {
            foreach(Transition transition in new List<Transition>(incomingTransitions))
            {
                transition.cleanup();
            }
            foreach (Transition transition in new List<Transition>(outgoingTransitions))
            {
                transition.cleanup();
            }
        }
    }
}
