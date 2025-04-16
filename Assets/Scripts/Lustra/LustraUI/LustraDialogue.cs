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
    public LookAtPlaya lookAtPlayaScript;
    public LustraFollow lustraFollowScript;
    public float typeSpeed = 0.06f;
    public LustraControlPanel toggleUIScript;
    public TogglePlayerInter togglePlayerScript;
    public Transform Playa, otherObj;
    public Animator anim;
    public void displayResponse(string line) {
        toggleUIScript.ToggleDialogueUI(true);
        StopAllCoroutines();
        if (line == "Lustra is responding.. <Space to exit>") StartCoroutine(StandardTypeText(line));
        else StartCoroutine(ExpressedTypeText(line));

    }

    IEnumerator StandardTypeText(string line) {
        dialogueText.text = "";
        togglePlayerScript.SetMovement(false);
        toggleUIScript.ToggleButtonUI(false);
        var sadKey = ExpressionKey.CreateFromPreset(ExpressionPreset.sad);
        var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);
        lustra.LookAtTarget = otherObj;
        lustraFollowScript.enabled = false;
        lookAtPlayaScript.enabled = false;
        anim.SetBool("thinking", true);
        lustra.Runtime.Expression.SetWeight(sadKey, 1f);
        lustra.Runtime.Expression.SetWeight(happyKey, 0f);
        foreach (char c in line) {
            dialogueText.text += c;
            yield return new WaitForSeconds(typeSpeed);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        lustra.LookAtTarget = Playa;
        lustraFollowScript.enabled = true;
        lookAtPlayaScript.enabled = true;
        anim.SetBool("thinking", false);
        togglePlayerScript.SetMovement(true);
        toggleUIScript.ToggleDialogueUI(false);
        toggleUIScript.ToggleButtonUI(false);
        lustra.Runtime.Expression.SetWeight(sadKey, 0f);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    }

    IEnumerator ExpressedTypeText(string line) {
        dialogueText.text = "";
        lustra.LookAtTarget = Playa;
        togglePlayerScript.SetMovement(false);
        toggleUIScript.ToggleButtonUI(false);
        lustraFollowScript.enabled = true;
        lookAtPlayaScript.enabled = true;
        anim.SetBool("thinking", false);
        anim.SetBool("talking", true);
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

            lustra.Runtime.Expression.SetWeight(talkKeyA, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyB, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyC, 0f);
            lustra.Runtime.Expression.SetWeight(talkKeyD, 0f);

            int random = Random.Range(0, 4);
            switch (random) {
                case 0: lustra.Runtime.Expression.SetWeight(talkKeyA, 1f); break;
                case 1: lustra.Runtime.Expression.SetWeight(talkKeyB, 1f); break;
                case 2: lustra.Runtime.Expression.SetWeight(talkKeyC, 1f); break;
                case 3: lustra.Runtime.Expression.SetWeight(talkKeyD, 1f); break;
            }

            yield return new WaitForSeconds(typeSpeed);
        }
        lustra.Runtime.Expression.SetWeight(talkKeyA, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyB, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyC, 0f);
        lustra.Runtime.Expression.SetWeight(talkKeyD, 0f);
        anim.SetBool("talking", false);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        togglePlayerScript.SetMovement(true);
        toggleUIScript.ToggleDialogueUI(false);
        toggleUIScript.ToggleButtonUI(true);
        lustra.Runtime.Expression.SetWeight(sadKey, 0f);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    }
}
