using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Block : MonoBehaviour {

    [SerializeField] float MaxMovement;
    public bool Collision = false;
    public List<GameObject> Player = null;
    Vector3 currentPos, prevPos;
    private void Start()
    {
        currentPos = this.transform.position;
    }
    void Update ()
    {
        prevPos = currentPos;
        currentPos = this.transform.position;
        if(prevPos == currentPos)
        {
            return;
        } else if(Collision == true)
        {
            if (Mathf.Abs(currentPos.x - prevPos.x) + Mathf.Abs(currentPos.y - prevPos.y) >= MaxMovement)
            {
                foreach (GameObject player in Player)
                {
                    player.GetComponentInChildren<ParticleSystem>().startColor = this.GetComponent<Renderer>().material.color;
                    player.GetComponentInChildren<ParticleSystem>().Play();
                    player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    player.GetComponent<Rigidbody>().useGravity = true;
                    player.GetComponent<Rigidbody>().freezeRotation = false;
                    player.GetComponent<PlayerMovement>().LockMovement = true;
                }
                Invoke("Reset", 2f);
            }
        }

    }

    private void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collision = true;
            if (!Player.Contains(collision.gameObject))
            {
                Player.Add(collision.gameObject);
            }
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collision = true;
            if (!Player.Contains(collision.gameObject))
            {
                Player.Add(collision.gameObject);
            }
        }
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Collision = false;
            if (!Player.Contains(collision.gameObject))
            {
                Player.Remove(collision.gameObject);
            }
        }
    }


}
