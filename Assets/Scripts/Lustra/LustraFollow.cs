using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LustraFollow : MonoBehaviour
{
    public Transform target;     // Drag your player/camera here
    public float speed = 2f;     // Walk speed
    public float followDistance = 5f;  // How close she should get
    public Animator anim;
    void Update() {
        if (target == null) return;

        Vector3 direction = target.position - transform.position;
        direction.y = 0; // keep her on the ground

        if (direction.magnitude > followDistance) {
            Vector3 moveDir = direction.normalized;
            transform.position += moveDir * speed * Time.deltaTime;

            // Make her face you
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(moveDir),
                Time.deltaTime * 5f
            );
            anim.SetFloat("Speed", 1f);
        } else anim.SetFloat("Speed", 0f);
    }
}


//    public Transform target;         // Your player or camera
//    public float speed = 3f;
//    public float followDistance = 2f;
//    public Animator animator;        // Drag Lustra's Animator here

//    void Update() {
//    if (target == null || animator == null) return;

//    Vector3 direction = target.position - transform.position;
//    direction.y = 0;

//    float distance = direction.magnitude;

//    // Movement
//    if (distance > followDistance) {
//        Vector3 moveDir = direction.normalized;
//        transform.position += moveDir * speed * Time.deltaTime;

//        // Rotate toward player
//        transform.rotation = Quaternion.Slerp(
//            transform.rotation,
//            Quaternion.LookRotation(moveDir),
//            Time.deltaTime * 5f
//        );

//        // Walk anim on
//        animator.SetFloat("Speed", 1f);
//    } else animator.SetFloat("Speed", 0f);
//}

