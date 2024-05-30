using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Freeze : MonoBehaviour
{
    public float reloadTime;
    private float timePassed;
    private Image fill;

    // Start is called before the first frame update
    void Start()
    {
        fill = transform.Find("Fill").gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageFill();
    }

    public void ActivateFreeze()
    {
        GameManager.instance.freezeGame = true;
    }

    private void ManageFill()
    {
        timePassed += Time.deltaTime;
        while (timePassed <= reloadTime)
        fill.fillAmount = timePassed / reloadTime;
    }
}
