using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public bool isOcupied;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOcupied = true;
        Debug.Log(isOcupied);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOcupied = false;
        Debug.Log(isOcupied);
    }


}
