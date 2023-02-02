using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class Timer : MonoBehaviour
{
    [Header("Timer")]
    public float countdownTime;
    private float StartTime;
    public float coroutinewaitfor;

    [Header("Power Meter")]
    public Angled_Movement_PM Power;
    public bool CoTime = false;

    [Header("Bomb")]
    public Image BombRope;

    [Header("Sounds")]
    public AudioSource Aud;
    public AudioClip Ticking;
    public bool Ticked = false;

    private void Start()
    {
        StartTime = countdownTime;
    }

    private void Update()
    {
        if (Power.SpaceStart == true && CoTime == false)
        {
            StartCoroutine(CountdownToStart());
            CoTime = true;
        }

        if (countdownTime == 0 && Power.stopped == false)
        {
            Power.StartCoroutine(Power.CountdownLoss());
            Power.FlickAudio = true;
            Aud.Stop();
        }

        BombRope.fillAmount = countdownTime / StartTime;

        if (countdownTime < 20 && Ticked == false && !(countdownTime <= 0))
        {
            Aud.PlayOneShot(Ticking, 5f);
            Ticked = true;
        }
    }

    IEnumerator CountdownToStart()
    {
        while (countdownTime > 0)
        {
            yield return new WaitForSeconds(coroutinewaitfor);

            countdownTime--;
        }
        
    }
 }
