using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCharacter : PlayerObject
{
    private Rigidbody thisRigidbody;
    public bool charAlive;
    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump")) Jump();
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1f);
    }
    private void Jump() {
        if(isGrounded) {
            thisRigidbody.AddForce(Vector3.up * verticalJump, ForceMode.Impulse);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("door")) {
            StaticData.level++;
            SceneManager.LoadScene(0);
        }
    }
}
