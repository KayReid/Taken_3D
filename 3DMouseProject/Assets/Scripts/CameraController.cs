using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    [Tooltip("The target transform to follow.")]
    [SerializeField] Transform target = null;
    [SerializeField] float minSpeed = 5;

    Vector3 offset;

    void Start() {
        offset = transform.position + target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() {
        //transform.position = target.transform.position + offset;


        Vector3 newPos = transform.position;
        Vector3 targetPosition = target.position + offset;

        // Creates a smoother animation - the farther the target from its original place, the faster the camera moves to catch it.
        if ((newPos - targetPosition).magnitude > minSpeed * Time.deltaTime)
        {
            Vector3 targetDir = targetPosition - newPos;
            targetDir.Normalize();
            newPos += targetDir * (Time.deltaTime * minSpeed);
        }

        transform.position = newPos;

    }
}
