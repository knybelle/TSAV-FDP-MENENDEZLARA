using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastCamera : MonoBehaviour
{
    public float rayDist = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, rayDist, ~LayerMask.GetMask("Player")))
        {
            Debug.Log(hit.transform.name);
        }

    }
}
