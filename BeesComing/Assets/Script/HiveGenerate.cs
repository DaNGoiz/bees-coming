using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveGenerate : MonoBehaviour
{    
    public GameObject hivePrefab;
    public Sprite[] sprites;
    public float timeSpeed = 1f;    // 工蜂的加速
    public float buildDelta = 0.5f; // 按住多少秒升级一次

    float timeVar = 0f; // 计时 按住空格
    bool isPlayer = false;
    SpriteRenderer spriteRenderer;
    int curIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[curIndex++];
    }

    // Update is called once per frame
    void Update()
    {

        if(isPlayer && Input.GetKey(KeyCode.Space))
        {
            timeVar += Time.deltaTime * timeSpeed;
            
            if(timeVar >= buildDelta)
            {
                SoundManager.instance.BuildAudio();
                spriteRenderer.sprite = sprites[curIndex++];
                timeVar = 0;
            }
            // isPlayer = false;
        }
        if(curIndex >= 5)
        {
            GameObject temp = Instantiate(hivePrefab, transform.position, Quaternion.identity);
            temp.transform.parent = GameObject.Find("HiveParent").transform;
            Destroy(this.gameObject);
        }
    }

    
    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}
