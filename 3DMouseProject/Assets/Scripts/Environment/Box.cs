using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour {

    [Tooltip("An optional item that will appear when the box is destroyed.")]
    [SerializeField] GameObject item = null;

    public AudioClip breakSound;

    // The number of times a box can be hit before it is destroyed by the player
    public int hits = 1;
    // The amount of time the box should be shaking
    public float shakeTimeStandard = 0.2f;
    // The strength of the box shake
    public float shakeStrengthStandard = 0.15f;

    private float shakeTimeRemaining;

    private void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            Vector3 shake = new Vector3(Random.Range(-.2f, .2f), 0, Random.Range(-.2f, .2f)) * shakeStrengthStandard;
            shakeTimeRemaining -= Time.deltaTime;
            transform.position += shake;
            return;
        }   
    }

    // Called when a bullet from the player hits the box. Will "hurt" the box by 1 each time
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Poop")
        {
            hits--;
            AudioSource.PlayClipAtPoint(breakSound, transform.position);
            shakeTimeRemaining = shakeTimeStandard;

            Quaternion keyRotation = Quaternion.Euler(new Vector3(-80.5f, -159.2f, 183.5f));
            Vector3 keyPosition = new Vector3(transform.position.x, .5f, transform.position.z);

            if (hits == 0)
            {
                // If an item is "inside" the box, spawn it
                if (item != null)
                {
                    Instantiate(item, keyPosition, keyRotation);
                }
                Destroy(gameObject);
            }
        }
    }
}
