using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour {

    [SerializeField] GameObject Wall;
    [SerializeField] Transform WallParent;
    // Use this for initialization
    void Start () {
		for(int r = 0; r<12; r++)
            for (int c = 0; c<12; c++)
            {
                if(r == 0 || r == 11 || c == 0 || c == 11)
                    Instantiate(Wall, new Vector3(r, c, 0), Quaternion.Euler(0, 0, 0), WallParent);
            }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
