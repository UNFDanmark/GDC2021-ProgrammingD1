using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject tank;
    public float moveSpeed;


    Transform followerTransform;

    // Update is called once per frame
    void Update()
    {
        Follow();

    }

    void Follow()
    {
        // Finder afstanden og retningen til tanken.
        Vector3 direction = tank.GetComponent<Transform>().position - followerTransform.position;
        Vector3 movement = direction.normalized * moveSpeed * Time.deltaTime;
        followerTransform.Translate(movement, Space.World);

        //Kig på tanken
        followerTransform.LookAt(tank.GetComponent<Transform>());
    }
}
