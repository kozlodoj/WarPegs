using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float ballPower = 5;
    public float reloadRate = 5;
    public float buff = 2;
    public float respawn = 2;
    public float intialStat = 100f;

    public bool randomSpawn = false;

    private ButtonsScript buttons;


    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

   

    }

    public void LevelSelect(int levelNum)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(levelNum);

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void RandomSpawn(bool isTrue)
    {
        randomSpawn = isTrue;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameObject.Find("UI").GetComponent<UIScript>().ActivateGameOverUI();
    }
}
