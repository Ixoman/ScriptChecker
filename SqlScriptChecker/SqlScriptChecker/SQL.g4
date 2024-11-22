grammar SQL;

sql
    : statement+ EOF
    ;

statement
    : updateStatement
    | deleteStatement
    | selectStatement
    ;

updateStatement
    : 'UPDATE' tableName 'SET' columnAssignment (',' columnAssignment)* ('FROM' joinTable 'ON' condition)? whereClause?
    ;

deleteStatement
    : 'DELETE' 'FROM' tableName whereClause?
    ;

selectStatement
    : 'SELECT' columnList 'FROM' tableName ( joinType 'JOIN' joinTable 'ON' condition )? whereClause?
    ;

tableName
    : IDENTIFIER ('AS' IDENTIFIER)?
    ;

columnAssignment
    : IDENTIFIER '=' expression
    ;

expression
    : value
    | IDENTIFIER arithmeticOperator value
    | functionCall
    ;

joinTable
    : IDENTIFIER ('AS' IDENTIFIER)?
    ;

whereClause
    : 'WHERE' condition (logicalOperator condition)*
    ;

condition
    : IDENTIFIER comparisonOperator value
    ;

comparisonOperator
    : '=' | '>' | '<' | '>=' | '<=' | '<>'
    ;

logicalOperator
    : 'AND' | 'OR'
    ;

columnList
    : IDENTIFIER (',' IDENTIFIER)*
    ;

value
    : STRING
    | NUMBER
    | '(' selectStatement ')'
    ;

functionCall
    : IDENTIFIER '(' (IDENTIFIER (',' IDENTIFIER)*)? ')'
    ;

arithmeticOperator
    : '+' | '-' | '*' | '/'
    ;

joinType
    : 'LEFT' | 'RIGHT' | 'FULL' | 'INNER'
    ;

IDENTIFIER
    : [a-zA-Z_][a-zA-Z0-9_]*
    ;

STRING
    : '\'' .*? '\''
    ;

NUMBER
    : [0-9]+
    ;

WS
    : [ \t\r\n]+ -> skip
    ;
