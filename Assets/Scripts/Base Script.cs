using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField]
    private float HP = 100f;
    private float currentHp;
    [SerializeField]
    private bool isEnemy;
    [SerializeField]
    private int goldDrop;

    private UnitUI UI;

    // Start is called before the first frame update
    void Start()
    {
        UI = transform.Find("Canvas").GetComponent<UnitUI>();
        currentHp = HP;
        UI.UpdateHP(HP, currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        ManageHP();
    }

    public void DealDamage(float amount)
    {
        if (isEnemy)
            GameManager.instance.AddGold(goldDrop * (int)amount);
        currentHp -= amount;
        UI.UpdateHP(HP, currentHp);
    }

    private void ManageHP()
    {
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            GameManager.instance.GameOver();
        }

    }
}
