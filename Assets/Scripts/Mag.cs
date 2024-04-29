using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
   
    [SerializeField]
    private List<GameObject> slots = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ballPrefabs = new List<GameObject>();

    private List<GameObject> ballsInMag = new List<GameObject>();

    private int magSize = 3;

    public bool cocked = false;

    private float timePassed;
    
    void Start()
    {

    }
    private void Update()
    {
        timePassed += Time.deltaTime;
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

    private void FillMag()
    {
        for (int i = 0; i < magSize; i++)
        {   
            ballsInMag.Add(Instantiate(RandomBall(), slots[i].transform.position, slots[i].transform.rotation));
        }
    }

    public Vector3 FirstSlotPosition()
    {
        return slots[0].transform.position;
    }

    public void MoveNext()
    {
        ballsInMag[1].transform.position = slots[0].transform.position;
    }

    public void NewBall()
    {
        Instantiate(RandomBall(), slots[2].transform.position, slots[2].transform.rotation);
    }
}
