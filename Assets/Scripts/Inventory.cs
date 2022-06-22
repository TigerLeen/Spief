using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public float maxWeight = 100;
    public float currentWeight;
    public List<Item> itemList = new List<Item>();


    public void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentWeight = 0;    
    }

    public void AddItem(Item itemToAdd)
    {
        if(currentWeight + itemToAdd.weight <= maxWeight)
        {
            //addItem
            currentWeight += itemToAdd.weight;
            itemList.Add(itemToAdd);
            itemToAdd.gameObject.SetActive(false);
        }
        else
        {
            //overweight, didn't add item to inventory
            Debug.Log("Overweight, item not added");
        }
    }


}
