using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void FlashStart()
    {
        animator.SetBool("spawn", true);
    }
    public void FlashStop()
    {
        animator.SetBool("spawn", false);
    }
   
}
