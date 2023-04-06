using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    float multi = 12.5f;

    private void Start() {
        rb = GetComponent<Rigidbody>();
       
    }
    void GoRight() {
        // rb.AddForce(Vector3.right* multi);
        rb.velocity = new Vector3(multi, rb.velocity.y, rb.velocity.z);

    }
    void GoLeft() {
        //rb.AddForce(Vector3.left * multi);
        rb.velocity = new Vector3(-multi, rb.velocity.y, rb.velocity.z);
    }

    void NoGo() {
        rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
    }
    public bool canJump = true;

    void Jump() {
        if (!canJump) return;
        Debug.Log("jump");
        rb.AddForce(Vector3.up * 750);
        canJump = false;
        Invoke("CanJumpAgain", 1.25f);
    }

    void CanJumpAgain() {
        canJump = true;
    }

    private void Update() {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 20f);

        if (Input.GetKey(KeyCode.A)) GoLeft();
        else if (Input.GetKey(KeyCode.D)) GoRight();
        else NoGo();
        if (Input.GetKeyDown(KeyCode.Space)) Jump();


        Vector3 dir = Vector3.zero;
        dir.x = Input.acceleration.x;
        dir.y = Input.acceleration.y;

        if (dir.sqrMagnitude > 1) dir.Normalize();

        dir *= Time.deltaTime;

        rb.velocity = new Vector3(dir.x * multi, rb.velocity.y, rb.velocity.z);
    }


}
