using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{

    public PlayerMovement movement;
    public GameObject gate;
    public Animator animator;

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.collider.tag == "Enemy")
        {
            movement.enabled = false;
            gate.SetActive(false);
            animator.SetBool("Dead", true);
            Invoke("Restart", 1f);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
