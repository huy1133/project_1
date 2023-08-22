using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class gameManager : MonoBehaviour
{
    public Text tLaps;
    public Text tpos;
    public Text tconi;
    public Text tspeed;
    public Slider blood;
    public Slider fuels;
    public GameObject pause;
    int laps;
    int pos;
    int coin;
    int speed;
    // Start is called before the first frame update
    public void setlaps(int tmp)
    {
        laps = tmp;
    }
    public void setpos(int tmp)
    {
        pos = tmp;
    }
    public void setcoint(int tmp)
    {
        coin = tmp;
    }
    public void setspeed(int tmp)
    {
        speed = tmp;
    }
    public void bloodLoss(int tmp)
    {
        blood.value = 100 - tmp;
    }
    public void fuel(float capacity, float fuel)
    {
        fuels.minValue = 0;
        fuels.maxValue = capacity;
        fuels.value = fuel;
    }
    public void plauClick()
    {
        pause.SetActive(true);
        Time.timeScale = 0;
    }
    public void resumeClick()
    {
        pause.SetActive(false);
        Time.timeScale = 1;
    }
    public void retryClick()
    {
        pause.SetActive(false);
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void homeClick()
    {
        pause.SetActive(false);
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    void Start()
    {
        coin = 1;
        speed = 1;
        laps = 1;
        pos = 1;
        pause.SetActive(false);
    }
    
    // Update is called once per frame
    void Update()
    {
        tLaps.text = "" + laps + "/12";
        tconi.text = "" + coin;
        tspeed.text = "" + speed;
        tpos.text = "" + pos;
    }
}
