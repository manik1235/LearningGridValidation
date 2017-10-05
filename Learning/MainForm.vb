Option Strict On
Option Explicit On
Imports Learning

''' <summary>
'''   The train game First Draft
''' </summary>
Public Class MainForm

    Friend BackgroundGrid As New GridValidationClass ' Carries the grid information, for what is on the grid, in the particular locations.
    Dim BackgroundGraphic As Graphics ' Carries the graphics to draw on for the background
    Dim ImageOrder As New Dictionary(Of String, Integer) ' Holds the string name and cooresponding index of the image in the ImageList
    Dim OldBackgroundDateTime As DateTime ' Holds the hash of the background to detect changes and the need to update

    Private Sub PlayingFieldPanel_Paint(sender As Object, e As PaintEventArgs) Handles PlayingFieldPanel.Paint
        ' Playing field panel is where the trains move and where the grid gets painted
    End Sub

    Private Sub BackgroundPanel_Paint(sender As Object, e As PaintEventArgs) Handles BackgroundPanel.Paint
        ' This is the grid that gets painted

        ' Redraw the entire grid
        DrawEntireGrid(BackgroundGrid, BackgroundGraphic, New Size(TileImageList.ImageSize.Width, TileImageList.ImageSize.Height))

        ' Redraw a specific tile
        Dim x As Integer = 3
        Dim y As Integer = 3
        DrawGridTile(BackgroundGrid, BackgroundGraphic, New Size(TileImageList.ImageSize.Width, TileImageList.ImageSize.Height), New Point(x, y))



    End Sub

    ''' <summary>
    '''   Updates a single tile only, represented by the TileLocation point, relative to the passed graphic
    ''' </summary>
    ''' <param name="DrawGrid">The Grid from which to read data</param>
    ''' <param name="DrawGraphic">The Graphic to draw on</param>
    ''' <param name="TileSize">The size of the tiles</param>
    ''' <param name="TileLocation">The grid point to update</param>
    Private Sub DrawGridTile(DrawGrid As GridValidationClass, DrawGraphic As Graphics, TileSize As Size, TileLocation As Point)

        Dim curTile As String


        ' Get the current tile and look up what image it is
        curTile = DrawGrid.GetContents(TileLocation.X, TileLocation.Y)
        TileImageList.Draw(DrawGraphic, TileLocation.X * TileSize.Width, TileLocation.Y * TileSize.Height, ImageIndexByName(curTile))

    End Sub

    ''' <summary>
    ''' Draw (or redraw) the entire grid
    ''' </summary>
    ''' <param name="DrawGrid">The Grid to read.</param>
    ''' <param name="DrawGraphic">The Graphics to write to/modify.</param>
    ''' <param name="TileSize">The Size of the individual tiles</param>
    Private Sub DrawEntireGrid(DrawGrid As GridValidationClass, DrawGraphic As Graphics, TileSize As Size)
        ' Draw the corresponding image based on the grid contents.

        Dim x As Integer
        Dim y As Integer

        Dim curTile As String

        For x = 0 To DrawGrid.GridArray.Width
            For y = 0 To DrawGrid.GridArray.Height
                ' Get the current tile and look up what image it is
                curTile = DrawGrid.GetContents(x, y)
                TileImageList.Draw(DrawGraphic, x * TileSize.Width, y * TileSize.Height, ImageIndexByName(curTile))

            Next
        Next
    End Sub

    Private Sub InitializeImageDictionary()
        ' Current order of the image list is as follows:
        ' White
        ' Open
        ' Wall
        ' Forest
        ' CircleCar

        Dim i As Integer = 0


        'i += 1
        ImageOrder.Add("White", i)
        i += 1
        ImageOrder.Add("Open", i)
        i += 1
        ImageOrder.Add("Wall", i)
        i += 1
        ImageOrder.Add("Forest", i)
        i += 1
        ImageOrder.Add("CircleCar", i)

    End Sub

    Private Function ImageIndexByName(curTile As String) As Integer
        ' Current order of the image list is as follows:
        ' White
        ' Open
        ' Wall
        ' Forest
        ' CircleCar

        Try
            Return ImageOrder.Item(curTile)
        Catch
            Return ImageOrder.Item(ConvertTestToImage(curTile))
        End Try
    End Function

    Private Function ConvertTestToImage(curTile As String) As String
        If Strings.Left(curTile, 4) = "Wall" Then
            Return "Wall"
        ElseIf Strings.Left(curTile, 3) = "Car" Then
            Return "CircleCar"
        Else
            ' Return the blank white square by default.
            Return "White"
        End If
        Stop

    End Function

    ''' <summary>
    '''   This is The main loop that causes repeating events to occur.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TickTimer_Tick(sender As Object, e As EventArgs) Handles TickTimer.Tick

        'Me.InvokePaintBackground(BackgroundPanel, CType(e, PaintEventArgs))

        'BackgroundPanel_Paint(sender, CType(e, PaintEventArgs))

        ' This needs to be way more efficient
        ' Update it if the hash is different?
        ' Use the new TimeStamp function in GridValidationClass

        If (BackgroundGrid.GetTimeStamp = OldBackgroundDateTime) Then
            ' No update required
            'Stop
            Debug.Print("No Update Required")
        Else
            ' The background panel has changed. Set the timestamp
            OldBackgroundDateTime = BackgroundGrid.SetTimeStamp
            BackgroundPanel.Refresh()


        End If

    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' Create the image dictionary
        InitializeImageDictionary()

        ' Create the initial BackgroundGraphics
        InitializeBackgroundGraphic()

    End Sub


    ''' <summary>
    '''   Make the graphic to draw on
    ''' </summary>
    Private Sub InitializeBackgroundGraphic()
        ' Make the background graphic, currently using the BackgroundPanel
        BackgroundGraphic = BackgroundPanel.CreateGraphics


    End Sub
End Class