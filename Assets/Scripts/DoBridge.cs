using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoBridge : MonoBehaviour
{
    [SerializeField] private Transform _firstStepPos;

    public void SetFirstStepPos(Transform pos)
    {
        _firstStepPos = pos;
    }

    [SerializeField] private float _itemSpeed;
    [SerializeField] private Vector3 _offSet;
    [SerializeField] private int _stepIndex;
    private Vector3 _targetPoisiton;
    [SerializeField] private PlayerBag Inventory;
    [SerializeField] private int _stepCount;
    [SerializeField] private GameObject _bridgeParts;

    public void SetBridgePartsPos(GameObject obj)
    {
        _bridgeParts = obj;
    }

    [SerializeField] private bool _doBridge;
    [SerializeField] private List<GameObject> _stairsPart;
    public void SetDoBridge(bool value)
    {
        _doBridge = value;
    }
    public void SetStepIndex(int value)
    {
        _stepIndex = value;
    }
    private void Update()
    {

    }

    public void MakeBridge(GameObject obj)
    {
        if (_stepIndex == 0)
        {
            _targetPoisiton = Vector3.zero;
        }
        if (_stepIndex <= _stepCount)
        {
            if (obj == null) return;
            _stairsPart.Add(obj);
            obj.transform.parent = _bridgeParts.transform;
            obj.GetComponent<CollectableItemScript>().OnCollider();
            obj.transform.DOLocalMove(_targetPoisiton, _itemSpeed).SetSpeedBased();
            _targetPoisiton += _offSet;
            _stepIndex++;

        }

    }



    //IEnumerator MakeBridge()
    //{
    //    SetDoBridge(false);
    //    while (_doBridge)
    //    {
    //        Debug.Log("ss");
    //        if (_stepIndex == 0)
    //        {
    //            _targetPoisiton = Vector3.zero;
    //        }
    //        if (_stepIndex <= _stepCount)
    //        {
    //            GameObject obj = Inventory.GetItemFromInventory();
    //            if (obj == null) break;
    //            _stairsPart.Add(obj);
    //            obj.transform.parent = _bridgeParts.transform;
    //            obj.GetComponent<CollectableItemScript>().OnCollider();
    //            obj.transform.DOLocalMove(_targetPoisiton, _itemSpeed).SetSpeedBased();
    //            _targetPoisiton += _offSet;
    //            _stepIndex++;

    //        }
    //        yield return new WaitUntil(() => _doBridge == false);
    //    }
    //}
}
