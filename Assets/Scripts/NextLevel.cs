using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] LevelHolder NextLevelHolder;
    [SerializeField] LevelHolder PreviousLevelHolder;
    Collider col;
    int playerCount;
    int maxPlayer = 2;
    private void Start()
    {
        col = GetComponent<Collider>();
    }
    private void OnTriggerEnter(Collider other)
    {
        other.transform.parent = NextLevelHolder.transform;
        PlayerBag bag = other.GetComponentInChildren<PlayerBag>();
        PreviousLevelHolder.FindSpawner(bag.gameObject,false);
        NextLevelHolder.FindSpawner(bag.gameObject, true);
    }
    private void OnTriggerExit(Collider other)
    {
        playerCount++;
    }
    private void Update()
    {
        if (playerCount == maxPlayer)
        {
            col.isTrigger = false;
        }
    }



}
