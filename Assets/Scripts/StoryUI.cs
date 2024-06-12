using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI diamondText;
    private GameObject baseMenu;
    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        baseMenu = GameObject.Find("Base Menu");
        store = transform.Find("Store").gameObject;
        SetGoldText(GameManager.instance.gold);
        SetDiamondText(GameManager.instance.diamonds);
    }

    public void SetGoldText(int amount)
    {
        goldText.SetText(amount.ToString());
    }
    public void SetDiamondText(int amount)
    {
        diamondText.SetText(amount.ToString());
    }
    public void Play()
    {
        GameManager.instance.LevelSelect(7);
    }

    public void BackToMenu()
    {
        GameManager.instance.BackToMenu();
    }
    public void ActivateStore()
    {
        baseMenu.SetActive(false);
        store.SetActive(true);
    }
    public void ActivateBaseMenu()
    {
        store.SetActive(false);
        baseMenu.SetActive(true);
    }

}
