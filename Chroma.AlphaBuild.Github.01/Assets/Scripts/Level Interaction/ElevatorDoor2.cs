using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorDoor2 : MonoBehaviour
{
    public float speed;
    public Vector3 targetPosDoor1;
    public Vector3 targetPos;
    public GameObject unequipGun;
    public GameObject hiddenWall;
    public Transform door1;
    [HideInInspector]
    public bool closing;

    Vector3 initPos;
    GameObject elevatorEnter;
    ElevatorEnter entered;

    [Space]

    [Header("Next Scene")]

    [SerializeField] private string sceneName;

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
            door1.localPosition = Vector3.MoveTowards(door1.localPosition, targetPosDoor1, speed * Time.deltaTime);
        }
        
        if(entered.isEntered == true) // closes door
        {
            hiddenWall.SetActive(true);
            door1.localPosition = Vector3.MoveTowards(door1.localPosition, initPos, speed * Time.deltaTime);
            closing = true;
        }

        if(closing == true && door1.localPosition == initPos) // starts elevator
        {
            transform.localPosition = Vector3.MoveTowards(this.transform.localPosition, targetPos, speed * Time.deltaTime);
            Invoke("SceneLoad", 4f);
        }
    }

    private void SceneLoad()
    {
        SceneManager.LoadScene(sceneName);
    }
}
