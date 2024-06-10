Imports System.Data.OleDb
Module conn
    Public sqlconn As New OleDbConnection
    Public sqlquery As New OleDbCommand
    Public adapter As New OleDb.OleDbDataAdapter(sqlquery)
    Public dt As New DataTable
    'Public ds As New DataSet
    Sub OpenCon()
        sqlconn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=tblStudent.mdb"
        sqlconn.Open()
    End Sub
End Module
