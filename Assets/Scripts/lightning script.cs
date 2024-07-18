using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightningscript : MonoBehaviour
{
    public List<PegScript> pegsInRadius = new List<PegScript>();
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Peg") && collision.gameObject != gameObject.transform.parent.gameObject && collision.gameObject.GetComponent<Collider2D>().isActiveAndEnabled)
            pegsInRadius.Add(collision.gameObject.GetComponent<PegScript>());
    }
    public void ClearPegList()
    {
        pegsInRadius.Clear();
    }
    public PegScript ClosestPeg()
    {
        if (pegsInRadius.Count != 0)
        {
            var random = Random.Range(0, pegsInRadius.Count);
            return pegsInRadius[random];
        }
        else
            return null;
    }
}
