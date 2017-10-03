''' <summary>
'''   Holds Properties, Variables, Subroutines, Functions, Interfaces
'''   Related to the Player component of the Vertical Race Game
''' </summary>
Public Class PlayerClass
    ' Make an interface for each class, because you can update it and add stuff. it won't delete, it'll add (overload?)
    ' All descriptions of definitions go in the Interface, they get implemented in their classes

    ''' <summary>
    '''   Holds the information for a player
    ''' </summary>
    Public Interface IPlayer
        ' Holds the variables and properties that are associated with a player

        ' Profile Name? Maybe. Could be good to simplify fun options for arthur
        ' Name? No. That should go in Character
        ' 


    End Interface

    Public Class Player
        ' Holds the variables and properties that are associated with a player
        Implements IPlayer

    End Class

End Class
