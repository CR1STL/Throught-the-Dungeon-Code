using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class Next_LVL : MonoBehaviour
{
    public Collider collider1;
    public static int score;
    public int curScore;
    public Animator anim;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneAdvance.Instance.LoadNextScene();
        }
    }
    void Start()
    {
        collider1 = GetComponent<BoxCollider>();
        score = curScore;
    }
    private void Update()
    {
        if (score <= 0)
        {
            collider1.isTrigger = true;
            anim.SetBool("IsOpen", true);
        }
        else
        {
            collider1.isTrigger = false;
        }
    }
    public static void GetScore()
    {
        score--;
    }
}