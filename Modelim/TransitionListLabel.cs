using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modelim
{
    public partial class TransitionListLabel : UserControl
    {
        private Transition transition;
        public TransitionListLabel(String labelText, Transition transition)
        {
            InitializeComponent();
            label1.Text = labelText;
            this.transition = transition;
        }

        public TextBox getTextBox()
        {
            return textBox1;
        }

        private void remove(object sender, EventArgs e)
        {
            transition.cleanup();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            transition.repaint();
        }
    }
}
