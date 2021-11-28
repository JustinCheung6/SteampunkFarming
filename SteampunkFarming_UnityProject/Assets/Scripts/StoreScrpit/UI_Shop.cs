using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Shop : MonoBehaviour 
{

    private Transform container;
    private Transform shopItemTemplate;


    private void Awake() 
    {
        container = transform.Find("container");
        shopItemTemplate = container.Find("shopItemTemplate");
        shopItemTemplate.gameObject.SetActive(false);
    }

    private void Start() 
    {
        CreateItemButton(Item.ItemType.appleSeed, Item.GetSprite(Item.ItemType.appleSeed), "appleSeed", Item.GetCost(Item.ItemType.appleSeed), 0);
        CreateItemButton(Item.ItemType.blueberrySeed, Item.GetSprite(Item.ItemType.blueberrySeed), "blueberrySeed", Item.GetCost(Item.ItemType.blueberrySeed), 1);
        CreateItemButton(Item.ItemType.potato, Item.GetSprite(Item.ItemType.potato), "potato", Item.GetCost(Item.ItemType.potato), 2);
        Hide();
    }

    private void CreateItemButton(Item.ItemType itemType, Sprite itemSprite, string itemName, int itemCost, int positionIndex) 
    {
        Transform shopItemTransform = Instantiate(shopItemTemplate, container);
        shopItemTransform.gameObject.SetActive(true);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 90f;
        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);

        shopItemTransform.Find("nameText").GetComponent<TextMeshProUGUI>().SetText(itemName);
        shopItemTransform.Find("costText").GetComponent<TextMeshProUGUI>().SetText(itemCost.ToString());

        shopItemTransform.Find("itemImage").GetComponent<Image>().sprite = itemSprite;
    }
}