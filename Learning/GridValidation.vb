Option Explicit On
Option Strict On


Public Class GridValidation
    ' Use a grid to detect collisions
    ' Start with a 2 dimensional array the size of the (visible?) field

    ' Starting the grid as a 10x10
    Dim GridArray(9, 9) As String ' value is gaOpen if open, otherwise it's the name of the Object in that spot.

    Const gaOPEN = "Open" ' The string in the grid array if the spot is open.


    Friend Sub InitializeGrid()

        'Dim GridElement As Boolean

        Dim x As Integer
        Dim y As Integer

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
