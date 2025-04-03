using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : PlayerObject
{
    public PlayerShadow playerShadow;
    private Rigidbody thisRigidbody;
    private ConstantForce thisConstantForce;
    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisConstantForce = GetComponent<ConstantForce>();

        
    }
    private void Update()
    {
        if (!swapWorld) {
            if (Input.GetButtonDown("Jump")) {
                Jump(); 
            } 
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
            // Check for Mirror Swap here
            TryMirrorSwap();
            thisConstantForce.enabled = false;
            thisRigidbody.useGravity = true;
            if (!isDead) {
                if (isGrounded && isMoving) {
                    animatorChar.Play("CharacterRun");
                }

                if (isGrounded && !isMoving) {
                    animatorChar.Play("NewCharacterIdle");
                }

                if (!isGrounded) {
                    animatorChar.Play("CharacterJump");
                }
            }
            
        }
        else if (swapWorld) {
            if (Input.GetButtonDown("Jump")) MirrorJump();
            isGroundedSwap = Physics.Raycast(transform.position, Vector3.up, 1f);
            thisConstantForce.enabled = true;
            thisRigidbody.useGravity = false;
            if (!isDead) 
            {
                if (isGroundedSwap && isMoving) {
                animatorChar.Play("CharacterRun");
            }
            if (isGroundedSwap && !isMoving) {
                animatorChar.Play("NewCharacterIdle");
            }
            if (!isGroundedSwap) {
                animatorChar.Play("CharacterJump");
            }
            }
            
        }

        
    }
    
    private void Jump() {
        if(isGrounded) {
            thisRigidbody.AddForce(Vector3.up * verticalJump, ForceMode.Impulse);
        }
    }

    private void MirrorJump() {
        if(isGroundedSwap) {
            thisRigidbody.AddForce(Vector3.down * verticalJump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door")) {
            StaticData.level++;
            SceneManager.LoadScene(0);
        }

        else if(other.CompareTag("mirror")) {
            playerCouldTransfer=true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("mirror"))
        {
            playerCouldTransfer=false;

        }
    }
}
