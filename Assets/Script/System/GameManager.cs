using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : Singleton<GameManager>
{

    public float seeds;
    public float sprits;

    public GameObject pauseCanvas;

    public ScoreManager scoreManager;
    public InvenManager invenManager;

    // Start is called before the first frame update
    void Start()
    {
        seeds = 10f;
        sprits = 20f;


        pauseCanvas.SetActive(false);

        
    }

    // Update is called once per frame
    void Update()
    {
        scoreManager.SetSeedText(seeds.ToString());
        scoreManager.SetSpiritText(sprits.ToString());


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }


    public void setSeeds(float number) {
        seeds = seeds - number;

    }
    public void SetSprits(float number) {
        sprits = sprits - number;
    }

    private void TogglePause()
    {
        // 일시정지 상태를 토글합니다.
        bool isPaused = Mathf.Approximately(Time.timeScale, 0.0f);      // Time.timeScale이 0이면 일시정지 상태

        // 일시정지 상태에 따라 Time.timeScale을 변경하고, Pause UI를 활성화 또는 비활성화합니다.
        if (isPaused)
        {
            Time.timeScale = 1.0f; // 게임 시간을 정상적으로 진행하도록 합니다.
            Cursor.lockState = CursorLockMode.Locked; // 커서 잠금 설정
            Cursor.visible = false; // 커서 숨김 설정
            pauseCanvas.SetActive(false); // Pause UI를 비활성화합니다.
        }
        else
        {
            Time.timeScale = 0.0f; // 게임 시간을 멈추도록 합니다.
            Cursor.lockState = CursorLockMode.None; // 커서 잠금 해제
            Cursor.visible = true; // 커서 표시
            pauseCanvas.SetActive(true); // Pause UI를 활성화합니다.
        }
    }

    public void ResumeGame()
    {
        // "재개" 버튼을 클릭하면 일시정지를 해제합니다.
        TogglePause();
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("InGameScene");
        
    }

   public void ExitGame()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadSceneAsync("MenuScene", LoadSceneMode.Single);

    }

}
