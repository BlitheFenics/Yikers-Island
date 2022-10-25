using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


enum PREF_TARGET { WALL, TOWER, RESOURCE, HUB};

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent agent;
    
    [SerializeField]
    int HP;
    [SerializeField]
    int HPMAX;
    [SerializeField]
    float range;
    [SerializeField]
    int damage;
    [SerializeField]
    int PlutoniumValue;
    [SerializeField]
    PREF_TARGET targetting;
    [SerializeField]
    SphereCollider sphereCollider;
    [SerializeField]
    GameObject currentTarget;
    [SerializeField]
    bool Alive = true;
    [SerializeField]
    float attackRange;
    private IEnumerator attackCoroutine;
    [SerializeField]
    GameObject deathPop;

    private Vector3 deathPosition;

    public HealthBar healthBar;
    public AudioSource DyingSound;

    [SerializeField]
    private float AttackDelay = 0.5f;
    private int ModifiedDamage = 1;

    

    private void OnTriggerEnter(Collider other)
    {
        if(!currentTarget.CompareTag("HUB"))
        {
            return;
        }
        switch(targetting)
        {
            case PREF_TARGET.WALL:
                Debug.Log("Start Targetting");
                if(other.CompareTag("Wall"))
                {
                    ModifiedDamage = 3;
                    currentTarget = other.gameObject;
                    Debug.Log("Found Wall");
                }
                break;
            case PREF_TARGET.TOWER:
                if (other.CompareTag("Tower"))
                {
                    ModifiedDamage = 1;
                    currentTarget = other.gameObject;
                    Debug.Log("Found Tower");
                }
                break;
            case PREF_TARGET.RESOURCE:
                if (other.CompareTag("Resource") || other.CompareTag("Energy"))
                {

                    ModifiedDamage = 1;
                    currentTarget = other.gameObject;
                    Debug.Log("Found Resource");
                }
                break;
            case PREF_TARGET.HUB:
                ModifiedDamage = 1;
                break;
        }
        agent.SetDestination(currentTarget.transform.position);
        Debug.Log("Set Destination");

    }

    // Start is called before the first frame update
    void Start()
    {
        currentTarget = GameObject.FindGameObjectWithTag("HUB");
        agent = GetComponent<NavMeshAgent>();
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = range;
        agent.SetDestination(currentTarget.transform.position);
        healthBar.SetHealth(HP, HP);
    }

    // Update is called once per frame
    void Update()
    {

        
		healthBar.SetHealth(HP, HPMAX);
        if (HP <=0 && Alive)
        {
            DyingSound.Play();
            Debug.Log("Now Dead");
            agent.updatePosition = false;
            Alive = false;
            agent.enabled = false;
            deathPosition = transform.position;
            Instantiate(deathPop, deathPosition, transform.rotation);
            transform.Translate(new Vector3(0, -100, 0));
            GameObject.FindGameObjectWithTag("ResourceManager")?.GetComponent<ResourceSystem>().AddPlutonium(PlutoniumValue);
            StartCoroutine(Death());
        }
        
        if(currentTarget == null)
        {
            currentTarget = GameObject.FindGameObjectWithTag("HUB");
            agent.SetDestination(currentTarget.transform.position);
        }
        Debug.DrawLine(transform.position, currentTarget.transform.position, Color.cyan, Time.deltaTime);
        float distance = Vector3.Distance(transform.position, currentTarget.transform.position);
        if (agent == null)
            return;

        //if (distance > 2.5f)
        //{
        //    //agent.updatePosition = true;
        //    agent.isStopped = false;
        //    //agent.SetDestination(target.position);
        //}
        //else
        //{
        //    //agent.updatePosition = false;
        //    agent.isStopped = true;
        //}

        if (distance <= attackRange)
        {
            if (attackCoroutine == null)
            {
                attackCoroutine = Attack();
                StartCoroutine(attackCoroutine);
            }

        }
    }

    IEnumerator Death()
    {
        ResourceSystem.Instance?.AddPlutonium(PlutoniumValue);
        yield return new WaitForSeconds(0.5f);

        Destroy(this.gameObject);
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public bool IsAlive()
    {
        return Alive;
    }

    IEnumerator Attack()
    {
        currentTarget.GetComponent<Tower>().TakeDamage(damage * ModifiedDamage);
        yield return new WaitForSeconds(AttackDelay);

        attackCoroutine = null;
    }
}
