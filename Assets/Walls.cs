using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour {

    [SerializeField] PlayerMovement[] Players;
    [SerializeField] Arrow arrow;
    int[] Rotations = { 90, 180, -90 };
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)|| Input.GetKeyDown(KeyCode.M))
        {
            if (arrow.Lock == true)
                return;

            int i = Random.Range(0, 3);
            if (i == 0)
            {
                arrow.RotateArrow(Rotations[2]);
            } else if (i == 2)
            {
                arrow.RotateArrow(Rotations[0]);
            } else
            {
                arrow.RotateArrow(Rotations[1]);
            }
            
            transform.RotateAround(new Vector3(5.5f, 5.5f, 0), Vector3.forward, Rotations[i]);  
            foreach(PlayerMovement player in Players)
            {
                player.CheckRow(player.gameObject.transform.position.x + 0.5f);
            }
        }

	}
}
