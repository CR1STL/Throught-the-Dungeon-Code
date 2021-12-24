using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_Control : MonoBehaviour
{
    public float xInp, zInp, yVelocity;
    public float speed;
    CharacterController cc;
    public GameObject carrot;
    public int HP = 8;
    public Animator anim;
    public Animator anim2;
    public bool IsAtak = false;
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !IsAtak)
        {
            Destroy(Instantiate(carrot, transform.position, Quaternion.identity), 0.1f);
            anim.SetBool("IsAttack", true);
            Invoke ("StopAttack", 1f);
            IsAtak = true;
        }
        xInp = Input.GetAxis("Horizontal");
        zInp = Input.GetAxis("Vertical");
        var Nor = new Vector2(xInp, zInp);
        var direction = new Vector3(Nor.x * speed, -30, Nor.y * speed) * Time.deltaTime;
        cc.Move(direction);

        if (HP <= 0)
        {
            anim2.SetBool("HeDead", true);
            Time.timeScale = 0.1f;
            Invoke("Death_2", 0.3f);
        }
    }
    private void StopAttack()
    {
        anim.SetBool("IsAttack", false);
        IsAtak = false;
    }
    public void Damage_Player()
    {
        HP_UI.instance.UpdateHealthDisplay();
        HP -= 1;
    }
    public void Death_2()
    {
        SceneAdvance.Instance.Death_Scene();
        anim2.SetBool("HeDead", false);
        Time.timeScale = 1f;
    }
    IEnumerator Attack_Player()
    {
        while (true)
        {
            anim.SetBool("IsAttack", false);
            yield return new WaitForSeconds(1f);
            anim.SetBool("IsAttack", true);
            yield return new WaitForSeconds(1f);

        }
    }
}