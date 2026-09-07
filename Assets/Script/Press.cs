using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Press : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    private bool PointerEntered = false;
    [SerializeField] private Color pressedColour;
    private SpriteRenderer spriteRenderer;

    private Press script;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        spriteRenderer = GetComponent<SpriteRenderer>();
        script = GetComponent<Press>();
        script.enabled = true;
    }

    //method status and name(what the method contains)
    public void OnPointerEnter(PointerEventData eventData)
    {
        //what the method does

        print($"On Mouse Enter On {this.name}!");
        PointerEntered = true;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"On Mouse Exit On {this.name}!");
        PointerEntered = false;
        print($"Miss");
        script.enabled = false;
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.WasPressedThisFrame() && xAction.IsPressed())
            {
                print($"X key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColour;
            }

            if (zAction.WasPressedThisFrame() && zAction.IsPressed())
            {
                print($"Z key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColour;
            }

        }

    }

}