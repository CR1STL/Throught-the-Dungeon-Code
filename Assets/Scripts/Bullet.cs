using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            GameObject.Find("Player").GetComponent<Player_Control>().Damage_Player();
        }
        if (other.tag == "Fighter")
        {
            Destroy(gameObject);
            GameObject.Find("Fighter").GetComponent<Enemy>().Damage();
        }
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}