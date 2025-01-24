using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Finish : MonoBehaviour
{
    [Header("Finish UI var")]
    public GameObject finishUI;
    public GameObject playerUI;
    public GameObject playerCar;

    [Header("win/lose Status")]
    public Text status;

    private void Start()
    {
        finishUI.SetActive(false);
        StartCoroutine(waitforthefinishUI());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;

            status.text = "You Win";
            status.color = Color.green;
        }
        else if(other.gameObject.tag=="OpponentCar"){
            StartCoroutine(finishZoneTimer());
            gameObject.GetComponent<BoxCollider>().enabled = false;

            status.text = "You Lose";
            status.color = Color.red;
        }
    }

    IEnumerator waitforthefinishUI()
    {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(10f);
        gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    IEnumerator finishZoneTimer()
    {
        finishUI.SetActive(true);
        playerUI.SetActive(false);
        playerCar.SetActive(false);

        yield return new WaitForSeconds(5f);
        Time.timeScale = 0f;
    }
}
