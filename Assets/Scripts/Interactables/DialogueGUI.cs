using UnityEngine;

public class DialogueGUI : MonoBehaviour {
    public GameObject dialogueUI; // your DialogueFrame
    private bool isVisible = false;

    public void popupGUI() {
        isVisible = !isVisible;
        dialogueUI.SetActive(isVisible);
    }
}
