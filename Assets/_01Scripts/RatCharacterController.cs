using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DataSystem;

public class RatCharacterController : MonoBehaviour, IMischievable, ISwarmable
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

    public int hitRange = 5;

    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;
    bool attacking;
    public float timerRemaining = 15;
    IDestructible tmpDestructible;


    private void OnEnable()
    {
        GlobalEventHolder._aInstance.OnSwarmableCreated.RaiseISwarmable(this);
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();

        lifeTotal = 100;
        mischiefTotal = 0;

        ////screenText.text = "";
        //lifeMeterText.text = "Life: " + lifeTotal;
        //mischiefMeterText.text = "Mischief: " + mischiefTotal;
    }

    // Update is called once per frame
    void Update()
    {
        //GetInput();
        //Movement();
        //ScreenPrompts();
    }

    void Movement()
    {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                attacking = true;
                anim.SetInteger("condition", 3);
                anim.SetBool("isRunning", false);
                Attacking();
                
            } 
        if (controller.isGrounded)
        {
            if (attacking) return;

            if (Input.GetKey(KeyCode.UpArrow))
            {
                moveDir = new Vector3(0, 0, 1);
                moveDir *= moveSpeed;
                moveDir = transform.TransformDirection(-moveDir);
                anim.SetInteger("condition", 1);
                anim.SetBool("isRunning", true);
            }
            else
            {
                anim.SetBool("isRunning", false);
                anim.SetInteger("condition", 0);
                moveDir = new Vector3(0, 0, 0);
            }


        }


        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        if (!attacking)
        {
            moveDir.y -= gravity * Time.deltaTime;
            controller.Move(moveDir * Time.deltaTime);
        }
    }

    void Attacking()
    {   
        Debug.DrawRay(transform.position, -transform.forward, Color.yellow, 5f);
        if (Physics.Raycast(transform.position.WithAddY(1f), -transform.forward, out RaycastHit hit, hitRange))
        {
            hit.transform.TryGetComponent<IDestructible>(out tmpDestructible);
            if (tmpDestructible != null)
            {
                tmpDestructible.TakeDamage(30, this);
            }
        }

        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        attacking = true;
        anim.SetBool("isAttacking", true);
        anim.SetInteger("condition", Random.Range(2, 6));
        yield return new WaitForSeconds(1.25f);
        anim.SetInteger("condition", 0);
        anim.SetBool("isAttacking", false);
        attacking = false;
    }
    public void Die()
    {
        GlobalEventHolder._aInstance.OnSwarmableDied.RaiseISwarmable(this);
    }

    //private void OnCollisionEnter(Collision col)
    //{
    //    mischiefTotal += 10;

    //    if (col.gameObject.tag == "Pickup")
    //    {
    //        mischiefTotal += 10;
    //    }

    //    if (mischiefTotal > 9)
    //        screenText.text = "You Win!";
    //}

    void ScreenPrompts()
    {
        //if (timerRemaining > 0)
        //{
        //    timerRemaining -= Time.deltaTime;
        //}

        //if (timerRemaining > 13 && timerRemaining < 14)
        //    screenText.text = "Use arrow keys to move";

        //if (timerRemaining > 10 && timerRemaining < 11)
        //    screenText.text = "";

        //if (timerRemaining > 8 && timerRemaining < 9)
        //    screenText.text = "Press space or click to destroy things";

        //if (timerRemaining > 5 && timerRemaining < 6)
        //    screenText.text = "";

        //if (timerRemaining > 3 && timerRemaining < 4)
        //    screenText.text = "Cause Mischief!";

        //if (timerRemaining > 1 && timerRemaining < 2)
        //    screenText.text = "";

        //lifeMeterText.text = "Life: " + lifeTotal;
        //mischiefMeterText.text = "Mischief: " + mischiefTotal;
    }

    public void AddToMischief(int value)
    {
        mischiefTotal += value;
        //if (mischiefTotal > 9)
            //screenText.text = "You Win!";
    }


    public Transform GetMyTransform()
    {
        return transform;
    }

    public void SetMyDestination(Transform followPoint)
    {
        transform.forward = Vector3.Lerp(transform.forward, transform.position - followPoint.position, Time.deltaTime * 4f);
        transform.position = Vector3.Lerp(transform.position, followPoint.position, Time.deltaTime * 3f);
    }
}
