using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{

    [SerializeField] private List<GameObject> bagelList = new List<GameObject>();
    [SerializeField] private GameObject bagelPrefab;
    [SerializeField] private TMP_Text bagelCountText;
    [SerializeField] private AudioClip bagelSound;
    [SerializeField] private AudioClip positiveGateSound;
    [SerializeField] private AudioClip negativeGateSound;
    [SerializeField] private AudioClip gameOverSound;
    private AudioSource playerAudio;
    private CameraFollow cameraFollow;
    private float speed = 5;
    private float horizontalInput;
    private float xRange = 3.8f;
    private int bagelCount = 0;
    private int totalBagelCount = 0;
    private int gateNumber = 0;
    private float updateCameraOffsetY = 0.1f;
    private float updateCameraOffsetZ = 0.3f;
    private float bagelRange = 0.3f;
    public bool isGameOver = false;


    private void Start()
    {
        
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow>();
        playerAudio = GetComponent<AudioSource>();
    }



    void FixedUpdate()
    {
        Move();
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bagel"))
        {
            cameraFollow.offset = new Vector3(cameraFollow.offset.x, cameraFollow.offset.y +updateCameraOffsetY, cameraFollow.offset.z-updateCameraOffsetZ);
            other.gameObject.transform.SetParent(transform);
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.localPosition = new Vector3(0, bagelList[bagelList.Count - 1].transform.localPosition.y + bagelRange, 0);
            bagelList.Add(other.gameObject);
            playerAudio.PlayOneShot(bagelSound,1);
            UpdateBagelCountText();
            UpdateBegelCount();
        }

        if (other.gameObject.CompareTag("Gate"))
        {
           
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            gateNumber = other.gameObject.GetComponent<GateController>().GetGateNumber();
            

            if (gateNumber > 0)
            {
                totalBagelCount = bagelCount + gateNumber;
                CreateBagel();
                playerAudio.PlayOneShot(positiveGateSound,1);
                UpdateBagelCountText();
                UpdateBegelCount();
            }
            else if (gateNumber < 0)
            {
                if(gateNumber >= -(bagelList.Count - 1))
                {
                    totalBagelCount = bagelCount + gateNumber;
                    DestroyBagel();
                    playerAudio.PlayOneShot(negativeGateSound, 1);
                    UpdateBagelCountText();
                    UpdateBegelCount();
                }
                else
                {
                    isGameOver = true;
                    playerAudio.PlayOneShot(gameOverSound, 1);
                    Time.timeScale = 0;
                    
                }
                
            }
        }

    }


    private void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    private void UpdateBagelCountText()
    {
        bagelCountText.text ="Score : " +(bagelList.Count-1).ToString();
    }

    private void UpdateBegelCount()
    {
        bagelCount = bagelList.Count;
    }

   
    

    private void CreateBagel()
    {
        cameraFollow.offset = new Vector3(cameraFollow.offset.x, cameraFollow.offset.y + (gateNumber * updateCameraOffsetY), cameraFollow.offset.z - (gateNumber * updateCameraOffsetZ));
        for (int i = 0; i < gateNumber; i++)
        {
            GameObject newBagel = Instantiate(bagelPrefab);
            newBagel.transform.SetParent(transform);
            newBagel.GetComponent<BoxCollider>().enabled = false;
            newBagel.transform.localPosition = new Vector3(0, bagelList[bagelList.Count - 1].transform.localPosition.y + bagelRange, 0);
            bagelList.Add(newBagel);
        }
    }

    private void DestroyBagel()
    {
        cameraFollow.offset = new Vector3(cameraFollow.offset.x, cameraFollow.offset.y - (-gateNumber * updateCameraOffsetY), cameraFollow.offset.z + (-gateNumber * updateCameraOffsetZ));
        for (int i = bagelCount - 1; i >= totalBagelCount; i--)
        {
            Destroy(bagelList[i]);
            bagelList.RemoveAt(i);
        }
    }
}
