using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairParts : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Collider _collider;
    public void Active()
    {
        _mesh.enabled = true;
        _collider.enabled = false;
    }
}
