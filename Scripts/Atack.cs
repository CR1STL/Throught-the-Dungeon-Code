using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Atack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fighter")
        {
            other.GetComponent<Enemy>().Damage();
            Destroy(gameObject);
            Next_LVL.GetScore();
        }
        if (other.tag == "Archer")
        {
            other.GetComponent<Archer>().Archer_Damage();
            Destroy(gameObject);
            Next_LVL.GetScore();
        }
    }
    public void Destroy_Zone()
    {
        Destroy(gameObject);
    }
}