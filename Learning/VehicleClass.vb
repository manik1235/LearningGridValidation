''' <summary>
'''   Holds Properties, Variables, Subroutines, Functions, Interfaces
'''   Related to the Vehicle component of the Vertical Race Game.
''' </summary>
Public Class VehicleClass
    Public Class Inside
        Public Sub CoolSub()

        End Sub
        Public Function CoolFunction(input As Boolean) As Boolean
            CoolFunction = Not input
        End Function
    End Class


    Public Interface IVehicle
        ' Holds the variables And properties that are associated With a vehicle

        ' V 
        ' A
        ' dA
        ' X
        ' Y
        ' Ry
        ' td ' Tick Divisor (Dividend / Divisor = Quotent)

    End Interface

    Public Class Vehicle
        ' Holds the variables And properties that are associated With a vehicle
        Implements IVehicle


    End Class
End Class
