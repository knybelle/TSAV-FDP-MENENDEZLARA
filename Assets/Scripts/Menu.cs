using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pausa;

    // Start is called before the first frame update
    void Start()
    {
        if (pausa != null)
        {
            pausa.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            pausa.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void Continue()
    {
        pausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
