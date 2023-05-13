using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Create here first variable to character movements
    private CharacterController controller; 

    [Header("Config Player")]
    public float movementSpeed = 3f;

    // Create a variable type vector contains 3 positions x,y,z
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;

        controller.Move(direction * movementSpeed * Time.deltaTime);

    }
}
