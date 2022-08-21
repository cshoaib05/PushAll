using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 6f;
    public float smooth = 0.1f;
    float turnsmooth;
    public Animator animator;
    public Animator hitAnim;
    public Joystick joystick;
    public static bool hitIt = false;
    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = joystick.Horizontal;  // Input.GetAxisRaw("Horizontal");
        float vertical = joystick.Vertical;   // Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        animator.SetFloat("speed", direction.magnitude);
        
        if (direction.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnsmooth, smooth);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        if(Input.GetMouseButtonUp(0))
        {
            StartCoroutine(Hit());
        }
    }


    IEnumerator Hit()
    {
        hitAnim.SetTrigger("hit");
        hitIt = true;
        yield return new WaitForSeconds(1f);
        hitIt = false;
    }
}
