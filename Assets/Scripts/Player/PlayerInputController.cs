using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            CallClickEvent();

            // UI 요소가 클릭된 경우 CallAttackEvent를 실행하지 않음
            if (!IsPointerOverUIElement()) CallAttackEvent();          
        }
    }

    private bool IsPointerOverUIElement()
    {
        // 현재 선택된 UI 요소가 있는지 확인
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return true;
        }

        // 그래픽 레이캐스터를 사용하여 UI 요소를 확인
        PointerEventData eventData = new PointerEventData(EventSystem.current)
        {
            position = Mouse.current.position.ReadValue()
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}
    