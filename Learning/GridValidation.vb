Public Class GridValidation
    ' Use a grid to detect collisions
    ' Start with a 2 dimensional array the size of the (visible?) field

    ' Starting the grid as a 10x10
    Dim GridArray(9, 9) As Boolean ' Starting as boolean, because I only need a true (open) or false (blocked)

    Public Sub InitializeGrid()

        'Dim GridElement As Boolean

        Dim x As Integer
        Dim y As Integer

        ' Make sure each grid element starts as "Open" (True)
        For x = 0 To GridArray.GetUpperBound(0)
            For y = 0 To GridArray.GetUpperBound(1)
                GridArray(x, y) = True
            Next
        Next
        'GridArray(2, 3) = True

        Debug.Print(CStr(GridArray(2, 3)))
    End Sub

    Friend Function MoveFromTo(currentSpot As Point, newSpot As Point) As Point
        ' Returns the new spot if the move is successful, returns the old spot if unsuccessful
        ' Moves from the currentSpot (mark that location open) to the newSpot (mark that location closed)

        Dim returnValue As New Point

        If (IsSpaceOpen(newSpot)) Then
            ' Successful move
            GridArray(currentSpot.X, currentSpot.Y) = True
            GridArray(newSpot.X, newSpot.Y) = False
            returnValue = newSpot
        Else
            ' unsuccessful move, return the original spot
            returnValue = currentSpot
        End If

        Return returnValue

    End Function

    Public Function IsSpaceOpen(pt As Point)
        ' Takes a point on the grid. Returns True if Open, False if closed
        Return GridArray(pt.X, pt.Y)

    End Function






End Class
