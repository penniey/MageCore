using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuUi;
    public bool isActive;
    void Start()
    {
        isActive = false;
        menuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleMenu();
        }
    }

    public void ToggleMenu()
    {
        if (isActive)
        {
            menuUi.SetActive(false);
            isActive = false;

            
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
            isActive = true;
            menuUi.SetActive(true);
        }
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
