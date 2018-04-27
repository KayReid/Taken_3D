using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtImage : MonoBehaviour {

    public static HurtImage instance;
    public Image image;

    // Use this for initialization, make image completely transparent
    private void Awake()
    {
        instance = this;
        var tempColor = image.color;
        tempColor.a = 0f;
        image.color = tempColor;
    }

    // Called when player is injured - makes the whole screen red while injured
    public void DisplayHurt(float seconds)
    {
        StartCoroutine(HurtRoutine(seconds));
    }

    // Coroutine to display the hurt image
    IEnumerator HurtRoutine(float seconds)
    {
        var tempColor = image.color;
        tempColor.a = 0.5f;
        image.color = tempColor;
        yield return new WaitForSeconds(seconds);

        tempColor.a = 0f;
        image.color = tempColor;
    }
}
