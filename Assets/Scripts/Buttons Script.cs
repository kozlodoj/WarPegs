using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    public void LoadLevel(int level)
    {
        GameManager.instance.LevelSelect(level);
    }
}
