using UnityEngine;

public class Candle : SwitchObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool shadowHasEntered;
    public Animator candleAnimator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&shadowHasEntered)
        {
            StartCoroutine(ScaleOverTimeOverworld(1f,0.5f)); 
            candleAnimator.Play("CandleDie");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            shadowHasEntered=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Shadow"))
        {
            shadowHasEntered=false;
        }
    }
    
}
