using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawn : MonoBehaviour
{

    [SerializeField]
    private Transform obj;
    public Transform parent;

    Vector3 spawnPos;

    private float timeCh;

    float firstPress, appearanceTime, reloadTime, maxCount, lifeCount, time, timeToPress;

    public bool game;
    public GameObject button;
    public int point, pointMiss, score, shots;
    public Text _scoreText, _timeText, _heartsText, _finalScoreText, _finalTimeText, _pointText, _pointMissText;

    public GameObject _panelGameOver;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _heartsText.text = lifeCount.ToString();
        _timeText.text = time.ToString();
        _scoreText.text = score.ToString();
        if (game)
        {

            if (Time.time > timeCh)
            {
                timeCh = timeCh + reloadTime + firstPress + appearanceTime;
                startPosition();
                Debug.Log(timeCh);
            }

            if (Time.time > timeToPress)
            {
                timeToPress = timeToPress + reloadTime + firstPress + appearanceTime;
                
                destroyTarget();
                Debug.Log(timeToPress);
            }
        }

    }

    public void NewGame()
    {
        Destroy(GameObject.Find("Goal(Clone)"));

        firstPress = PlayerPrefs.GetFloat("firstPress") / 100;
        appearanceTime = PlayerPrefs.GetFloat("appearanceTime") / 100;
        reloadTime = PlayerPrefs.GetFloat("reloadTime");
        maxCount = PlayerPrefs.GetFloat("maxCount");
        lifeCount = PlayerPrefs.GetFloat("lifeCount");

        timeCh = Time.time + reloadTime + firstPress;

        timeToPress = firstPress + Time.time;

        

        _panelGameOver.SetActive(false);

        time = 0;
        score = 0;
        point = 0;
        pointMiss = 0;
        shots = 0;


        startGame();
        StartCoroutine(IdleFarm());
    }

    IEnumerator IdleFarm()
    {
        if (game)
        {
            yield return new WaitForSeconds(1);
            time++;

            StartCoroutine(IdleFarm());
        }
    }

    void startGame()
    {
        game = true;
        startPosition();
    }

    void startPosition()
    {
        var child = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity, parent);
        child.localPosition = spawnPos;
    }

    public void checkHit()
    {
        GameScore();
        hitCounter();
        Destroy(GameObject.Find("Goal(Clone)"));
    }

    public void destroyTarget()
    {
        missCounter();
        
        Destroy(GameObject.Find("Goal(Clone)"));

    }

    public void hitCounter()
    {
        point++;
        //pointMiss--;

        timeToPress = firstPress + reloadTime + timeToPress - appearanceTime;
        timeCh = timeCh - 2 * appearanceTime;

        Debug.Log(point);

        shotsCounter();
    }

    public void missCounter()
    {
        pointMiss++;
        lifeCounter();
        shotsCounter();
        Debug.Log(pointMiss);
    }

    public void GameScore()
    {
        score += 10;
    }

    public void lifeCounter()
    {
        lifeCount--;
        if(lifeCount == 0)
        {
            game = false;
            StopCoroutine(IdleFarm());
            _panelGameOver.SetActive(true);
            GameStatistic();
        }
    }

    public void shotsCounter()
    {
        shots++;
        if(shots == maxCount)
        {
            game = false;
            StopCoroutine(IdleFarm());
            _panelGameOver.SetActive(true);
            GameStatistic();
        }
    }

    public void GameStatistic()
    {
        _finalScoreText.text = ($"Ваш счет:{score}");
        _finalTimeText.text = ($"Время:{time}");
        _pointText.text = ($"Попаданий:{point}");
        _pointMissText.text = ($"Промахов:{pointMiss}");
    }

    public void NewGameButton()
    {
        NewGame();
    }
} 