using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIPanel : UIPanel, IUITitled
{
    [SerializeField]
    private Text _title;

    [SerializeField]
    private Text _smallChestCount;
    [SerializeField]
    private Text _middleChestCount;
    [SerializeField]
    private Text _bigChestCount;

    [SerializeField]
    private Button _smallChestOpen;
    [SerializeField]
    private Button _middleChestOpen;
    [SerializeField]
    private Button _bigChestOpen;

    [SerializeField]
    private Transform _inventoryPanel;



    public event Action OnSmallChestOpenClicked;
    public event Action OnMiddleChestOpenClicked;
    public event Action OnBigChestOpenClicked;



    public void Awake()
    {
        _smallChestOpen.onClick.AddListener(() => OnSmallChestOpenClicked.Invoke());
        _middleChestOpen.onClick.AddListener(() => OnMiddleChestOpenClicked.Invoke());
        _bigChestOpen.onClick.AddListener(() => OnBigChestOpenClicked.Invoke());
    }

    public void OnDestroy()
    {
        _smallChestOpen.onClick.RemoveAllListeners();
        _middleChestOpen.onClick.RemoveAllListeners();
        _bigChestOpen.onClick.RemoveAllListeners();
    }




    public void SetTitle(string title)
    {
        _title.text = title;
    }

    public void SetChests(int small, int middle, int big)
    {
        _smallChestCount.text = small.ToString();
        _middleChestCount.text = middle.ToString();
        _bigChestCount.text = big.ToString();

        _smallChestOpen.interactable = small > 0;
        _middleChestOpen.interactable = middle > 0;
        _bigChestOpen.interactable = big > 0;
    }

    public void SetInventory(Inventory.InventoryObjects inventoryObjects)
    {
        foreach (Transform t in _inventoryPanel)
        {
            Destroy(t.gameObject);
        }

        inventoryObjects = Inventory.Sort(inventoryObjects);

        for (int i = 0; i < inventoryObjects.inventoryObjects.Length; i++)
        {
            CellUI cell = Instantiate(Resources.Load<CellUI>(Inventory.Cell), _inventoryPanel);
            Inventory.InventoryObject obj = inventoryObjects.inventoryObjects[i];
            cell.SetUp(obj.count, obj.rarity);
            Instantiate(Resources.Load(obj.location), cell.ItemPanel);
        }
    }
}