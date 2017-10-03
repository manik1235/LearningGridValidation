Option Explicit On
Option Strict On

''' <summary>
'''   Use a grid to detect collisions and keep track of vehicles or other things like walls
''' </summary>
Public Class GridValidationClass
    ' Use a grid to detect collisions
    ' Start with a 2 dimensional array the size of the (visible?) field

    ' Starting the grid as a 10x10
    Dim GridArray(9, 5) As String ' value is gaOpen if open, otherwise it's the name of the Object in that spot.
    ' Instead of being an array, it could just be a collection or dictionary or something, with a key of "x,y"
    ' which could easily be extended to "x,y,z" for example
    ' I think changing this structure to a collection is going to help a lot on size


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

    Public Sub New()
        ' This is what runs when you create a new one. 
        ' Set the initial values for the grid
        InitializeGrid()
    End Sub

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
        Width = GridArray.GetUpperBound(0)
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
            If currentSpot = New Point(-1, -1) Then
                ' Object was not found if -1,-1 is returned. Right now, that creates the object, but it should probably fail...
                Throw New NotImplementedException()
            End If
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
    ''' <returns>A Point representing the object's location on the grid. Returns Nothing/null if object not found</returns>
    Friend Function FindObject(whoKey As String) As Point

        Dim x As Integer ' Counter for the first array dimension
        Dim y As Integer ' Counter for the second array dimension

        Dim returnPoint As New Point  ' Holds the return value of the point. Might make this a collection if objects take up more than one space....

        'returnPointString = New Point 'should default to isEmpty
        If returnPoint.IsEmpty = False Then Stop


        ' Look through the grid until it finds the whoKey it's looking for
        For x = 0 To GridArray.GetUpperBound(0)
            For y = 0 To GridArray.GetUpperBound(1)
                If (GridArray(x, y) = whoKey) Then


                    returnPoint = New Point(x, y)
                    Return returnPoint
                End If
            Next
        Next
        'stop
    End Function

    Friend Function IsSpaceOpen(pt As Point) As Boolean
        ' Takes a point on the grid. Returns True if Open, False if closed
        Return (GridArray(pt.X, pt.Y) = gaOPEN) ' Returns True if it's equal to the Open symbol.

    End Function


    ''' <summary>
    '''   Adds an item to the grid in the newSpot. 
    ''' </summary>
    ''' <param name="whoKey">The name of the object being added</param>
    ''' <param name="newSpot">The location of the addition</param>
    ''' <param name="Overwrite">If True, replace the item in the newSpot with the new item</param>
    ''' <returns>Returns True if successful, false if not.</returns>
    Friend Function Add(whoKey As String, newSpot As Point, Optional Overwrite As Boolean = False) As Boolean

        Dim returnValue As New Boolean
        Dim currentSpot As New Point

        If (Overwrite Or IsSpaceOpen(newSpot)) Then
            ' The space is open, or Overwrite is enabled. Place the object.
            GridArray(newSpot.X, newSpot.Y) = whoKey
            returnValue = True
        Else
            ' The space is full. Return False
            returnValue = False
        End If

        Return returnValue

    End Function

    ''' <summary>
    '''   Adds an item to the grid in the newSpot. 
    ''' </summary>
    ''' <param name="whoKey">The name of the object being added</param>
    ''' <param name="newSpotX">The x location of the addition</param>
    ''' <param name="newSpotY">The y location of the addition</param>
    ''' <param name="Overwrite">If True, replace the item in the newSpot with the new item</param>
    ''' <returns></returns>
    Friend Function Add(whoKey As String, newSpotX As Integer, newSpotY As Integer, Optional Overwrite As Boolean = False) As Boolean
        ' Overloaded. Hopefully this is how you do it.
        Return Add(whoKey, New Point(newSpotX, newSpotY), Overwrite)
    End Function

    ''' <summary>
    '''   Removes the item whoKey from the grid
    ''' </summary>
    ''' <param name="whoKey">The name of the item to remove</param>
    ''' <returns>Returns True if Remove is successful, False if not.</returns>
    Friend Function RemoveItemByName(whoKey As String) As Boolean
        'Dim x As Integer
        'Dim y As Integer
        Dim pt As New Point

        pt = FindObject(whoKey)

        If pt.IsEmpty Then
            ' Nothing was found
            Return False
        Else
            GridArray(pt.X, pt.Y) = gaOPEN
            Return True
        End If


    End Function


    Friend Function RemoveItemByPoint(x As Integer, y As Integer) As Boolean

        ' set the passed point to Open, return True because it can't really fail
        GridArray(x, y) = gaOPEN
        Return True

    End Function
End Class
