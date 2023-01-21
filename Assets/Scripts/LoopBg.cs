using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class LoopBg : MonoBehaviour
{
    [SerializeField] public  float speed = 1f;
    [SerializeField]  float range = 1f;
    [SerializeField]  float maxPosition = -37f;
    [SerializeField]  float newPosition = 58f;
    public bool IsMove = false;

    void Update()
    {
        //move();
        if (IsMove)
            move();
        Stop();

        if (transform.position.z <= maxPosition)
        {
            transform.position = new Vector3(0, 0, newPosition);
        }
        
    }

    public void move()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void Stop()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

}
