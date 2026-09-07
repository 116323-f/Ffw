using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Hold : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    InputAction xAction;
    InputAction zAction;
    
    private bool PointerEntered = false;
    [SerializeField] private Color pressedColour;
    
    [SerializeField] private float HitCounter = 0f;
    [SerializeField] private float PayPerSecond = 1f;
    private float Pay = 0f;

    private SpriteRenderer spriteRenderer;
    private Color originalColour;

    //private help;

    private void Start()
    {
        xAction = InputSystem.actions.FindAction("Xkey");
        zAction = InputSystem.actions.FindAction("Zkey");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColour = spriteRenderer.color;
        //help = GetComponent<Hold>;
        //help.enabled = true;
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
    }

    void Update()
    {
        if (PointerEntered == true)
        {
            if (xAction.IsPressed())
            {
                //print($"X key properly Pressed On {this.name}!");
                spriteRenderer.color = pressedColour;
                ProperlyHit();
            }

            else if (xAction.WasReleasedThisFrame())
            {
                print($"X key released On {this.name}!");
                spriteRenderer.color = originalColour;
            }

            if (zAction.IsPressed())
            {
                //print($"Z key properly Pressed On {this.name}!");
                ProperlyHit();
            }

            else if (zAction.WasReleasedThisFrame())
            {
                print($"Z key released On {this.name}!");
                ProperlyHit.enabled = false;
            }
        }

    }

    //count up hitcounter by seconds held and convert this into pay 
    private void ProperlyHit()
    {
        HitCounter += Time.deltaTime;
        // Convert seconds held into pay
        Pay = (HitCounter/2) * PayPerSecond;
        
        print($"Hit Counter: {HitCounter} seconds, Pay: {Pay}");
    }

    //stop hitcounter and set note to null so its unable to be pressed any longer.
    //make sure to only set this for that single note missed
    //private void NotProperlyHit()
    //{
    //    this.gameObject.SetActive(false);
    //}


}