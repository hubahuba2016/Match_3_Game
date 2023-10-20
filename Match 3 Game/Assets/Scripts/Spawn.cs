using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public int total_width = 5;
    public int total_height = 5;
    public GameObject background;
    public GameObject blue_block;
    public GameObject yellow_block;
    public GameObject red_block;
    int random_object;
    // Start is called before the first frame update
    void Start()
    {
        for(var i=0; i<total_width;i++)
        {
            for(var j = 0; j< total_height; j++)
            {
                Instantiate(background, new Vector3((float)i, (float)j, 1f), Quaternion.identity);
                random_object = Random.Range(0, 3);
                if(random_object==0)
                {
                    Instantiate(blue_block, new Vector3((float)i, (float)j, 0f), Quaternion.identity);
                    Debug.Log("Blue block is at " + i + "," + j);
                }
                else if(random_object==1)
                {
                    Instantiate(yellow_block, new Vector3((float)i, (float)j, 0f), Quaternion.identity);
                    Debug.Log("Yellow block is at " + i + "," + j);
                }
                else if(random_object==2)
                {
                    Instantiate(red_block, new Vector3((float)i, (float)j, 0f), Quaternion.identity);
                    Debug.Log("Red block is at " + i + "," + j);
                }
                else
                {
                    Debug.Log("random object error");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
