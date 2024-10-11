using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentMoney;
    public TMP_Text moneyText;
    public GameObject deathscreen;
    public GameObject winscreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addMoney(int moneyToAdd)
    {
        currentMoney += moneyToAdd;
        moneyText.text = "Points: " + currentMoney;
    }

    public void win()
    {
        winscreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }


    public void dead()
    {
        deathscreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void deathReset()
    {
        SceneManager.LoadScene("Platforming");
    }
}
