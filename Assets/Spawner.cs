using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField] List<GameObject> Shapes;
    int TotalShape;
	void Start () {
        TotalShape = Shapes.Count;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Shapes[Random.Range(0, TotalShape)]);
        }
	}
}
