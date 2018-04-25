using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour {
    [Tooltip("The target transform to follow.")]
    [SerializeField] Transform target = null;

    Vector3 offset;

    void Start() {
        offset = transform.position - target.transform.position;
    }

    // Updates the camera position based on position of the target, which is the player. 
    void LateUpdate() {
        transform.position = target.transform.position + offset;
    }
}
