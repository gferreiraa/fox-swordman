using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Create here first variable to character movements
    private CharacterController controller;

    private Animator anim;

    [Header("Config Player")]
    public float movementSpeed = 3f;

    // Create a variable type vector contains 3 positions x,y,z
    private Vector3 direction;
    private bool isWalk;


    [Header("Attack Config")]
    public ParticleSystem fxAttack;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // TODO: 

    // Update is called once per frame
    void Update()
    {

        Inputs();

        MoveCharacter();

        UpdateAnimator();

    }


    #region My methods

    void Inputs()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        direction = new Vector3(horizontal, 0f, vertical).normalized;
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
        fxAttack.Emit(1);
    }

    void MoveCharacter()
    {
        if (direction.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }


        controller.Move(direction * movementSpeed * Time.deltaTime);
    }

    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
    }
    #endregion





}
