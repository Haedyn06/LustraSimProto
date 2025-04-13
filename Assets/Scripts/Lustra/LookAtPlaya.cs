using System.Data;
using UnityEngine;
using UniVRM10;
using static UnityEngine.GraphicsBuffer;
public class LookAtPlaya : MonoBehaviour {
    public Animator animator;
    public float rotationSpeed = 30f;
    public Transform playa;

    public float minX = -30f, maxX = 30f;
    public float minY = -65f, maxY = 65f;
    public float minZ = -10f, maxZ = 10f;

    void LateUpdate() {

        //Vector3 euler = head.rotation.eulerAngles;

        var head = animator.GetBoneTransform(HumanBodyBones.Head);
        if (head != null) {
            head.LookAt(playa.position);

            // Convert rotation to Euler angles
            Vector3 euler = head.localEulerAngles;
            //Debug.Log("Lustra's Head is at: " + euler);
            euler.x = NormalizeAngle(euler.x);
            euler.y = NormalizeAngle(euler.y);
            euler.z = NormalizeAngle(euler.z);

            // Clamp
            euler.x = Mathf.Clamp(euler.x, minX, maxX);
            euler.y = Mathf.Clamp(euler.y, minY, maxY);
            euler.z = Mathf.Clamp(euler.z, minZ, maxZ);

            // Apply clamped rotation
            head.localEulerAngles = euler;
        }
    }

    float NormalizeAngle(float angle) {
        if (angle > 180f) angle -= 360f;
        return angle;
    }
}

//-0.12571, -0.54576, -0.08323, 0.82427 and - 0.10434, 0.50378, 0.06146, 0.85531

//342.12, 50.94, 0.00 and 351.51, 299.02, 0.00