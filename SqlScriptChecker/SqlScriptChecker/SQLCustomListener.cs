using System.Collections.Generic;

namespace SqlScriptChecker
{
    public class SQLCustomListener : SQLBaseListener
    {
        public List<string> Errors { get; private set; } = new List<string>();

        public override void EnterDeleteStatement(SQLParser.DeleteStatementContext context)
        {
            // Verificar DELETE sin WHERE
            if (context.whereClause() == null)
            {
                Errors.Add("DELETE statement without WHERE clause.");
            }
        }

        public override void EnterUpdateStatement(SQLParser.UpdateStatementContext context)
        {
            // Verificar UPDATE sin WHERE
            if (context.whereClause() == null && context.joinTable() == null)
            {
                Errors.Add("UPDATE statement without WHERE clause.");
            }
            else if (context.joinTable() != null && context.whereClause() == null)
            {
                Errors.Add("UPDATE statement with JOIN but without WHERE clause.");
            }
        }

        public override void EnterWhereClause(SQLParser.WhereClauseContext context)
        {
            // Verificar cláusula WHERE incompleta
            if (context.GetText().EndsWith("=") || context.GetText().EndsWith("AND") || context.GetText().EndsWith("OR"))
            {
                Errors.Add("Incomplete WHERE clause.");
            }
        }
    }
}
