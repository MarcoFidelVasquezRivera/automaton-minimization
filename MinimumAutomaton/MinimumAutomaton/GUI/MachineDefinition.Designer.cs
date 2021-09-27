
namespace MinimumAutomaton.GUI
{
    partial class MachineDefinition
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numberOfStates = new System.Windows.Forms.TextBox();
            this.alphaLength = new System.Windows.Forms.TextBox();
            this.Mealy = new System.Windows.Forms.RadioButton();
            this.Moore = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "AUTOMATA REDUCTION";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Number of states";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alphabet length";
            // 
            // numberOfStates
            // 
            this.numberOfStates.Location = new System.Drawing.Point(350, 107);
            this.numberOfStates.Name = "numberOfStates";
            this.numberOfStates.Size = new System.Drawing.Size(100, 20);
            this.numberOfStates.TabIndex = 5;
            // 
            // alphaLength
            // 
            this.alphaLength.Location = new System.Drawing.Point(350, 194);
            this.alphaLength.Name = "alphaLength";
            this.alphaLength.Size = new System.Drawing.Size(100, 20);
            this.alphaLength.TabIndex = 6;
            // 
            // Mealy
            // 
            this.Mealy.AutoSize = true;
            this.Mealy.Location = new System.Drawing.Point(33, 137);
            this.Mealy.Name = "Mealy";
            this.Mealy.Size = new System.Drawing.Size(53, 17);
            this.Mealy.TabIndex = 7;
            this.Mealy.TabStop = true;
            this.Mealy.Text = "Mealy";
            this.Mealy.UseVisualStyleBackColor = true;
            // 
            // Moore
            // 
            this.Moore.AutoSize = true;
            this.Moore.Location = new System.Drawing.Point(33, 160);
            this.Moore.Name = "Moore";
            this.Moore.Size = new System.Drawing.Size(55, 17);
            this.Moore.TabIndex = 8;
            this.Moore.TabStop = true;
            this.Moore.Text = "Moore";
            this.Moore.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Machine Type";
            // 
            // MachineDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Mealy);
            this.Controls.Add(this.Moore);
            this.Controls.Add(this.alphaLength);
            this.Controls.Add(this.numberOfStates);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "MachineDefinition";
            this.Size = new System.Drawing.Size(489, 320);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numberOfStates;
        private System.Windows.Forms.TextBox alphaLength;
        private System.Windows.Forms.RadioButton Mealy;
        private System.Windows.Forms.RadioButton Moore;
        private System.Windows.Forms.Label label2;
    }
}
