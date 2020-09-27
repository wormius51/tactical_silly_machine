using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// Holds the information about the players and the state of the match.
/// Information such as: Who's turn is it? How manny players and AI are playing?
///</summary>
public class MatchManager : MonoBehaviour
{
    public Player[] players;

    ///<summary>
    /// The nuber of rounds that passed since the start of the match.
    ///</summary>
    public int roundNumber {get; private set;}

    ///<summary>
    /// The index of the player who has the right to move.
    ///</suammary>
    public int turnPlayerIndex {get; private set;}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>
    /// Passes the turn to the next play that is not eliminated.
    /// Increments the roundNumber after all players has passed (or made) their turn.
    ///</summary>
    /// <returns> True if a living player was found, 
    /// false if otherwise (everyone is dead).
    /// </returns>
    public bool passTurn() {
        int iterrationTimes = 0;
        do {
            if (iterrationTimes >= players.Length)
                return false;
            turnPlayerIndex++;
            if (turnPlayerIndex >= players.Length) {
                turnPlayerIndex = 0;
                roundNumber++;
            }
            iterrationTimes++;
        } while (players[turnPlayerIndex].isEliminated);
        return true;
    }
}