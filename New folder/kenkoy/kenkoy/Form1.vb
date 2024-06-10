Imports System.Data.OleDb

Public Class Form1

    Dim con As New OleDbConnection
    Dim dbProvider As String = "Provider=Microsoft.Jet.OLEDB.4.0;"
    Dim dbSource As String = "Data Source=C:\Users\EDUARDO\Desktop\New folder\LoginAndRegister.mdb"
    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If TextBox1.Text = Nothing Or TextBox2.Text = Nothing Then
            MessageBox.Show("Please Enter your Correct Information", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Using login As New OleDbCommand("SELECT COUNT(*) FROM member WHERE [USERNAME] = @USERNAME AND [PASSWORD]=@PASSWORD", con)
            login.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = TextBox1.Text.Trim
            login.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = TextBox2.Text.Trim

            Dim logincount = Convert.ToInt32(login.ExecuteScalar())
            If logincount > 0 Then
                Me.Hide()
                Form2.Show()
            Else
                MessageBox.Show("Invalid, Please try Again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox1.Clear()
                TextBox2.Clear()
            End If
        End Using
        con.Close()
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If TextBox3.Text = Nothing Or TextBox4.Text = Nothing Then
            MessageBox.Show("Please Enter Empty details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        If con.State = ConnectionState.Closed Then
            con.Open()
        End If
        Using cmd As New OleDbCommand("SELECT COUNT(*) FROM member WHERE [USERNAME] = @USERNAME OR [PASSWORD]=@PASSWORD", con)
            cmd.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = TextBox3.Text.Trim
            cmd.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = TextBox4.Text.Trim

            Dim count = Convert.ToInt32(cmd.ExecuteScalar())
            If count > 0 Then
                MessageBox.Show("Opps, username and password has already taken", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End Using
        Using create As New OleDbCommand("INSERT INTO member([USERNAME],[PASSWORD])VALUES(@USERNAME,@PASSWORD)", con)
            create.Parameters.AddWithValue("@USERNAME", OleDbType.VarChar).Value = TextBox3.Text.Trim
            create.Parameters.AddWithValue("@PASSWORD", OleDbType.VarChar).Value = TextBox4.Text.Trim
            If create.ExecuteNonQuery Then
                MessageBox.Show("Account Created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                TextBox3.Clear()
                TextBox4.Clear()
            End If
        End Using
        con.Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.ConnectionString = dbProvider & dbSource
        Me.BackColor = Color.LightBlue
    End Sub


End Class
