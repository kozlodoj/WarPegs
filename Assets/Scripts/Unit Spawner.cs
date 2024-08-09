using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;
    [SerializeField]
    private int unitNum;
    [SerializeField]
    private Transform spawnPoint;
    private Flash flash;
    private TowManager towManager;

    private bool reactivateOnSpawn;

    private PegManager pegs;

    private Freeze freezeScript;
    private Animator animator;

    public bool isEvent;
    private void Start()
    {
        if (GameManager.instance.storyMode && !isEvent)
        {
            if (unitNum == 2 && !GameManager.instance.isUnitTwoActive)
            {
                gameObject.SetActive(false);
            }
            if (unitNum == 3 && !GameManager.instance.isUnitThreeActive)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (unitNum == 2 && !EventManager.instance.isUnitTwoActive)
            {
                gameObject.SetActive(false);
            }
            if (unitNum == 3 && !EventManager.instance.isUnitThreeActive)
            {
                gameObject.SetActive(false);
            }
        }
        animator = gameObject.GetComponent<Animator>();
        GameObject sPoint = GameObject.FindWithTag("Unit Spawn Point");
        spawnPoint = sPoint.transform;
        flash = sPoint.GetComponent<Flash>();
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        reactivateOnSpawn = GameManager.instance.reactivatePegsOnSpawn;
        pegs = GameObject.FindWithTag("Peg Layout").gameObject.GetComponent<PegManager>();
        if (GameManager.instance.isPerkOneActive)
        freezeScript = GameObject.FindGameObjectWithTag("Freeze").GetComponent<Freeze>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("animate", true);
            Vibration.VibratePeek();
            flash.FlashStart();
            GameObject newUnit = Instantiate(unitPrefab, spawnPoint) as GameObject;
            newUnit.GetComponent<Unit>().Buff(collision.gameObject.GetComponent<Ball>().GetBuff());
            towManager.UpdateUnitList(newUnit);
            if (unitNum == 3)
                StartCoroutine(pegs.ReactivateDome());
            if (!isEvent)
            CheckDaily(collision.gameObject);
        }
    }
    public void VibrateandAnimationStop()
    {
        animator.SetBool("animate", false);
        
    }
    private void CheckDaily(GameObject collision)
    {
        if (collision.gameObject.GetComponent<Ball>().GetBuff() >= 2f)
        {
            GameManager.instance.buffGathered = 1;
            GameManager.instance.ManageDaily();
        }
        if (reactivateOnSpawn)
            pegs.ReactivatePegs();
        if (GameManager.instance.freezeGame)
        {
            GameManager.instance.UnFreezeTow();
            if (freezeScript != null)
                freezeScript.ResetFreeze();
        }
        if (unitNum == 2)
        {
            GameManager.instance.unitTwoSpawned++;
            GameManager.instance.ManageDaily();
        }
        else if (unitNum == 3)
        {
            GameManager.instance.unitThreeSpawned++;
            GameManager.instance.ManageDaily();
        }
    }
}
