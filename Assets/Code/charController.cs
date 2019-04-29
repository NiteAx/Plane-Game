using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class charController : MonoBehaviour
{
    public float speed = 12.0F;
    public float minSpeed = 10.0F;
    public float acc = 5.0F; // This is how fast it will accelerate.
    public float maxSpeed = 20.0F; // This is the players maximum speed.
    private float yaw, pitch, roll = 0.0F;
    public float pitchSensitivity = 1.0F; 
    public float rollSensitivity = 1.0F;
    public float yawSensitivity = 0.15F;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        yaw = yawSensitivity * Input.GetAxis("Yaw") * Time.deltaTime *10* acc;
        pitch = pitchSensitivity * Input.GetAxis("Vertical") * Time.deltaTime *10* acc;
        roll = rollSensitivity * Input.GetAxis("Horizontal") * Time.deltaTime *10* acc;
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;
        if (speed <= minSpeed)
            speed = minSpeed;
        else if (speed >= maxSpeed)
            speed = maxSpeed;
        speed += Input.GetAxis("Acceleration") * Time.deltaTime * acc;
        if (transform.position.y <= 1.7F){
            rot.z = 0;
            transform.rotation=rot;
        }    
        if (transform.position.y <= 1.0F){
            pos.y = 1.0F;
            speed-=1.0F;
            if (rot.x > 0 && rot.w > 0)
                rot.x = 0;
            if (rot.x < 0 && rot.w < 0)
                rot.x = 0;
            transform.position=pos;
            transform.rotation=rot;
            speed-=acc/2*Time.deltaTime;
        }
        transform.position+=transform.forward * Time.deltaTime * speed * speed;
        transform.Rotate(pitch, yaw, -roll);
        Debug.Log("Rot: "+rot+" Pos: "+pos);
    }
}
