using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goal : MonoBehaviour
{
    public TextMeshProUGUI PointText;
    public TextMeshProUGUI pauseText;
    int redPoints;
    int bluePoints;
    GameObject Dice;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.tag == "Dice")
        {
            Dice = collision.gameObject;
            Dice.SetActive(false);
            Dice.transform.position = new Vector2(0, 0);
           // WaitTime(5);
            Dice.SetActive(true);
            if(gameObject.name =="BlueGoal")
            {
                bluePoints++;
                Debug.Log("BluePoint = "+ bluePoints);
                PointText.SetText(bluePoints.ToString());
                pauseText.SetText(bluePoints.ToString());
            }
            if(gameObject.name =="RedGoal")
            {
                redPoints++;
                Debug.Log("RedPoint = "+ redPoints);
                PointText.SetText(redPoints.ToString());
                pauseText.SetText(redPoints.ToString());
            }

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
