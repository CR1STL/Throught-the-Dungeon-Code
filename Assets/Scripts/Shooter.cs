using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Shooter : MonoBehaviour
{
    public Transform target;
    public Transform objectl;
    Vector3 direction;
    public int HP = 3;
    void Update()
    {
        direction = Vector3.RotateTowards(objectl.forward, target.position - objectl.position, 1000f, 1000);
        Debug.DrawRay(objectl.position, direction, Color.red);
        objectl.rotation = Quaternion.LookRotation(direction);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(direction + objectl.position, 0.25f);
    }
    public void Shooter_Damage()
    {
        HP -= 1;
        if (HP < 1)
        {
            Destroy(gameObject);
        }
    }
}