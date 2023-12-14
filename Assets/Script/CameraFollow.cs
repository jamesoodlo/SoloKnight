using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    InputHandle inputHandle;
    public float speed;
    public Transform target;
    public float smoothTime = 0.3f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    void Awake() 
    {
        inputHandle = GetComponent<InputHandle>();
    }
    void Update()
    {
        Vector3 movement = new Vector3(inputHandle.camMove.x, 0f, inputHandle.camMove.y);

        if (movement != Vector3.zero && target != null)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
        }
        else
        {
            if(target != null)
            {
                Vector3 targetPosition = target.position + offset;

                transform.position = Vector3.SmoothDamp(transform.position , targetPosition, ref velocity, smoothTime);
            }
        }
        
    }
}
