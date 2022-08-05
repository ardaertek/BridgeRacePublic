using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBag : MonoBehaviour
{
    [SerializeField] public List<GameObject> ItemList;
    [SerializeField] private DoBridge BridgeMaker;
    [SerializeField] private int _index;
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
        PController.MovementSpeed -= 0.01f * ItemList.Count;
        ItemList.Add(obj);
    }
    public GameObject GetItemFromInventory()
    {

        if (_index == 0)
        {
            return null;
        }
        _index--;
        PController.MovementSpeed += 0.01f * ItemList.Count;
        GameObject obj = ItemList[ItemList.Count - 1];
        ItemList.Remove(obj);
        return obj;
    }
    private IEnumerator _bridgeCourutine;

    public void BridgeCourutineStarter()
    {
        _bridgeCourutine = DoBridgeCourutine();
        StartCoroutine(_bridgeCourutine);
    }
    public void BridgeCourutineStoper()
    {

        if (_bridgeCourutine != null)
        {
            StopCoroutine(_bridgeCourutine);
            _bridgeCourutine = null;
        }
    }


    IEnumerator DoBridgeCourutine()
    {
        int loopCount = ItemList.Count;
        for (int i = 0; i < loopCount; i++)
        {

            BridgeMaker.MakeBridge(GetItemFromInventory());
            yield return new WaitForSeconds(0.5f);
        }
    }
}
