using UnityEngine;

public class PlayerObject : MonoBehaviour
{
    public float speed;
    public Animator animatorChar;
    public Animator animatorShadow;
    public float verticalJump;
    public SpriteRenderer charSpriteRenderer;
    public SpriteRenderer shadowSpriteRenderer;
    public bool isGrounded;
    private bool isDead;
    public static bool swapWorld;
    public Transform playerPosition;
    public Transform shadowPosition;
    public bool playerCouldTransfer;
    

    private void Update()
    {
        if (!isDead) {
            if(Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                animatorChar.Play("CharacterRun");
                animatorShadow.Play("ShadowRun");
                charSpriteRenderer.flipX = true;
                shadowSpriteRenderer.flipX = true;
               
            }
        if(Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                animatorChar.Play("CharacterRun");
                animatorShadow.Play("ShadowRun");
                charSpriteRenderer.flipX = false;
                shadowSpriteRenderer.flipX = false;
            }
        }

        /*
        if (charPosition.position.y < 0 ) {
            isDead = true;
        }
        if (shadowPosition.position.y > 0) {
            isDead = true;
        }
        */

    }

    public void TryMirrorSwap()
    {
        if (playerCouldTransfer && Input.GetKeyDown(KeyCode.F))
        {
            MirrorSwap();
        }
    }


    public void MirrorSwap()
    {
        swapWorld = true; 
        playerPosition.position = new Vector3(playerPosition.position.x, -0.75f, playerPosition.position.z);
        playerPosition.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        shadowPosition.position = new Vector3(shadowPosition.position.x, 0.75f, shadowPosition.position.z);
        shadowPosition.Rotate(180f,0f,0f,Space.Self);
    }
    
}
