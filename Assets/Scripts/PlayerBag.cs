using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] public List<GameObject> ItemList;
    [SerializeField] private int _index;
    [SerializeField] private LayerMask _changeLayer;
    PlayerController PController;
    
    public int GetIndex()
    {
        return _index;
    }
    private void Start()
    {
        PController = GetComponentInParent<PlayerController>();
        ItemList = new List<GameObject>();
    }
    public void AddObjectToInvectory(GameObject obj)
    {
        _index++;
        ItemList.Add(obj);
        if(PController)
        PController.MovementSpeed -= 0.01f * ItemList.Count;
    }
    public void GetItemFromInventory()
    {
        if (_index == 0)
        {
            return;
        }
        _index--;
        if(PController)
        PController.MovementSpeed += 0.01f * ItemList.Count;
        GameObject obj = ItemList[ItemList.Count - 1];
        ItemList.Remove(obj);
        obj.SetActive(false);
    }


    [SerializeField] GameObject rayPos;
    Ray ray;
    RaycastHit hit;
    RaycastHit hit2;
    public LayerMask layer;
    public bool check;
    GameObject objj;
    private void FixedUpdate()
    {
        if (Physics.Raycast(rayPos.transform.position, rayPos.transform.forward, out hit, 1f, layer))
        {
            if (ItemList.Count > 0)
            {
                objj = hit.transform.gameObject;
                objj.layer = LayerMask.NameToLayer("Default");
                GetItemFromInventory();
                objj.GetComponent<StairParts>().Active();
            }
        }
    }
}
