Imports System.Text

''' <summary>
''' Controller responsible for overall game loop.
''' </summary>
Public Class Game
    Private mDeck As Deck
    Private mRandom As Random
    Private mPlayer1 As Player
    Private mPlayer2 As Player

    Public Sub New(deck As Deck, random As Random, player1 As Player, player2 As Player)
        mDeck = deck
        mRandom = random
        mPlayer1 = player1
        mPlayer2 = player2
    End Sub

    Public ReadOnly Property Deck As Deck
        Get
            Return mDeck
        End Get
    End Property

    Public ReadOnly Property Random As Random
        Get
            Return mRandom
        End Get
    End Property

    Public ReadOnly Property Player1 As Player
        Get
            Return mPlayer1
        End Get
    End Property

    Public ReadOnly Property Player2 As Player
        Get
            Return mPlayer2
        End Get
    End Property

    ''' <summary>
    ''' Main control loop. You an imagine this routine to reflect the actions of the dealer, who
    ''' coordinates gameplay.
    ''' 
    ''' This simple game is played by two players.
    ''' The dealer is given a single fresh deck of cards, which he then shuffles.
    ''' Each player is dealt two cards.
    ''' Then each player takes their turn.
    ''' During their turn, a player can choose to "hit", which means they want to be dealt another card,
    ''' or to "stand", which means they will end their turn.
    ''' The player may "hit" as many times as they wish before ending their turn.
    ''' Once both players have taken their turn, the winner is determined.
    ''' The winner is the player with the greatest number of points without exceeding 21.
    ''' </summary>
    ''' <returns>Output from the game</returns>
    Public Function Play() As String
        Dim output As New StringBuilder()

        ' The game begins...
        mDeck.Shuffle(Random) 'SHUFFLE THE CARDS TO GET DIFFERENT CARDS RATHER THAN JUST ACE OF SPADES

        Dim hand1 = New Hand(mPlayer1)
        hand1.AddCard(mDeck.Deal())
        hand1.AddCard(mDeck.Deal())

        Dim hand2 = New Hand(mPlayer2)
        'hand1.AddCard(mDeck.Deal()) '4 CARDS FOR PLAYER 1 ONLY
        'hand1.AddCard(mDeck.Deal()) '4 CARDS FOR PLAYER 1 ONLY
        hand2.AddCard(mDeck.Deal())
        hand2.AddCard(mDeck.Deal())

        output.AppendFormat("{0} starts with {1}{2}", hand1.Player.Name, hand1.Description, Environment.NewLine)
        output.AppendFormat("{0} starts with {1}{2}", hand2.Player.Name, hand2.Description, Environment.NewLine)

        ' Players take their turns
        Dim hands As New List(Of Hand)({hand1, hand2})
        For Each hand As Hand In hands
            Dim name As String = hand.Player.Name
            output.AppendFormat("{0}'s turn...{1}", name, Environment.NewLine)
            While (hand.Player.WantsToHit(hand.TotalPoints))
                Dim dealt As Card = mDeck.Deal()
                output.AppendFormat("{0} hits: {1}{2}", name, dealt.Description, Environment.NewLine)
                hand.AddCard(dealt)
            End While
            If hand.TotalPoints > 21 Then
                output.AppendFormat("{0} bursts.{1}", name, Environment.NewLine)
            Else
                output.AppendFormat("{0} stands.{1}", name, Environment.NewLine)
            End If
        Next

        ' Determine the winner
        If hand1.Beats(hand2) Then
            output.AppendFormat("{0} WINS!{1}", hand1.Player.Name, Environment.NewLine)
        ElseIf hand2.Beats(hand1) Then
            output.AppendFormat("{0} WINS!{1}", hand2.Player.Name, Environment.NewLine)
        Else
            output.AppendFormat("It's a DRAW!{0}", Environment.NewLine)
        End If

        Return output.ToString()
    End Function
End Class