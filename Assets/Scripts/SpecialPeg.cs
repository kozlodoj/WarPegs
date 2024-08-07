using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpecialPeg : MonoBehaviour
{
    [SerializeField]
    private Image lvlBar;
    [SerializeField]
    private TextMeshProUGUI lvlText;
    public SpecPeg data;
    public int pegNumber;
    public float lvl;
    public float chance;
    public int slot;
    private SaveScript save;
    private void Start()
    {
        save = GameManager.instance.gameObject.GetComponent<SaveScript>();
        LoadData();
        SetLvlUI();
    }

    public void SetLvlUI()
    {
        lvlBar.fillAmount = lvl % 1;
        lvlText.SetText("lvl " + (lvl - (lvl % 1)));
        
        
    }
    public void SetLvl()
    {
        lvl += 0.25f;
        if (lvl % 1 == 0)
            chance += 25;
        SetLvlUI();
    }
    public void LoadData()
    {
        pegNumber = data.pegNumber;
        lvl = data.lvl;
        chance = data.chance;
    }
    private SpecPeg CurrentData()
    {
        SpecPeg data = new SpecPeg();
        data.pegNumber = pegNumber;
        data.lvl = lvl;
        data.chance = chance;
        return data;
    }
    public void Save(int slot)
    {
        GameManager.instance.gameObject.GetComponent<SaveScript>().SaveSpecPegCard(CurrentData(), slot);
    }
}
