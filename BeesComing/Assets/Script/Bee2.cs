using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee2 : MonoBehaviour
{
    public GameObject sting2Prefab;
    public float attackDelta = 1f;
    // public int bulletNum = 3;
    // public float bulletAngle = 30;

    float accumulateTime = 0;
    AudioSource audioSource;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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

    // 发射追踪刺
    void Attack()
    {
        Vector3 ATKdot = transform.GetChild(0).position;
        GameObject sting2 = Instantiate(sting2Prefab, ATKdot, Quaternion.Euler(transform.eulerAngles));
        sting2.transform.parent = GameObject.Find("StingParent").transform;
        // sting2.transform.parent = this.transform;
    }
}
