using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int player1Score = 0;
    public Text player1ScoreText;
    public int player2Score = 0;
    public Text player2ScoreText;

    public GameObject player1Options;
    public Text option1_1;
    public Text option1_2;
    public Text option1_3;
    public Image image1;
    
    public GameObject player2Options;
    public Text option2_1;
    public Text option2_2;
    public Text option2_3;
    public Image image2;

    void Start()
    {
        player1Options.SetActive(false);
        player2Options.SetActive(false);
    }
    void Update()
    {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();

        float h1 = Input.GetAxisRaw("Horizontal1");
        float h2 = Input.GetAxisRaw("Horizontal2");
        //Debug.Log(Input.GetButtonDown("Horizontal1"));

        if (player1Options.activeSelf && h1 != 0 && (Input.GetButtonDown("Horizontal1")))
        {
            image1.transform.localPosition += 100 * h1*Vector3.right;
        }
        
        if (player2Options.activeSelf && h2 != 0 && (Input.GetButtonDown("Horizontal2")))
        {
            image2.transform.localPosition += 100 * h2*Vector3.right;
        }
    }

    public void LevelUp(int p)
    {
        if (p==1)
        {
            player1Options.SetActive(true);
            image1.transform.localPosition = new Vector3(100,0,0);
        }
        if (p==2)
        {
            player2Options.SetActive(true);
            image2.transform.localPosition = new Vector3(-100,0,0);
        }
    }
}
