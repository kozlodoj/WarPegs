using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float ballPower { private set; get; }
    public float reloadRate { private set; get; }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        ballPower = 4f;
        reloadRate = 2f;

    }

    public void LevelSelect(int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    public void SetBallPower(string power)
    {
        ballPower = float.Parse(power);
    
    }

    public void SetReloadRate(string rate)
    {
        reloadRate = float.Parse(rate);
    }
 
}
