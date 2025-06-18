using UnityEngine;

public class LeftGoal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallController>() != null)
        {
            ScoreManager.instance.Player2Scored();
        }
    }
}