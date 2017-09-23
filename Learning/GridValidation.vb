Option Explicit On
Option Strict On


Public Class GridValidation
    ' Use a grid to detect collisions
    ' Start with a 2 dimensional array the size of the (visible?) field

    ' Starting the grid as a 10x10
    Dim GridArray(9, 9) As String ' value is gaOpen if open, otherwise it's the name of the Object in that spot.

    Const gaOPEN = "Open" ' The string in the grid array if the spot is open.

    Private _width As Integer
    ''' <summary>
    '''   Gets or Sets the width of the Grid Array
    ''' </summary>
    ''' <returns>An integer representing the number of horizontal spots in the grid</returns>
    Public Property Width As Integer
        Get
            Return _width
        End Get
        Set(value As Integer)
            _width = value
        End Set
    End Property

    Private _height As Integer
    ''' <summary>
    '''   Gets or sets the height of the Grid Array
    ''' </summary>
    ''' <returns>An integer representing the number of vertical spots in the grid</returns>
    Public Property Height As Integer
        Get
            Return _height
        End Get
        Set(value As Integer)
            _height = value
        End Set
    End Property

    Friend Sub InitializeGrid()

        'Dim GridElement As Boolean

        Dim x As Integer
        Dim y As Integer

        ' Assign the height and width properties based on the initial size of the array
        Width = GridArray.GetUpperBound(1)
        Height = GridArray.GetUpperBound(1)


        ' Make sure each grid element starts as "Open" (True)
        For x = 0 To GridArray.GetUpperBound(0)
            For y = 0 To GridArray.GetUpperBound(1)
                GridArray(x, y) = gaOPEN
            Next
        Next
        'GridArray(2, 3) = True

        'Debug.Print(CStr(GridArray(2, 3)))
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="whoKey">The unique name of the object to move</param>
    ''' <param name="newSpot"></param>
    ''' <returns></returns>
    Friend Function MoveTo(whoKey As String, newSpot As Point) As Boolean
        ' Returns the new spot if the move is successful, returns the old spot if unsuccessful
        ' Moves from the currentSpot (mark that location open) to the newSpot (mark that location closed)

        Dim returnValue As New Boolean
        Dim currentSpot As New Point

        If (IsSpaceOpen(newSpot)) Then
            ' Successful move. Move the object and return "True"
            currentSpot = FindObject(whoKey)
            GridArray(currentSpot.X, currentSpot.Y) = gaOPEN
            GridArray(newSpot.X, newSpot.Y) = whoKey
            returnValue = True
        Else
            ' unsuccessful move, return False
            returnValue = False
        End If

        Return returnValue

    End Function

    ''' <summary>
    '''   Returns the contents of the Array at the specified point
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    Friend Function GetContents(x As Integer, y As Integer) As String ' Return type should be the same as the GridArray array type

        Return GridArray(x, y)

        'Throw New NotImplementedException()
    End Function

    ''' <summary>
    '''   Takes the "who" and returns the location in the array it is currently occupying
    '''   Assumes all objects occupy only one space.
    ''' </summary>
    ''' <param name="whoKey">The unique name of the object being moved.</param>
    ''' <returns>A Point representing the object's location on the grid</returns>
    Friend Function FindObject(whoKey As String) As Point

        Dim x As Integer ' Counter for the first array dimension
        Dim y As Integer ' Counter for the second array dimension

        Dim returnPoint As New Point ' Holds the return value of the point. Might make this a collection if objects take up more than one space....

        ' Make sure each grid element starts as "Open" (gaOpen)
        For x = 0 To GridArray.GetUpperBound(0)
            For y = 0 To GridArray.GetUpperBound(1)
                If (GridArray(x, y) = whoKey) Then


                    returnPoint = New Point(x, y)
                    Return returnPoint
                End If
            Next
        Next

    End Function

    Friend Function IsSpaceOpen(pt As Point) As Boolean
        ' Takes a point on the grid. Returns True if Open, False if closed
        Return (GridArray(pt.X, pt.Y) = gaOPEN) ' Returns True if it's equal to the Open symbol.

    End Function






End Class
