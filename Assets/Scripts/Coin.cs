using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{ 
    public float speed;
    private Transform coinCollector;
    private Vector3 counter;
    // Start is called before the first frame update
    void Start()
    {
        coinCollector = GameObject.Find("TOW").gameObject.transform.Find("Coin Collector").gameObject.transform;
        counter = GameObject.Find("UI").GetComponent<UIScript>().counterPosition;
        StartCoroutine(GoToCollector());
    }

    private IEnumerator GoToCollector()
    {
        transform.DOMove(CollectorWithRandomOffset(), speed).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(speed);
        StartCoroutine(GoToCounter());
    }
    private IEnumerator GoToCounter()
    {
        transform.DOMove(counter, speed).SetEase(Ease.OutExpo);
        yield return new WaitForSeconds(speed);
        Destroy(gameObject);
        
    }
    private Vector3 CollectorWithRandomOffset()
    {
        return new Vector3(coinCollector.position.x + Random.Range(-1f, 1f), coinCollector.position.y, coinCollector.position.z);
    }
}
