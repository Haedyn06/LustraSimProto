using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniVRM10;

public class TogglePlayerInter : MonoBehaviour
{
    public LustraFollow lustraFollowScript;
    public MonoBehaviour movementScript, interactionScript;

    public void setfollowLustra(bool what) {
        lustraFollowScript.enabled = what;
    }

    public void SetMovement(bool what) {
        if (!what) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            movementScript.enabled = false;
            interactionScript.enabled = false;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            movementScript.enabled = true;
            interactionScript.enabled = true;
        }
    }
}