using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameObject.GetComponent<Camera>().orthographicSize = GameManager.instance.cameraScale;
        transform.position = GameManager.instance.cameraYoffset;
    }

}
