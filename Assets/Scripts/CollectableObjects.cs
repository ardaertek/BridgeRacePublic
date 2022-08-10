using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour
{
    [SerializeField] private GameObject _objectPrefab;
    [SerializeField] private float _spawnFreq;
    GameObject obj;
    private void Start()
    {
        StartCoroutine(SpawnObject());
    }
    IEnumerator SpawnObject()
    {
        while (true)
        {
            float Xpos = Random.Range(transform.position.x - 10, transform.position.x + 10);
            float Zpos = Random.Range(transform.position.z - 6, transform.position.z + 6);
            obj = Instantiate(_objectPrefab, new Vector3(Xpos, transform.position.y, Zpos), Quaternion.identity);
            obj.transform.parent = transform;
            yield return new WaitForSeconds(_spawnFreq);
        }
    }
}
