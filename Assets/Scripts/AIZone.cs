using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIZone : MonoBehaviour
{
    public bool AiActive;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Dice")
        {//Sets true if dice enters collider.
            AiActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Dice")
        {//Sets false if dice exits collider.
            AiActive = false;
        }
    }

}
