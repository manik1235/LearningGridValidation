Option Strict On
Option Explicit On


''' <summary>
'''   The train game First Draft
''' </summary>
Public Class MainForm

    Friend BackgroundGrid As New GridValidationClass ' Carries the grid information, for what is on the grid, in the particular locations.
    Dim BackgroundGraphic As Graphics ' Carries the graphics to draw on for the background
    Dim ImageOrder As New Dictionary(Of String, Integer) ' Holds the string name and cooresponding index of the image in the ImageList

    Private Sub PlayingFieldPanel_Paint(sender As Object, e As PaintEventArgs) Handles PlayingFieldPanel.Paint
        ' Playing field panel is where the trains move and where the grid gets painted
    End Sub

    Private Sub BackgroundPanel_Paint(sender As Object, e As PaintEventArgs) Handles BackgroundPanel.Paint
        ' This is the grid that gets painted

        ' Draw the corresponding image based on the grid contents.

        Dim x As Integer
        Dim y As Integer

        Dim curTile As String

        For x = 0 To BackgroundGrid.Width
            For y = 0 To BackgroundGrid.Height
                ' Get the current tile and look up what image it is
                curTile = BackgroundGrid.GetContents(x, y)
                TileImageList.Draw(BackgroundGraphic, x * TileImageList.ImageSize.Width, y * TileImageList.ImageSize.Height, ImageIndexByName(curTile))

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
        If curTile = "Wall" Then
            Return "Wall"
        End If
    End Function

    ''' <summary>
    '''   This is The main loop that causes repeating events to occur.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TickTimer_Tick(sender As Object, e As EventArgs) Handles TickTimer.Tick




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