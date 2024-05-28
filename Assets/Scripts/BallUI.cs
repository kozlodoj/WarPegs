using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallUI : MonoBehaviour
{
    [SerializeField]
    private Image chargeBar;
    [SerializeField]
    private GameObject charger;
    [SerializeField]
    private TextMeshProUGUI buffText;
    [SerializeField]
    private TextMeshProUGUI buffTextOutline;


    private Transform ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, -ball.rotation.z);
    }

    public void SetCharge(float amount)
    {
        chargeBar.fillAmount = 1f - amount;
    }
    public void DisactivateChargebar()
    {
        charger.SetActive(false);
    }
    public void SetBuffText(float amount)
    {
        if (amount != 0)
        {
            buffText.SetText(amount.ToString());
            buffTextOutline.SetText(amount.ToString());
        }
    }
}
