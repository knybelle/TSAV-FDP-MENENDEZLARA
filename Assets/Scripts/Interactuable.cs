using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable : MonoBehaviour
{
    public float rayDist = 100.0f;
    public GameObject particulas;
    public float outlineThickness = 0.2f;
    public Color outlineColor;
    private Material prevMat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (prevMat != null)
        {
            prevMat.SetFloat("_outlineThickness", 0);
        }
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, rayDist, LayerMask.GetMask("Desaparecible")))
        {
            MeshRenderer mr = hit.transform.GetComponent<MeshRenderer>();
            if (mr != null)
            {
                prevMat = mr.materials[0];
                prevMat.SetFloat("_outlineThickness", outlineThickness);
                prevMat.SetColor("_outlineColor", outlineColor);
            }
            if (Input.GetKey(KeyCode.E))
            {
                hit.transform.gameObject.SetActive(false);
                //Instantiate(particulas, hit.point, Quaternion.identity);
                //Alternativa:
                //Instantiate(particulas, hit.transform.position, Quaternion.Identity);
            }
        }
    }
}
