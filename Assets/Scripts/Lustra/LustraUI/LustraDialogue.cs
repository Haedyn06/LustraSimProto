using UnityEditor.Rendering;
using UnityEngine;
using UniVRM10;
using System.Collections;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class LustraDialogue : MonoBehaviour
{
    public GameObject lustraDialogue;
    public TMP_Text dialogueText;
    public Vrm10Instance lustra;
    public float typeSpeed = 0.06f;
    public LustraControlPanel toggleUIScript;
    public TogglePlayerInter togglePlayerScript;

    public void displayResponse(string line) {
        toggleUIScript.ToggleDialogueUI(true);
        StopAllCoroutines();
        StartCoroutine(TypeText(line));
    }

    //IEnumerator TypeText(string line) {
    //    dialogueText.text = "";
    //    togglePlayerScript.SetMovement(false);
    //    toggleUIScript.ToggleButtonUI(false);
    //    var sadKey = ExpressionKey.CreateFromPreset(ExpressionPreset.relaxed);
    //    var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);

    //    var talkKeyA = ExpressionKey.CreateFromPreset(ExpressionPreset.aa);
    //    var talkKeyB = ExpressionKey.CreateFromPreset(ExpressionPreset.ih);
    //    var talkKeyC = ExpressionKey.CreateFromPreset(ExpressionPreset.ee);
    //    var talkKeyD = ExpressionKey.CreateFromPreset(ExpressionPreset.ou);

    //    lustra.Runtime.Expression.SetWeight(sadKey, 1f);
    //    lustra.Runtime.Expression.SetWeight(happyKey, 0f);
    //    foreach (char c in line) {
    //        dialogueText.text += c;
    //        yield return new WaitForSeconds(typeSpeed);
    //    }

    //    yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

    //    togglePlayerScript.SetMovement(true);
    //    toggleUIScript.ToggleDialogueUI(false);
    //    toggleUIScript.ToggleButtonUI(true);
    //    lustra.Runtime.Expression.SetWeight(sadKey, 0f);
    //    lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    //}

    IEnumerator TypeText(string line) {
        dialogueText.text = "";
        togglePlayerScript.SetMovement(false);
        toggleUIScript.ToggleButtonUI(false);

        var sadKey = ExpressionKey.CreateFromPreset(ExpressionPreset.relaxed);
        var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);

        var talkKeyA = ExpressionKey.CreateFromPreset(ExpressionPreset.aa);
        var talkKeyB = ExpressionKey.CreateFromPreset(ExpressionPreset.ih);
        var talkKeyC = ExpressionKey.CreateFromPreset(ExpressionPreset.ee);
        var talkKeyD = ExpressionKey.CreateFromPreset(ExpressionPreset.ou);

        lustra.Runtime.Expression.SetWeight(sadKey, 1f);
        lustra.Runtime.Expression.SetWeight(happyKey, 0f);

        foreach (char c in line) {
            dialogueText.text += c;

            // Reset all talking expressions
            lustra.Runtime.Expression.SetWeight(talkKeyA, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyB, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyC, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyD, 0f);

            // Pick a random one
            int random = Random.Range(0, 4);
            switch (random) {
                case 0: lustra.Runtime.Expression.SetWeight(talkKeyA, 1f); break;
                case 1: lustra.Runtime.Expression.SetWeight(talkKeyB, 1f); break;
                case 2: lustra.Runtime.Expression.SetWeight(talkKeyC, 1f); break;
                case 3: lustra.Runtime.Expression.SetWeight(talkKeyD, 1f); break;
            }

            yield return new WaitForSeconds(typeSpeed);
        }

        // Reset mouth
        lustra.Runtime.Expression.SetWeight(talkKeyA, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyB, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyC, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyD, 0f);

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

        togglePlayerScript.SetMovement(true);
        toggleUIScript.ToggleDialogueUI(false);
        toggleUIScript.ToggleButtonUI(true);
        lustra.Runtime.Expression.SetWeight(sadKey, 0f);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    }
}
