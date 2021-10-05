using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChestUIPanel : UIPanel
{
    [SerializeField]
    private Animator _smallChest;
    [SerializeField]
    private Animator _middleChest;
    [SerializeField]
    private Animator _bigChest;

    [SerializeField]
    private Text _counter;

    [SerializeField]
    private Transform _effect;

    [SerializeField]
    private Button _click;

    [SerializeField]
    private RectTransform _start;

    [SerializeField]
    private RectTransform _end;

    private Inventory.Chest _chest;
    private int _count;
    private int _id;
    private float _lastClick = 0f;



    public event Action OnNextClicked;




    private void Awake()
    {
        _click.onClick.AddListener(() =>
        {
            if (_lastClick + 0.55f < Time.time)
            {
                StartCoroutine(NextAnim(false));
                _lastClick = Time.time;
            }
            });
    }


    public void SetUp(Inventory.Chest chest)
    {
        _chest = chest;
        _id = 0;
        _count = chest.Count();
        _counter.text = _count.ToString();
        _effect.gameObject.SetActive(false);

        if(_chest.chestType == Inventory.EInventoryChestType.small)
        {
            _smallChest.gameObject.SetActive(true);
            _middleChest.gameObject.SetActive(false);
            _bigChest.gameObject.SetActive(false);
        }
        else if (_chest.chestType == Inventory.EInventoryChestType.middle)
        {
            _smallChest.gameObject.SetActive(false);
            _middleChest.gameObject.SetActive(true);
            _bigChest.gameObject.SetActive(false);
        }
        else if (_chest.chestType == Inventory.EInventoryChestType.big)
        {
            _smallChest.gameObject.SetActive(false);
            _middleChest.gameObject.SetActive(false);
            _bigChest.gameObject.SetActive(true);
        }

        StartCoroutine(NextAnim(true));
        _lastClick = Time.time;
    }

    private IEnumerator NextAnim(bool isFirst)
    {
        _counter.text = (--_count).ToString();
        if (_count >= 0)
        {
            OnNextClicked.Invoke();
            foreach (Transform t in _start)
                Destroy(t.gameObject);

            if (isFirst)
            {
                _smallChest.SetBool("stay", false);
                _middleChest.SetBool("stay", false);
                _bigChest.SetBool("stay", false);
            }

            yield return new WaitForSeconds(0.3f);

            CellUI cell = Instantiate<CellUI>(Resources.Load<CellUI>(Inventory.Cell), _start);
            RectTransform rect = (RectTransform)cell.transform;
            rect.localPosition = new Vector3(rect.localPosition.x, rect.localPosition.y, 0f);

            if (_chest.gems > 0)
            {
                Instantiate(Resources.Load(Inventory.Gems), cell.ItemPanel);
                cell.SetUp(_chest.gems, Inventory.EInventoryObjectRarity.none);
                _chest.gems = 0;
            }
            else if (_chest.energy > 0)
            {
                Instantiate(Resources.Load(Inventory.Energy), cell.ItemPanel);
                cell.SetUp(_chest.energy, Inventory.EInventoryObjectRarity.none);
                _chest.energy = 0;
            }
            else if (_chest.keys > 0)
            {
                Instantiate(Resources.Load(Inventory.Key), cell.ItemPanel);
                cell.SetUp(_chest.keys, Inventory.EInventoryObjectRarity.none);
                _chest.keys = 0;
            }
            else
            {
                Inventory.InventoryObject obj = _chest.InventoryObjects.inventoryObjects[_id++];
                Instantiate(Resources.Load(obj.location), cell.ItemPanel);
                cell.SetUp(obj.count, obj.rarity);
            }

            StartCoroutine(CellAnim(cell.transform));
        }

        if (_count < 0)
        {
            foreach (Transform t in _start)
                Destroy(t.gameObject);
            Hide();
        }

        _effect.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        _effect.gameObject.SetActive(false);
        _smallChest.SetBool("stay", true);
        _middleChest.SetBool("stay", true);
        _bigChest.SetBool("stay", true);
    }

    private IEnumerator CellAnim(Transform cell)
    {
        RectTransform rect = (RectTransform)cell.transform;

        while(cell != null && rect.position != _end.position)
        {
            rect.position = Vector3.MoveTowards(rect.position, _end.position, 7f * Time.deltaTime);
            yield return null;
        }
    }
}
