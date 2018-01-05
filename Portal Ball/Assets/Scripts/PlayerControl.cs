using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 0.0f;
    private Rigidbody rb;
    public GameObject deathParticles;
    Vector3 spawnLoc;

	// Use this for initialization
	void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawnLoc = transform.position;
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        rb.AddForce(movement * playerSpeed);

        // Check if the player has fallen off the world 
        if (transform.position.y < -150.0f)
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            TheGameManager.instance.IncrementDeath(1);
            this.gameObject.SetActive(false);
            Invoke("KillPlayer", 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            FindObjectOfType<AudioControl>().PlayAudioFile("CollectableSound");
            TheGameManager.instance.IncrementPlayerScore(1);
        }

        if (other.CompareTag("Enemy"))
        {
            Instantiate(deathParticles, transform.position, transform.rotation);
            TheGameManager.instance.IncrementDeath(1);
            this.gameObject.SetActive(false);
            Invoke("KillPlayer", 2.0f);
        }
    }

    void KillPlayer()
    {
        this.gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        transform.position = spawnLoc;
    }
}
