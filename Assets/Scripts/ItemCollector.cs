using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemCollector : MonoBehaviour
{
    private Vector3 _targetPosition;
    private CollectableItemScript _item;
    [SerializeField] private GameObject _bag;
    [SerializeField] private float _itemSpeed;
    [SerializeField] private int _colorID;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private PlayerBag Inventory;
    public PlayerBag GetInventory
    {
        get => Inventory;
    }
    AnimatorController _animC;
    private bool _doBridge;
    private void Start()
    {
        _animC = GetComponentInParent<AnimatorController>();
    }
    public void SetDoBridge(bool value)
    {
        _doBridge = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Inventory.GetIndex() == 0)
        {
            _targetPosition = Vector3.zero;
        }
        _item = other.GetComponent<CollectableItemScript>();
        if (_colorID == _item.ColorID && !_doBridge)
        {
            Inventory.AddObjectToInvectory(_item.gameObject);
            _item.OffCollider();
            _item.transform.parent = _bag.transform;
            _targetPosition.y = _offSet.y * Inventory.GetIndex();
            _item.transform.DOLocalMove(_targetPosition, _itemSpeed).SetSpeedBased();
        }
    }

}
