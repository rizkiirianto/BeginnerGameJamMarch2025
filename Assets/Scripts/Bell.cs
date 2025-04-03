using UnityEngine;

public class Bell : SwitchObject
{
    private bool playerHasEntered;
    public AudioSource bellSFX;
    public AudioSource obstacleSFX;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&playerHasEntered)
        {
            StartCoroutine(ScaleOverTimeUnderworld(1f,0.5f)); 
            bellSFX.Play();
            obstacleSFX.Play();
            
        }
    }

    
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bumped");
            playerHasEntered = true;
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
