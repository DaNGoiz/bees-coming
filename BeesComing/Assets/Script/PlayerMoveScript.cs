using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public GameObject hiveGeneratePrefab;
    public GameObject preHive;
    public float speed = 1.0f;
    public float sprintSpeed = 20.0f;
    public float pullPower = 10f;


    GameObject preHiveIsExist;
    Vector3 currentHive;
    Vector3 direction;
    Rigidbody2D rb;
    Animator animator;
    AudioSource audioSource;
    float stopX = 0, stopY = 0;
    int[] a = new int[2];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        direction = Vector3.zero;
        currentHive = Vector3.zero;

        a[0] = 1;
        a[1] = -1;

    }


    // Update is called once per frame
    void Update()
    {
        MovePlayer();

        PreBuildHive();
        GenerateHive();

    }

    void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0 || y != 0)
        {
            animator.SetBool("isMoving", true);
            stopX = x;
            stopY = y;
            audioSource.UnPause();
        }
        else
        {
            animator.SetBool("isMoving", false);            
            audioSource.Pause();
        }
        animator.SetFloat("dirX", stopX);
        animator.SetFloat("dirY", stopY);

        LayerMask mask = ~(1 << 8) & ~(1 << 6);
        // 判断是否在平台内
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position - new Vector3(0, 1, 0) + new Vector3(x, y, 0) * .5f, .1f, mask);
        if(hits.Length == 0)
        {
            x = 0; y = 0;
            // print("Can not move");
        }

        transform.Translate(new Vector3(x, y, 0) * speed * Time.deltaTime);

        if(x != 0 || y != 0)
            direction = new Vector3(x, y, 0);
    }

    // 用于测试平台是否能限制住玩家
    // private void OnDrawGizmos() 
    // {
    //     Gizmos.color = Color.yellow;
    //     // Gizmos.DrawSphere(transform.position - new Vector3(0, 1, 0) + new Vector3(x, y, 0) * 0.2f, .1f);
    //     // Gizmos.DrawSphere(temp, .2f);
    // }


    // 建造蜂巢之前预先出现虚框
    void PreBuildHive()
    {
        // temp计算下一个虚线蜂巢块的位置
        Vector3 temp = direction;
        if(direction.y == 0)
            temp += new Vector3(direction.x, 0, 0);
        if(direction.x == 0)
            temp += new Vector3(a[Random.Range(0, 2)],0 , 0);
        //     return;
        temp += currentHive;


        LayerMask mask = ~(1 << 8) & ~(1 << 6);
        // 生成对象前判断该点是否已经存在方块
        Collider2D[] hits = Physics2D.OverlapCircleAll(temp, .2f);
        
        if(!preHiveIsExist && hits.Length == 0)// && !Physics.Raycast(Camera.main.transform.position, dir.normalized, out hit, 100f))
        {
            // print(hit.collider.name);
            preHiveIsExist = Instantiate(preHive, temp, Quaternion.identity);
            Destroy(preHiveIsExist, .2f);
        }
    }

    void GenerateHive()
    {
        if(Input.GetKeyDown(KeyCode.Space) && preHiveIsExist)
        {
            GameObject temp = Instantiate(hiveGeneratePrefab, preHiveIsExist.transform.position, Quaternion.identity);
            temp.transform.parent = GameObject.Find("HiveParent").transform;
        }
    }
    private void OnTriggerStay2D(Collider2D other) 
    {
        // canMove = true;
        if(other.CompareTag("Hive"))
            currentHive = (Vector2)other.transform.position;
    }


}
