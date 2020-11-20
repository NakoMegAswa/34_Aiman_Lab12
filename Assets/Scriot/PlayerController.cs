using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speed;

    public GameObject CoinCollectedText;
   
    public float RotateSpeed;
    public float coinCount;
    private int totalCoin;
    private int coinLeft;
    // Start is called before the first frame update
    void Start()
    {
        CoinCollectedText.GetComponent<Text>().text = "Start Function";
        CoinCollectedText.GetComponent<Text>().text = "Coin Collected: " + coinCount.ToString();
        totalCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        coinLeft = GameObject.FindGameObjectsWithTag("Coin").Length;
        Debug.Log("Total Coin left: " + coinLeft.ToString());
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * -RotateSpeed, 0));
        
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Rotate(new Vector3(0, Time.deltaTime * RotateSpeed, 0));
       

        }

        if (coinCount == totalCoin)
        {
            print("You win!");
            SceneManager.LoadScene("WinScene");
        }

        if (transform.position.y < -5)
        {
            print("You lose");
            SceneManager.LoadScene("LoseScene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Coin")
        {

            coinCount++;
            CoinCollectedText.GetComponent<Text>().text = "Coin Collected: " + coinCount.ToString();
            Destroy(other.gameObject);
        }
    }


}
