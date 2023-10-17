using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class GameModeManager : MonoBehaviour
{
    public npcGenerator npcGenerator;
    public GameObject modelContainer;
    public GameObject[] firePoints;
    public GameObject playGamePanel;
    public GameObject gameEndPanel;
    public Transform cameraTransform;
    public float cameraTransitionTime = 2f;
    public GameObject losePanel;
    public GameObject winPanel;
    public count Counter;
    public Camera testCamera;
    public CountdownUIController countdownController;
    private Vector3 initialCameraPosition;
    private Quaternion initialCameraRotation;
    private Quaternion zeroRotation = Quaternion.Euler(0f, 180f, 0f);
    private Vector3 specificPosition = new Vector3(-154.7f, 63.28f, -77.08f);
    public GameObject fire1;
    public GameObject fire3;

    public void Start()
    {
        cameraTransform = Camera.main.transform;
        initialCameraPosition = cameraTransform.position;
        initialCameraRotation = cameraTransform.rotation;
        modelContainer.SetActive(false);
        playGamePanel.SetActive(true);
        gameEndPanel.SetActive(false);
        fire1.SetActive(false);
        fire3.SetActive(false);

        Camera.main.enabled = true;
        testCamera.enabled = false;

        StartCoroutine(EndGameAfterTime(180f));
    }

    public void PlayGame()
    {
        StopCoroutine("EndGameAfterTime");
        playGamePanel.SetActive(false);
        modelContainer.SetActive(true);
        gameEndPanel.SetActive(false);
        npcGenerator.GenerateNPCs();

        Counter.StartCounting();
        if (countdownController != null)
            countdownController.StartCountdown();

        // Randomly select one of the 3 scenarios
        int randomMode = Random.Range(1, 4);
        switch (randomMode)
        {
            case 1:
                StartCoroutine(SelectMode1());
                break;
            case 2:
                StartCoroutine(SelectMode2());
                break;
            case 3:
                StartCoroutine(SelectMode3());
                break;
        }

        StartCoroutine(EndGameAfterTime(180f));
    }

    IEnumerator CameraTransition(Vector3 targetPosition, Quaternion targetRotation)
    {
        Vector3 startPosition = cameraTransform.position;
        Quaternion startRotation = cameraTransform.rotation;

        float elapsedTime = 0f;
        while (elapsedTime < cameraTransitionTime)
        {
            cameraTransform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / cameraTransitionTime);
            cameraTransform.rotation = Quaternion.Lerp(startRotation, targetRotation, elapsedTime / cameraTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        cameraTransform.position = targetPosition;
        cameraTransform.rotation = targetRotation;
    }

    IEnumerator SelectMode1()
    {
        yield return CameraTransition(new Vector3(-116.8f, 65.8f, -124f), Quaternion.Euler(20f, 150f, 0f));
        firePoints[0].GetComponent<FireSpread>().isActiveScene = true;
        firePoints[0].SetActive(true);
        firePoints[0].GetComponent<FireSpread>().StartFire();
        yield return new WaitForSeconds(5f);
        StartCoroutine(CameraTransition(specificPosition, zeroRotation));
        fire1.SetActive(true);
    }

    IEnumerator SelectMode2()
    {
        yield return CameraTransition(new Vector3(-76.86f, 65.91f, -80.37f), Quaternion.Euler(20f, 200f, 0f));
        firePoints[1].GetComponent<FireSpread>().isActiveScene = true;
        firePoints[1].SetActive(true);
        firePoints[1].GetComponent<FireSpread>().StartFire();
        yield return new WaitForSeconds(5f);
        StartCoroutine(CameraTransition(specificPosition, zeroRotation));
    }

    IEnumerator SelectMode3()
    {
        yield return CameraTransition(new Vector3(-178.37f, 79.22f, -81.71f), Quaternion.Euler(20f, -90f, 0f));
        firePoints[2].GetComponent<FireSpread>().isActiveScene = true;
        firePoints[2].SetActive(true);
        firePoints[2].GetComponent<FireSpread>().StartFire();
        yield return new WaitForSeconds(5f);
        StartCoroutine(CameraTransition(specificPosition, zeroRotation));
        fire3.SetActive(true);
    }

    IEnumerator EndGameAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        bool playerWon = (Counter != null && Counter.escapeCount == 9) ;

        EndGame(playerWon);
    }

    public void RestartGame()
    {

        RTSUtils[] npcs = FindObjectsOfType<RTSUtils>();
        foreach (RTSUtils npc in npcs)
        {
            Destroy(npc.gameObject);
        }

        npcGenerator.GenerateNPCs();

        Debug.Log("RestartGame: Entry");

            if (modelContainer != null)
            {
                Debug.Log("RestartGame: Setting modelContainer inactive");
                modelContainer.SetActive(false);
            }

            if (gameEndPanel != null)
            {
                Debug.Log("RestartGame: Setting gameEndPanel inactive");
                gameEndPanel.SetActive(false);
            }

            if (playGamePanel != null)
            {
                Debug.Log("RestartGame: Setting playGamePanel inactive");
                playGamePanel.SetActive(false);
            }

            Debug.Log("RestartGame: Calling PlayGame");
            PlayGame();

            Debug.Log("RestartGame: Exit");
            
        
    }

    public void QuitGame()
    {
#if UNITY_STANDALONE
        Application.Quit();
#endif

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void EndGame(bool isWinner)
    {
        if (countdownController != null)
        {
            countdownController.progressBar.gameObject.SetActive(false);
            countdownController.countdownText.gameObject.SetActive(false);
        }
        if (Counter != null)
        {
            Counter.showCount = false;
           
        }

        modelContainer.SetActive(false);
        playGamePanel.SetActive(false);
        gameEndPanel.SetActive(true);

        foreach (Transform child in gameEndPanel.transform)
        {
            child.gameObject.SetActive(false);  
        }

        if (isWinner)
        {
            winPanel.SetActive(true); // Activate win panel when player has won
        }
        else
        {
            losePanel.SetActive(true); // Activate lose panel when player has lost
        }
      


        cameraTransform.position = initialCameraPosition;
        cameraTransform.rotation = initialCameraRotation;
    }
}
