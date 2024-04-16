using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    [SerializeField]
    private GameObject mag;

    private UIScript uiScript;
    private Mag magScript;

    private bool loaded = false;
    // Start is called before the first frame update
    void Start()
    {
        uiScript = UI.GetComponent<UIScript>();
        magScript = mag.GetComponent<Mag>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!loaded)
        {
            loaded = true;
            Instantiate(magScript.NextBall());
        }
    }

    public void LoadBall()
    {
        loaded = false;
    }

    
}
