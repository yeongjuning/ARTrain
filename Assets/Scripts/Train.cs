using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Train : MonoBehaviour
{
    float moveTime;
    Vector3 startPos;

    [Header("가속도 : m/s^2")]
    public float acceleration;
    [Header("최대 속도 : m/s")]
    public float maxVelocity;

    [SerializeField] Text txtVelocity;
    [SerializeField] Text txtPosition;

    [SerializeField] Text txtIsUpdate;
    [SerializeField] Text txtIsStop;

    public float velocity { get; set;}

    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance == null) return;
        if (false == GameManager.Instance.IsPlace) return;

        txtIsUpdate.text = "Update";
        
        if (false == GameManager.Instance.IsStop)
        {
            txtIsStop.text = "Start Train";
            velocity = Mathf.Max(maxVelocity, velocity + acceleration * Time.deltaTime);
            transform.position += transform.forward * velocity * Time.deltaTime;

            txtVelocity.text = velocity.ToString();
            txtPosition.text = transform.position.z.ToString("N3");

            moveTime += Time.deltaTime;

            if (20f <= moveTime)
            {
                //gameObject.SetActive(false);
                velocity = 0f;
                txtIsStop.text = "Stop Train";
                moveTime = 0;
            }
        }
        else
        {
            maxVelocity = 0f;
            acceleration = 0f;
            moveTime = 0f;
        }
    }

    public void ReLocation()
    {
        transform.position = startPos;
        velocity = 0;
    }

}
