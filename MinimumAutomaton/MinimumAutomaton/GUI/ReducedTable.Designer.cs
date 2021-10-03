
namespace MinimumAutomaton.GUI
{
    partial class ReducedTable
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
            this.stateTable1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.stateTable1)).BeginInit();
            this.SuspendLayout();
            // 
            // stateTable1
            // 
            this.stateTable1.AllowUserToAddRows = false;
            this.stateTable1.AllowUserToDeleteRows = false;
            this.stateTable1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.stateTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stateTable1.Location = new System.Drawing.Point(0, 0);
            this.stateTable1.Name = "stateTable1";
            this.stateTable1.ReadOnly = true;
            this.stateTable1.Size = new System.Drawing.Size(595, 484);
            this.stateTable1.TabIndex = 1;
            // 
            // ReducedTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.stateTable1);
            this.Name = "ReducedTable";
            this.Size = new System.Drawing.Size(687, 487);
            ((System.ComponentModel.ISupportInitialize)(this.stateTable1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView stateTable1;
    }
}
