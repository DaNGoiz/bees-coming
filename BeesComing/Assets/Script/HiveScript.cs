using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveScript : MonoBehaviour
{
    public GameObject[] beesPrefab;
    public bool isBase = false; //如果是初始搭建的，就不需要生成蜜蜂了

    // Start is called before the first frame update
    void Start()
    {
        if(!isBase)
        {
            // 加分
            GameController.instance.addScores();

            int a = Random.Range(0, 4);
            if(a != 0)
            {
                int b = Random.Range(0, 10);
                if(b >= 8)// 工蜂(护盾)
                    GameController.instance.addShield();

                else if(b <= 4) // 三叉
                {
                     GameObject temp = Instantiate(beesPrefab[0], transform.position, Quaternion.identity);
                    temp.transform.parent = GameObject.Find("BeeParent").transform;
                }
                else    // 追踪
                {
                    GameObject temp = Instantiate(beesPrefab[1], transform.position, Quaternion.identity);
                    temp.transform.parent = GameObject.Find("BeeParent").transform;
                }
            }




            
        }

    }
}
