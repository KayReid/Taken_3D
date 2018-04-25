using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenGlass : MonoBehaviour {

    // Injure player when they step on glass
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player")
        {
            print("Hit broken glass");
            Player.instance.Injure();
        }
    }
}
