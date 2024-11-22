using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.IO;
using System.Windows.Forms;

namespace SqlScriptChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnExecuteScript.Enabled = false; // Asegúrate que los nombres coincidan.
            txtScriptInput.ReadOnly = true;   // Asegúrate que los nombres coincidan.
        }

        private void btnLoadScript_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtScriptInput.Text = File.ReadAllText(openFileDialog1.FileName);
                var validationMessages = ValidateScript(txtScriptInput.Text);
                txtOutput.Text = validationMessages;
                btnExecuteScript.Enabled = validationMessages == "Validation passed.";
            }
        }

        private void btnExecuteScript_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Executing script...");
        }

        private string ValidateScript(string script)
        {
            try
            {
                AntlrInputStream inputStream = new AntlrInputStream(script);
                SQLLexer lexer = new SQLLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
                SQLParser parser = new SQLParser(commonTokenStream);

                IParseTree tree = parser.sql(); // Ajusta este método según el punto de entrada del MySQL Parser

                SQLCustomListener listener = new SQLCustomListener();  // Usando el listener que ya tenías
                ParseTreeWalker.Default.Walk(listener, tree);

                if (parser.NumberOfSyntaxErrors == 0 && listener.Errors.Count == 0)
                {
                    return "Validation passed.";
                }
                else
                {
                    return string.Join("\n", listener.Errors);
                }
            }
            catch (Exception ex)
            {
                return $"Validation failed: {ex.Message}";
            }
        }
    }
}
