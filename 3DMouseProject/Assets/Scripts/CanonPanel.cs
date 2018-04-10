using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanonPanel : MonoBehaviour {

    public Text canonText;
    public int numCanons;
    public static CanonPanel instance;

    void Awake() {
        instance = this;
    }

    public void CollectCanon() {
        numCanons++;
        setCoinText();
    }

    public void setCoinText() {
        canonText.text = numCanons.ToString();

    }

    public bool canUseItem() {
        if (numCanons >= 10) {
            return true;
        } else {
            return false;
        }
    }
}
