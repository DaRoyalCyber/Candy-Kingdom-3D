using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemies : MonoBehaviour
{
    public float maxSpeed = 3f;
    public float minSpeed = 1f;
    public Transform castle;

    float moveSpeed;

    Rigidbody rb;

    public float rayDistance = 2f;

    bool isBlocked = false;


    // hp 

   public float currentHP = 100f;

    Animator anim;
    public GameObject psDeath;

    //path

    Transform[] pathPoints;
    int currentPAthIndex = 0;


    // blocked 
    public Transform dropPoint;

    bool isGivingUp = false;

    bool goingToDrop;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
     
        anim = GetComponentInChildren<Animator>();
        moveSpeed =Random.Range(minSpeed,maxSpeed);

    }
    private void Start()
    {

        castle = CastlesMAnager.Instance.GetCastle();
      EnemyPAth[] allPaths = FindObjectsOfType<EnemyPAth>();
        float minDistance = 1000f;

        EnemyPAth closestPath = null;

        foreach (EnemyPAth path in allPaths) { 
        float dis = path.GetDistanceToPathStart(transform.position);

        if(dis< minDistance)
            {
                minDistance = dis;
                closestPath = path;
            }
        
        }
        if (closestPath != null) { 
        
        pathPoints = closestPath.pathPoints;
        }

 
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayDistance)) {

            if (hit.collider.gameObject.tag == "Rubble")
            {
                isBlocked = true;
                Invoke("GiveUp",0.1f);
            }
            else
            {
                isBlocked = false;
            }
        }
        else
        {
            isBlocked = false;
        }
    }
    private void FixedUpdate()
    {

        if(isGivingUp && dropPoint != null)
        {
            anim.SetBool("Walk", true);
         


            Vector3 dir = (dropPoint.position - transform.position).normalized;
            rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);
            return;
        }
        if (!isBlocked )
        {
            anim.SetBool("Walk", true);
         

            Vector3 pointPos;
            if (currentPAthIndex < pathPoints.Length)
            {
                pointPos = pathPoints[currentPAthIndex].position;
                Vector3 dir = (pointPos - transform.position).normalized;

                rb.MovePosition(transform.position + dir * maxSpeed * Time.deltaTime);

                if (Vector3.Distance(pointPos, transform.position) < 0.5f)
                {
                    currentPAthIndex++;
                 
                }

            }
            else
            {
                Vector3 dir = (castle.transform.position - transform.position).normalized;
                rb.MovePosition(transform.position + dir * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (SceneManager.GetActiveScene().name == "GumLevel")
        {
            GumLevelHOUse gumLevel = collision.gameObject.GetComponent<GumLevelHOUse>();
            if (gumLevel != null)
            {

              
                gumLevel.ShakeHouse();
            }
        }
        else if (SceneManager.GetActiveScene().name == "Spinning Level")
        {
            HouseCandy houseCandy = collision.gameObject.GetComponent<HouseCandy>();
            if (houseCandy != null)
            {
                houseCandy.ShakeHouse();
            }
        }
        else if(SceneManager.GetActiveScene().name == "bridgeLevel")
        {
            BridgeHouse houseBridge = collision.gameObject.GetComponent<BridgeHouse>();
            if(houseBridge != null)
            {
                houseBridge.ShakeHouse();
            }
        }
        if (collision.gameObject.tag == "Death")
        {
            EnemySpawner.RegisterEnemyDeath();
        }
    }

    public void GetDamaged(float damage)
    {
        currentHP -= damage;
        if (currentHP <= 0) {
            anim.SetTrigger("Death");
       
            EnemySpawner.RegisterEnemyDeath();

            Instantiate(psDeath, transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
        }
    }
    void GiveUp()
    {
        if (isBlocked)
        {
            isGivingUp = true;

        }

    }



}

