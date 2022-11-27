using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private Material _highlight;
    private Material _defaultMaterial;
    private void Start() {
        _defaultMaterial = _mesh.material;
    }
    /*private void OnMouseEnter() {
        _mesh.material = _highlight;
    }
    private void OnMouseExit() {
        _mesh.material = _defaultMaterial;
    }*/
   
    private void Update() { }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _mesh.material = _highlight;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _mesh.material = _defaultMaterial;
    }
}
