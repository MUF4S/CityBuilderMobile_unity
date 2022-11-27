using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour
{
    
    Vector3 hitPos;
    // Start is called before the first frame update
    void Start()
    {
        hitPos = new Vector3(transform.position.x, -1f, transform.position.z);
        CheckGround();

    }
    private void LateUpdate()
    {

    }

    private void CheckGround()
    {
        RaycastHit hit;
        var direction = new Vector3(transform.position.x, transform.position.y * -10, transform.position.z);
        if (Physics.Raycast(transform.position - new Vector3(0, 0.2f, 0), hitPos, out hit))
        {
            transform.position = hit.point + Vector3.up * 0.02f;
            if (hit.transform.gameObject.layer == 7)
            {
                Destroy(gameObject);
            }
        }

        else
        {
            Destroy(gameObject);
        }
    }
}
