using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class EventManager : MonoBehaviour
{
    //public static event Action StopGame;
    //public static event Action StartGame;
    NavMeshAgent nav;
    public void EndGame(GameObject obj)
    {
        if (obj.TryGetComponent<NavMeshAgent>(out nav))
        {
            nav.speed = 0;
        }
        else
        {
            obj.GetComponent<PlayerController>().MovementSpeed = 0;

        }
    }



}
