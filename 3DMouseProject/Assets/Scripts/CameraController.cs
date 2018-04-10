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
        transform.position = target.transform.position + offset;
    }
}
