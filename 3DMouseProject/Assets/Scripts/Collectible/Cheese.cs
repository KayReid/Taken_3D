﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheese : MonoBehaviour{

    /// <summary>
    /// If object is touched by player, will be destroyed on impact. Can give health if relevant.
    /// </summary>
    /// <param name="collision"></param>
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(this.gameObject); // Destroy this cheese object
            Player.instance.Heal(); 
        }
    }

}
