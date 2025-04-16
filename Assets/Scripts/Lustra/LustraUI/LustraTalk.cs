using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UniVRM10;


public class LustraTalk : MonoBehaviour
{
    //variable declaration
    public Vrm10Instance lustra;
    public LustraDialogue dialogueScript;
    public LustraFollow lustraFollowScript;
    public ServerInputSend ServerSendScript;
    public LustraControlPanel toggleUIScript;
    public TogglePlayerInter togglePlayaInterScript;
    public GameObject UserInputUI;
    public TMP_InputField inputField;
    private bool activeUserInp = false;

    //Input Submission Mqtt Server Comm 
    void Update() {
        if (activeUserInp && Input.GetKeyDown(KeyCode.Return)) SubmitInput();
        if (activeUserInp && Input.GetKeyDown(KeyCode.Escape)) ToggleUserInput();
    }
    public void ToggleUserInput() {
        activeUserInp = !activeUserInp;
        UserInputUI.SetActive(activeUserInp);

        if (activeUserInp) {
            //Disable Player Movement
            togglePlayaInterScript.SetScreenLock(true);
            inputField.ActivateInputField();
            EventSystem.current.SetSelectedGameObject(inputField.gameObject);
        } else {
            togglePlayaInterScript.SetScreenLock(false);
        }
    }

    public void SubmitInput() {
        string text = inputField.text;
        Debug.Log("User Message: " + text);
        ToggleUserInput();
        ServerSendScript.sendMsgServer(text); //Initiate Ai processing
        inputField.text = "";
        toggleUIScript.ToggleDialogueUI(true);
        toggleUIScript.ToggleUIPanel(false);
        toggleUIScript.ToggleButtonUI(false);
        dialogueScript.displayResponse("Lustra is responding.. <Space to exit>");
        //Lustra  Think Expression
        //StartTypewriter("Hi my dear master! I have not seen you in for so long want to spend time with me? Talk a bit longer.. See what this place can offer?");
    }
}
