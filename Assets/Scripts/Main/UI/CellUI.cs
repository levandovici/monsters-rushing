using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellUI : MonoBehaviour
{
    [SerializeField]
    private Image _itemPanel;
    [SerializeField]
    private Image _itemCountPanel;
    [SerializeField]
    private Text _itemCount;



    public Transform ItemPanel => _itemPanel.transform;



    public void SetUp(int count, Inventory.EInventoryObjectRarity rarity)
    {
        _itemCount.text = count.ToString();
        _itemPanel.color = Inventory.GetColor(rarity);
    }

    public void SetUp(int count, int from, Inventory.EInventoryObjectRarity rarity)
    {
        _itemCount.text = $"{count}/{from}";
        _itemPanel.color = Inventory.GetColor(rarity);

        if(count < from)
        {
            _itemCountPanel.color = Color.red;
        }
        else
        {
            _itemCountPanel.color = Color.green;
        }
    }
}
