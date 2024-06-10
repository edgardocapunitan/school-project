Imports System.Text
Public Class Form5
    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles btnContinue.Click
        Dim amount As Integer

        If Integer.TryParse(txtAmount.Text, amount) AndAlso amount > 0 Then
            Dim randomCode As String = GenerateRandomCode()
            Form6.SetRandomCode(randomCode)
            Form6.SetAmount(amount)
            Form6.ShowDialog()
            Me.Hide()
        Else
            MessageBox.Show("Invalid amount. Please enter a valid positive number.")
        End If
    End Sub

    Private Function GenerateRandomCode() As String
        Dim random As New Random()
        Dim codeBuilder As New StringBuilder()

        For i As Integer = 0 To 5
            Dim randomChar As Char = ChrW(random.Next(65, 91))
            codeBuilder.Append(randomChar)
        Next

        Return codeBuilder.ToString()
    End Function

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
    End Sub
End Class