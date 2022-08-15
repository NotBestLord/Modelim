namespace Modelim
{
    public partial class Window : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.turingLabel = new System.Windows.Forms.Label();
            this.example2 = new System.Windows.Forms.Label();
            this.example1 = new System.Windows.Forms.Label();
            this.cancelSelectedStateButton = new System.Windows.Forms.Button();
            this.selectedStateLabel = new System.Windows.Forms.Label();
            this.resultLabel = new System.Windows.Forms.Label();
            this.RunType = new System.Windows.Forms.ComboBox();
            this.PaintType = new System.Windows.Forms.ComboBox();
            this.TransitionList = new System.Windows.Forms.FlowLayoutPanel();
            this.isDeterministic = new System.Windows.Forms.CheckBox();
            this.inputBox = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.turingLabel);
            this.panel2.Controls.Add(this.example2);
            this.panel2.Controls.Add(this.example1);
            this.panel2.Controls.Add(this.cancelSelectedStateButton);
            this.panel2.Controls.Add(this.selectedStateLabel);
            this.panel2.Controls.Add(this.resultLabel);
            this.panel2.Controls.Add(this.RunType);
            this.panel2.Controls.Add(this.PaintType);
            this.panel2.Controls.Add(this.TransitionList);
            this.panel2.Controls.Add(this.isDeterministic);
            this.panel2.Controls.Add(this.inputBox);
            this.panel2.Controls.Add(this.run);
            this.panel2.Location = new System.Drawing.Point(854, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(210, 681);
            this.panel2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Bauhaus 93", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(135, 661);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 12;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // turingLabel
            // 
            this.turingLabel.AutoSize = true;
            this.turingLabel.Location = new System.Drawing.Point(0, 643);
            this.turingLabel.Name = "turingLabel";
            this.turingLabel.Size = new System.Drawing.Size(68, 15);
            this.turingLabel.TabIndex = 11;
            this.turingLabel.Text = "TuringStrip:";
            // 
            // example2
            // 
            this.example2.AutoSize = true;
            this.example2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.example2.Location = new System.Drawing.Point(73, 468);
            this.example2.Name = "example2";
            this.example2.Size = new System.Drawing.Size(40, 21);
            this.example2.TabIndex = 10;
            this.example2.Text = "a,b,c";
            // 
            // example1
            // 
            this.example1.AutoSize = true;
            this.example1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.example1.Location = new System.Drawing.Point(0, 447);
            this.example1.Name = "example1";
            this.example1.Size = new System.Drawing.Size(90, 21);
            this.example1.TabIndex = 9;
            this.example1.Text = "Examples: a";
            // 
            // cancelSelectedStateButton
            // 
            this.cancelSelectedStateButton.Location = new System.Drawing.Point(187, 354);
            this.cancelSelectedStateButton.Name = "cancelSelectedStateButton";
            this.cancelSelectedStateButton.Size = new System.Drawing.Size(23, 22);
            this.cancelSelectedStateButton.TabIndex = 8;
            this.cancelSelectedStateButton.Text = "X";
            this.cancelSelectedStateButton.UseVisualStyleBackColor = true;
            this.cancelSelectedStateButton.Click += new System.EventHandler(this.cancelSelectedState);
            // 
            // selectedStateLabel
            // 
            this.selectedStateLabel.AutoSize = true;
            this.selectedStateLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectedStateLabel.Location = new System.Drawing.Point(0, 351);
            this.selectedStateLabel.Name = "selectedStateLabel";
            this.selectedStateLabel.Size = new System.Drawing.Size(151, 21);
            this.selectedStateLabel.TabIndex = 7;
            this.selectedStateLabel.Text = "Selected State: None";
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.resultLabel.Location = new System.Drawing.Point(0, 598);
            this.resultLabel.MaximumSize = new System.Drawing.Size(200, 0);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(68, 28);
            this.resultLabel.TabIndex = 6;
            this.resultLabel.Text = "Result:";
            // 
            // RunType
            // 
            this.RunType.FormattingEnabled = true;
            this.RunType.Items.AddRange(new object[] {
            "Final Automaton",
            "Stack Automaton",
            "Turing Machine"});
            this.RunType.Location = new System.Drawing.Point(0, 379);
            this.RunType.Name = "RunType";
            this.RunType.Size = new System.Drawing.Size(210, 23);
            this.RunType.TabIndex = 5;
            this.RunType.Text = "Final Automaton";
            this.RunType.SelectedIndexChanged += new System.EventHandler(this.RunType_SelectedIndexChanged);
            // 
            // PaintType
            // 
            this.PaintType.FormattingEnabled = true;
            this.PaintType.Items.AddRange(new object[] {
            "Start State (1)",
            "State (2)",
            "Transition (3)",
            "Self Transition (4)",
            "Final State (5)",
            "Set State Final (6)",
            "Eraser (7)"});
            this.PaintType.Location = new System.Drawing.Point(0, 325);
            this.PaintType.Name = "PaintType";
            this.PaintType.Size = new System.Drawing.Size(210, 23);
            this.PaintType.TabIndex = 4;
            this.PaintType.Text = "Start State (1)";
            // 
            // TransitionList
            // 
            this.TransitionList.AutoScroll = true;
            this.TransitionList.BackColor = System.Drawing.SystemColors.HotTrack;
            this.TransitionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.TransitionList.Location = new System.Drawing.Point(0, 0);
            this.TransitionList.Name = "TransitionList";
            this.TransitionList.Size = new System.Drawing.Size(210, 320);
            this.TransitionList.TabIndex = 3;
            // 
            // isDeterministic
            // 
            this.isDeterministic.AutoSize = true;
            this.isDeterministic.Checked = true;
            this.isDeterministic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isDeterministic.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isDeterministic.Location = new System.Drawing.Point(0, 408);
            this.isDeterministic.Name = "isDeterministic";
            this.isDeterministic.Size = new System.Drawing.Size(128, 25);
            this.isDeterministic.TabIndex = 2;
            this.isDeterministic.Text = "Deterministic?";
            this.isDeterministic.UseVisualStyleBackColor = true;
            // 
            // inputBox
            // 
            this.inputBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inputBox.Location = new System.Drawing.Point(0, 509);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(210, 29);
            this.inputBox.TabIndex = 1;
            this.inputBox.Enter += new System.EventHandler(this.inputBox_Enter);
            this.inputBox.Leave += new System.EventHandler(this.inputBox_Leave);
            // 
            // run
            // 
            this.run.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.run.Font = new System.Drawing.Font("Bauhaus 93", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.run.Location = new System.Drawing.Point(0, 556);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(210, 39);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = false;
            this.run.Click += new System.EventHandler(this.run_button_click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panel2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.Text = "Modelim";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.Form1_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panel2;

        private Button run;
        private TextBox inputBox;
        private CheckBox isDeterministic;
        private FlowLayoutPanel TransitionList;
        private ComboBox RunType;
        private ComboBox PaintType;
        private Label resultLabel;
        private Label selectedStateLabel;
        private Button cancelSelectedStateButton;
        private Label example2;
        private Label example1;
        private Label turingLabel;
        private Button button1;
    }
}