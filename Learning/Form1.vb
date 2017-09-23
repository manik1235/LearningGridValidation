Option Explicit On
Option Strict On


Public Class Form1
    Dim GridItem As New GridValidation

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GridItem.InitializeGrid()

        InitializeTableLayoutPanel()

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
        Label10.Text = CStr(GridItem.MoveTo(whoKey, NewSpot)) ' Return True if move is successful, false if not.


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Find Object

        Dim pt As New Point

        pt = GridItem.FindObject(TextBox8.Text)

        TextBox9.Text = CStr(pt.X)
        TextBox10.Text = CStr(pt.Y)


    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)
        Label10.Text = ""
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)
        Label1.Text = ""
    End Sub

    ''' <summary>
    '''   Update the Table Layout Panel to show the overall contents of the Grid class.
    '''   Use Labels and Colors to represent different things. Probably just labels to start
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim x As Integer = 0
        Dim y As Integer = 0

        Debug.Print("tick")

        Dim mControl() As Control

        For x = 0 To GridItem.Width
            For y = 0 To GridItem.Height
                mControl = TableLayoutPanel1.Controls.Find("GridLabel" & Trim(CStr(x)) & "," & Trim(CStr(y)), True)
                mControl(0).Text = GridItem.GetContents(x, y)

            Next
        Next

    End Sub

    ''' <summary>
    '''   Set the initial properties of the TableLayoutPanel
    ''' </summary>
    Private Sub InitializeTableLayoutPanel()
        ' Set the number of horizontal and verticle panels to be the same as the size of the grid
        TableLayoutPanel1.ColumnCount = GridItem.Width + 1
        TableLayoutPanel1.RowCount = GridItem.Height + 1

        Dim x As Integer
        Dim y As Integer
        Dim i As Integer = 0
        Dim pt As New Point


        ' Test the GetChildAtPoint thing
        'Debug.Print(TableLayoutPanel2.GetChildAtPoint(New Point(5, 5)).Name)

        'TableLayoutPanel2.Controls.GetChildIndex()


        'TableLayoutPanel2.g


        ' Add a label to each cell
        For x = 0 To GridItem.Width
            For y = 0 To GridItem.Height
                TableLayoutPanel1.Controls.Add(New Label)
                'pt = New Point(x + 1, y + 1)
                'TableLayoutPanel1.GetChildAtPoint(pt).Text = "x: " & CStr(x) & " y: " & CStr(y)
                'TableLayoutPanel1.Controls.Item(i).Text = "x: " & CStr(TableLayoutPanel1.Controls.Item(i).Left) & " y: " & CStr(TableLayoutPanel1.Controls.Item(i).Top)
                TableLayoutPanel1.Controls.Item(i).Name = "GridLabel" & Trim(CStr(x)) & "," & Trim(CStr(y)) ' You have to set the name property in order for it to have a key. The key is the name
                TableLayoutPanel1.Controls.Item(i).Text = TableLayoutPanel1.Controls.Item(i).Name
                Debug.Print(TableLayoutPanel1.Controls.Item(i).Name)
                Debug.Print(CStr(TableLayoutPanel1.Controls.ContainsKey(TableLayoutPanel1.Controls.Item(i).Name)))
                i += 1
            Next
        Next

        'TableLayoutPanel1.Controls.Item(2).Text = "Initial Text"


        ' Make sure they're all set to be the same size

    End Sub
End Class
