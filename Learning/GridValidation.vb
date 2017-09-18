Public Class GridValidation
    ' Use a grid to detect collisions
    ' Start with a 2 dimensional array the size of the (visible?) field

    ' Starting the grid as a 10x10
    Dim GridArray(9, 9) As Boolean ' Starting as boolean, because I only need a true (open) or false (blocked)

    Sub InitializeGrid()
        ' Make sure each grid element starts as "Open" (True)
        For Each GridElement In GridArray
            GridElement = True
        Next
    End Sub

    Function IsSpaceOpen(pt As Point)
        ' Takes a point on the grid. Returns True if Open, False if closed
        Return GridArray(pt.X, pt.Y)

    End Function






End Class
