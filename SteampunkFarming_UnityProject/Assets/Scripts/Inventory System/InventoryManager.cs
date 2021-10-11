using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
                g.name = "Inventory Manager";
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

    [SerializeField] private List<Image> toolbarElements = new List<Image>();
    [SerializeField] private Color selectedColor = Color.white;
    [SerializeField] private Color defaultColor = Color.gray;

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

        for(int i = 0; i < toolbarElements.Count; i++)
        {
            toolbarElements[i].color = defaultColor;
            if (i == currentToolbarSelected)
                toolbarElements[i].color = selectedColor;
        }
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
            {
                if (currentToolbarSelected == 9)
                    ChangeSelectedToolbar(0);
                else
                    ChangeSelectedToolbar(currentToolbarSelected + 1);
            }
            else if (Input.GetAxisRaw("ScrollToolBar") < 0)
            {
                if (currentToolbarSelected == 0)
                    ChangeSelectedToolbar(9);
                else
                    ChangeSelectedToolbar(currentToolbarSelected - 1);
            }
        }
        //Set Toolbar
        for(int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown((KeyCode)(48 + i)))
            {
                ChangeSelectedToolbar(i);
            }
        }
    }

    private void ChangeSelectedToolbar(int i)
    {
        toolbarElements[currentToolbarSelected].color = defaultColor;
        currentToolbarSelected = i;
        toolbarElements[i].color = selectedColor;
    }
}
