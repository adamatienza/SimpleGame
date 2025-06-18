using UnityEngine;

public class RightGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallController>() != null)
        {
            ScoreManager.instance.Player1Scored();
        }
    }
}