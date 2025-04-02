using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShadow : PlayerObject
{
    public float gravityScale;
    private Rigidbody shadowRigidbody;
    private ConstantForce shadowConstantForce;
    
    // Update is called once per frame
    private void Start()
    {
        shadowRigidbody = GetComponent<Rigidbody>();
        shadowConstantForce = GetComponent<ConstantForce>();
    }

    private void Update()
    {
        if (!swapWorld) {
            if (Input.GetButtonDown("Jump")) Jump();
            isGrounded = Physics.Raycast(transform.position, Vector3.up, 1f);
            shadowConstantForce.enabled = true;
            shadowRigidbody.useGravity = false;
            if (!isDead) {
                if (isGrounded && isMoving) {
                animatorShadow.Play("ShadowRun");
            }

            if (isGrounded && !isMoving) {
                animatorShadow.Play("NewShadowIdle");
            }

            if (!isGrounded) {
                animatorShadow.Play("ShadowJump");
            }
            }
            
        }

        else if (swapWorld) {
            if (Input.GetButtonDown("Jump")) MirrorJump();
            isGroundedSwap = Physics.Raycast(transform.position, Vector3.down, 1f);
            shadowConstantForce.enabled = false;
            shadowRigidbody.useGravity = true;
            TryMirrorExit();
            if (!isDead) {
                 if (isGroundedSwap && isMoving) {
                animatorShadow.Play("ShadowRun");
            }
            if (isGroundedSwap && !isMoving) {
                animatorShadow.Play("NewShadowIdle");
            }
            if (!isGroundedSwap) {
                animatorShadow.Play("ShadowJump");
            }
            }
           
        }
        
    }

    private void Jump() {
        if(isGrounded) {
            shadowRigidbody.AddForce(Vector3.down * verticalJump, ForceMode.Impulse);
        }
    }

    private void MirrorJump() {
        if(isGroundedSwap) {
            shadowRigidbody.AddForce(Vector3.up * verticalJump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("exit mirror")) {
            playerCouldExit=true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("exit mirror"))
        {
            playerCouldExit=false;
        }
    }

}
