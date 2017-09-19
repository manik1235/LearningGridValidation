Public Class Form1
    Dim GridItem As New GridValidation

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridItem.InitializeGrid()



    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Label1.Text = CStr(GridItem.IsSpaceOpen(New Point(CInt(TextBox1.Text), CInt(TextBox2.Text))))
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' I don't think I need to validate the move beforehand, because the class does that for me.

        'Dim CurrentSpot As New Point(CInt(TextBox3.Text), CInt(TextBox4.Text))
        Dim NewSpot As New Point(CInt(TextBox5.Text), CInt(TextBox6.Text))

        Dim whoKey As String = TextBox7.Text ' This needs to be the name of the object that is being moved.

        ' Grid space is open, remove self from spot and move to new spot
        Label10.Text = GridItem.MoveTo(whoKey, NewSpot) ' Return True if move is successful, false if not.


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Find Object

        Dim pt As New Point

        pt = GridItem.FindObject(TextBox8.Text)

        TextBox9.Text = pt.X
        TextBox10.Text = pt.Y


    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click
        Label10.Text = ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Label1.Text = ""
    End Sub
End Class
