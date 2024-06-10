Public Class Form3
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
        TextBox1.Select()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Call searchTable()
            e.Handled = True
            TextBox1.Text = ""

        End If

    End Sub

    Private Sub searchTable(Optional ByVal q As String = "")
        sqlquery.Connection = sqlconn
        OpenCon()
        Try


            sqlquery.CommandText = "SELECT * FROM tblStudents WHERE StudentsNumber = '" & TextBox1.Text & "'"
            adapter.SelectCommand = sqlquery
            dt.Clear()
            adapter.Fill(dt)


            For i As Integer = 0 To dt.Rows.Count - 1
                Label1.Text = dt.Rows(i)("StudentsNumber").ToString
                Label2.Text = dt.Rows(i)("FullName").ToString
                Label3.Text = dt.Rows(i)("CourseYearSection").ToString
                Label4.Text = dt.Rows(i)("Program").ToString
                Label5.Text = dt.Rows(i)("Status").ToString
            Next
            sqlconn.Close()



        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form4.Show()
    End Sub
End Class