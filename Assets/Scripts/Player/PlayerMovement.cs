using UnityEngine;
using CnControls;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    private Vector3 movement;
    private Animator anim;
    private Rigidbody playerRigidBody;
    private int floorMask;
    private float camRayLength = 100f;
    public GameObject joystickArea;

    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Floor");
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        var h = CnInputManager.GetAxisRaw("Horizontal");
        var v = CnInputManager.GetAxisRaw("Vertical");
        Move(h, v);
        Turning();
        Animating(h, v);
    }

    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidBody.MovePosition(transform.position + movement);
    }

    private void Turning()
    {
        if (DeviceType.Handheld == SystemInfo.deviceType)
        {
            var h = CnInputManager.GetAxis("Aim Horizontal");
            var v = CnInputManager.GetAxis("Aim Vertical");
            var newRotation = Quaternion.LookRotation(new Vector3(h, 0f, v));
            playerRigidBody.MoveRotation(newRotation);
        }
        else
        {
            var camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit floorHit;
            if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
            {
                var playerToMouse = floorHit.point - transform.position;
                playerToMouse.y = 0f;
                var newRotation = Quaternion.LookRotation(playerToMouse);
                playerRigidBody.MoveRotation(newRotation);
            }
        }
    }

    private void Animating(float h, float v)
    {
        var walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}
