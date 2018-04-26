using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICollectible : MonoBehaviour {

    [SerializeField] Image key;
    [SerializeField] Image pipe;
    [SerializeField] Image wheel1;
    [SerializeField] Image wheel2;
    [SerializeField] Image stand;
    [SerializeField] Image bomb;

    public static UICollectible instance;

    void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// If the player runs into a collectible that is not currently in the inventory, it will change the UI's representation of the
    /// player's inventory.
    /// </summary>
    /// <param name="collectible"></param>
    public void UpdateInventory(GameObject collectible)
    {
        string tag = collectible.tag;
        Image item;

        // Based on the tag of the collectible, we can then toggle that item's image in the UI if it is part of the inventory
        switch(tag)
        {
            case "Key":
                item = key;
                break;
            case "Pipe":
                item = pipe;
                break;
            case "Wheel1":
                item = wheel1;
                break;
            case "Wheel2":
                item = wheel2;
                break;
            case "Stand":
                item = stand;
                break;
            case "Bomb":
                item = bomb;
                break;
            default:
                return;
        }

        // Turn sprite's image black
        item.GetComponent<Image>().color = Color.black;
    }
}
