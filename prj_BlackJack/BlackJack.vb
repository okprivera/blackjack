''' <summary>
''' Emulates a black jack game between two different AI players.
''' </summary>
Public Class Blackjack

    Public Shared ReadOnly AllCards As New List(Of Card)
    ''' <summary>
    ''' Static constructor.
    ''' Generates a list containing one of every possible card.
    ''' This simplified game assumes a single deck of 52 cards, one of every unique suit and rank combination.
    ''' </summary>
    Shared Sub New()
        For Each s As Card.Suit In [Enum].GetValues(GetType(Card.Suit))
            For Each r As Card.Rank In [Enum].GetValues(GetType(Card.Rank))
                AllCards.Add(New Card(r, s))
            Next
        Next
    End Sub

    ''' <summary>
    ''' Main method. Constructs the object, plays the game, prints the output.
    ''' Don't change this method!
    ''' </summary>
    ''' <param name="args">Command line args, unused.</param>
    Public Shared Sub Main(args As String())
        Dim deck As New Deck(AllCards)
        Dim random As New Random()
        Dim calculator As New ProbabilityCalculator(AllCards)
        Dim player1 As New Player("Harry", calculator)
        Dim player2 As New Player("Joe", calculator)
        Dim game As New Game(deck, random, player1, player2)
        Console.WriteLine(game.Play())
        Console.ReadLine()
    End Sub
End Class