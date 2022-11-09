using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    [Range(10000,99999)]
    [SerializeField] private int _seed;
    [SerializeField] public  int _width, _height;
    [SerializeField] private GameObject _grassTile, _lakeTile;
    [SerializeField] private GameObject[] _mountainsTiles;
    [SerializeField] private int _maxView;
    private GameObject Terrain;

    public Dictionary<Vector2,GameObject> Tiles = new Dictionary<Vector2, GameObject>();
    private void Awake() {
        transform.position = new Vector3(_width/2, 0, _height/2 );
        Instance = this;
    }
    private void Start() {
        Terrain = new GameObject("Terrain");
        
        GenerateMainGrid(_width, _height);
        RenderTerrain(new Vector2(0,0));

    }
    void GenerateMainGrid(int width, int height){
        
        for (int x = (-width/2); x < width/2; x++)
        {
            for (int z =(-height/2); z < height/2; z++)
            {
                var randomTile = _grassTile;
                var spawnedTile = Instantiate(randomTile, new Vector3(x, 0, z), Quaternion.identity, Terrain.transform);
                
                spawnedTile.name = $"Tile {x} {z}";

                Tiles[new Vector2 (x,z)] = spawnedTile;

                
            }
        }
        //GenerateEnvironment();
    }

    public void GenerateGrid(int width, int height, Vector2 startPos){
        _width += width;
        _height += height;
        for (int x = (-width/2); x < width/2; x++)
        {
            
            for (int z =(-height/2); z < height/2; z++)
            {
                var xPos = Mathf.RoundToInt(startPos.x + x);
                var zPos = Mathf.RoundToInt( z + startPos.y);
                var randomTile = _grassTile;
                print($"KURWA: {Tiles.ContainsKey(new Vector2(xPos, zPos))}");
                if(!Tiles.ContainsKey(new Vector2(xPos, zPos)))
                {
                    var spawnedTile = Instantiate(randomTile, new Vector3(xPos, 0, zPos), Quaternion.identity, Terrain.transform);
                    spawnedTile.SetActive(false);
                    spawnedTile.name = $"Tile {xPos} {zPos}";

                    Tiles[new Vector2 (xPos, z + zPos)] = spawnedTile;
                    print($"Wygenerowano {xPos} + {zPos}");
                }

                
            }
            
        }
        //Generator.Instance.GenerateLakes();
    }

    public void RenderTerrain(Vector2 startPoint){
            //Vector2 tileToSpawn = startPoint + new Vector2(-1,1)*i;
            //Vector2 tileToSpawn1 = startPoint + new Vector2(1,1)*i;
            //Vector2 tileToSpawn2 = startPoint + new Vector2(-1,-1)*i;
            //Vector2 tileToSpawn3 = startPoint + new Vector2(1,-1)*i;

            //Tiles[tileToSpawn].SetActive(true);
            // Tiles[tileToSpawn1].SetActive(true);
            //Tiles[tileToSpawn2].SetActive(true);
            //Tiles[tileToSpawn3].SetActive(true);

       
        for (int i = 0; i <_maxView*2; i++)
        {
            Vector2 tileToSpawn =startPoint - new Vector2(-_maxView + i,0);
            if(Tiles.ContainsKey(tileToSpawn)){
                Tiles[tileToSpawn].SetActive(true);
            }
            
        
            for (int j = 0 ; j < _maxView*2; j++)
            {
                Vector2 tileToSpawn1 = tileToSpawn + new Vector2(0,-_maxView+j);
                if(Tiles.ContainsKey(tileToSpawn1)){
                    Tiles[tileToSpawn1].SetActive(true);
                }
                
            }
        }
        
    }
    

    public GameObject GetTileAtPosition(Vector2 pos){
        if(Tiles.TryGetValue(pos,out var tile )){
            return tile;
        }

        return null;
    }
}
