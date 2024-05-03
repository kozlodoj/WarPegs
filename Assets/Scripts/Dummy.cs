using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    public int contacts;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        contacts++;
    }
}
