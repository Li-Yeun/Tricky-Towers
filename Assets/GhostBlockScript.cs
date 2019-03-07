using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBlockScript : MonoBehaviour {

    public bool collision = false;
    public List<GameObject> CollisionBlocks = null;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            collision = true;
            if (!CollisionBlocks.Contains(other.gameObject))
            {
                CollisionBlocks.Add(other.gameObject);
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            collision = true;
            if (!CollisionBlocks.Contains(other.gameObject))
            {
                CollisionBlocks.Add(other.gameObject);
            }
        }

    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Friendly")
        {
            collision = false;
            if (CollisionBlocks.Contains(other.gameObject))
            {
                CollisionBlocks.Remove(other.gameObject);
            }
        }

    }


}
