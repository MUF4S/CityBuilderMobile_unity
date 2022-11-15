using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    bool destroy = false;
    Vector3 hitPos;
    // Start is called before the first frame update
    void Start()
    {
        hitPos = new Vector3(transform.position.x, -1f, transform.position.z);
        
    }
    private void LateUpdate() {
        CheckGround();
    }

    private void CheckGround(){
        RaycastHit hit;
        var direction = new Vector3(transform.position.x,transform.position.y*-10,transform.position.z);
        if(Physics.Raycast(transform.position - new Vector3(0,0.2f,0), hitPos, out hit)){
           gameObject.name = hit.transform.name;
            hitPos = hit.transform.position;
             print($"Uderzono: {hit}");
            //print($"Uderzono: {gameObject.name}");
            if(hit.transform.gameObject.layer != 6){
                print($"Uderzono: {hit.point ==null}");
                hit.transform.localScale *= 20f;
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.DrawLine(transform.position - new Vector3(0,0.2f,0),hitPos);
       


    }
}
