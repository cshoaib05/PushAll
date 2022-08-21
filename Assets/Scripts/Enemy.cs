using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public Rigidbody rb;
    Vector3 tempos;
    bool ishit;
    void Start()
    {
        ishit = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < 50f && !ishit)
        {
            tempos = Vector3.MoveTowards(transform.position, player.transform.position, 5f * Time.deltaTime);
            rb.MovePosition(tempos);
            transform.LookAt(player.transform);
        }
        if (ishit)
        {

        }

    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("hit") && PlayerMovement.hitIt)
        {
            StartCoroutine(Hit());
        }
    }


    IEnumerator Hit()
    {
        ishit = true;
        rb.AddForce(-transform.forward * 30f);
        yield return new WaitForSeconds(2f);
        ishit = false;
    }
}
