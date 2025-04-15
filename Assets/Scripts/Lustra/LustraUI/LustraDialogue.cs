using UnityEditor.Rendering;
using UnityEngine;
using UniVRM10;
using System.Collections;
using TMPro;
public class LustraDialogue : MonoBehaviour
{
    public GameObject lustraDialogue;
    public TMP_Text dialogueText;
    public Vrm10Instance lustra;
    public float typeSpeed = 0.03f;
    public LustraControlPanel toggleUIScript;


    public void displayResponse(string line) {
        toggleUIScript.ToggleDialogueUI(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(line));
    }

    IEnumerator TypeText(string line) {
        dialogueText.text = "";
        toggleUIScript.ToggleButtonUI(false);
        var sadKey = ExpressionKey.CreateFromPreset(ExpressionPreset.relaxed);
        var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);
        lustra.Runtime.Expression.SetWeight(sadKey, 1f);
        lustra.Runtime.Expression.SetWeight(happyKey, 0f);
        foreach (char c in line) {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }
        yield return new WaitForSeconds(10);
        toggleUIScript.ToggleDialogueUI(false);
        toggleUIScript.ToggleButtonUI(true);
        lustra.Runtime.Expression.SetWeight(sadKey, 0f);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    }
}
