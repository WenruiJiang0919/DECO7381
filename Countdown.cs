using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownUIController : MonoBehaviour
{
    public Slider progressBar;                 // Slider UI to display the countdown progress
    public TextMeshProUGUI countdownText;      // Text component to display the countdown time left
    public Camera cameraToFollow;              // Camera which the canvas will follow
    public Vector3 offset = new Vector3(10, 10, 0);  

    public float startingTime = 180f;          // Total time (in seconds) for the countdown
    private float timeLeft;                    // Time left (in seconds) in the countdown
    private int lastDisplayedTime;             // Last rounded time displayed to prevent frequent UI updates

    private void Start()
    {
        progressBar.maxValue = startingTime;   
        timeLeft = startingTime;               // Initialize time left with starting time
        lastDisplayedTime = Mathf.RoundToInt(timeLeft) + 1;  // Set the initial last displayed time
    }

    private void Update()
    {
        PositionCanvasTopRight();  // Adjust canvas position according to camera

        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;        // Decrement time left
            progressBar.value = timeLeft;      // Update progress bar value

            // If rounded time has changed, update the display
            int currentRoundedTime = Mathf.RoundToInt(timeLeft);
            if (currentRoundedTime != lastDisplayedTime)
            {
                countdownText.text = "Time Left: " + currentRoundedTime + "s";
                lastDisplayedTime = currentRoundedTime;
            }

            // Change the color of the progress bar based on remaining time
            if (timeLeft <= 50f)
            {
                progressBar.fillRect.GetComponent<Image>().color = Color.red;
            }
            else
            {
                progressBar.fillRect.GetComponent<Image>().color = Color.green;
            }
        }
   
        else
        {
            
        }
    }

  
    void PositionCanvasTopRight()
    {
        if (cameraToFollow == null) return;   // Return if no camera is set

        // Get top-right position of the camera view
        Vector3 cameraTopRight = cameraToFollow.ViewportToWorldPoint(new Vector3(1, 1, cameraToFollow.nearClipPlane));
        
        // Calculate new position with the offset
        Vector3 newPosition = cameraTopRight + offset;
        
        transform.position = newPosition;     // Update canvas position
    }
}
