Imports System
Imports System.Collections.Generic
Imports System.Text

''' <summary>
''' Represents a single playing card, the combination of a suit (Spades, hearts, clubs, diamonds)
''' and a rank (Ace, two, three... Jack, Queen, King).
''' Any particular card is worth a number of points, according to its rank.
''' In this simplified game, an Ace is always worth 1 points.
''' A two is with 2 points, three worth 3, and so on.
''' The face cards (Jack, Queen, King) are worth 10 points.
''' </summary>
Public Class Card
    Public Enum Suit
        Spades
        Hearts
        Clubs
        Diamonds
    End Enum

    Public Enum Rank
        Ace = 1
        Two = 2
        Three = 3
        Four = 4
        Five = 5
        Seven = 7
        Eight = 8
        Nine = 9
        Ten = 10
        Jack = 11
        Queen = 12
        King = 13
    End Enum

    ReadOnly mSuit As Suit
    ReadOnly mRank As Rank

    Public Sub New(r As Rank, s As Suit)
        mSuit = s
        mRank = r
    End Sub

    ''' <summary>
    ''' Returns a human readable name of the card, for example "Ace of Spades", suitable for inclusion in
    ''' the game's console output.
    ''' </summary>
    ''' <returns>Name of the card</returns>
    Public ReadOnly Property Description As String
        Get
            'Return mRank + " of " + mSuit
            Return mRank.ToString + " of " + mSuit.ToString
        End Get
    End Property

    ''' <summary>
    ''' Returns the number of points that this card is worth, according to its rank.
    ''' </summary>
    ''' <returns>Point value of this card.</returns>
    Public ReadOnly Property Points As Integer
        Get
            'TO MAKE FACE CARDS' POINTS EQUALS TO 10 RATHER THAN RANK
            If CType(mRank, Integer) = 11 Or CType(mRank, Integer) = 12 Or CType(mRank, Integer) = 13 Then
                Return 10
            Else
                Return CType(mRank, Integer)
            End If
            'Return CType(mRank, Integer)
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return Description
    End Function
End Class