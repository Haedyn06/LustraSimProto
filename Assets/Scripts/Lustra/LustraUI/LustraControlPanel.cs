using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System.Collections;
using UniVRM10;

public class LustraControlPanel : MonoBehaviour
{
    //variable declaration
    public GameObject ControlPanelUI, DialogueUI, InterButtonUI; 
    private bool activeControlPanel = false, activeDialogueUI = false, activeButtonInter = true;

    //Visibility UI
    public void ToggleUIPanel(bool what) {
        activeControlPanel = what;
        ControlPanelUI.SetActive(activeControlPanel);
    }    
    public void SetUIPanel() {
        activeControlPanel = !activeControlPanel;
        ControlPanelUI.SetActive(activeControlPanel);
    }

    //Visibility Dialogue
    public void ToggleDialogueUI(bool what) {
        activeDialogueUI = what;
        DialogueUI.SetActive(activeDialogueUI);
    }

    //Visibility Interact Button
    public void ToggleButtonUI(bool what) {
        activeButtonInter = what;
        InterButtonUI.SetActive(activeButtonInter);
    }
}
