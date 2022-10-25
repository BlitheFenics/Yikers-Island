using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerBarDragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField]
    TowerType tower = TowerType.ATTACKING;

    public GameObject TowerTransparent;
    public GameObject MiningTransparent;
    public GameObject AtomicTransparent;
    public GameObject WallTransparent;

    private KeyboardSpawner Spawner;

   

    private void Start()
    {
        Spawner = FindObjectOfType<KeyboardSpawner>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {

        }
        //if (eventData.button == PointerEventData.InputButton.Right)
        //{ }
        //if (eventData.button == PointerEventData.InputButton.Middle)
        //{ }
        Debug.Log("BeginDrag");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag" + eventData.delta);
        //Position += eventData.delta / canvas.scaleFactor;
    }

    
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("EndDrag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("DragPointerDown");
        switch (tower)
        {
            case TowerType.ATTACKING:
                Debug.Log("Attack Tower Selected");
                Spawner.OnSelectTower1();
                break;
            case TowerType.MINING:
                Debug.Log("Mining Selected");
                Spawner.OnSelectTower2();
                break;
            case TowerType.ATOMIC:
                Debug.Log("Atomic Tower Selected");
                Spawner.OnSelectTower3();
                break;
            case TowerType.WALL:
                Debug.Log("Wall Tower Selected");
                Spawner.OnSelectTower4();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// when an object of same type is dropped on this object it will increase its count effectively combining the two.
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDragDrop");
    }
}
