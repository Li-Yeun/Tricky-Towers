using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    [SerializeField] PlayerMovement[] Players;
    int[] Rotations = { 90, 180, 270 };
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            int i = Random.Range(0, 3);
            transform.RotateAround(new Vector3(5.5f, 5.5f, 0), Vector3.forward, Rotations[i]);  
            foreach(PlayerMovement player in Players)
            {
                player.CheckRow(player.gameObject.transform.position.x + 0.5f);
            }
        }

	}
}
