using TMPro;
using UnityEngine;

public class Accuracy : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI comboText;
    public void CheckHit(float playerInputTime, float noteTargetTime)
    {
        float timeDifference = Mathf.Abs(playerInputTime - noteTargetTime);

        if (timeDifference <= 0.05f)
        {
            Debug.Log("Perfect!");
            comboText.text = "Perfect!";
        }
        else if (timeDifference <= 0.15f)
        {
            Debug.Log("Good!");
            comboText.text = "Good!";
        }
        else
        {
            Debug.Log("Bad");
            comboText.text = "Bad";
        }
    }
}
