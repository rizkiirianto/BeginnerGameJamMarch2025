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
        }

        else if (swapWorld) {
            Debug.Log ("udah kebalik");
            if (Input.GetButtonDown("Jump")) MirrorJump();
            shadowConstantForce.enabled = false;
            shadowRigidbody.useGravity = true;
            TryMirrorExit();
        }
        
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
