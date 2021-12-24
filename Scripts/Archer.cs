using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Archer : MonoBehaviour
{
    public Transform target;
    public Transform objectl;
    public Transform bow;
    Vector3 direction;
    public int HP = 3;
    public GameObject Bullet;
    void Update()
    {
        direction = Vector3.RotateTowards(objectl.forward, target.position - objectl.position, 1000f, 1000);
        Debug.DrawRay(objectl.position, direction, Color.red);
        objectl.rotation = Quaternion.LookRotation(direction);
        objectl.LookAt(target);
        objectl.eulerAngles += Vector3.up * 90f;
        objectl.eulerAngles = new Vector3(0, objectl.eulerAngles.y, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(direction + objectl.position, 0.25f);
    }
    public void Archer_Damage()
    {
        HP -= 1;
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Instantiate(Bullet, objectl.transform.position, objectl.transform.rotation);
        }
    }
    void Start()
    {
        StartCoroutine("Attack");
    }
}