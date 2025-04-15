using UnityEngine;

public class FollowLustra : MonoBehaviour {
    public Transform lustra;
    public Vector3 offset;

    void Update() {
        if (lustra != null) {
            transform.position = lustra.position + offset;
            transform.rotation = lustra.rotation;
        }
    }
}
