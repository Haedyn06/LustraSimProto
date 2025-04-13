//using UnityEngine;
//using static UnityEngine.InputSystem.XR.TrackedPoseDriver;

//public class ForceLustraLook : MonoBehaviour {
//    public Transform lustraHead; // Assign Lustra's HEAD bone here
//    public Transform cameraTarget;

//    private VRMLookAtHead lookAtHead;
//    private VRMLookAtBoneApplyer boneApplyer;

//    void Start() {
//        lookAtHead = gameObject.AddComponent<VRMLookAtHead>();
//        boneApplyer = gameObject.AddComponent<VRMLookAtBoneApplyer>();

//        // Setup head tracking
//        lookAtHead.Head = lustraHead;
//        lookAtHead.Target = cameraTarget;
//        lookAtHead.UpdateType = UpdateType.LateUpdate;

//        // Setup bone applyer
//        boneApplyer.LeftEye = transform.Find("J_Bip_L_Eye");
//        boneApplyer.RightEye = transform.Find("J_Bip_R_Eye");

//        // Degree mapping setup (optional)
//        boneApplyer.VerticalUp.CurveXRangeDegree = 90;
//        boneApplyer.VerticalUp.CurveYRangeDegree = 10;
//    }
//}
