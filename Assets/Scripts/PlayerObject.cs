using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public float speed;
    public float verticalJump;
    public bool isGrounded;

    private void Update()
    {
        if(Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        if(Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
    }

}
