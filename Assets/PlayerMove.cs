using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    private CharacterController controller;
    private Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 8.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        controller.detectCollisions = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        if (Input.GetAxis("Horizontal") > 0)
        {   
            animator.Play("leftStrafe");
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            animator.Play("rightStrafe");
        }
        else if ((playerVelocity.y <= 0) && (Globals.endCondition == false))
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                animator.Play("crawling");
                
                if (controller.center.y == 0.92f)
                {
                    controller.center  = new Vector3(0, 0.24F, 0);
                    controller.height = 0.57f;
                }
            }
            else
            {
                animator.Play("running");
                if (controller.center.y  < 0.92f)
                {
                    controller.center = new Vector3(0, 0.92F, 0);
                    controller.height = 1.69f;
                }
            }
            // animator.Play("running");
        }
        transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if ((Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow)) && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            animator.Play("jumping");
        }

        

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.transform.parent.gameObject.tag == "Wall")
        {
            Globals.endCondition = true;
            Debug.Log("YOU LOSEEEEEE");
            animator.Play("dying");
            StartCoroutine(CloseAfterTime(5f));
        }
    }

    public IEnumerator CloseAfterTime(float t)
    {
        yield return new WaitForSeconds(t);
        Globals.endCondition = false;
        SceneManager.LoadScene(0);
    }
}
