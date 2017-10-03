Option Strict On
Option Explicit On


''' <summary>
'''   The train game First Draft
''' </summary>
Public Class MainForm

    Dim BackgroundGrid As GridValidationClass

    Private Sub PlayingFieldPanel_Paint(sender As Object, e As PaintEventArgs) Handles PlayingFieldPanel.Paint
        ' Playing field panel is where the trains move and where the grid gets painted
    End Sub

    Private Sub BackgroundPanel_Paint(sender As Object, e As PaintEventArgs) Handles BackgroundPanel.Paint
        ' This is the grid that gets painted

        ' Draw the corresponding image based on the grid contents.

        Dim x As Integer
        Dim y As Integer

        For x = 0 To BackgroundGrid.Width
            For y = 0 To BackgroundGrid.Height
                BackgroundGrid.GetContents(x, y)

            Next
        Next




    End Sub

    ''' <summary>
    '''   This is The main loop that causes repeating events to occur.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub TickTimer_Tick(sender As Object, e As EventArgs) Handles TickTimer.Tick




    End Sub


End Class