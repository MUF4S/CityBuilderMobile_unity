using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator Instance;
    [SerializeField] private GameObject[] _lakeObjects;
    [SerializeField] private GameObject[] _rockObjects;
    [SerializeField] private GameObject[] _treeObjects;
    
    [SerializeField] private int _lakeObjectsCount;
    [SerializeField] private int _rockObjectsCount;
    [SerializeField] private int _treeObjectsCount;
    [SerializeField] private int _forestCount;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        GenerateLakes();
        GenerateTrees();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateLakes(){
        GameObject Lakes = new GameObject("Lakes");
        for (int i = 0; i < _lakeObjectsCount; i++)
        {
            Vector3 pos = Random.insideUnitSphere * (GridManager.Instance._height/2);
            pos = new Vector3(Mathf.Floor(pos.x), 0, Mathf.Floor(pos.z));
            pos.y = 0;
            GameObject selected = _lakeObjects[Random.Range(0, _lakeObjects.Length)];

            GameObject lake = Instantiate(selected, pos, selected.transform.rotation, Lakes.transform);
            Destroy(GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)]);
            GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)] = lake;
           
        }
    }
    void GenerateTrees(){
        for (int i = 0; i < _forestCount; i++)
        {
            Vector3 forestPos = Random.insideUnitSphere * (GridManager.Instance._height/2);
            forestPos.y = 0;
            GameObject forest = new GameObject($"Forest {i}");
            //print($"Pozycja{forestPos}");
            forest.transform.position = forestPos;
            for (int j = 0; j < _treeObjectsCount; j++)
            {
            
                Vector3 pos = new Vector3(forestPos.x * Random.insideUnitSphere.x,20, forestPos.z * Random.insideUnitSphere.z )/10;  
                pos.y = 20;
                RaycastHit hit;
                if(Physics.Raycast(forestPos,Vector3.down,out hit)){
                    if(hit.transform.gameObject.layer == 6){
                        GameObject selected = _treeObjects[Random.Range(0, _treeObjects.Length)];
                        hit.point = new Vector3(hit.point.x,0.2f,hit.point.z);
                        Vector3 spawnPoint = hit.point + Random.insideUnitSphere *2;
                        spawnPoint.y = 0.2f;
                        GameObject tree = Instantiate(selected, spawnPoint, selected.transform.rotation,forest.transform);
                    }
                }
            }
        }
    }
}
