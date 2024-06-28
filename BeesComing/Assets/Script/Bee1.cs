using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee1 : MonoBehaviour
{
    public GameObject sting1Prefab;
    public float attackDelta = 1f;
    public int bulletNum = 3;
    public float bulletAngle = 30;

    float accumulateTime = 0;
    Transform playerPos;
    Animator animator;
    AudioSource audioSource;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        playerPos = GameObject.Find("Player").transform;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        accumulateTime += Time.deltaTime;

        if(accumulateTime >= attackDelta)
        {
            animator.SetBool("isAttack", true);
            Attack();
            accumulateTime = 0;
            animator.SetBool("isAttack", false);
            audioSource.Play();
        }
    }

    // 发射三叉刺
    void Attack()
    {
        Vector3 ATKdot = transform.GetChild(0).position;
        Vector3 direction = (playerPos.position - ATKdot).normalized;

        int medium = bulletNum / 2;
        for(int i = 0; i < bulletNum; i++)
        {
            GameObject sting = Instantiate(sting1Prefab, ATKdot, Quaternion.Euler(transform.eulerAngles));
            sting.transform.parent = GameObject.Find("StingParent").transform;
            sting.transform.Rotate(this.transform.rotation.eulerAngles);

            if(bulletNum % 2 == 1)
                sting.GetComponent<Sting1>().SetDirection(Quaternion.AngleAxis(bulletAngle * (i - medium), Vector3.forward) * direction);
            else
                sting.GetComponent<Sting1>().SetDirection(Quaternion.AngleAxis(bulletAngle * (i - medium) + bulletAngle / 2, Vector3.forward) * direction);

        }



   
    }
}
