using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IDragHandler,IBeginDragHandler,IEndDragHandler
{
    //not the best code but it works

    private GameObject _copy;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _copy = Instantiate(transform.gameObject,transform.parent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _copy.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hit , 100) && hit.collider.tag == "CardStack")
        {
            Destroy(_copy);
            gameObject.SetActive(false);
        }
        else
        Destroy(_copy);

    }
}
