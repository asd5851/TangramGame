using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzlePlayPart : MonoBehaviour, IPointerDownHandler
, IPointerUpHandler, IPointerMoveHandler
{
    private bool isClicked = false;

    void Start()
    {
        isClicked = false;   
    }
    
    void Update()
    {
        
    }
    
    //! 마우스 버튼을 눌렀을 때 동작하는 함수
    public void OnPointerDown(PointerEventData eventData)
    {
        isClicked = true;
        // DEBUG
        //GFunc.Log($"{gameObject.name}을 선택했다.");
    }       // OnPointerDown
    
    //! 마우스 버튼에서 손을 뗐을 때 동작하는 함수
    public void OnPointerUp(PointerEventData eventData)
    {
        isClicked = false;
        // DEBUG
        //GFunc.Log($"{gameObject.name}을 선택해제했다.");

    }       // OnPointerUp

    //! 마우스를 드래그 중일 때 동작하는 함수
    public void OnPointerMove(PointerEventData eventData)
    {
        if(isClicked == true)
        {
            gameObject.SetLocalPos(eventData.position.x, eventData.position.y, 0f);
            GFunc.Log($"마우스의 포지션 확인 : {eventData.position.x}, {eventData.position.y}");
        }      // if : 현재 오브젝트를 선택한 경우
    }       // OnPointerMove
}
