using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    [Tooltip("The target transform to follow.")]
    [SerializeField] Transform target = null;

    // All code related to screen shaking has been borrowed and slightly modified
    // <copyright file="CameraController2D.cs" company="DIS Copenhagen">
    // Copyright (c) 2017 All Rights Reserved
    // </copyright>
    // <author>Benno Lueders</author>
    // <date>07/14/2017</date>
    [Header("ScrenShake")]
    [Tooltip("How long is a strong standart screen shake.")]
    [SerializeField] float shakeTimeStandardStrong = 0.5f;
    [Tooltip("How much does the camera shake during a strong standard screen shake.")]
    [SerializeField] float strengthStandardStrong = 0.5f;
    [Tooltip("How long is a light standard screen shake.")]
    [SerializeField] float shakeTimeStandardLight = 0.2f;
    [Tooltip("How much does the camera shake during a light standard screen shake.")]
    [SerializeField] float strengthStandardLight = 0.2f;

    float screenShakeStrength = 0;
    float screenShakeTimer = 0;

    public static CameraController instance;
    Vector3 offset;


    private void Awake()
    {
		if (target.gameObject.activeInHierarchy) {
			offset = transform.position - target.transform.position;
		}
        instance = this;
    }

    // Updates the camera position based on position of the target, which is the player. 
    void Update() {
        // borrowed 
        if (screenShakeTimer > 0)
        {
            Vector3 newOffset = Random.insideUnitCircle * screenShakeStrength; // must assign on different line to force Vector2 -> Vector3
            newOffset += offset;
            screenShakeTimer -= Time.deltaTime;
            transform.position = target.transform.position + newOffset;
            return;
        }
        // /borrowed
        transform.position = target.transform.position + offset;
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // All code from this point on is borrowed and slightly modified
    /// <summary>
	/// Perform a light screen shake.
	/// </summary>
	public void ScreenShakeLight()
    {
        instance.screenShakeStrength = instance.strengthStandardLight;
        instance.screenShakeTimer = instance.shakeTimeStandardLight;
    }

    /// <summary>
    /// Perform a strong screen shake.
    /// </summary>
    public void ScreenShakeStrong()
    {
        instance.screenShakeStrength = instance.strengthStandardStrong;
        instance.screenShakeTimer = instance.shakeTimeStandardStrong;
    }

    /// <summary>
    /// Perform a custom screen shake.
    /// </summary>
    /// <param name="strength">Strength of shake.</param>
    /// <param name="shakeTime">Shake time.</param>
    public void ScreenShake(float strength, float shakeTime)
    {
        instance.screenShakeStrength = strength;
        instance.screenShakeTimer = shakeTime;
    }
}
