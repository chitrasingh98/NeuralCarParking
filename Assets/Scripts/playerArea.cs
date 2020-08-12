using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using TMPro;

public class playerArea : MonoBehaviour
{
    [Tooltip("The agent inside the area")]
    public playerAgent playerAgent;

    [Tooltip("The TextMeshPro text that shows the cumulative reward of the agent")]
    public TextMeshPro cumulativeRewardText;

    public Vector3 startPosition;
    /// <summary>
    /// Reset the area, including Car placement
    /// </summary>
    public void ResetArea()
    {
        SpawnCar();
        //playerAgent.SetReward(0.0f);

    }
    

    public void SpawnCar()
    {
        playerAgent.transform.position = transform.position + new Vector3(Random.Range(-6,6),
        Random.Range(-1.5f, 1.5f), 0f);
        playerAgent.transform.rotation = Quaternion.Euler(0f,0f,90f);
        playerAgent.transform.position = new Vector3(8f, 3f, 0f);
        //playerAgent.transform.rotation = Quaternion.Euler(0f,Random.Range(0f, 360f), 0f);
    }
    /// <summary>
    /// Called when the game starts
    /// </summary>
    private void Start()
    {
        ResetArea();
    }
    /// <summary>
    /// Called every frame
    /// </summary>
    private void Update()
    {
        // Update the cumulative reward text
        cumulativeRewardText.text = playerAgent.GetCumulativeReward().ToString("0.00");
    }
}
