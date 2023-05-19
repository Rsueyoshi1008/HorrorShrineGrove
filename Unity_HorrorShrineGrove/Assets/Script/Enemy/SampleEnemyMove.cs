using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleEnemyMove : MonoBehaviour
{
    private int count = 0;
    private bool flag = true;
    private Vector3 enemyMove = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count % 360 == 0)
        {
            if(flag == true)
            {
                flag = false;
            }
            else
            {
                flag = true;
            }
            
        }
        //enemyMove = (1.0f , 0.0f, 0.0f);

        transform.Translate(enemyMove * 5 * Time.deltaTime);
    }
}
