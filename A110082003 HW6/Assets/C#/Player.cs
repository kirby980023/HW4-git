using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    CharacterController cc;
    public Joystick joystick;
    public float speed = 30f;
    private float timerInterval = 0.3f;
    private float passedTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        Vector3 dir = new Vector3(h, 0, v);
        
        passedTime += Time.deltaTime;

        if (dir.magnitude > 0.1f)
        {
           float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
           Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
           transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        if(!cc.isGrounded)
        {
            dir.y = -9.8f * 30 *Time.deltaTime;
        }

        if (passedTime >= timerInterval)
        {
            if (Input.GetKey(KeyCode.Space))
            {

               Instantiate(bullet, firePoint.transform.position, transform.rotation);
            }

        passedTime = 0;
        }
        
        cc.Move(dir * Time.deltaTime * 5);
    }
}
