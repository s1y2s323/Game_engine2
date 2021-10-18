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
        m_Timer = CountdownTimer(false); // Text�� �ʱⰪ�� �־� �ֱ� ����
        isGameover = false;
    }

    private void Update()
    {
        if (!isGameover)
        {
            m_Timer = CountdownTimer();

            // m_TotalSeconds�� �پ�鶧, ������ 0�� ����� ���� ������  
            if (m_TotalSeconds <= 0)
            {
                SetZero();

                //���� ���¸� ���ӿ��� ���·� ��ȯ
                isGameover = true;

                //... ���⿡ ī��Ʈ �ٿ��� ���� �ɶ� [�̺�Ʈ]�� ������ �˴ϴ�.
                //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
                gameoverText.SetActive(true);
            }

            if (timeText)
                timeText.text = m_Timer;
        }
        
        /* ������ �Ǵ� �ּ�
        if (TotalSeconds > 0)
            TotalSeconds -= Time.deltaTime;

        Timer.text = Mathf.Ceil(TotalSeconds).ToString();
        */

        if (isGameover)
        {
            //���ӿ��� ���¿��� RŰ�� ���� ���
            if(Input.GetKeyDown(KeyCode.R))
            {
                //Play ���� �ε�
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

    //���߿� Player?���� �÷��̾��� HP�� 0�� �� ��츦 ������ �� EndGame() Ȱ��
    //�÷��̾��� HP�� ��Ÿ���� ������ �� ã�ھ��
    public void EndGame()
    {
        //���� ���¸� ���ӿ��� ���·� ��ȯ
        isGameover = true;

        //���ӿ��� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);
    }
}
