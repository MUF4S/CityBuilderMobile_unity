using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
   
   
        
   private void Update() {

    
    if(Input.GetKey(KeyCode.W)){
        transform.position += Vector3.forward * Time.deltaTime *5f;
    }
    if(Input.GetKey(KeyCode.S)){
        transform.position += Vector3.back * Time.deltaTime *5f;

    }
    if(Input.GetKey(KeyCode.A)){
        transform.position += Vector3.left * Time.deltaTime *5f;

    }
    if(Input.GetKey(KeyCode.D)){
        transform.position += Vector3.right * Time.deltaTime *5f;

    }
    GridManager.Instance.RenderTerrain(new Vector2((float)Mathf.RoundToInt(transform.position.x), (float)Mathf.RoundToInt(transform.position.z)));
   }
   
}
