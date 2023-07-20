using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    float moveTime = 0;
    Vector3 startPos;

    [Header("가속도 : m/s^2")]
    public float acceleration;
    [Header("최대 속도 : m/s")]
    public float maxVelocity;

    public float velocity
    {
        get; set;
    }

    // Start is called before the first frame update
    void Awake()
    {
        //startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //velocity = Mathf.Max(maxVelocity, velocity + acceleration * Time.deltaTime);
        //transform.position += transform.forward * velocity * Time.deltaTime;

        //moveTime += Time.deltaTime;

        //if(30 <= moveTime)
        //{
        //    gameObject.SetActive(false);
        //    moveTime = 0;
        //}
    }

    public void ReLocation()
    {
        transform.position = startPos;
        velocity = 0;
    }

}
