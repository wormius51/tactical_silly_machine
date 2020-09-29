using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

///<summary>
/// Holds the information about the players and the state of the match.
/// Information such as: Who's turn is it? How manny players and AI are playing?
///</summary>
public class MatchManager : MonoBehaviour
{
    public static MatchManager instance {get; private set;}
    public Player[] players;
    public float maxMoveTime;

    ///<summary>
    /// The nuber of rounds that passed since the start of the match.
    ///</summary>
    public int roundNumber {get; private set;}
    ///<summary>
    /// The index of the player who has the right to move.
    ///</suammary>
    public int turnPlayerIndex {get; private set;}
    ///<summary>
    /// A camera looking at the map from above.
    ///</summary>
    public Camera overviewCamera;
    ///<summary>
    /// The unit that is acting right now.
    ///</summary>
    public ControllableUnit activeUnit;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        // Just for testing.
        players[0].units[0].focus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startMatch() {
        turnPlayerIndex = 0;
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

    public void setOverviewCameraActive(bool isActive) {
        if (overviewCamera != null) {
            overviewCamera.gameObject.SetActive(isActive);
            if (isActive) {
                // Release the mouse and show it.
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void move(InputAction.CallbackContext context) {
        if (activeUnit != null) {
            activeUnit.move(context.ReadValue<Vector2>());
        }
    }

    public void look(InputAction.CallbackContext context) {
        if (activeUnit != null) {
            activeUnit.look(context.ReadValue<Vector2>());
        }
    }
}