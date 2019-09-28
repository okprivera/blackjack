''' <summary>
''' Represents a player, and their decision making logic for whether to
''' "hit" or "stand"
''' </summary>
Public Class Player

    ''' <summary>
    ''' A friendly name that identifies the player.
    ''' </summary>
    Private mName As String

    ''' <summary>
    ''' Used for calculating probability of bust
    ''' </summary>
    Private mProbabilityCalculator As ProbabilityCalculator

    ''' <summary>
    ''' Constructor.
    ''' </summary>
    ''' <param name="name">player's name</param>
    ''' <param name="probabilityCalculator">for calculating probability of bust</param>
    ''' <remarks></remarks>
    Public Sub New(name As String, probabilityCalculator As ProbabilityCalculator)
        mName = name
        mProbabilityCalculator = probabilityCalculator
    End Sub

    ''' <summary>
    ''' Returns the player's name
    ''' </summary>
    ''' <returns>name</returns>
    Public ReadOnly Property Name As String
        Get
            Return mName
        End Get
    End Property

    ''' <summary>
    ''' Determines whether the player would like to "hit" (have another card dealt to their hand),
    ''' or "stand" (end their turn).
    ''' In this simple implementation, the player's strategy is to hit, so long as they are more likely
    ''' to increase their points than they are to bust.
    ''' If their current points are at 21, they should always stay
    ''' If their current points are at 10 or below, they can never bust, so they should always hit
    ''' For points in between, they will hit so long as the probability of the next draw causing a bust is less
    ''' than 50%.
    ''' </summary>
    ''' <param name="currentPoints">The total of the cards currently held by this player</param>
    ''' <remarks>True if the players wants to "hit", false if they want to "stand".</remarks>
    Public Function WantsToHit(currentPoints As Integer)
        If currentPoints >= 21 Then
            Return False
        ElseIf currentPoints <= 10 Then
            Return True
        Else
            Return mProbabilityCalculator.CalculateProbability(currentPoints) < 0.5
        End If
    End Function

End Class