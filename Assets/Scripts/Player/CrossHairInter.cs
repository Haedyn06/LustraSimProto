using UnityEngine;
using UnityEngine.UI;

public class CrosshairInteractor : MonoBehaviour {
    public float interactDistance = 5f;
    public LayerMask interactLayer;
    public Image crosshairImage;

    private Camera cam;

    void Start() {
        cam = Camera.main;
        if (crosshairImage == null)
            Debug.LogError("❌ crosshairImage not assigned!");
    }

    void Update() {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer)) {
            string hitName = hit.transform.name;
            int hitLayer = hit.transform.gameObject.layer;
            string objTag = hit.transform.tag;
            string layerName = LayerMask.LayerToName(hitLayer);
            //Debug.Log($"🎯 Aiming at: {hitName} (Layer: {layerName}); (Tag: {objTag})");
            crosshairImage.color = Color.red;

            if (Input.GetKeyDown(KeyCode.E)) {
                var button = hit.transform.GetComponent<UnityEngine.UI.Button>();
                if (button != null) {
                    button.onClick.Invoke();
                }
            }
        } else {
            crosshairImage.color = Color.white;
        }
    }
}


