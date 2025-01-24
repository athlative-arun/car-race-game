using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countDownTimer = 5f;
    [Header("Things to stop")]
    public PlayerCarController playerCarController;
    public OpponentCar opponentCar;
    public OpponentCar opponentCar1;
   
   public Text countDownText;

// Start is called before the first frame update
    void Start()
    {
            StartCoroutine(TimeCount());
    }

// Update is called once per frame
    void Update()
    {
        if (countDownTimer > 1)
        {
            playerCarController.accelerationForce = 0f;
            opponentCar.movingSpeed = 0f;
            opponentCar1.movingSpeed = 0f;
        
        }
         else if (countDownTimer == 0)
        {
            playerCarController.accelerationForce = 300f;
            opponentCar.movingSpeed = 10f;
            opponentCar1.movingSpeed = 12f;
        }
    }

    IEnumerator TimeCount()
    {
        while (countDownTimer > 0){
            countDownText.text = countDownTimer.ToString();
            yield return new WaitForSeconds(1f);
            countDownTimer--;
        }

        countDownText.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownText.gameObject.SetActive(false);
    }

}
