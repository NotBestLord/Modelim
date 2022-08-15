using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelim
{
    public class Transition
    {
        private State origin;
        private State destination;
        private TransitionListLabel listLabel;
        private Window window;
        public Transition(Window window, State origin, State destination, String listLabelText)
        {
            this.window = window;
            this.origin = origin;
            this.destination = destination;
            this.listLabel = new TransitionListLabel(listLabelText, this);
            window.addTransitionListLabel(listLabel);
        }

        public String getLabelString()
        {
            return listLabel.getTextBox().Text;
        }
        
        public bool doesAcceptFA(char c)
        {
            foreach (String arg in listLabel.getTextBox().Text.Split(','))
            {
                try 
                {
                    if (c == arg.ToCharArray()[0])
                    {
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }
        public bool doesAcceptSTACK(char c, Stack<char> stack)
        {
            foreach (String arg in listLabel.getTextBox().Text.Split(','))
            {
                try
                {
                    char arg1 = arg.Split('/')[0].ToCharArray()[2];
                    String arg2 = arg.Split('/')[1];
                    Console.Error.WriteLine(arg);
                    if (c == arg.ToCharArray()[0] && 
                        ((arg1 == '_' && stack.Count == 0) || (stack.Count != 0 && stack.Peek() == arg1)))
                    {
                        String arg3 = arg2.Split(' ')[0];
                        if(arg3.ToLower() == "push")
                        {
                            String arg4 = arg2.Split(' ')[1];
                            foreach (char arg5 in arg4.ToCharArray())
                            {
                                stack.Push(arg5);
                            }
                        }
                        else if (arg3.ToLower() == "pop")
                        {
                            stack.Pop();
                        }
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }

        public bool doesAcceptTURING(TuringStrip turingStrip)
        {
            foreach (String arg in listLabel.getTextBox().Text.Split(','))
            {
                try
                {
                    char arg1 = arg.Split('/')[0].ToCharArray()[2];
                    char arg2 = arg.Split('/')[1].ToLower().ToCharArray()[0];
                    if (turingStrip.getChar() == arg.ToCharArray()[0])
                    {
                        turingStrip.setChar(arg1);
                        if(arg2 == 'r')
                        {
                            turingStrip.right();
                        }
                        if (arg2 == 'l')
                        {
                            turingStrip.left();
                        }
                        return true;
                    }
                }
                catch { }
            }
            return false;
        }

        public State getOrigin() { return origin; }
        public State getDestination() { return destination; }

        public void cleanup()
        {
            origin.OutgoingTransitions().Remove(this);
            destination.IncomingTransitions().Remove(this);
            window.removeTransitionListLabel(listLabel);
            window.repaint();
        }

        public void repaint()
        {
            window.repaint();
        }
    }
}
