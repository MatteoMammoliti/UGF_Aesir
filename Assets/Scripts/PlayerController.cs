using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // private vars
    private Vector3 moveDirection;

    // public vars
    public float speed;
    public float jumpForce;
    public float gravityScale; // we don't want our player to be moving at the gravity speed each frame
    public CharacterController controller;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, 0f, Input.GetAxis("Vertical") * speed); // 0f means it's a float value

        if(Input.GetButton("Jump")) // if jump is pressed we jump with a setted force
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale); // whatever the position is, we reset the y position adding the gravity once a frame
        
        controller.Move(moveDirection * Time.deltaTime); // Time.deltaTime records how long it was since the last frame happened, so we delay the update of the speed
    }
}