﻿using System.Collections;
using UnityEngine;

public class CameraControllerNan : MonoBehaviour
{
   
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;
   

    // Start is called before the first frame update
    void Start()
    {
        playerRB = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void LateUpdate()
    {

        Vector3 playerForward = (playerRB.velocity + player.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(Offset) + playerForward * (-5f), speed * Time.deltaTime);
        transform.LookAt(player);

    }



    public void ChangePlayer(Transform newPlayer)
    {
        player = newPlayer;
    }
} 

