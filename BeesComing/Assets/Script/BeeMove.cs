using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMove : MonoBehaviour
{
    public float radius = 5f;
    public float speed = 1f;
    public float moveDeltaTime = 5f;

    float timeVal = 0;
    Rigidbody2D rigidb;

    // Start is called before the first frame update
    void Start()
    {
        rigidb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        timeVal += Time.deltaTime;
        BeeFly();
    }

    
    // 检测范围圈，检测到检测到玩家就远离
    void BeeFly()
    {
       LayerMask mask = 1 << 8;
       // 检测玩家并避开
       Collider2D playerHit = Physics2D.OverlapCircle(transform.position, radius, mask);
       if(playerHit)
       {
            Vector3 direction = (transform.position - playerHit.transform.position).normalized;
            // transform.Translate(direction * speed * Time.deltaTime);
            rigidb.velocity = direction * speed;
       }

        
        Collider2D playerHit2 = Physics2D.OverlapCircle(transform.position, radius * 3.5f, mask);
        if(!playerHit2)
        {
            Vector3 direction = (GameObject.Find("Player").transform.position - transform.position).normalized;
            rigidb.velocity = direction * speed;
        }

        if(timeVal >= moveDeltaTime)
        {
            Vector3 temp = Random.insideUnitCircle * 5 * speed;
            // transform.Translate(temp * Time.deltaTime);
            rigidb.velocity = temp;
            timeVal = 0;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.DrawWireSphere(transform.position, radius * 3.5f);
    }

}
