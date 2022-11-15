using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTile : MonoBehaviour
{
    private static int _rockCount;
    Vector3 hitPos;
    // Start is called before the first frame update
    void Start()
    {
        hitPos = new Vector3(transform.position.x, -1f, transform.position.z);
        CheckGround();
        print($"Transform:  {transform.position}");
    }

    private void CheckGround(){
       int destroyed = 0;
        RaycastHit hit;
        var direction = new Vector3(transform.position.x,transform.position.y*-10,transform.position.z);
        if(Physics.Raycast(transform.position - new Vector3(0,0.2f,0), hitPos, out hit)){
                transform.position = hit.point + Random.insideUnitSphere *0.07f;
                _rockCount++;  
                print($"ROCK:  {_rockCount}");
                if(hit.transform.gameObject.layer == 7 || hit.transform.tag == "LakeTile"){
                    Destroy(gameObject);
                }
            }
        
        else{
           Destroy(gameObject);
           destroyed++;
        }
        if(destroyed>0){
             Generator.Instance.GenerateRocks(destroyed);
        }
       
        
    }
}
