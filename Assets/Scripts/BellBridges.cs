using UnityEngine;

public class BellBridges : SwitchObject
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
            StartCoroutine(Bridge(1f,0.5f)); 
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