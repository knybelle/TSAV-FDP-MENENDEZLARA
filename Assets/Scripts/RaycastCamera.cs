using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastCamera : MonoBehaviour
{
    public float rayDist = 100;
    public float rangoInteractuable = 10;

    public LayerMask interactuable;


    public int cantidadRegalos;
    private int contadorRegalos;
    public Text texto;
    public Text winScreen;
    public float tiempoEspera;
    public string escenaPrincipal;

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


        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, rangoInteractuable, interactuable))
        {
            if (hit.transform.CompareTag("puerta"))
            {
                hit.transform.GetComponent<Animator>().SetTrigger("open");
            }
            else if (hit.transform.CompareTag("regalo"))
            {
                hit.transform.gameObject.SetActive(false);
                contadorRegalos++;
                texto.text = contadorRegalos + " / " + cantidadRegalos;
                if (contadorRegalos == cantidadRegalos)
                {
                    StartCoroutine(Win());
                }
            }
        }
    }

    IEnumerator Win()
    {
        winScreen.gameObject.SetActive(true);
        yield return new WaitForSeconds(tiempoEspera);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(escenaPrincipal);
    }
}