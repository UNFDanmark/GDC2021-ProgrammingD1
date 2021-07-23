using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public float speed;
    public float RotateSpeed;
    public float bulletSpeed;
    public float reloadTime;

    public GameObject bulletObj;


    Transform trans;




    float timeLastFired;

    // Start is called before the first frame update
    void Start()
    {
        trans = gameObject.GetComponent<Transform>();

        timeLastFired = 0;


        Physics.IgnoreLayerCollision(6, 7, true);

        
    }

 

    // Update is called once per frame
    void Update()
    {

        

        if (Input.GetKeyDown(KeyCode.Mouse0)){

            bool reloadTimeHasPassed = Time.time >= timeLastFired + reloadTime;

            if (reloadTimeHasPassed)
            {
                Shoot();
            }
        }

    }

    private void FixedUpdate()
    {
        moveHandler();


    }

    void moveHandler() {

        Rigidbody tankRB = gameObject.GetComponent<Rigidbody>();

        if (Input.GetKey("w"))
        {
            tankRB.velocity = gameObject.GetComponent<Transform>().forward * speed;
        }
        if (Input.GetKey("d"))
        {
            tankRB.AddTorque(new Vector3(0, 1, 0) * RotateSpeed);
        }
        if (Input.GetKey("a"))
        {
            tankRB.AddTorque(new Vector3(0, -1, 0) * RotateSpeed);
        }


        /* Transform.translate movement

        if (Input.GetKey("w"))
        {
            Vector3 direction = gameObject.GetComponent<Transform>().forward;
            tankTransform.Translate(direction, Space.Self);
        }
        if (Input.GetKey("d"))
        {
            tankTransform.Rotate(new Vector3(0, 20, 0));
        }
        if (Input.GetKey("a"))
        {
            tankTransform.Rotate(new Vector3(0, -20, 0));
        }
        */
    }


    public void Shoot()
    {
        timeLastFired = Time.time;

        GameObject bullet = Instantiate(bulletObj, trans.position, trans.rotation);
        bullet.GetComponent<Rigidbody>().velocity = trans.forward * bulletSpeed;
    }

}
