using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public static Generator Instance;
    [SerializeField] private GameObject[] _lakeObjects;
    [SerializeField] private GameObject[] _rockObjects;
    [SerializeField] private GameObject[] _treeObjects;
    [SerializeField] private GameObject[] _mountainObjects;
    private GameObject Rocks;

    
    [SerializeField] private int _lakeObjectsCount;
    [SerializeField] private int _rockObjectsCount;
    [SerializeField] private int _treeObjectsCount;
    [SerializeField] private int _mountainsObjectsCount;
    [SerializeField] private int _forestCount;
    [SerializeField] private int _mountainsRangeCount;

    private void Awake() {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Rocks = new GameObject("Rocks");
        GenerateLakes();
        GenerateTrees();
        GenerateMountains();
        GenerateRocks();
        SpawnAnimals.Instance.FirstSpawn();
        
        
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
            
            Vector3 forestPos = Random.insideUnitSphere* ((GridManager.Instance._height/2));
            forestPos.y = 1f;
            GameObject forest = new GameObject($"Forest {i}");
            //print($"Pozycja{forestPos}");
            forest.transform.position = forestPos;
            for (int j = 0; j < _treeObjectsCount; j++)
            {
            
              //  Vector3 pos = new Vector3(forestPos.x * Random.insideUnitSphere.x,20, forestPos.z * Random.insideUnitSphere.z )/10;  
                
                RaycastHit hit;
                if(Physics.Raycast(forestPos,Vector3.down,out hit)){
                    if(hit.transform.gameObject.layer == 6){
                        Vector3 randomPos = Random.insideUnitSphere;
                        randomPos.y =0;
                        GameObject selected = _treeObjects[Random.Range(0, _treeObjects.Length)];
                        hit.point = new Vector3(hit.point.x,0.2f,hit.point.z);
                        Vector3 spawnPoint = hit.point + randomPos*5; 
                        spawnPoint.y = 1f;
                        GameObject tree = Instantiate(selected, spawnPoint, selected.transform.rotation,forest.transform);
                       
                    }
                    else{
                        j--;
                    }
                }

                if(forest.transform.childCount ==0){
                    Destroy(forest);
                    i--;
                }
            }
        }
    }

    private void GenerateMountains(){
        for (int i = 0; i < _mountainsRangeCount; i++)
        {
            Vector3 mountainRangePos = Random.insideUnitSphere * ((GridManager.Instance._height/2));
            mountainRangePos.y = 1;
            GameObject mountainRange = new GameObject($"MountainRange {i}");
            //print($"Pozycja{forestPos}");
            mountainRange.transform.position = mountainRangePos;
            for (int j = 0; j < _mountainsObjectsCount; j++)
            {
            
              //  Vector3 pos = new Vector3(forestPos.x * Random.insideUnitSphere.x,20, forestPos.z * Random.insideUnitSphere.z )/10;  
                
                RaycastHit hit;
                if(Physics.Raycast(mountainRangePos,Vector3.down,out hit)){
                    if(hit.transform.gameObject.layer == 6){
                        GameObject selected = _mountainObjects[Random.Range(0, _mountainObjects.Length)];
                        hit.point = new Vector3(hit.point.x,0.2f,hit.point.z);
                        Vector3 spawnPoint = hit.point + Random.insideUnitSphere*2f; 
                        spawnPoint.y = 0.6f;
                        GameObject tree = Instantiate(selected, spawnPoint, selected.transform.rotation,mountainRange.transform);
                       
                    }
                    else{

                    }
                }

                if(mountainRange.transform.childCount ==0){
                    Destroy(mountainRange);
                    i--;
                }
            }
        }
    }

    void GenerateRocks(){
        Rocks.transform.position = Vector3.up;
        RaycastHit hit;
        if(Physics.Raycast(Rocks.transform.position,Vector3.down,out hit)){
            for (int i = 0; i < _rockObjectsCount; i++)
            {
                Vector3 randomPos = Random.insideUnitSphere;
                randomPos.y = 0;
                Vector3 pos = Random.insideUnitSphere * (GridManager.Instance._height/2);
                pos = new Vector3(Mathf.Floor(pos.x), 0, Mathf.Floor(pos.z));
                Vector3 spawnPoint = hit.point + randomPos*5;
                spawnPoint.y = 2;
                GameObject selected = _rockObjects[Random.Range(0, _rockObjects.Length)];

                GameObject rock = Instantiate(selected, spawnPoint, selected.transform.rotation, Rocks.transform);
            // Destroy(GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)]);
            // GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)] = lake;
            
            }
        }
    }
    public void  GenerateRocks(int howMany){
        if(Rocks!= null){
            RaycastHit hit;
            if(Physics.Raycast(Rocks.transform.position,Vector3.down,out hit)){
                for (int i = 0; i < howMany; i++)
                {
                    Vector3 randomPos = Random.insideUnitSphere;
                    randomPos.y = 0;
                    Vector3 pos = Random.insideUnitSphere * (GridManager.Instance._height/2);
                    pos = new Vector3(Mathf.Floor(pos.x), 0, Mathf.Floor(pos.z));
                    Vector3 spawnPoint = hit.point + randomPos*5;
                    spawnPoint.y = 2;
                    GameObject selected = _rockObjects[Random.Range(0, _rockObjects.Length)];

                    GameObject rock = Instantiate(selected, spawnPoint, selected.transform.rotation, Rocks.transform);
                // Destroy(GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)]);
                // GridManager.Instance.Tiles[new Vector2(pos.x, pos.z)] = lake;
                
                }
            }
        }
    }
}
