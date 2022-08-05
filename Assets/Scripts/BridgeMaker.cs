using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeMaker : MonoBehaviour
{
    [SerializeField] private List<GameObject> _stairsPart;
    [SerializeField] private int _stairLenght;
    [SerializeField] private int _index;
    [SerializeField] private PlayerBag Inventory;
    [SerializeField] private bool _doBridge;

    public void SetDoBridge(bool value)
    {
        _doBridge = value;
    }
    public void SetStepIndex(int value)
    {
        _index = value;
    }

    private void Start()
    {
        _stairsPart = new List<GameObject>();
    }


    public void MakeBridge(GameObject obj)
    {
        //if (_index <= _stairLenght && Inventory.ItemList.Count > 0)
        //{
            obj.GetComponent<StairParts>().Active();
            _index++;
        //}


        //if (obj == null) return;
        //MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
        //CollectableItemScript col = obj.GetComponent<CollectableItemScript>();
        //if (_index <= _stairLenght && Inventory.ItemList.Count > 0)
        //{
        //    GameObject objFromBag;
        //    objFromBag = Inventory.GetItemFromInventory();
        //    objFromBag.transform.DOMove(obj.transform.position, 2f).OnComplete(() =>
        //    {
        //         objFromBag.SetActive(false);
        //         mesh.enabled = true;
        //        _index++;
        //         col.OffObstacleCollider();
        //    });
        //    obj.GetComponent<MeshRenderer>().enabled = true;
        //    obj.GetComponent<CollectableItemScript>().OffObstacleCollider();

        //}
    }
}
