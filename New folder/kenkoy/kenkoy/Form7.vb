Public Class Form7
    Private amount As Integer
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Call searchTable()
            e.Handled = True
            TextBox1.Text = ""


        End If

    End Sub

    Private Sub searchTable(Optional ByVal q As String = "")
        Try


            sqlquery.CommandText = "SELECT * FROM tblStudents WHERE StudentsNumber = '" & TextBox1.Text & "'"
            adapter.SelectCommand = sqlquery
            dt.Clear()
            adapter.Fill(dt)


            For i As Integer = 0 To dt.Rows.Count - 1
                TextBox2.Text = dt.Rows(i)("StudentsNumber").ToString
                TextBox3.Text = dt.Rows(i)("FullName").ToString
                TextBox4.Text = dt.Rows(i)("Age").ToString
                TextBox5.Text = dt.Rows(i)("Program").ToString
                TextBox6.Text = dt.Rows(i)("Status").ToString
                TextBox7.Text = dt.Rows(i)("CourseYearSection").ToString
                TextBox8.Text = dt.Rows(i)("PrelimGrade").ToString
                TextBox9.Text = dt.Rows(i)("MidtermGrade").ToString
                TextBox10.Text = dt.Rows(i)("PreFinalGrade").ToString
                TextBox11.Text = dt.Rows(i)("FinalGrade").ToString
            Next
            sqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
        sqlconn.Close()
    End Sub
    Private Sub Form7_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAmount.Text = amount.ToString()
        Me.BackColor = Color.LightBlue
    End Sub
    Public Sub SetAmount(value As Integer)
        amount = value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Hide()
    End Sub
End Class