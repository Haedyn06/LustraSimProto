using UnityEngine;

public class LustraProximityRange : MonoBehaviour
{
    public LustraControlPanel toggleUIScript;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Playa"))toggleUIScript.ToggleButtonUI(true);
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Playa")) toggleUIScript.ToggleButtonUI(false);
    }
}
