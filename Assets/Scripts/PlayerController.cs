using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 50f;

    [SerializeField] float xRange = 22f;
    [SerializeField] float yRange = 14f;
    [SerializeField] float positionPitchRatio = -2f;
    [SerializeField] float controlledPitchRatio = -10f;
    [SerializeField] float positionRollRatio = -2f;
    [SerializeField] float positionYawRatio = 1.5f;
    [SerializeField] float controlledRollRatio = -10f;
    [SerializeField] GameObject explosion;
    [SerializeField] GameObject guns;

    

    


    float xThrow, yThrow;

    bool playerAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    if(playerAlive)
    {
        ProcessTranslation();
        ProcessRotation();
    }
     

    }
    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * Speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(clampedXpos, transform.localPosition.y, transform.localPosition.z);
        

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * Speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos =Mathf.Clamp(rawYPos, -yRange, yRange);
        // float clampedXpos = Mathf.Clamp(rawXPos, -xRange, xRange);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchRatio + yThrow * controlledPitchRatio;
        float yaw = transform.localPosition.x * positionYawRatio;
        float roll = transform.localPosition.x * positionRollRatio + xThrow * controlledRollRatio;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void PlayerDeath()
    {
        playerAlive = false;
        explosion.SetActive(true);
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
        guns.SetActive(false);
        StartCoroutine(GameOver());
        

    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }

   

   
}
