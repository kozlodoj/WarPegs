using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;

    // Start is called before the first frame update
    void Start()
    {
        SetGoldText(GameManager.instance.gold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGoldText(int amount)
    {
        goldText.SetText(amount.ToString());
    }
    public void Play()
    {
        GameManager.instance.LevelSelect(6);
    }

    public void BackToMenu()
    {
        GameManager.instance.BackToMenu();
    }

}
