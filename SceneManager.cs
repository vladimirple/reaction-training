using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private RandomSpawn randomSpawn;

    public GameObject _panelSetting, _panelGame, _panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        _panelGame.SetActive(false);
        _panelSetting.SetActive(false);
        _panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPanelSetting()
    {
        _panelSetting.SetActive(true);
    }
                                                        
    public void GetMainMenu()
    {
        _panelGame.SetActive(false);
        _panelSetting.SetActive(false);
    }

    public void GetPanelGame()
    {
        _panelGame.SetActive(true);

        randomSpawn.NewGame();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

}