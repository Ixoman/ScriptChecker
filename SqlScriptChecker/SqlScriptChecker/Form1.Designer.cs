namespace SqlScriptChecker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtScriptInput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnLoadScript;
        private System.Windows.Forms.Button btnExecuteScript;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtScriptInput = new System.Windows.Forms.TextBox();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnLoadScript = new System.Windows.Forms.Button();
            this.btnExecuteScript = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();

            // 
            // txtScriptInput
            // 
            this.txtScriptInput.Location = new System.Drawing.Point(13, 13);
            this.txtScriptInput.Multiline = true;
            this.txtScriptInput.Name = "txtScriptInput";
            this.txtScriptInput.Size = new System.Drawing.Size(775, 150);
            this.txtScriptInput.TabIndex = 0;

            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(13, 300);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(775, 150);
            this.txtOutput.TabIndex = 1;

            // 
            // btnLoadScript
            // 
            this.btnLoadScript.Location = new System.Drawing.Point(13, 170);
            this.btnLoadScript.Name = "btnLoadScript";
            this.btnLoadScript.Size = new System.Drawing.Size(100, 30);
            this.btnLoadScript.TabIndex = 2;
            this.btnLoadScript.Text = "Load Script";
            this.btnLoadScript.UseVisualStyleBackColor = true;
            this.btnLoadScript.Click += new System.EventHandler(this.btnLoadScript_Click);

            // 
            // btnExecuteScript
            // 
            this.btnExecuteScript.Location = new System.Drawing.Point(688, 170);
            this.btnExecuteScript.Name = "btnExecuteScript";
            this.btnExecuteScript.Size = new System.Drawing.Size(100, 30);
            this.btnExecuteScript.TabIndex = 3;
            this.btnExecuteScript.Text = "Execute";
            this.btnExecuteScript.UseVisualStyleBackColor = true;
            this.btnExecuteScript.Click += new System.EventHandler(this.btnExecuteScript_Click);

            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnExecuteScript);
            this.Controls.Add(this.btnLoadScript);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.txtScriptInput);
            this.Name = "Form1";
            this.Text = "SQL Script Checker";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
