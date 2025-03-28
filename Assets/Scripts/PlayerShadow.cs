using UnityEngine;

public class PlayerShadow : PlayerObject
{
    public float gravityScale;
    private Rigidbody shadowRigidbody;
    // Update is called once per frame
    private void Start()
    {
        shadowRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //shadowRigidbody.AddForce(Vector3.up * gravityScale, ForceMode.Impulse);
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Jump() {
         shadowRigidbody.AddForce(Vector3.down * verticalJump, ForceMode.Impulse);
    }

}
