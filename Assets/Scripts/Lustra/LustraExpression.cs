using UnityEngine;
using UniVRM10;
using System.Collections;

public class LustraExpression : MonoBehaviour
{

    public Vrm10Instance lustra;
    void Start() {
        StartCoroutine(BlinkAndSmileLoop());
    }

    IEnumerator BlinkAndSmileLoop() {
        var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);
        var blinkKey = ExpressionKey.CreateFromPreset(ExpressionPreset.blink);
        //var blinkLKey = ExpressionKey.CreateFromPreset(ExpressionPreset.blinkLeft);
        //var blinkRKey = ExpressionKey.CreateFromPreset(ExpressionPreset.blinkRight);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
        while (true) {
            //lustra.Runtime.Expression.SetWeight(blinkRKey, 1f);
            //lustra.Runtime.Expression.SetWeight(blinkLKey, 1f);
            lustra.Runtime.Expression.SetWeight(blinkKey, 1f);
            yield return new WaitForSeconds(0.4f);
            //lustra.Runtime.Expression.SetWeight(blinkRKey, 0f);
            //lustra.Runtime.Expression.SetWeight(blinkLKey, 0f);
            lustra.Runtime.Expression.SetWeight(blinkKey, 0f);
            yield return new WaitForSeconds(Random.Range(4f, 12f));
        }
    }
}
