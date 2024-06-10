Public Class Form4
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        sqlquery.Connection = sqlconn
        OpenCon()
        Try


            sqlquery.CommandText = "SELECT * FROM tblStudents WHERE StudentsNumber = '" & TextBox2.Text & "'"
            adapter.SelectCommand = sqlquery
            dt.Clear()
            adapter.Fill(dt)
            For i As Integer = 0 To dt.Rows.Count - 1
                TextBox2.Text = dt.Rows(i)("StudentsNumber").ToString
                TextBox1.Text = dt.Rows(i)("Balance").ToString

            Next
            sqlconn.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form5.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form3.Show()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
    End Sub
End Class