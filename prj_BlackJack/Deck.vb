''' <summary>
''' Represents a collection of playing cards that will be dealt in the game.
''' 
''' A fresh deck usually begins with the cards in an ordered sequence according to their suit and rank.
''' Before dealing cards to the players, the dealer should shuffle the deck, <see cref="System.Random" />
''' otherwise cards will be dealt in their original sequence.
''' 
''' During the game, the dealer deals one card at a time, removing it from the top
''' of the deck, and adding it to the player's hand.
''' </summary>
''' <remarks></remarks>
Public Class Deck
    ''' <summary>
    ''' The cards remaining to be dealt
    ''' </summary>
    Private mCards As New List(Of Card)
    ''' <summary>
    ''' Constructs a fresh deck with the specified cards in the given sequence
    ''' </summary>
    ''' <param name="cards">@param cards cards</param>
    Public Sub New(cards As List(Of Card))
        mCards = cards
    End Sub

    ''' <summary>
    ''' Randomizes the sequence of the cards within the deck.
    ''' </summary>
    Public Sub Shuffle(random As Random)

        ' Keep a reference to the existing cards, then build a new list and copy
        ' the cards over in a random sequence.
        Dim originalCards As List(Of Card) = mCards
        Dim shuffledCards As New List(Of Card)

        Dim numberOfCards As Integer = originalCards.Count - 1
        For i As Integer = 0 To numberOfCards
            Dim nextCardIndex As Integer = random.Next(originalCards.Count)
            Dim nextCard As Card = originalCards(nextCardIndex)
            shuffledCards.Add(nextCard)
        Next

        mCards = shuffledCards
    End Sub

    ''' <summary>
    ''' Draws a card from the top of the deck, so that it can be added to a player's hand.
    ''' </summary>
    ''' <returns>Dealt card</returns>
    Public Function Deal() As Card
        'Return mCards(0) 'REMOVED CARDS THAT WERE DEALT
        Dim removedCard As Card = mCards(0)
        mCards.RemoveAt(0)
        Return removedCard
    End Function

    ''' <summary>
    ''' Returns the list of cards in the deck, in the sequence that they are going to be dealt.
    ''' </summary>
    ''' <returns>Cards cards in the deck</returns>
    Public ReadOnly Property Cards As List(Of Card)
        Get
            Return mCards
        End Get
    End Property
End Class