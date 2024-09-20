using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float jumpHeight = 15;
    [SerializeField] float speed = 5;
    [SerializeField] int jumpLevel;
    [SerializeField] int jumpLevelIncrement = 1;

    private int maxJumpLevel = 10;
    private int maxJumpHeight = 15;
    private Rigidbody rb;
    private CustomGravity gravity;

    private RaycastHit hit;
    private RaycastHit hit2;
    private RaycastHit hit3;
    private RaycastHit hit4;
    private RaycastHit hit5;

    [SerializeField] float idleTimerMax = 0.2f;
    [SerializeField] float idleTimer = 0;
    [SerializeField] Vector3 previousPosition;

    [SerializeField] float jumpTimer;
    [SerializeField] float jumpTimerMax;

    [SerializeField] JumpTrigger jumpTrigger;

    public bool isDying;
    public Vector3 deathCoordinates;

    [SerializeField] Quaternion startingRotation;
    private Quaternion rightRotation = new Quaternion(0, 135, 0, 0);
    private Quaternion leftRotation = new Quaternion(0, 225, 0, 0);



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        gravity = GetComponent<CustomGravity>();
        jumpLevel = maxJumpLevel;

        previousPosition = transform.position;
        startingRotation = transform.rotation;
    }

    private void Update()
    {

        if (isDying)
        {
            transform.position = deathCoordinates;
            return;
        }

        /*
        ManageScale();

        if (jumpTimer > 0) jumpTimer -= Time.deltaTime;

        if (transform.position.y == previousPosition.y)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer  >= idleTimerMax && jumpTrigger.isGrounded)
            {
                Debug.Log("AAAAAAA");
                Jump();
                idleTimer = -0.2f;
            }
        }
        

        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = leftRotation;
            transform.localEulerAngles = new Vector3(0, 225, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 135, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (Screen.width / 2))
            {
                transform.localEulerAngles = new Vector3(0, 135, 0);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 225, 0);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
        */

        previousPosition = transform.position;
    }

    private void CheckMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = leftRotation;
            transform.localEulerAngles = new Vector3(0, 225, 0);
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 135, 0);
            transform.position += Vector3.right * speed * Time.deltaTime;
        }


        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > (Screen.width / 2))
            {
                transform.localEulerAngles = new Vector3(0, 135, 0);
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 225, 0);
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDying) return;

        ManageScale();

        if (jumpTimer > 0) jumpTimer -= Time.deltaTime;

        if (transform.position.y == previousPosition.y)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTimerMax && jumpTrigger.isGrounded)
            {
                Debug.Log("AAAAAAA");
                Jump();
                idleTimer = -0.2f;
            }
        }

        CheckMovement();

        rb.AddForce(Physics.gravity * (gravity.gravityScale - 1) * rb.mass);
    }

    private bool CheckIfFloorUnderneath()
    {
        bool jumpCheck = false;

        Physics.Raycast(transform.position, Vector3.down, out hit, 1);
        Physics.Raycast(transform.position + new Vector3(-0.5f, 0, 0), Vector3.down, out hit2, 1);
        Physics.Raycast(transform.position + new Vector3(0.5f, 0, 0), Vector3.down, out hit3, 1);
        Physics.Raycast(transform.position + new Vector3(-0.25f, 0, 0), Vector3.down, out hit4, 1);
        Physics.Raycast(transform.position + new Vector3(0.25f, 0, 0), Vector3.down, out hit5, 1);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Floor"))
            {
                //Jump();
                jumpCheck = true;
            }
        }

        if (hit2.collider != null)
        {
            if (hit2.collider.gameObject.CompareTag("Floor"))
            {
                //Jump();
                jumpCheck = true;
            }
        }

        if (hit3.collider != null)
        {
            if (hit3.collider.gameObject.CompareTag("Floor"))
            {
                //Jump();
                jumpCheck = true;
            }
        }

        if (hit4.collider != null)
        {
            if (hit4.collider.gameObject.CompareTag("Floor"))
            {
                //Jump();
                jumpCheck = true;
            }
        }

        if (hit5.collider != null)
        {
            if (hit5.collider.gameObject.CompareTag("Floor"))
            {
                //Jump();
                jumpCheck = true;
            }
        }

        return jumpCheck;
    }

    private void Jump()
    {
        AudioManager.Instance.PlayBounce();
        transform.localScale = new Vector3(1, 0.8f, 1);
        jumpTimer = jumpTimerMax;
        ResetVelocity();
        float jumpForce = Mathf.Sqrt(jumpHeight * -2 * (Physics2D.gravity.y * gravity.gravityScale));
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void ManageScale()
    {
        if (transform.localScale.y >= 1)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (transform.localScale.y < 1)
        {
            transform.localScale = new Vector3(1, transform.localScale.y + Time.deltaTime, 1);
        }
    }

    public void EmergencyJump()
    {
        if (CheckIfFloorUnderneath() && !isDying /*&& jumpTimer <= 0*/) Jump();
    }

    public void DecreaseMovementSpeed()
    {
        if (jumpLevel <= 0) return;
        jumpLevel--;
        jumpHeight -= jumpLevelIncrement;
        GetComponent<PlayerTrashManager>().AddTrash();
    }

    public void IncreaseMovementSpeed()
    {
        if (jumpLevel >= maxJumpLevel) return;
        jumpLevel++;
        jumpHeight += jumpLevelIncrement;
        GetComponent<PlayerTrashManager>().RemoveTrash();
    }

    public void ResetVelocity()
    {
        rb.velocity = Vector3.zero;
    }

    public void ResetJumpHeight()
    {
        jumpHeight = maxJumpHeight;
    }

    public void ResetJumpLevel()
    {
        jumpLevel = maxJumpLevel;
    }
}
