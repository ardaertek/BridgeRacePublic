using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent nav;
    PlayerBag _inventory;
    [SerializeField] Collider[] _collectableObjects;
    [SerializeField] LayerMask _cubeLayer;
    float _sightRange = 4f, _timer, _timeFreq = 1.5f;
    //-------------
    LevelHolder _levelHolder;
    public bool _doBridge;
    public bool _goEntry;
    public float _steCount;
    private void Start()
    {
        _levelHolder = GetComponentInParent<LevelHolder>();
        _inventory = GetComponentInChildren<PlayerBag>();
        nav = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        _timer += Time.deltaTime;
        _collectableObjects = Physics.OverlapSphere(transform.position, _sightRange, _cubeLayer);

        if (_doBridge)
        {
            if (_inventory.ItemList.Count != 0)
            {
                nav.SetDestination(_bridgeSelecter().GetComponent<Bridges>().ExitPoint.position);
            }
            if(_inventory.ItemList.Count == 0)
            {
                if(_steCount != 26) nav.SetDestination(_levelHolder.LevelPosition.position);
                if(_steCount == 26) nav.SetDestination(_bridgeSelecter().GetComponent<Bridges>().ExitPoint.position);
            }
        }
        if (_inventory.ItemList.Count >= 7 && !_doBridge)
        {
            nav.SetDestination(_bridgeSelecter().GetComponent<Bridges>().EntryPoint.position);
            _sightRange = 1.5f;
        }
        else _sightRange = 4f;
        if (_collectableObjects.Length != 0)
        {
            nav.SetDestination(_mostCloseObject());
        }
        else if (_collectableObjects.Length == 0 && _timer > _timeFreq && _inventory.ItemList.Count < 7)
        {
            nav.SetDestination(_randomPatrolling());
            _timer = 0;
        }
    }


    //----------------------------------------
    Vector3 _patrolPoint;
    [SerializeField] float _movementDistancex;
    [SerializeField] float _movementDistancez;
    private Vector3 _randomPatrolling()
    {
        float xPos = Random.Range(_levelHolder.LevelPosition.position.x - _movementDistancex, _levelHolder.LevelPosition.position.x + _movementDistancex);
        float zPos = Random.Range(_levelHolder.LevelPosition.position.z - _movementDistancez, _levelHolder.LevelPosition.position.z + _movementDistancez);
        _patrolPoint = new Vector3(xPos, 0, zPos);
        return _patrolPoint;
    }
    //---------------------------------------

    GameObject _mostCloseObjectG;
    float dis1, dis2;
    private Vector3 _mostCloseObject()
    {
        _mostCloseObjectG = _collectableObjects[0].gameObject;
        for (int i = 0; i < _collectableObjects.Length - 1; i++)
        {
            for (int j = i + 1; j < _collectableObjects.Length; j++)
            {
                dis1 = Vector3.Distance(_collectableObjects[j].transform.position, transform.position);
                dis2 = Vector3.Distance(_collectableObjects[i].transform.position, transform.position);
                if (dis1 < dis2)
                {
                    _mostCloseObjectG = _collectableObjects[j].gameObject;
                }
            }
        }
        return _mostCloseObjectG.transform.position;
    }

    //----------------------------------------
    GameObject _mostCloseBridge;
    private GameObject _bridgeSelecter()
    {
        _levelHolder = GetComponentInParent<LevelHolder>();
        _mostCloseBridge = _levelHolder.Bridge[0].gameObject;
        for (int i = 0; i < _levelHolder.Bridge.Length - 1; i++)
        {
            for (int j = i + 1; j < _levelHolder.Bridge.Length; j++)
            {
                dis1 = Vector3.Distance(_levelHolder.Bridge[j].transform.position, transform.position);
                dis2 = Vector3.Distance(_levelHolder.Bridge[i].transform.position, transform.position);
                if (dis1 < dis2)
                {
                    _mostCloseBridge = _levelHolder.Bridge[j].gameObject;
                }
            }
        }
        return _mostCloseBridge;
    }
}
