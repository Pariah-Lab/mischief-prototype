using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MischievousRatController : MonoBehaviour
{
    public float moveSpeed = 4.0f;
    public float rotSpeed = 80.0f;
    public float rot = 0f;
    public float gravity = 8.0f;

    public Text screenText;
    public Text lifeMeterText;
    public Text mischiefMeterText;

    public int lifeTotal;
    public int mischiefTotal;

    private int hitRange = 1;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;

    public float timerRemaining = 15;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        lifeTotal = 100;
        mischiefTotal = 0;

        screenText.text = "";
        lifeMeterText.text = "Life: " + lifeTotal;
        mischiefMeterText.text = "Mischief: " + mischiefTotal;
    }

    // Update is called once per frame
    void Update()
    {
        ScreenPrompts();
        Movement();
        GetInput();
    }

    void Movement ()
    {
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if(anim.GetBool("isAttacking") == true)
                {
                    return;
                }
                else if (anim.GetBool("isAttacking") == false)
                {
                    anim.SetInteger("condition", 1);
                    anim.SetBool("isRunning", true);
                    moveDir = new Vector3(0, 0, 1);
                    moveDir *= moveSpeed;
                    moveDir = transform.TransformDirection(-moveDir);
                }
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                anim.SetBool("isRunning", false);
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void GetInput ()
    {
        if (controller.isGrounded)
        {
            if(Input.GetMouseButtonDown (0) || Input.GetKey(KeyCode.Space))
            {
                if (anim.GetBool("isRunning") == true)
                {
                    anim.SetBool("isRunning", false);
                    anim.SetInteger("condition", 0);
                }
                else if (anim.GetBool("isRunning") == false)
                {
                    Attacking();
                }
            }
        }
    }

    void Attacking ()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 origin = transform.position;

        if (Physics.Raycast (origin, forward, out hit, hitRange))
        {
            if (hit.transform.gameObject.tag == "Enemy")
            {
                hit.transform.gameObject.SendMessage("TakeDamage", 30);
            }
        }

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine ()
    {
        anim.SetBool("isAttacking", true);
        anim.SetInteger("condition", Random.Range(2, 6));
        yield return new WaitForSeconds(0.25f);
        anim.SetInteger("condition", 0);
        anim.SetBool("isAttacking", false);
    }

    private void OnCollisionEnter(Collision col)
    {
        mischiefTotal += 10;

        if (col.gameObject.tag == "Pickup")
        {
            mischiefTotal += 10;
        }

        if (mischiefTotal > 9)
            screenText.text = "You Win!";
    }

    void ScreenPrompts ()
    {
        if (timerRemaining > 0)
        {
            timerRemaining -= Time.deltaTime;
        }

        if (timerRemaining > 13 && timerRemaining < 14)
            screenText.text = "Use arrow keys to move";

        if (timerRemaining > 10 && timerRemaining < 11)
            screenText.text = "";

        if (timerRemaining > 8 && timerRemaining < 9)
            screenText.text = "Press space or click to destroy things";

        if (timerRemaining > 5 && timerRemaining < 6)
            screenText.text = "";

        if (timerRemaining > 3 && timerRemaining < 4)
            screenText.text = "Cause Mischief!";

        if (timerRemaining > 1 && timerRemaining < 2)
            screenText.text = "";

        lifeMeterText.text = "Life: " + lifeTotal;
        mischiefMeterText.text = "Mischief: " + mischiefTotal;
    }
}
