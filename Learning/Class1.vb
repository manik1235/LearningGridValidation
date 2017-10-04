Public Class Class1


    ''' <summary>
    '''   This structure allows all player items to be held in a single variable
    ''' </summary>
    Structure PlayerInfoStructure
        Dim P1 As PlayerControls
        Dim P2 As PlayerControls

        ''' <summary>
        '''   This structure aggregates all the characteristics that are shared between players but have unique values
        ''' </summary>
        Structure PlayerControls
            Dim keyMoveLeft As PlayerKeys
            Dim keyMoveRight As PlayerKeys
            Dim keyAccel As PlayerKeys
            Dim keyBrake As PlayerKeys
            Dim PrimaryCarPictureBox As PictureBox
            Dim RelativeCarPictureBox As PictureBox
            Dim TrackPictureBox As PictureBox

            Dim AFriction As Double ' Acceleration due to friction

            Dim Da As Double ' The amount the acceleration changes per tick when the accelerator is pressed

            Dim MinA As Double
            Dim MaxA As Double ' Max Acceleration allowed, same units as above
            Dim MinV As Double
            Dim MaxV As Double ' Max Velocity allowed, same units as above
            Dim ReverseV As Integer ' The Velocity to travel at when going backward. No accelarating on reversing right now, kinda like how Mario Kart feels
            Dim primaryCarImage As Image
            Private _v As Double ' Current Velocity (probably in pixels/tick ?)
            Private _vasInt As Integer ' Current Velocity changed to an Int
            Private _a As Double ' Current Acceleration (probably in pixels/tick^2 ?)
            Private _x As Integer ' Current x (horz) position of the player vehicle
            Dim dx As Integer ' Amount to change the x position for each tick
            Dim rx As Integer ' Current x (horz) position of the player vehicle relative to the track segment
            Dim Y As Integer ' Current y (vert) position of the player vehicle
            Dim ry As Integer ' Current y (vert) position of the player vehicle relative to the track segment
            Dim MinX As Integer ' Left boundary of the map
            Dim MaxX As Integer ' Right boundary of the map

            Public ReadOnly Property VasInt As Integer
                ' Hopefully returns the value cast to an integer.
                ' I do it here so I can have one consistent place to do rounding
                Get
                    ' If V is between 0 and 1, jump it up to 1 so it starts going right away.
                    If _v > 0 And _v < 1 Then
                        _vasInt = 1
                    Else
                        _vasInt = CInt(Int(_v))
                    End If

                    Return _vasInt
                End Get
            End Property


            Public Property V As Double
                ' Set the sanity checks and boundry conditions for Velocity
                Get
                    Return _v
                End Get
                Set(value As Double)
                    ' Make sure the velocity trying to be set is between the Min and Max allowed
                    If value < MinV Then value = MinV
                    If value > MaxV Then value = MaxV
                    _v = value
                End Set
            End Property

            Public Property A As Double
                ' Set the sanity checks and boundry conditions for Acceleration
                Get
                    Return _a
                End Get
                Set(value As Double)
                    ' Make sure the acceleration trying to be set is between the Min and Max allowed
                    If value < MinA Then value = MinA
                    If value > MaxA Then value = MaxA
                    _a = value
                End Set
            End Property

            Public Property X As Integer
                Get
                    Return _x
                End Get
                Set(value As Integer)
                    ' Enforce the boundary conditions
                    If value < MinX Then
                        value = MinX
                    ElseIf value > MaxX Then
                        value = MaxX
                    End If
                    _x = value
                End Set
            End Property


            ''' <summary>
            '''   Holds the info on the keys assigned to each player
            ''' </summary>
            Structure PlayerKeys
                Private _isDown As Boolean
                Private _defaultValue As Integer
                Private _curValue As Integer

                Public Property IsDown As Boolean
                    Get
                        Return _isDown
                    End Get
                    Set(value As Boolean)
                        _isDown = value
                    End Set
                End Property

                Public Property DefaultValue As Integer
                    Get
                        Return _defaultValue
                    End Get
                    Set(value As Integer)
                        _defaultValue = value
                    End Set
                End Property

                Public Property CurValue As Integer
                    Get
                        Return _curValue
                    End Get
                    Set(value As Integer)
                        _curValue = value
                    End Set
                End Property
            End Structure



        End Structure


    End Structure

    Structure TrackInfoStructure
        ' This structure defines the MyTracks variable
        ' This layer allows for the Left and Right (and more if desired) tracks

        Dim LeftTrack As TrackControls ' Holds data for the Left Track (Player 1)
        Dim RightTrack As TrackControls ' Holds data for the Right Track (Player 2)

        Structure TrackControls
            ' This structure supports the Left and Right track items.
            ' This layer allows for the separation into the different track segment picture boxes.
            ' Used to create smooth, continous track movement.

            Dim A As TrackControlsAB ' Holds the info for Track segment A
            Dim B As TrackControlsAB ' HOlds the info for Track segment B

            ' These variables Hold border layer data
            Dim BorderHeight As Integer ' Holds the height of the container panel for these track sections

            Structure TrackControlsAB
                ' Holds the deepest level data for the track segments
                Dim Top As Integer ' Holds the y value (top) for the Track A/B 
                Dim Height As Integer ' Holds the height of the Picturebox track section


            End Structure

        End Structure
    End Structure

    Dim TickCounter As Integer ' Counts the ticks (right now from 0 to 999)

    ' Various Debug Counters
    Dim DbgPreviewKeyDownCounter As Integer
    Dim DbgKeyDownCounter As Integer
    Dim DbgKeyPressCounter As Integer
    Dim DbgKeyUpCounter As Integer

    Dim MyPlayers As PlayerInfoStructure ' Holds the information for the Player and car structures

    Dim MyTracks As TrackInfoStructure ' Holds the information for the Track structures

End Class