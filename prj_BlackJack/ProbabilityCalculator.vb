''' <summary>
''' Used by the player's hit/stand decision making, to determine the probability of busting if
''' they deal another card.
''' </summary>
Public Class ProbabilityCalculator

    ''' <summary>
    ''' All possible cards
    ''' </summary>
    Private mFullDeck As List(Of Card)

    Public Sub New(fullDeck As List(Of Card))
        mFullDeck = fullDeck
    End Sub

    ''' <summary>
    ''' Determines the probability of a "bust" if the players deals one more card into their hand.
    ''' A "bust" occurs if the next card takes their total over 21.
    ''' 
    ''' The probability is simulated as follows:
    ''' Consider all possible cards that might be dealt next if the player chooses to "hit".
    ''' (Since "card counting" is a no-no in Blackjack, we imagine that *any* of the cards from a
    ''' normal full deck could be dealt next. ie. don't exclude cards that have already been dealt).
    ''' For each possibility, determine the total points that would be achieved if that card
    ''' were added to the player's hand, and decide whether or not it is a bust.
    ''' The probability of a bust is the percentage of all the combinations tried that resulted in a bust.
    ''' 
    ''' For example, if the player's current total is 12, then dealing any card worth 10 points
    ''' will result in a bust. Out of the 52 cards in a deck, 16 of them are worth 10 points (the Tens, Jacks,
    ''' Queens and Kings of Spades, Hearts, Clubs and Diamonds). So, the probability of a bust
    ''' is 0.3077 (30.77%), which is 16 divided by 52.
    ''' Similarly, if the player's current total is 19, there are 44 possible cards that will result in
    ''' a bust (everything except the aces and twos), and so the probability is 0.8462.
    ''' </summary>
    ''' <param name="currentPoints">the total points for the player's current hand</param>
    ''' <returns>probability of a bust if one more card is dealt (0.5f = 50%)</returns>
    Public Function CalculateProbability(currentPoints As Integer) As Decimal
        ' Problem: we can't calculate the probability if we don't have any cards to simulate with.
        ' This shouldn't happen, but to prevent potential crashes, we'll return 50% 
        If mFullDeck.Count = 0 Then
            Return 0.5
        End If

        Dim numberOfBusts As Integer = 0
        Dim numberOfNonBusts As Integer = 0

        For Each card As Card In mFullDeck
            Dim potentialPoints = currentPoints + card.Points
            If (potentialPoints > 21) Then
                numberOfBusts += 1
            Else
                numberOfNonBusts += 1
            End If
        Next

        Return numberOfBusts / CType(numberOfNonBusts, Decimal)

    End Function
End Class