using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Camera mainCam;

    public Transform targetTransform;

    void Start()
    {
        mainCam = Camera.main;
    }

    void LateUpdate()
    {
        if (mainCam == null) return;

        targetTransform.LookAt(targetTransform.position + mainCam.transform.rotation * Vector3.forward,
            mainCam.transform.rotation * Vector3.up);
    }
}