using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Material _highlight;
    private Material _defaultMaterial;
    private void Start() {
        _defaultMaterial = _mesh.material;
    }
    private void OnMouseEnter() {
        _mesh.material = _highlight;
    }
    private void OnMouseExit() {
        _mesh.material = _defaultMaterial;
    }

    
}
