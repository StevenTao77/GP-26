using UnityEngine;
using System.Collections.Generic;  

public class PlayerInventory : MonoBehaviour
{
    [Header("Inventory Data")]
     
    public string[] hotbar = new string[3];

     
    public List<string> backpack = new List<string>();

    
    public void AddItem(string itemName)
    {
         
        for (int i = 0; i < hotbar.Length; i++)
        {
             
            if (string.IsNullOrEmpty(hotbar[i]))
            {
                hotbar[i] = itemName;
                Debug.Log($"Added [{itemName}] to Hotbar slot {i}");
                PrintInventoryStatus();
                return;  
            }
        }

         
        backpack.Add(itemName);
        Debug.Log($"Hotbar is full! Added [{itemName}] to Backpack. Total items in backpack: {backpack.Count}");

        PrintInventoryStatus();
    }

     
    private void PrintInventoryStatus()
    {
        string hotbarContents = $"Hotbar: [{hotbar[0] ?? "Empty"}, {hotbar[1] ?? "Empty"}, {hotbar[2] ?? "Empty"}]";
        Debug.Log(hotbarContents);
    }
}