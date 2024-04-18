using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mag : MonoBehaviour
{
   
    [SerializeField]
    private GameObject ballLouncher;
    private BallLauncher louncherScript;

    [SerializeField]
    private List<GameObject> slots = new List<GameObject>();

    [SerializeField]
    private List<GameObject> ballPrefabs = new List<GameObject>();

    private List<GameObject> ballsInMag = new List<GameObject>();

    [SerializeField]
    private GameObject UI;
    private UIScript uiScript;

    private int magSize = 3;

    public bool cocked = false;

    private float timePassed;
    // Start is called before the first frame update
    void Start()
    {
        uiScript = UI.GetComponent<UIScript>();
        louncherScript = ballLouncher.GetComponent<BallLauncher>();
        //FillMag();


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
