using UnityEngine;

public class PlayerCharacter : PlayerObject
{
    private Rigidbody thisRigidbody;
    private void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump")) Jump();
    }
    private void Jump() {
         thisRigidbody.AddForce(Vector3.up * verticalJump);
    }
}
