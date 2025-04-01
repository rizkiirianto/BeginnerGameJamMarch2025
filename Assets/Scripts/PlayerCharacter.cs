using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : PlayerObject
{
    public PlayerShadow playerShadow;
    private Rigidbody thisRigidbody;
    private bool playerCouldTransfer;
    private ConstantForce thisConstantForce;
    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
        thisConstantForce = GetComponent<ConstantForce>();
        
    }
    private void Update()
    {
        if (!swapWorld) {
            if (Input.GetButtonDown("Jump")) Jump();
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
            if(Input.GetKeyDown(KeyCode.F)&&playerCouldTransfer) playerShadow.ShadowEnterMirror();
        }
        else if (swapWorld) {
            if (Input.GetButtonDown("Jump")) MirrorJump();
            thisConstantForce.enabled = true;
            thisRigidbody.useGravity = false;
        }
    }
    public void MirrorSwap()
    {
        swapWorld = true; 
        transform.position = new Vector3(transform.position.x, -0.75f, transform.position.z);
        transform.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        playerShadow.ShadowEnterMirror();
    }
    private void Jump() {
        if(isGrounded) {
            thisRigidbody.AddForce(Vector3.up * verticalJump, ForceMode.Impulse);
        }
    }

    private void MirrorJump() {
        if(isGrounded) {
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
            Debug.Log("Mirror");
            playerCouldTransfer=true;
        }
    }

     private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("mirror"))
        {
            Debug.Log("Leave");
            playerCouldTransfer=false;
        }
    }
}
