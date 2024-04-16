using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
   
    [SerializeField]
    private List<GameObject> ballPrefabs = new List<GameObject>();

    private List<GameObject> ballsInMag = new List<GameObject>();

    private int magSize = 3;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < magSize; i++)
        ballsInMag.Add(RandomBall());

        
    }

    private GameObject RandomBall()
    {
        GameObject ball;
        ball = ballPrefabs[RandomNum(ballPrefabs.Count)];

        return ball;
    }

    private int RandomNum(int maxNum)
    {
        return Random.Range(0, maxNum);

    }

    public GameObject NextBall()
    {
        GameObject nextBall = ballsInMag[0];
        ballsInMag.RemoveAt(0);

        return nextBall;
    }

    public void AddBall(GameObject ball)
    {
        ballsInMag.Add(ball);
    }
}
