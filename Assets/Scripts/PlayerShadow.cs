using UnityEngine;

public class PlayerShadow : PlayerObject
{
    public float gravityScale;
    private Rigidbody shadowRigidbody;
    private ConstantForce shadowConstantForce;
    // Update is called once per frame
    private void Start()
    {
        shadowRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!swapWorld) {
            if (Input.GetButtonDown("Jump")) Jump();
            isGrounded = Physics.Raycast(transform.position, Vector3.up, 1f);
        }

        else if (swapWorld) {
            if (Input.GetButtonDown("Jump")) MirrorJump();
            shadowConstantForce.enabled = false;
            shadowRigidbody.useGravity = true;
        }
        
    }
    public void ShadowEnterMirror()
    {
        swapWorld = true; 
        transform.position = new Vector3(transform.position.x, 0.75f, transform.position.z);
        transform.Rotate(0f,0f,0f,Space.Self);
        
    }

    private void Jump() {
        if(isGrounded) {
            shadowRigidbody.AddForce(Vector3.down * verticalJump, ForceMode.Impulse);
        }
    }

    private void MirrorJump() {
        if(isGrounded) {
            shadowRigidbody.AddForce(Vector3.up * verticalJump, ForceMode.Impulse);
        }
    }

}
