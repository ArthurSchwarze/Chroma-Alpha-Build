using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorDoor2 : MonoBehaviour
{
    public float speed, speed2;
    public Vector3 targetPosDoor1;
    public Vector3 targetPos;
    public GameObject unequipGun;
    public GameObject hiddenWall;
    public Transform door1;
    [HideInInspector]
    public bool closing;

    bool oneTime, oneTime2;

    Vector3 initPos;
    GameObject elevatorEnter;
    ElevatorEnter entered;

    [Space]

    [Header("Next Scene")]

    [SerializeField] private string sceneName;

    [Space]

    [Header("SFX")]

    [SerializeField] AudioSource mainSound;
    [SerializeField] AudioSource openSound;
    [SerializeField] AudioSource closeSound;

    private void Start()
    {
        initPos = door1.localPosition;
        elevatorEnter = GameObject.Find("ElevatorEnter");
        entered = elevatorEnter.GetComponent<ElevatorEnter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (unequipGun.activeInHierarchy && entered.isEntered == false) // opens door
        {
            if (!openSound.isPlaying && !oneTime)
            {
                openSound.Play();
                oneTime = true;
            }
            door1.localPosition = Vector3.MoveTowards(door1.localPosition, targetPosDoor1, speed2 * Time.deltaTime);
        }
        
        if(entered.isEntered == true) // closes door
        {
            if (!closeSound.isPlaying && oneTime)
            {
                closeSound.Play();
                oneTime = false;
            }
            hiddenWall.SetActive(true);
            door1.localPosition = Vector3.MoveTowards(door1.localPosition, initPos, speed2 * Time.deltaTime);
            closing = true;
        }

        if(closing == true && door1.localPosition == initPos) // starts elevator
        {
            if (!closeSound.isPlaying && !oneTime2)
            {
                mainSound.PlayDelayed(1f);
                oneTime2 = true;
            }           
            Invoke("ElevatorDoorMove", 3f);
        }
    }

    private void ElevatorDoorMove()
    {
        transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, speed * Time.deltaTime);
        Invoke("SceneLoad", 6f);
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(sceneName);
    }
}
