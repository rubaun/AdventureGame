using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoMove : MonoBehaviour
{
    public float speed = 0.01f;
    public float posX;
    public float posY;
    public float limitX = -14.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if(transform.position.x < limitX)
        {
            transform.position = new Vector3(posX, posY, 0);
        }
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
    }
}
