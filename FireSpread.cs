using UnityEngine;

public class FireSpread : MonoBehaviour
{
    public float spreadInterval;
    public Vector3[] spreadDirections;
    public Transform fireScenesTransform;
    public bool isActiveScene = false;
    private bool hasStarted = false;
    private ParticleSystem fireParticles;
    private float timer = 0f;
    private static bool shouldStopSpreading = false;

    private void Awake()
    {
        fireParticles = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        if (isActiveScene) 
        {
            StartFire();
        }
    }

    private void Update()
    {
        if (hasStarted)
        {
            timer += Time.deltaTime; // update timer
            if (timer >= 7f) 
            {
                shouldStopSpreading = true;
                hasStarted = false; 
            }
        }
    }

    public void StartFireSpread()
    {
        // Debug.Log(gameObject.name + ": Starting fire spread");
        if (hasStarted && !shouldStopSpreading)
        {
            foreach (Vector3 direction in spreadDirections)
            {
                Vector3 newPosition = transform.position + direction;
                // Debug.Log(gameObject.name + ": Spreading fire to position " + newPosition);
                CreateFireInstance(newPosition);
            }
        }
    }

    public void StartFire(bool isNewInstance = false)
    {
        // Debug.Log(gameObject.name + ": Starting fire");
        if (fireParticles != null && !fireParticles.isPlaying)
        {
            fireParticles.Play();
        }
        gameObject.SetActive(true);
        hasStarted = true;

        if(!isNewInstance)
        {
            InvokeRepeating("StartFireSpread", spreadInterval, spreadInterval);
        }
    }

    void CreateFireInstance(Vector3 position)
    {
        if (!shouldStopSpreading) {
            // Debug.Log(gameObject.name + ": Creating fire instance at " + position);
            GameObject newFireInstance = Instantiate(gameObject, position, Quaternion.identity);
            newFireInstance.transform.SetParent(fireScenesTransform);
            Vector3 currentRotation = newFireInstance.transform.eulerAngles;
            newFireInstance.transform.eulerAngles = new Vector3(-90f, currentRotation.y, currentRotation.z);
            newFireInstance.transform.position = position;

            FireSpread newFireSpread = newFireInstance.GetComponent<FireSpread>();
            if (newFireSpread)
            {
                // Debug.Log(gameObject.name + ": Setting spread directions for new instance");
                newFireSpread.spreadDirections = this.spreadDirections;
                newFireSpread.StartFire(true);
            }

            newFireInstance.SetActive(true);
        }
    }
}
