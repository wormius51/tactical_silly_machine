using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableUnit : MonoBehaviour
{
    public int ownerIndex;
    public int numberOfActionPerTurn;
    public Camera myCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    ///<summary>
    /// Switches the focus to this unit. It can move after this method is called.
    ///</summary>
    public void focus() {
        MatchManager.instance.activeUnit = this;
        if (myCamera != null) {   
            myCamera.gameObject.SetActive(true);
        }
        MatchManager.instance.setOverviewCameraActive(myCamera == null);
    }

    ///<summary>
    /// Switches the focus to the given unit.
    /// If null is passed to this method,
    /// Returns to the overview camera.
    ///</summary>
    public void yieldFocus(ControllableUnit nextUnit) {
        MatchManager.instance.activeUnit = nextUnit;
        if (myCamera != null) {
            myCamera.gameObject.SetActive(false);
        }
        if (nextUnit == null) {
            MatchManager.instance.setOverviewCameraActive(true);
        } else {
            nextUnit.focus();
        }
    }

    public void loseFocus() {
        yieldFocus(null);
    }

    ///<summary>
    /// The character walks in the direction of the vector.
    ///</summary>
    public void move(Vector2 input) {

    }

    ///<summary>
    /// Rotates the player horizontally, and the camera vertically.
    ///</summary>
    public void look(Vector2 input) {
        GameManager gm = GameManager.instance;
        Transform cameraTransform = myCamera.transform;
        // Check if the camera is getting out of the allowed range.
        if ((input.y > 0) ? (cameraTransform.forward.y > gm.verticalLookMaximum) : (cameraTransform.forward.y < gm.verticalLookMinimum))
            return;
        // Rotate the player and the camera.
        transform.rotation *= Quaternion.Euler(0, input.x * gm.lookSensitivity.x, 0);
        cameraTransform.RotateAround(transform.position, transform.right ,-input.y * gm.lookSensitivity.y);
    }
}
