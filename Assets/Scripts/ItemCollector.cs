using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollector : MonoBehaviour
{
    private Vector3 _targetPosition;
    private CollectableItemScript _item;
    [SerializeField] private float _itemSpeed;
    [SerializeField] private int _colorID;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private PlayerBag _inventory;
    public PlayerBag GetInventory
    {
        get => _inventory;
    }
    private bool _doBridge;
    public void SetDoBridge(bool value)
    {
        _doBridge = value;
    }
    private void Start()
    {
        Debug.Log(_inventory.name);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (_inventory.GetIndex() == 0)
        {
            _targetPosition = Vector3.zero;
        }
        _item = other.GetComponent<CollectableItemScript>();
        if (_colorID == _item.ColorID && !_doBridge)
        {
            _inventory.AddObjectToInvectory(_item.gameObject);
            _item.OffCollider();
            _item.transform.parent = _inventory.transform;
            _targetPosition.y = _offSet.y * _inventory.GetIndex();
            _item.transform.DOLocalMove(_targetPosition, _itemSpeed).SetSpeedBased();
        }
    }

}
