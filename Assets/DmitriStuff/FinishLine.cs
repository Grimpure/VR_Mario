using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public int currentBlock;
    public TextMeshProUGUI tmp_Laps, tmp_Timer;
    private int i_Laps = 1;
    private int MinuteCountTiendes, MinuteCountEenheden, SecondCountTiendes, SecondCountEenheden;
    private float MilliCountTiendes, MilliCountEenheden;
    public GameObject powerupImage;
    public Vector3 lastblock;
    public Scene mainMenu;
    public TextMeshProUGUI EndTime;
    private bool finished = false;
    void Start()
    {
        currentBlock = 0;
        MilliCountTiendes = 0;
        MilliCountEenheden = 0;
        SecondCountTiendes = 0;
        SecondCountEenheden = 0;
        MinuteCountTiendes = 0;
        MinuteCountEenheden = 0;
        EndTime.enabled = false;
    }
    private void Awake()
    {
        finished = false;
    }


    void Update()
    {
        //When pressing space, the car's position will go to the last position of the last checkpoint's block.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.transform.position = lastblock;
        } 
        
        //Text for the laps on the scoreboard. (Made a draw version of the max laps. So its not working yet. FIX ME PLZ!)
        tmp_Laps.text = "Lap: " + i_Laps.ToString() + " / 5";

        //When the interget currentblock is higher then 42, change it to 0.
        if(currentBlock == 42)
        {
            currentBlock = 0;
            i_Laps++;
        }

        if(i_Laps == 2)
        {
            finished = true;
            StartCoroutine(Finished());
        }
    }
    private void FixedUpdate()
    {
  
        tmp_Timer.text = MinuteCountTiendes.ToString("f0") + MinuteCountEenheden.ToString("f0") + ":" + SecondCountTiendes.ToString("f0") + SecondCountEenheden.ToString("f0") + ":" + MilliCountTiendes.ToString("f0") + MilliCountEenheden.ToString("f0");
        if (!finished)
        {
            MilliCountEenheden += Time.deltaTime * 10;
            if (MilliCountEenheden >= 9.5f)
            {
                MilliCountEenheden = 0;
                MilliCountTiendes++;
            }
            if (MilliCountTiendes >= 9.5f)
            {
                MilliCountTiendes = 0;
                SecondCountEenheden++;
            }
            if (SecondCountEenheden >= 9)
            {
                SecondCountEenheden = 0;
                SecondCountTiendes++;
            }
            if (SecondCountTiendes >= 6)
            {
                SecondCountTiendes = 0;
                MinuteCountEenheden++;
            }
            if (MinuteCountEenheden >= 9)
            {
                MinuteCountEenheden = 0;
                MinuteCountTiendes++;
            }
        }else if (finished)
        {
            powerupImage.SetActive(false);
            tmp_Laps.enabled = false;
            tmp_Timer.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Collision when tag colliding, the name wil be changed to a int. So blocks are called 1,2,3 etc...
        //if the block name like "1" is one higher to the current interger "CurrentBlock" then do +1 to the currentblock.
        if (other.gameObject.tag == "BLOCK")
        {
            int i;
            int.TryParse(other.gameObject.name, out i);
            lastblock = other.gameObject.transform.position;
            if (i == currentBlock + 1)
            {
                currentBlock++;
            }
        }
    }
    IEnumerator Finished()
    {
        int MinuteTiendes_End, MinuteEenheden_End, SecondTiendes_End, SecondsEenheden_End;
        float MillicountTiendes_End, MillicountEenheden_End;

        MinuteTiendes_End = MinuteCountTiendes;
        MinuteEenheden_End = MinuteCountEenheden;
        SecondTiendes_End = SecondCountTiendes;
        SecondsEenheden_End = SecondCountEenheden;
        MillicountTiendes_End = MilliCountTiendes;
        MillicountEenheden_End = MilliCountEenheden;
        EndTime.text = "Your End time is: " + MinuteTiendes_End.ToString("f0") + MinuteEenheden_End.ToString("f0") + ":" + SecondTiendes_End.ToString("f0") + SecondsEenheden_End.ToString("f0") + ":" + MillicountTiendes_End.ToString("f0") + MilliCountEenheden.ToString("f0");
        EndTime.enabled = true;
        yield return new WaitForSeconds(8);
        EndTime.enabled = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

}
