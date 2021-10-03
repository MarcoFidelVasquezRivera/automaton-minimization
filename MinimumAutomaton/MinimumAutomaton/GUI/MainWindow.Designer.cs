
namespace MinimumAutomaton
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.machineDefinition1 = new MinimumAutomaton.GUI.MachineDefinition();
            this.machineDefinitionButton = new System.Windows.Forms.Button();
            this.goBackButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.machineDefinition1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(767, 401);
            this.panel1.TabIndex = 0;
            // 
            // machineDefinition1
            // 
            this.machineDefinition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.machineDefinition1.Location = new System.Drawing.Point(0, 0);
            this.machineDefinition1.Name = "machineDefinition1";
            this.machineDefinition1.Size = new System.Drawing.Size(767, 401);
            this.machineDefinition1.TabIndex = 0;
            // 
            // machineDefinitionButton
            // 
            this.machineDefinitionButton.Location = new System.Drawing.Point(355, 419);
            this.machineDefinitionButton.Name = "machineDefinitionButton";
            this.machineDefinitionButton.Size = new System.Drawing.Size(75, 23);
            this.machineDefinitionButton.TabIndex = 8;
            this.machineDefinitionButton.Text = "Confirm";
            this.machineDefinitionButton.UseVisualStyleBackColor = true;
            this.machineDefinitionButton.Click += new System.EventHandler(this.CreateTable);
            // 
            // goBackButton
            // 
            this.goBackButton.Location = new System.Drawing.Point(593, 419);
            this.goBackButton.Name = "goBackButton";
            this.goBackButton.Size = new System.Drawing.Size(43, 23);
            this.goBackButton.TabIndex = 9;
            this.goBackButton.Text = "Back";
            this.goBackButton.UseVisualStyleBackColor = true;
            this.goBackButton.Visible = false;
            this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goBackButton);
            this.Controls.Add(this.machineDefinitionButton);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GUI.MachineDefinition machineDefinition1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button machineDefinitionButton;
        private System.Windows.Forms.Button goBackButton;
    }
}

