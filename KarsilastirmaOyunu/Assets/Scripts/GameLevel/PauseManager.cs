using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject PausePanel;
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    
    public void YenidenOyna()
    {
        PausePanel.SetActive(false);
    }
    public void MenuDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void OyundanCik()
    {
        Application.Quit();
    }

}
