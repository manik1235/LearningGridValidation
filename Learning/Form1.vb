Public Class Form1
    Dim GridItem As New GridValidation

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridItem.InitializeGrid()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = CStr(GridItem.IsSpaceOpen(New Point(CInt(TextBox1.Text), CInt(TextBox2.Text))))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If GridItem.IsSpaceOpen(New Point(CInt(TextBox1.Text), CInt(TextBox2.Text))) Then

            Dim CurrentSpot As New Point(CInt(TextBox3.Text), CInt(TextBox4.Text))
            Dim NewSpot As New Point(CInt(TextBox5.Text), CInt(TextBox6.Text))

            ' Grid space is open, remove self from spot and move to new spot
            MsgBox(GridItem.MoveFromTo(CurrentSpot, NewSpot)) ' Return True if move is successful, false if not.
        End If
    End Sub
End Class
