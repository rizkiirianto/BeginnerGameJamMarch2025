using UnityEngine;

public class BellTembokCrusher : SwitchObject
{
    private bool playerHasEntered;
    public AudioSource bellSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&playerHasEntered)
        {
            TembokCrusherSlowDown();
            bellSFX.Play();
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bumped");
            playerHasEntered=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Leave");
            playerHasEntered=false;
        }
    }

    
    
    
}
