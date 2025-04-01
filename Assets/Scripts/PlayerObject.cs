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
    public bool swapWorld;
    

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
    
}
