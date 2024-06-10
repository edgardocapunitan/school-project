Imports System.Data.OleDb

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadTables()
        Me.BackColor = Color.LightBlue
    End Sub
    Private Sub RefreshTables(Optional ByVal q As String = "")
        sqlquery.Connection = sqlconn
        OpenCon()
        Try
            Dim adapter As New OleDbDataAdapter
            Dim dt As New DataTable
            sqlquery.CommandText = "SELECT * FROM tblStudents WHERE StudentsNumber = '" &
           txtSearch.Text & "'"
            adapter.SelectCommand = sqlquery
            dt.Clear()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            sqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()
    End Sub
    Private Sub LoadTables(Optional ByVal q As String = "")
        sqlquery.Connection = sqlconn
        OpenCon()
        Try
            Dim adapter As New OleDbDataAdapter
            Dim dt As New DataTable
            sqlquery.CommandText = "SELECT * FROM tblStudents"
            adapter.SelectCommand = sqlquery
            dt.Clear()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
            sqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()
    End Sub
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        txtAverage.Text = (Val(txtpgrade.Text) + Val(txtmgrade.Text) + Val(txtpfgrade.Text) + Val(txtfGrade.Text)) / 4
        txtname.Text = txtfn.Text
        txtsection.Text = txtcys.Text
        txtsnum.Text = txtsn.Text
        Dim grade As Single

        grade = txtAverage.Text
        Select Case grade
            Case 60 To 73
                txtRemarks.Text = "Failed"
            Case 74 To 75
                txtRemarks.Text = "Passed"
            Case 76 To 84
                txtRemarks.Text = "Good"
            Case 85 To 89
                txtRemarks.Text = "Very Good"
            Case 90 To 100
                txtRemarks.Text = "Excellent"
            Case Else
                txtRemarks.Text = "Error"
        End Select
        OpenCon()
        sqlquery.Connection = sqlconn
        Try
            sqlquery.CommandText = "INSERT INTO tblStudents(StudentsNumber,FullName, CourseYearSection, PrelimGrade, MidtermGrade, PreFinalGrade, FinalGrade, Program, Balance, Status, Age) VALUES('" & txtsn.Text & "', '" & txtfn.Text & "','" & txtcys.Text & "', '" & txtpgrade.Text & "', '" & txtmgrade.Text & "','" & txtpfgrade.Text & "','" & txtfGrade.Text & "','" & txtprog.Text & "','" & txtbal.Text & "','" & txtsta.Text & "','" & txtAge.Text & "')"
            sqlquery.ExecuteNonQuery()
            MessageBox.Show("Successfully Registered")
            txtsn.Clear()
            txtfn.Clear()
            txtcys.Clear()
            txtpgrade.Clear()
            txtmgrade.Clear()
            txtpfgrade.Clear()
            txtfGrade.Clear()
            txtprog.Clear()
            txtbal.Clear()
            txtsta.Clear()
            txtAge.Clear()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Call RefreshTables()

    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        OpenCon()
        Try
            sqlquery.CommandText = "DELETE * FROM tblStudents WHERE StudentsNumber = '" &
           txtSearch.Text & "'"
            sqlquery.ExecuteNonQuery()
            MessageBox.Show("Record Deleted")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()
        Call LoadTables()

    End Sub
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        sqlquery.Connection = sqlconn
        OpenCon()
        Try
            sqlquery.CommandText = "UPDATE tblStudents SET StudentsNumber = '" &
            txtsn.Text & "', FullName = '" & txtfn.Text & "', CourseYearSection = '" &
            txtcys.Text & "', PrelimGrade = '" & txtpgrade.Text & "', MidtermGrade ='" &
            txtmgrade.Text & "',PreFinalGrade = '" & txtpfgrade.Text & "',FinalGrade = '" & txtfGrade.Text & "',Program = '" & txtprog.Text & "',Balance = '" & txtbal.Text & "',Status = '" & txtsta.Text & "',Age = '" & txtAge.Text & "' WHERE FullName = '" & txtSearch.Text & "'"
            sqlquery.ExecuteNonQuery()
            MessageBox.Show("Updated Record")
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()
        Call LoadTables()
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtcys.TextChanged

    End Sub

    Private Sub btnRetrieve_Click(sender As Object, e As EventArgs) Handles btnRetrieve.Click
        Try
            Dim connectionString As String = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\EDUARDO\Desktop\New folder\kenkoy\kenkoy\bin\Debug\tblStudent.mdb"
            Dim query As String = "SELECT * FROM tblStudents"

            Using connection As New OleDbConnection(connectionString)
                Dim command As New OleDbCommand(query, connection)
                connection.Open()
                Dim reader As OleDbDataReader = command.ExecuteReader()

                If reader.HasRows Then
                    While reader.Read()
                        Dim StudentsNumber As String = reader.GetString(reader.GetOrdinal("StudentsNumber"))
                        Dim FullName As String = reader.GetString(reader.GetOrdinal("FullName"))
                        Dim CourseYearSection As String = reader.GetString(reader.GetOrdinal("CourseYearSection"))
                        Dim PrelimGrade As String = reader.GetString(reader.GetOrdinal("PrelimGrade"))
                        Dim MidtermGrade As String = reader.GetString(reader.GetOrdinal("MidtermGrade"))
                        Dim PreFinalGrade As String = reader.GetString(reader.GetOrdinal("PreFinalGrade"))
                        Dim FinalGrade As String = reader.GetString(reader.GetOrdinal("FinalGrade"))
                        Dim Program As String = reader.GetString(reader.GetOrdinal("Program"))
                        'Dim Balance As String = reader.GetString(reader.GetOrdinal("Balance"))
                        Dim Status As String = reader.GetString(reader.GetOrdinal("Status"))
                        'Dim Age As String = reader.GetString(reader.GetOrdinal("Age"))

                        txtsn.Text = StudentsNumber
                        txtfn.Text = FullName
                        txtcys.Text = CourseYearSection
                        txtpgrade.Text = PrelimGrade
                        txtmgrade.Text = MidtermGrade
                        txtpfgrade.Text = PreFinalGrade
                        txtfGrade.Text = FinalGrade
                        txtprog.Text = Program
                        'txtbal.Text = Balance
                        txtsta.Text = Status
                        'txtAge.Text = Age
                    End While
                Else
                    MessageBox.Show("No data found.")
                End If

                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form3.Show()
    End Sub
End Class