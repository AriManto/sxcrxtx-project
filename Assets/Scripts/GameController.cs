using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Classes;
using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.WSA.Input;

public class GameController : MonoBehaviour
{
    [SerializeField]
    public Player Player;
    [SerializeField]
    public GameObject TestActivePanel;
    [SerializeField]
    public GameObject PausePanel;
    [SerializeField]
    public GameObject DeathPanel;
    [SerializeField]
    public GameObject HUDPanel;
    public static bool isGamePaused;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (Player.Health.IsAlive)
            {
                togglePauseState();
            }
        }
    }

    #region Button Click Handlers
    
    public void pauseButtonClicked()
    {
        showPausePanel(true);
    }
    public void resumeButtonClicked()
    {
        showPausePanel(false);
    }
    public void restartButtonClicked()
    {
        resumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void mainMenuButtonClicked()
    {
        //SceneManager.LoadScene("MainMenu");
    }
    public void exitButtonClicked()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
    #endregion

    #region HUDPanel
    public void showHUDPanel(bool showHud)
    {
        HUDPanel.SetActive(showHud);
    }
    #endregion

    #region Pause Panel 
    public void showPausePanel(bool pause)
    {
        if (pause)
        {
            PausePanel.SetActive(true);
            pauseGame();
        } else
        {
            PausePanel.SetActive(false);
            resumeGame();
        }
    }
    public void togglePauseState()
    {
        bool currentPausePanelState = PausePanel.activeSelf;
        showPausePanel(!currentPausePanelState);
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void resumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }
    #endregion

    #region Death Panel
    public void onPlayerDied()
    {
        pauseGame();
        showDeathPanel();
    }
    public void showDeathPanel()
    {
        showHUDPanel(false);
        DeathPanel.SetActive(true);
    }
    #endregion

    #region Test Panel
    public void onTogglePanelValueChanged()
    {
        TestActivePanel.gameObject.SetActive(!TestActivePanel.gameObject.activeSelf);
    }
    public void onDmgButtonClicked()
    {
        Player.RemoveHitpointsFromPlayer(1);
    }
    public void onHealButtonClicked()
    {
        Player.AddHitpointsToPlayer(1);
    }
    #endregion
}
