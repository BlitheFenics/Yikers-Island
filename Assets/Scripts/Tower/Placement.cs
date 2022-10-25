using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    [SerializeField]
    SkinnedMeshRenderer rend;
    [SerializeField]
    MeshRenderer otherRend;


    Material mat;

    private Grid grid;
    private int collisionCount = 0;

    RaycastHit hit;
    Vector3 movePoint;
    public GameObject AttackTower;
    public GameObject MiningTower;
    public GameObject AtomicTower;
    public GameObject Wall;
    public Vector3 offset = new Vector3(0, 1, 0);

    private CameraController CameraController;

    public KeyboardSpawner Spawner;
    public LayerMask SpawnLayer;

    public Color holoRed;
    public Color holoGreen;

    [SerializeField]
    private TowerManagerScript TowerManager;

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        TowerManager = FindObjectOfType<TowerManagerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraController = FindObjectOfType<CameraController>();

        name = gameObject.name;
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);   //old code from phoenix
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        if(Physics.Raycast(ray, out hit, 50000.0f, (1 << 10)))
        {
            transform.position = hit.point;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("The tower is: " + gameObject.name);
        Ray ray = Camera.main.ScreenPointToRay(CameraController.CurrentMousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, SpawnLayer))
        {
            //transform.position = hit.point + offset;
            TilePlacemnt(hit.point);
        }

        if (rend == null)
        {
            Debug.Log("rend is null");
        }

        float intensity = Mathf.Pow(2.0f, 2.61f);
        holoRed = new Color(1 * intensity, 0, 0);
        holoGreen = new Color(0, 1 * intensity, 0);

        if (rend != null)
        {
            mat = rend.material;
        }
        else if (otherRend != null)
        {
            mat = otherRend.material;
        }
    }

     private void OnCollisionEnter(Collision other)
    {
        mat?.SetColor("_HoloColor", holoRed);
        collisionCount++;
    }

    private void OnCollisionExit(Collision other)
    {
        mat.SetColor("_HoloColor", holoGreen);
        collisionCount--;
    }

    private void TilePlacemnt(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        gameObject.transform.position = finalPosition + offset;
    }
    public void OnPlaceTower()
    {


        if (collisionCount == 0)
        {
            if (Spawner != null)
            {
                Spawner.CurrentlySelectedTower = null;
            }
            if (name == "TowerTransparentUpright(Clone)"
            && ResourceSystem.Instance.GetEnergy() < ResourceSystem.Instance.EnergyMax
            && ResourceSystem.Instance.GetOre() >= 20)
            {
                TowerManager.AddNewTower(Instantiate(AttackTower, transform.position, transform.rotation));
                Destroy(gameObject);
            }
            if (name == "Mining Tower Transparent(Clone)" && ResourceSystem.Instance.GetEnergy() < ResourceSystem.Instance.EnergyMax)
            {
                TowerManager.AddNewTower(Instantiate(MiningTower, transform.position, transform.rotation));
                Destroy(gameObject);
            }
            if (name == "AtomicTower Transparent(Clone)" && ResourceSystem.Instance.GetPlutonium() >= 20)
            {
                Instantiate(AtomicTower, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (name == "Wall Transparent(Clone)" && ResourceSystem.Instance.GetOre() >= 20)
            {
                Instantiate(Wall, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }

    }

}
