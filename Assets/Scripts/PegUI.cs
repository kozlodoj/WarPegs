using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PegUI : MonoBehaviour
{
    private TextMeshProUGUI buffText;

    private bool scale = false;
    

    // Start is called before the first frame update
    void Start()
    {
        buffText = gameObject.transform.Find("BuffText").GetComponent<TextMeshProUGUI>();
       
    }

    private void Update()
    {
        ScaleText();
    }

    public void BuffText(float amount)
    {
        buffText.SetText("+ " + amount.ToString());
        scale = true;
       
    }
    private void ScaleText()
    {
        if (scale)
            buffText.transform.localScale += new Vector3(Time.deltaTime * 5f, Time.deltaTime * 5f, 0);
    }
    public void ResetScale()
    {
        
            scale = false;
            buffText.transform.localScale = new Vector3(1, 1, 1);
            buffText.SetText(" ");
       
        
    }


}
