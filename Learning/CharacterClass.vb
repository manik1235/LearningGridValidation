''' <summary>
'''   Holds Properties, Variables, Subroutines, Functions, Interfaces
'''   Related to the Character component of the Vertical Race Game.
''' </summary>
Public Class CharacterClass
    Public Class Inside
        Public Sub CoolSub()

        End Sub
        Public Function CoolFunction(input As Boolean) As Boolean
            CoolFunction = Not input
        End Function
    End Class


    Public Interface ICharacter
        ' Holds the variables and properties that are associated with a character

        ' Character Name
        ' Character Image
    End Interface

    Public Class Character
        ' Holds the variables and properties that are associated with a character
        Implements ICharacter


    End Class

End Class
