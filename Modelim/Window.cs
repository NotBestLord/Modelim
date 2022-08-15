namespace Modelim
{
    public partial class Window : Form
    {
        private Graphics graphics;
        private State? startState = null;
        private State? selectedState = null;
        private int selectedStateNum = 0;
        private List<State> allStates = new List<State>();
        public Window()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }

        public Graphics GetGraphics()
        {
            return graphics;
        }

        private void run_button_click(object sender, EventArgs e)
        {
            if (startState != null)
            {
                bool accept = false;
                if(inputBox.Text == "Input")
                {
                    if (startState.isFinal())
                    {
                        resultLabel.Text = "Result: Accepted";
                    }
                    else
                    {
                        resultLabel.Text = "Result: Rejected";
                    }
                    return;
                }
                switch (RunType.Text)
                {
                    case "Final Automaton":
                        if (isDeterministic.Checked)
                        {
                            accept = Logic.DFA(inputBox.Text, startState);
                        }
                        else
                        {
                            accept = Logic.FA(inputBox.Text, startState);
                        }
                        if (accept)
                        {
                            resultLabel.Text = "Result: Accepted";
                        }
                        else
                        {
                            resultLabel.Text = "Result: Rejected";
                        }
                        break;
                    case "Stack Automaton":
                        if (isDeterministic.Checked)
                        {
                            accept = Logic.DSTACK(inputBox.Text, startState, new Stack<char>());
                        }
                        else
                        {
                            accept = Logic.STACK(inputBox.Text, startState, new Stack<char>());
                        }
                        if (accept)
                        {
                            resultLabel.Text = "Result: Accepted";
                        }
                        else
                        {
                            resultLabel.Text = "Result: Rejected";
                        }
                        break;
                    case "Turing Machine":
                        TuringStrip turingStrip = new TuringStrip(inputBox.Text);
                        accept = Logic.DTURING(startState, turingStrip);
                        if (accept)
                        {
                            resultLabel.Text = "Result: Accepted";
                        }
                        else
                        {
                            resultLabel.Text = "Result: Rejected";
                        }
                        turingLabel.Text = "TuringStrip:" + turingStrip.getAsString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                resultLabel.Text = "Result: No Start State";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inputBox.Text = "Input";
        }

        private void inputBox_Enter(object sender, EventArgs e)
        {
            if (inputBox.Text == "Input")
            {
                inputBox.Text = "";
            }
        }

        private void inputBox_Leave(object sender, EventArgs e)
        {
            if (inputBox.Text == "")
            {
                inputBox.Text = "Input";
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Point mousePos = PointToClient(Cursor.Position);
            if(mousePos.X < 850)
            {
                switch (PaintType.Text)
                {
                    case "Start State (1)":
                        if(startState == null)
                        {
                            startState = new State(mousePos.X, mousePos.Y, 20, 20, false);
                        }
                        else
                        {
                            startState.cleanup();
                            startState = new State(mousePos.X,mousePos.Y,20,20,false);
                        }
                        break;
                    case "State (2)":
                        allStates.Add(new State(mousePos.X, mousePos.Y, 20, 20, false));
                        break;
                    case "Transition (3)":
                        if (startState != null &&
                            startState.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                        {
                            if (selectedState == null)
                            {
                                selectedStateLabel.Text = "Selected State: 0";
                                selectedStateNum = 0;
                                selectedState = startState;
                            }
                            else
                            {
                                Transition transition = new Transition(this, selectedState, startState, selectedStateNum+"->0");
                                startState.IncomingTransitions().Add(transition);
                                selectedState.OutgoingTransitions().Add(transition);
                                selectedState = null;
                                selectedStateLabel.Text = "Selected State: None";
                            }
                        }
                        else
                        {
                            for (int i = 1; i <= allStates.Count; i++)
                            {
                                State state = allStates[i - 1];
                                if (state.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                                {
                                    if (selectedState == null)
                                    {
                                        selectedStateLabel.Text = "Selected State: " + i;
                                        selectedStateNum = i;
                                        selectedState = state;
                                    }
                                    else
                                    {
                                        Transition transition = new Transition(this, selectedState, state, selectedStateNum + "->" + i);
                                        state.IncomingTransitions().Add(transition);
                                        selectedState.OutgoingTransitions().Add(transition);
                                        selectedState = null;
                                        selectedStateLabel.Text = "Selected State: None";
                                    }
                                    break;
                                }
                            }
                        }
                        break;
                    case "Self Transition (4)":
                        if (startState != null &&
                            startState.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                        {
                            Transition transition = new Transition(this, startState, startState, "0->0");
                            startState.IncomingTransitions().Add(transition);
                            startState.OutgoingTransitions().Add(transition);
                        }
                        else
                        {
                            for (int i = 1; i <= allStates.Count; i++)
                            {
                                State state = allStates[i - 1];
                                if (state.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                                {
                                    Transition transition = new Transition(this, state, state, i + "->" + i);
                                    state.IncomingTransitions().Add(transition);
                                    state.OutgoingTransitions().Add(transition);
                                    break;
                                }
                            }
                        }
                        break;
                    case "Final State (5)":
                        allStates.Add(new State(mousePos.X, mousePos.Y, 20, 20, true));
                        break;
                    case "Eraser (7)":

                        if (startState != null &&
                            startState.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                        {
                            startState.cleanup();
                            startState = null;
                        }
                        else
                        {
                            foreach (State state in new List<State>(allStates))
                            {
                                if (state.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                                {
                                    state.cleanup();
                                    allStates.Remove(state);
                                    break;
                                }
                            }
                        }
                        break;
                    case "Set State Final (6)":

                        if (startState != null &&
                            startState.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                        {
                            startState.setFinal(!startState.isFinal());
                        }
                        else
                        {
                            foreach (State state in new List<State>(allStates))
                            {
                                if (state.GetRectangle().IntersectsWith(new Rectangle(mousePos.X, mousePos.Y, 1, 1)))
                                {
                                    state.setFinal(!state.isFinal());
                                    break;
                                }
                            }
                        }
                        repaint();
                        break;
                    default:
                        break;
                    
                }
                repaint();
            }
        }


        public void repaint()
        {
            graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, 853, 720));
            List<Transition> transitions = new List<Transition>();
            if (startState != null)
            {
                graphics.FillEllipse(new SolidBrush(Color.LimeGreen), startState.GetRectangle());
                graphics.DrawString("0", DefaultFont, new SolidBrush(Color.Black), 
                    new PointF(startState.GetRectangle().X + startState.GetRectangle().Width/4, 
                    startState.GetRectangle().Y + startState.GetRectangle().Height/8));
                if (startState.isFinal())
                {
                    graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red)), startState.GetRectangle());
                }
                transitions.AddRange(startState.OutgoingTransitions());
            }
            SolidBrush brush = new SolidBrush(Color.Aqua);
            for(int i=1;i<=allStates.Count;i++)
            {
                State state = allStates[i-1];
                graphics.FillEllipse(brush, state.GetRectangle());
                if (state.isFinal())
                {
                    graphics.DrawEllipse(new Pen(new SolidBrush(Color.Red)), state.GetRectangle());
                }

                graphics.DrawString(i+"", DefaultFont, new SolidBrush(Color.Black),
                    new PointF(state.GetRectangle().X + state.GetRectangle().Width / (i > 9 ? 8 : 4),
                    state.GetRectangle().Y + state.GetRectangle().Height / 8));
                transitions.AddRange(state.OutgoingTransitions());
            }
            brush = new SolidBrush(Color.Gold);
            Pen pen = new Pen(Color.Black);
            pen.Width = 2;
            foreach (Transition transition in transitions)
            {
                Rectangle origin = transition.getOrigin().GetRectangle();
                Rectangle destination = transition.getDestination().GetRectangle();
                Point originM = new Point(origin.X + origin.Width / 2, origin.Y + origin.Height / 2);
                Point destinationM = new Point(destination.X + destination.Width / 2, destination.Y + destination.Height / 2);
                graphics.DrawLine(pen,originM, destinationM);

                Point third = new Point(originM.X + (destinationM.X - originM.X) / 3, originM.Y + (destinationM.Y - originM.Y) / 3);
                Point TwoThird = new Point(originM.X + 2 * (destinationM.X - originM.X) / 3, 
                    originM.Y + 2 * (destinationM.Y - originM.Y) / 3);

                double theta = Math.Atan2(third.Y - originM.Y, third.X - originM.X);
                int x = (int) (third.X - 10 * Math.Cos(theta + Math.PI / 6));
                int y = (int) (third.Y - 10 * Math.Sin(theta + Math.PI / 6));
                graphics.DrawLine(pen, third, new Point(x,y));

                x = (int)(third.X - 10 * Math.Cos(theta - Math.PI / 6));
                y = (int)(third.Y - 10 * Math.Sin(theta - Math.PI / 6));
                graphics.DrawLine(pen, third, new Point(x, y));

                x = (int)(TwoThird.X - 10 * Math.Cos(theta + Math.PI / 6));
                y = (int)(TwoThird.Y - 10 * Math.Sin(theta + Math.PI / 6));
                graphics.DrawLine(pen, TwoThird, new Point(x, y));

                x = (int)(TwoThird.X - 10 * Math.Cos(theta - Math.PI / 6));
                y = (int)(TwoThird.Y - 10 * Math.Sin(theta - Math.PI / 6));
                graphics.DrawLine(pen, TwoThird, new Point(x, y));

                if(transition.getOrigin() != transition.getDestination())
                {
                    PointF mid = new PointF(originM.X + (destinationM.X - originM.X) / 2, originM.Y + (destinationM.Y - originM.Y) / 2);
                    mid.X -= transition.getLabelString().Length*3;
                    graphics.DrawString(transition.getLabelString(), DefaultFont, brush, mid);

                }
            }
        }

        public void removeTransitionListLabel(TransitionListLabel listLabel)
        {
            TransitionList.Controls.Remove(listLabel);
        }

        public void addTransitionListLabel(TransitionListLabel listLabel)
        {
            TransitionList.Controls.Add(listLabel);
        }

        private void cancelSelectedState(object sender, EventArgs e)
        {
            selectedState = null;
            selectedStateNum = 0;
            selectedStateLabel.Text = "Selected State: None";
        }

        private void RunType_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (RunType.Text)
            {
                case "Final Automaton":
                    example1.Text = "Examples: a";
                    example2.Text = "a,b,c";
                    turingLabel.Text = "TuringStrip:";
                    break;
                case "Stack Automaton":
                    example1.Text = "Examples: a|S/push S";
                    example2.Text = "b|P/pop";
                    turingLabel.Text = "TuringStrip:";
                    break;
                case "Turing Machine":
                    example1.Text = "Examples: a|#/r";
                    example2.Text = "0|#/l";
                    turingLabel.Text = "TuringStrip:";
                    break;
                default:
                    break;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.D1:
                    PaintType.Text = "Start State (1)";
                    break;
                case Keys.D2:
                    PaintType.Text = "State (2)";
                    break;
                case Keys.D3:
                    PaintType.Text = "Transition (3)";
                    break;
                case Keys.D4:
                    PaintType.Text = "Self Transition (4)";
                    break;
                case Keys.D5:
                    PaintType.Text = "Final State (5)";
                    break;
                case Keys.D6:
                    PaintType.Text = "Set State Final (6)";
                    break;
                case Keys.D7:
                    PaintType.Text = "Eraser (7)";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            allStates.Clear();
            startState = null; 
            selectedState = null;
            selectedStateNum = 0;
            repaint();
        }
    }
}