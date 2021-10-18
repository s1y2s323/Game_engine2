using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    public string m_Timer = @"00:00:00.000";
    public float m_TotalSeconds = 1 * 60;

    public GameObject gameoverText;
    private bool isGameover;

    private void Awake()
    {
        //time = 15f;
        //time = 60f;
    }

    private void Start()
    {
        m_Timer = CountdownTimer(false); // Text에 초기값을 넣어 주기 위해
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            m_Timer = CountdownTimer();

            // m_TotalSeconds이 줄어들때, 완전히 0에 맞출수 없기 때문에  
            if (m_TotalSeconds <= 0)
            {
                SetZero();

                //현재 상태를 게임오버 상태로 전환
                isGameover = true;

                //... 여기에 카운트 다운이 종료 될때 [이벤트]를 넣으면 됩니다.
                //게임오버 텍스트 게임 오브젝트를 활성화
                gameoverText.SetActive(true);
            }

            if (timeText)
                timeText.text = m_Timer;
        }
        
        /* 지워도 되는 주석
        if (TotalSeconds > 0)
            TotalSeconds -= Time.deltaTime;

        Timer.text = Mathf.Ceil(TotalSeconds).ToString();
        */

        if (isGameover)
        {
            //게임오버 상태에서 R키를 누른 경우
            if(Input.GetKeyDown(KeyCode.R))
            {
                //Play 씬을 로드
                SceneManager.LoadScene("Play");
            }
        }
    }

    private string CountdownTimer(bool IsUpdate = true)
    {
        if (IsUpdate)
            m_TotalSeconds -= Time.deltaTime;

        TimeSpan timespan = TimeSpan.FromSeconds(m_TotalSeconds);
        string timer = string.Format("{0:00}:{1:00}:{2:00}.{3:000}",
            timespan.Hours, timespan.Minutes, timespan.Seconds, timespan.Milliseconds);

        return timer;
    }

    private void SetZero()
    {
        m_Timer = @"00:00:00.000";
        m_TotalSeconds = 0;
        //m_IsPlaying = false;
    }

    //나중에 Player?에서 플레이어의 HP가 0이 될 경우를 구현할 때 EndGame() 활용
    //플레이어의 HP를 나타내는 변수를 못 찾겠어요
    public void EndGame()
    {
        //현재 상태를 게임오버 상태로 전환
        isGameover = true;

        //게임오버 텍스트 게임 오브젝트를 활성화
        gameoverText.SetActive(true);
    }
}
