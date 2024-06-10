Public Class Form6
    Private randomCode As String
    Private amount As Integer

    Public Sub SetRandomCode(code As String)
        randomCode = code
        lblKey.Text = randomCode ' Update the label name here
    End Sub

    Public Sub SetAmount(value As Integer)
        amount = value
    End Sub

    Private Sub btnContinue_Click(sender As Object, e As EventArgs) Handles continueButton_Click.Click
        Dim userInput As String = txtKey.Text.Trim()

        If userInput = randomCode Then
            Dim form7 As New Form7()
            form7.SetAmount(amount)
            form7.ShowDialog()
            Me.Hide()
        Else
            MessageBox.Show("Invalid key. Please enter the correct code.")
        End If
    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
    End Sub
End Class