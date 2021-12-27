using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Player_Authors : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
    }
}