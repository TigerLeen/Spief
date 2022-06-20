using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public List<Item> NearbyItems = new List<Item>();





    public void PickUpItems()
    {
        //foreach item call pickup
        foreach (Item i in NearbyItems)
        {
            i.PickUpItem();
        }

        //clear list
        NearbyItems.Clear();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //press e check list
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItems();
        }
    }
}
