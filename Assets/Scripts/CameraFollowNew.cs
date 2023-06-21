using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowNew : MonoBehaviour
{
    
        public GameObject Player;
        public GameObject child;
        public float speed;

        private void Awake()
        {
            
            child = Player.transform.Find("camera constraint").gameObject;
        }

        private void FixedUpdate()
        {
            follow();
        }
        private void follow()
        {

            gameObject.transform.position = Vector3.Lerp(transform.position, child.transform.position, Time.deltaTime*speed);
            gameObject.transform.LookAt(Player.gameObject.transform.position);
        }


        public void ChangePlayer(GameObject newPlayer)
        {
            Player = newPlayer;
            child = Player.transform.Find("camera constraint").gameObject;
    }
 }

