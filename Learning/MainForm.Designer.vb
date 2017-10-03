<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.BasePanel = New System.Windows.Forms.Panel()
        Me.ControlFieldPanel = New System.Windows.Forms.Panel()
        Me.PlayingFieldPanel = New System.Windows.Forms.Panel()
        Me.BackgroundPanel = New System.Windows.Forms.Panel()
        Me.TileImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.TickTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BasePanel.SuspendLayout()
        Me.PlayingFieldPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BasePanel
        '
        Me.BasePanel.Controls.Add(Me.ControlFieldPanel)
        Me.BasePanel.Controls.Add(Me.PlayingFieldPanel)
        Me.BasePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.BasePanel.Location = New System.Drawing.Point(0, 0)
        Me.BasePanel.Name = "BasePanel"
        Me.BasePanel.Size = New System.Drawing.Size(874, 537)
        Me.BasePanel.TabIndex = 0
        '
        'ControlFieldPanel
        '
        Me.ControlFieldPanel.Location = New System.Drawing.Point(12, 12)
        Me.ControlFieldPanel.Name = "ControlFieldPanel"
        Me.ControlFieldPanel.Size = New System.Drawing.Size(272, 279)
        Me.ControlFieldPanel.TabIndex = 1
        '
        'PlayingFieldPanel
        '
        Me.PlayingFieldPanel.Controls.Add(Me.BackgroundPanel)
        Me.PlayingFieldPanel.Location = New System.Drawing.Point(301, 12)
        Me.PlayingFieldPanel.Name = "PlayingFieldPanel"
        Me.PlayingFieldPanel.Size = New System.Drawing.Size(520, 520)
        Me.PlayingFieldPanel.TabIndex = 0
        '
        'BackgroundPanel
        '
        Me.BackgroundPanel.Location = New System.Drawing.Point(10, 10)
        Me.BackgroundPanel.Name = "BackgroundPanel"
        Me.BackgroundPanel.Size = New System.Drawing.Size(500, 500)
        Me.BackgroundPanel.TabIndex = 0
        '
        'TileImageList
        '
        Me.TileImageList.ImageStream = CType(resources.GetObject("TileImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.TileImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.TileImageList.Images.SetKeyName(0, "50x50_White.png")
        Me.TileImageList.Images.SetKeyName(1, "50x50_Open.png")
        Me.TileImageList.Images.SetKeyName(2, "50x50_Wall.png")
        Me.TileImageList.Images.SetKeyName(3, "50x50_Forest.png")
        Me.TileImageList.Images.SetKeyName(4, "50x50_CircleCar.png")
        '
        'TickTimer
        '
        Me.TickTimer.Interval = 1000
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 537)
        Me.Controls.Add(Me.BasePanel)
        Me.Name = "MainForm"
        Me.Text = "MainForm"
        Me.BasePanel.ResumeLayout(False)
        Me.PlayingFieldPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BasePanel As Panel
    Friend WithEvents ControlFieldPanel As Panel
    Friend WithEvents PlayingFieldPanel As Panel
    Friend WithEvents BackgroundPanel As Panel
    Friend WithEvents TileImageList As ImageList
    Friend WithEvents TickTimer As Timer
End Class
