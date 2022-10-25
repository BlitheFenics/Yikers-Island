using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum TargetStyle
{
    Single_RetargetOutRange, 
    Single_RetargetOnFrame
}

public class TowerTargeting : MonoBehaviour
{
    [SerializeField]
    TargetStyle targetStyle = TargetStyle.Single_RetargetOutRange;
    [SerializeField]
    int AttacksPerSecond;
    [SerializeField]
    float timer;
    [SerializeField]
    int Damage;
    [SerializeField]
    float Range;
    [SerializeField]
    GameObject currentEnemyTarget;
    [SerializeField] 
    SphereCollider sphereCollider;
    [SerializeField] 
    List<GameObject> EnemysInRange;

    //public HealthBar healthBar;

    public Animator animr;
    public Transform pitch;
    public Transform yaw;

    private LineRenderer beam;

    public AudioSource shootSound;
    public bool EffectWorking = true;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something Entered");
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy");
            if (!EnemysInRange.Contains(other.gameObject))
            {
                Debug.Log("Enemy Added");
                EnemysInRange.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (EnemysInRange.Contains(other.gameObject))
            EnemysInRange.Remove(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        //sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = Range;
        //healthBar.SetHealth(10, 10); // we can put in health later

        animr = GetComponent<Animator>();
        beam = GetComponent<LineRenderer>();
        beam.SetPosition(0, pitch.position);
        beam.SetPosition(1, pitch.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!EffectWorking)
        {
            animr.SetBool("SeesEnemy", false);
            beam.SetPosition(1, pitch.position);
            return;
        }

        //healthBar.SetHealth(10, 10);
        if (targetStyle == TargetStyle.Single_RetargetOutRange)
        {
            if (currentEnemyTarget == null || !EnemysInRange.Contains(currentEnemyTarget))
            { ChooseNewTarget(); }
        }
        else if (targetStyle == TargetStyle.Single_RetargetOnFrame)
        {
            ChooseNewTarget();
        }

        //Draw lines to Each enemy in Range
        foreach (GameObject Enemy in EnemysInRange)
        {
            Debug.DrawLine(transform.position, Enemy.transform.position, Color.blue, Time.deltaTime);
        }
        if (currentEnemyTarget != null)
        {
            Debug.DrawLine(transform.position, currentEnemyTarget.transform.position, Color.red, Time.deltaTime + 0.01f);
        }
    }

    void ChooseNewTarget()
    {

        if (EnemysInRange.Count == 0)
        {
            currentEnemyTarget = null;
            animr.SetBool("SeesEnemy", false);
            beam.SetPosition(1, pitch.position);
            return;
        }
        // Check for Closest Enemy
        float closestDistance = 10000000;
        if (EnemysInRange[0] != null)
            closestDistance = Vector3.Distance(transform.position, EnemysInRange[0].transform.position);
        GameObject Target = EnemysInRange[0];
        foreach (GameObject Enemy in EnemysInRange)
        {
            if (Vector3.Distance(transform.position, Enemy.transform.position) <= closestDistance )
            {
                closestDistance = Vector3.Distance(transform.position, Enemy.transform.position);
                Target = Enemy;
            }
        }
        currentEnemyTarget = Target;
        animr.SetBool("SeesEnemy", true);
    }

    private void Update()
    {
        if (currentEnemyTarget == null)
            return;

        if (!EffectWorking) return;

        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0 && currentEnemyTarget != null)
        {
            currentEnemyTarget.GetComponent<EnemyAI>().TakeDamage(Damage);
            timer = 1.0f / AttacksPerSecond;
            shootSound.Play();

            AimAtTarget();
        }
    }


    private void AimAtTarget()
    {
        float dy = currentEnemyTarget.transform.position.y - pitch.position.y;
        float dx = currentEnemyTarget.transform.position.x - pitch.position.x;
        float dz = currentEnemyTarget.transform.position.z - pitch.position.z;

        float h = Vector3.Distance(currentEnemyTarget.transform.position, pitch.position);

        float theta = Mathf.Rad2Deg * Mathf.Asin(dy / h);

        Debug.Log(theta);

        animr.SetFloat("PitchAngle", theta);


        //float tangent = Mathf.Abs(dz) / Mathf.Abs(dx);
        //float yawTheta = Mathf.Atan(tangent);


        
        float yawAngle = Vector3.Angle(Vector3.ProjectOnPlane(currentEnemyTarget.transform.position - transform.position, Vector3.up), -transform.forward);
        animr.SetFloat("YawAngle", yawAngle);

        beam.SetPosition(1, currentEnemyTarget.transform.position);
    }
}
