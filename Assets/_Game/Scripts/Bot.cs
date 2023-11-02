using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = System.Random;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Bot : Character
{
    public NavMeshAgent navMeshAgent;
    [SerializeField] Transform finishBox;
    [SerializeField] private List<GameObject> finalStair;
    [SerializeField] private GameObject check;
    public int currentStair = 0;
    private IState currentState;
    private Vector3 target;
    private bool isPick= false;
    private int brickLayer= 1 << 6;

    void Start()
    {
        ChangeState(new PickBrickState());
    }
    void Update()
    {
        if (currentState != null) currentState.OnExecute(this);
    }
    public void ChangeState(IState newstate)
    {
        if(currentState!= null)
        {
            currentState.OnExit(this);
        }
        currentState = newstate;
        if(currentState != null)
        {
            currentState.OnEnter(this);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(conststring.BRICK)
            && other.GetComponent<Brick>().mycolor == colorCharater)
        {
            Addbrick(other.gameObject);
        }
        if (other.CompareTag(conststring.BRIDGEBRICK))
        {
            BridgeBrick bridgeBrick = other.GetComponent<BridgeBrick>();
            if (bridgeBrick.isreceived == true && colorCharater != bridgeBrick.brickColor && listBrick.Count > 0)
            {
                ReturnBrick(other.gameObject);
                bridgeBrick.brickColor = colorCharater;
            }
        }

        if (other.CompareTag("FinalStair") && currentStair < 4)
        {
            currentStair = 4;
            stageNumber++;
            ChangeState(new PickBrickState());
        }
    }
    public void StopMoving()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
    }
    public void AcrossBridge()
    {
        if(currentStair==0&& stageNumber == 1)
        {
            currentStair = Random.Range(1, 4);
        }
        else
        {
            navMeshAgent.SetDestination(finalStair[currentStair - 1].transform.position);
        }
    }
    public Transform GetDestination()
    {
        Collider[] hitColliders= Physics.OverlapSphere(transform.position,50, brickLayer);
        float minimumDistance = Mathf.Infinity;
        Transform des= transform;
        foreach (Collider collider in hitColliders)
        {
            if(collider.GetComponent<Brick>().mycolor== colorCharater && collider.name == $"BrickStage{stageNumber}")
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minimumDistance)
                {
                    minimumDistance = distance;
                    des = collider.transform;
                }
            }
        }
        return des;
    }
    public void PickBrick()
    {
        
        if (isPick)
        {
            navMeshAgent.destination = target;
            isPick = false;
        }
        else
        {
            target = GetDestination().position;

            isPick = true;
        }
    }

}
