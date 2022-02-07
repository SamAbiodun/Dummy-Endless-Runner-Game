using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody rb;
    private float horizontalInput;
    public float horizontalMultiplier = 1.7f;

    bool alive = true;

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        Vector3 moveForward = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveForward);

        Vector3 moveSideways = transform.right * horizontalInput *horizontalMultiplier* speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveForward + moveSideways);
    }


    // Update is called once per frame
    void Update()
    {
       horizontalInput = Input.GetAxis("Horizontal");
    }

    public void Die()
    {
        alive = false;
        //restart the game
        Invoke("Restart", 1.5f);
      
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
