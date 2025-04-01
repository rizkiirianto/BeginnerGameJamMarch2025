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
    public bool isGroundedPlayer;
    public bool isGroundedShadow;
    private bool isDead;
    public static bool swapWorld;
    public Transform playerPosition;
    public Transform shadowPosition;
    public bool playerCouldTransfer;
    public bool playerCouldExit;
    

    private void Update()
    {
        if (!isDead) {
            if (!swapWorld) {
                if (playerPosition.position.y < 0 ) {
                    isDead = true;
                    animatorChar.Play("CharacterDeath");
                }
                if (shadowPosition.position.y > 0) {
                    isDead = true;
                    animatorShadow.Play("ShadowDeath");
                }
            }
            //isGroundedPlayer = Physics.Raycast(playerPosition.position, Vector3.down, 0.5f);
            //isGroundedShadow = Physics.Raycast(shadowPosition.position, Vector3.up, 0.5f);
            if(Input.GetKey(KeyCode.A)) {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                charSpriteRenderer.flipX = true;
                shadowSpriteRenderer.flipX = true;
                animatorChar.Play("CharacterRun");
                animatorShadow.Play("ShadowRun");
               
            }
        if(Input.GetKey(KeyCode.D)) {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
                charSpriteRenderer.flipX = false;
                shadowSpriteRenderer.flipX = false;
                animatorChar.Play("CharacterRun");
                animatorShadow.Play("ShadowRun");
            }
        }

    }

    public void TryMirrorSwap()
    {
        if (playerCouldTransfer && Input.GetKeyDown(KeyCode.F))
        {
            MirrorSwap();
        }
    }

    public void TryMirrorExit()
    {
        if (playerCouldExit && Input.GetKeyDown(KeyCode.F))
        {
            MirrorExit();
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

    public void MirrorExit()
    {
        swapWorld = false; 
        shadowPosition.position = new Vector3(shadowPosition.position.x, -0.75f, shadowPosition.position.z);
        shadowPosition.Rotate(180.0f, 0.0f, 0.0f, Space.Self);
        playerPosition.position = new Vector3(playerPosition.position.x, 0.75f, playerPosition.position.z);
        playerPosition.Rotate(180f,0f,0f,Space.Self);
    }
    
}
