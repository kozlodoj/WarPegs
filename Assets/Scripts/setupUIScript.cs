using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class setupUIScript : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI speed;
    [SerializeField]
    private TextMeshProUGUI reload;

    // Start is called before the first frame update
    void Start()
    {
        speed.SetText("Power " + GameManager.instance.ballPower.ToString());
        reload.SetText("Reload speed " + GameManager.instance.reloadRate.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
