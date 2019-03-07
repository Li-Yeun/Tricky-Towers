using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] GameObject RedBlock,BlueBlock, GhostBlocksRed, GhostBlocksBlue, DeleteBlock;
    [SerializeField] Abilities Ability;
    [SerializeField] string Player;
    [SerializeField] Transform Field;
    [SerializeField] float MinimumDistance = 2f;
    GameObject CurrentBlock, DeleteBlocks, DeletingBlock = null;
    GameObject Player1GhostBLockRed, Player1GhostBLockBlue, Player1GhostBLockCurrent;

    float timer;
    float Speed = 3f, Delay = 1f;
    bool Lock = false, Deletes = false;
	// Use this for initialization
	void Start () {
        CurrentBlock = RedBlock;
        Player1GhostBLockRed = Instantiate(GhostBlocksRed);
        Player1GhostBLockBlue = Instantiate(GhostBlocksBlue);
        DeleteBlocks = Instantiate(DeleteBlock);
        Player1GhostBLockBlue.SetActive(false);
        Player1GhostBLockCurrent = Player1GhostBLockRed;
        CheckRow(transform.position.x + 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.collider);
        }
    }
    void Update ()
    {
        if(Player == "Red")
            Player1Movement();
        else
            Player2Movement();

        CheckDeleteBlock(); 
    }

    private void Player1Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Ability.Lock == false)
            {
                if (Deletes == true)
                {
                    Player1GhostBLockCurrent.GetComponent<GhostBlockScript>().CollisionBlocks.Remove(DeletingBlock);
                    Destroy(DeletingBlock);
                    //Particles
                }
                else
                {
                    Instantiate(CurrentBlock, new Vector3(Player1GhostBLockCurrent.transform.position.x, this.transform.position.y - 2f, -0.03f), Quaternion.Euler(0, 0, 0), Field);
                }
                Ability.Lock = true;
                Ability.UsingAbility();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (CurrentBlock == RedBlock)
            {
                CurrentBlock = BlueBlock;
                Player1GhostBLockBlue.SetActive(true);
                Player1GhostBLockRed.SetActive(false);
                Player1GhostBLockCurrent = Player1GhostBLockBlue;
                CheckRow(transform.position.x + 0.5f);
            }
            else
            {
                CurrentBlock = RedBlock;
                Player1GhostBLockBlue.SetActive(false);
                Player1GhostBLockRed.SetActive(true);
                Player1GhostBLockCurrent = Player1GhostBLockRed;
                CheckRow(transform.position.x + 0.5f);

            }
        }
    }

    private void Player2Movement()
    {
        if (Lock == true)
        {
            timer += Time.deltaTime;
            if (timer >= Delay)
                Lock = false;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.up * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            CheckRow(transform.position.x + 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            if (Ability.Lock == false)
            {
                if (Deletes == true)
                {
                    Player1GhostBLockCurrent.GetComponent<GhostBlockScript>().CollisionBlocks.Remove(DeletingBlock);
                    Destroy(DeletingBlock);
                    //Particles
                }
                else
                {
                    Instantiate(CurrentBlock, new Vector3(Player1GhostBLockCurrent.transform.position.x, this.transform.position.y - 2f, -0.03f), Quaternion.Euler(0, 0, 0), Field);
                }
                Ability.Lock = true;
                Ability.UsingAbility();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (CurrentBlock == RedBlock)
            {
                CurrentBlock = BlueBlock;
                Player1GhostBLockBlue.SetActive(true);
                Player1GhostBLockRed.SetActive(false);
                Player1GhostBLockCurrent = Player1GhostBLockBlue;
                CheckRow(transform.position.x + 0.5f);
            }
            else
            {
                CurrentBlock = RedBlock;
                Player1GhostBLockBlue.SetActive(false);
                Player1GhostBLockRed.SetActive(true);
                Player1GhostBLockCurrent = Player1GhostBLockRed;
                CheckRow(transform.position.x + 0.5f);

            }
        }
    }

    public void CheckRow(float xPos)
    {
        if (xPos < 1)
        {
            Player1GhostBLockCurrent.transform.position = new Vector3(1, 5.5f, 0f);
            return;
        }
        else if (xPos > 10)
        {
            Player1GhostBLockCurrent.transform.position = new Vector3(10, 5.5f, 0f);
            return;
        }
        else
        {
            for (int i = 1; i <= 10; i++)
            {
                if (xPos > i && xPos < i + 1)
                {
                    Player1GhostBLockCurrent.transform.position = new Vector3(i, 5.5f, 0f);
                    return;
                }
            }
        }
    }

    void CheckDeleteBlock()
    {
        if(Player1GhostBLockCurrent.GetComponent<GhostBlockScript>().collision == true)
        {
            GameObject NearestBlock = null;
            float ClosestDistance = 10000f;
            foreach (GameObject Block in Player1GhostBLockCurrent.GetComponent<GhostBlockScript>().CollisionBlocks)
            {
                if (Block == null)
                    return;
                if (Mathf.Abs(this.transform.position.x - Block.transform.position.x) + Mathf.Abs(this.transform.position.y - Block.transform.position.y) < ClosestDistance)
                {
                    NearestBlock = Block;
                    ClosestDistance = Mathf.Abs(this.transform.position.x - Block.transform.position.x) + Mathf.Abs(this.transform.position.y - Block.transform.position.y);
                }
                else
                    continue;
            }

            if (ClosestDistance <= MinimumDistance)
            {
                DeleteBlocks.transform.position = NearestBlock.transform.position;
                DeleteBlocks.GetComponent<MeshRenderer>().enabled = true;
                Deletes = true;
                DeletingBlock = NearestBlock;
            }
            else
            {
                DeleteBlocks.GetComponent<MeshRenderer>().enabled = false;
                Deletes = false;
                DeletingBlock = null;
            }


        } else
        {
            DeleteBlocks.GetComponent<MeshRenderer>().enabled = false;
            Deletes = false;
            DeletingBlock = null;
        }
    }
}
