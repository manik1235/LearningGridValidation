Option Explicit On
Option Strict On
Imports Learning

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

        'Debug.Print("tick")

        ' Update the grid display of the primary one
        UpdateGridDisplay(TableLayoutPanel1)

        ' Move Item
        ' Apply the movement updown contrls
        ' Move Car#1 around
        Debug.Print("Car#1: " & CStr(GridItem.MoveTo("Car#1", GridItem.FindObject("Car#1") + New Size(CInt(NumericUpDown1.Value), CInt(NumericUpDown2.Value))))) ' This line gives an error saying it can't cast from point to size, but FindObject returns a point.... why?


    End Sub

    ''' <summary>
    '''   Read the states of the grid and update the display.
    '''   This display is a TableLayoutPanel control.
    ''' </summary>
    ''' <param name="TableLayoutPanelControl"></param>
    Private Sub UpdateGridDisplay(TableLayoutPanelControl As TableLayoutPanel)
        ' Overload this sub when appropriate for different grids to update, or differnt ways to do it.
        Dim x As Integer = 0
        Dim y As Integer = 0

        ' Update the grid display
        Dim mControl() As Control
        For x = 0 To GridItem.Width
            For y = 0 To GridItem.Height
                mControl = TableLayoutPanelControl.Controls.Find("GridLabel" & Trim(CStr(x)) & "," & Trim(CStr(y)), True)
                mControl(0).Text = GridItem.GetContents(x, y)
                'Stop
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
                'TableLayoutPanel1.Controls.Item(i).Text = TableLayoutPanel1.Controls.Item(i).Name
                'Debug.Print(TableLayoutPanel1.Controls.Item(i).Name)
                'Debug.Print(CStr(TableLayoutPanel1.Controls.ContainsKey(TableLayoutPanel1.Controls.Item(i).Name)))
                i += 1
            Next
        Next


        ' Add features to the map
        AddGridFeatures(GridItem)


    End Sub

    ''' <summary>
    '''   Adds stuff to the map
    ''' </summary>
    ''' <param name="gridItem"></param>
    Private Sub AddGridFeatures(gridItem As GridValidation)


        Dim x As Integer
        Dim y As Integer

        ' Add walls to the outsides
        For x = 0 To gridItem.Width
            For y = 0 To gridItem.Height
                '  first row
                '  last row
                '  left wall
                '  right wall
                Debug.Print("Wall Coord: " & CStr(x) & "," & CStr(y))

                If (y = 0 And (x >= 0 And x <= gridItem.Width)) Or
                   (y = gridItem.Height And (x >= 0 And x <= gridItem.Width)) Or
                   (x = 0 And (y >= 0 And y <= gridItem.Height)) Or
                   (x = gridItem.Width And (y >= 0 And y <= gridItem.Height)) Then
                    Debug.Print("Wall Generator placement successful: " & CStr(x) & "," & CStr(y) & " " & CStr(gridItem.Add("Wall" & CStr(x) & "," & CStr(y), New Point(x, y))))
                Else
                    Debug.Print("Wall Generator skipping x,y:" & CStr(x) & " " & CStr(y))
                End If
                'Stop

            Next
        Next

        ' Add a VehicleClass Item
        gridItem.Add("Car#1", 2, 2, False)


    End Sub

    Private Sub TextBox15_TextChanged(sender As Object, e As EventArgs) Handles TextBox15.TextChanged
        If CInt(TextBox15.Text) > 0 Then
            'Only adjust the timer interval if the interval being set is greater than zero
            Timer1.Interval = CInt(TextBox15.Text)
        End If
    End Sub
End Class
