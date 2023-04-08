using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class İtemsManager : MonoBehaviour
{
    public Item Item;
    public bool isEmpty;
    public Image itemsImage;
    public TextMeshProUGUI ıtemsname;

    private void Start()
    {
        isEmpty = true;
        itemsImage.enabled = false;
        ıtemsname.enabled = false;
    }
    public void AddItems(Item _item)
    {
        Item = _item;
        isEmpty = false;
        itemsImage.enabled = true;
        ıtemsname.enabled = true;
        itemsImage.sprite = _item.image;
        ıtemsname.text = _item.name;
    }
    
    
}

