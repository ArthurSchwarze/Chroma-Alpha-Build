using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [HideInInspector]
    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject containerUI;
    public GameObject menuPanelUI;
    public GameObject helpPanelUI;
    public GameObject quitPanelUI;

    public GameObject controlsPanelUI;
    public GameObject whitePanelUI;
    public GameObject bluePanelUI;
    public GameObject redPanelUI;
    public GameObject yellowPanelUI;
    public GameObject greenPanelUI;
    public GameObject magentaPanelUI;

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
        ResetUI();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        look.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

        AudioListener.pause = false;

        gameIsPaused = false;
    }

    void Pause()
    {
        ResetUI();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        look.enabled = false;

        AudioListener.pause = true;

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

    private void ResetUI()
    {
        menuPanelUI.SetActive(false);
        helpPanelUI.SetActive(false);
        quitPanelUI.SetActive(false);
        containerUI.SetActive(true);

        controlsPanelUI.SetActive(false);
        whitePanelUI.SetActive(false);
        bluePanelUI.SetActive(false);
        redPanelUI.SetActive(false);
        yellowPanelUI.SetActive(false);
        greenPanelUI.SetActive(false);
        magentaPanelUI.SetActive(false);
    }
}