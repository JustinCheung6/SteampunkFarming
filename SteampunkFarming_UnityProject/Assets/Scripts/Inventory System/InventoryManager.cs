using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager s = null;
    public static InventoryManager S
    {
        get 
        { 
            if(s == null)
            {
                GameObject g = Instantiate(new GameObject());
                InventoryManager script = g.AddComponent<InventoryManager>();
                s = script;
            }
            return s;
        }
    }

    //Inventory
    private List<Item> inventoryList = new List<Item>();

    //Toolbar
    [SerializeField] private int currentToolbarSelected = 0;

    [SerializeField] private GameObject inventoryUI = null;
    [SerializeField] private GameObject toolBarUI = null;
    private void Awake()
    {
        if (s == null)
            s = this;
        else if (s != this)
        {
            Debug.Log("Duplicate Inventory Manager Found: " + this.name);
            Destroy(this);
        }

        if (inventoryUI != null)
            inventoryUI.SetActive(false);
        if (toolBarUI != null)
            toolBarUI.SetActive(true);
    }
    private void Update()
    {
        //Debug.Log("Toolbar Value: " + currentToolbarSelected);

        if (Input.GetButtonDown("ToggleInventory"))
        {
            Debug.Log("Inventory Toggled");

            toolBarUI.SetActive(inventoryUI.activeSelf);
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
        if (Input.GetAxisRaw("ScrollToolBar") != 0 && toolBarUI.activeSelf)
        {
            if(Input.GetAxisRaw("ScrollToolBar") > 0)
                currentToolbarSelected = Mathf.Min(currentToolbarSelected + 1, 9);
            else if (Input.GetAxisRaw("ScrollToolBar") < 0)
                currentToolbarSelected = Mathf.Max(currentToolbarSelected - 1, 0);
        }
        //Set Toolbar
        for(int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown((KeyCode)(48 + i)))
            {
                currentToolbarSelected = i;
            }
        }
    }
}
