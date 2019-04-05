using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    GameObject Dice;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1080, 1920, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dice")
        {
            Dice = collision.gameObject;
            Dice.SetActive(false);
            Dice.transform.position = new Vector2(0, 0);
           // WaitTime(5);
            Dice.SetActive(true);

        }
    }

    IEnumerable WaitTime(float time)
    {
        Debug.Log("Wait Start");
        yield return new WaitForSeconds(time);
        Dice.SetActive(true);
        Debug.Log("Wait Over");
    }
}
