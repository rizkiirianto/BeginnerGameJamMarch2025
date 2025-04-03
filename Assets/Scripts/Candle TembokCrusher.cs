using UnityEngine;

public class C : SwitchObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private bool shadowHasEntered;
    public Animator candleAnimator;
    public AudioSource candleSFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)&&shadowHasEntered)
        {
            TembokCrusherSlowDown();
            candleAnimator.Play("CandleDie");
            candleSFX.Play();
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