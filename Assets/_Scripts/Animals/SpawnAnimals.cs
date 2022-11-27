using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    public static SpawnAnimals Instance;
    [SerializeField] private GameObject[] _sheepSpawnGroup;
    [SerializeField] private GameObject[] _sheepsObj;
    [SerializeField] private int _howManySheeps;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        FirstSpawn();
    }
    // Start is called before the first frame update
    public void FirstSpawn()
    {
        GenerateShipSpawns();
        for (int i = 0; i < _sheepSpawnGroup.Length; i++)
        {
            SpawnShips(_sheepSpawnGroup[i].transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerateShipSpawns()
    {
        for (int i = 0; i < _sheepSpawnGroup.Length; i++)
        {

            Vector3 sheepSpawnGroup = Random.insideUnitSphere * ((GridManager.Instance._height / 2));
            sheepSpawnGroup.y = 1f;
            GameObject sheepSpawn = new GameObject($"SheepSpawn {i}");
            //print($"Pozycja{forestPos}");
            sheepSpawn.transform.position = sheepSpawnGroup;
            _sheepSpawnGroup[i] = sheepSpawn;
            
        }
    }


    public void SpawnShips(Transform spawnPoint)
    {
        
        for (int i = 0; i < _howManySheeps; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(spawnPoint.position, Vector3.down, out hit))
            {
                if (hit.transform.gameObject.layer == 6)
                {
                    Vector3 sheepSpawnPoint = hit.point + Random.insideUnitSphere * 5f;
                    sheepSpawnPoint.y = 0.1f;
                    GameObject sheep = Instantiate(_sheepsObj[Random.Range(0, _sheepsObj.Length)], sheepSpawnPoint, transform.rotation, spawnPoint);
                    sheep.name = $"Sheep{i}";
                }
            }
        }
        
        
    }
}
