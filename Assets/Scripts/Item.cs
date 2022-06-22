using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour
{
    public float weight;
    public float pickUpTime;
    public Inventory inventory;

    public void Start()
    {
        inventory = Inventory.instance;
    }

    public void PickUpItem()
    {
        //pick up the object
        inventory.AddItem(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision");
        //Add to List on the player
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            p.NearbyItems.Add(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Remove from List
        Player p = other.GetComponent<Player>();
        if (p != null)
        {
            p.NearbyItems.Remove(this);
        }
    }
}
