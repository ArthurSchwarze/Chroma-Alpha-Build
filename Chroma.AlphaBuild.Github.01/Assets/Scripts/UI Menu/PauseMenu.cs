using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    private GameObject mainCamera;
    private NewMouseLook look;

    void Awake()
    {
        pauseMenuUI.SetActive(false);

        mainCamera = GameObject.FindWithTag("MainCamera");
        look = mainCamera.GetComponent<NewMouseLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }

            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        look.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        look.enabled = false;

        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void QuitGame()
    {
        Debug.Log("quit game...");
        Application.Quit();
    }
}