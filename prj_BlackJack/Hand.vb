Imports System.Text

''' <summary>
''' Represents the collection of cards that have been dealt to a player.
''' </summary>
Public Class Hand

    ''' <summary>
    ''' The cards currently held in this hand
    ''' </summary>
    Private mCards As List(Of Card)

    ''' <summary>
    ''' The player to whom this hand belongs
    ''' </summary>
    Private mPlayer As Player

    ''' <summary>
    ''' Constructs a new hand for the specified player.
    ''' </summary>
    ''' <param name="player">The player to whom this hand belongs</param>
    Public Sub New(player As Player)
        mPlayer = player
        mCards = New List(Of Card)()
    End Sub

    ''' <summary>
    ''' Returns the player that this hand belongs to.
    ''' </summary>
    ''' <returns>player</returns>
    Public ReadOnly Property Player As Player
        Get
            Return mPlayer
        End Get
    End Property

    ''' <summary>
    ''' Adds a card to the hand
    ''' </summary>
    ''' <param name="card">the card to be added</param>
    Public Sub AddCard(card As Card)
        mCards.Add(card)
    End Sub

    ''' <summary>
    ''' Returns the total points for this hand by adding up the points of each card.
    ''' </summary>
    ''' <returns>total points</returns>
    Public ReadOnly Property TotalPoints As Integer
        Get
            Dim points As Integer = 0
            For i As Integer = 0 To (mCards.Count - 1)
                points += mCards(i).Points
            Next
            Return points
        End Get
    End Property

    ''' <summary>
    ''' Determines whether this hand is better than the other player's hand.
    ''' In general, the winning hand is the hand with the greatest number of points.
    ''' But, if the hand exceeds 21 then it is a "bust" - the other player wins.
    ''' If both players bust, or if their total points are the same, then it is a draw.
    ''' </summary>
    ''' <param name="other">the hand to compare against</param>
    ''' <returns>True, if this is a better hand than the specified other hand</returns>
    Public Function Beats(other As Hand) As Boolean
        Dim myScore As Integer = TotalPoints
        If myScore > 21 Then
            Return False
        End If

        Dim otherScore As Integer = other.TotalPoints
        If otherScore > myScore Then
            Return False
        End If

        If myScore = otherScore Then 'ADDED IF THE SAME SCORES FOR DRAW
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Returns a formatted description of the cards in the hand, suitable for screen output
    ''' </summary>
    ''' <returns>Description of the hand</returns>
    Public ReadOnly Property Description As String
        Get
            Dim desc As New StringBuilder()
            desc.Append(mCards.Count)
            desc.Append(" cards: ")
            Dim first As Boolean = True
            For Each card As Card In mCards
                If Not first Then
                    desc.Append(", ")
                End If
                desc.Append(card.Description)
                first = False
            Next
            desc.Append(".")
            Return desc.ToString()
        End Get
    End Property
End Class