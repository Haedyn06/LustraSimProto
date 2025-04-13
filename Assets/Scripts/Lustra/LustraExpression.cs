using UnityEngine;
using UniVRM10;
using System.Collections;

public class LustraExpression : MonoBehaviour
{

    public Vrm10Instance lustra;
    void Start() {
        //StartCoroutine(BlinkAndSmileLoop());
        var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);
        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    }

    //IEnumerator BlinkAndSmileLoop() {
    //    var blinkKey = ExpressionKey.CreateFromPreset(ExpressionPreset.blink);
    //    var happyKey = ExpressionKey.CreateFromPreset(ExpressionPreset.happy);

    //    while (true) {
    //        // Trigger blink
    //        lustra.Runtime.Expression.SetWeight(blinkKey, 1f);
    //        yield return new WaitForSeconds(0.1f);
    //        lustra.Runtime.Expression.SetWeight(blinkKey, 0f);

    //        // Trigger smile
    //        lustra.Runtime.Expression.SetWeight(happyKey, 1f);
    //        yield return new WaitForSeconds(Random.Range(1.5f, 3f));
    //        lustra.Runtime.Expression.SetWeight(happyKey, 0f);

    //        // Wait a bit before next cycle
    //        yield return new WaitForSeconds(Random.Range(1f, 3f));
    //    }
    //}
}
