using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Enemy : MonoBehaviour
{
    public float speed1;
    public float speed2;
    private Transform player;
    public Animator anim;
    public int HP = 3;
    bool canDamage = false;
    private float nextActionTime = 1f;
    public float nextUpdate = 0.9f;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, speed1 * Time.deltaTime);
        if (canDamage)
        {
            anim.SetBool("IsHere", true);
            speed1 = 0;
        }
        else
        {
            anim.SetBool("IsHere", false);
            speed1 = speed2;
        }
        if (Time.time >= nextUpdate)
        {

            nextUpdate = Mathf.FloorToInt(Time.time) + 1;

            Atack();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canDamage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canDamage = false;
        }
    }
    public void Damage()
    {
        HP -= 1;
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    public void Atack()
    {
        if (canDamage)
        {
            player.GetComponent<Player_Control>().Damage_Player();
        }
    }
}