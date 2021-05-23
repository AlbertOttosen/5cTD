using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cost : MonoBehaviour
{
    public int cost;
    HealthAndEnergy healthAndEnergy;
    
    // Start is called before the first frame update
    void Start()
    {
        healthAndEnergy = GameObject.Find("HealthAndEnergy").GetComponent<HealthAndEnergy>();
    }

    public void BuildTower(GameObject tower) {
        Debug.Log("attempted to buy" + tower.ToString());
        int cost = tower.GetComponent<Cost>().cost;
        if (healthAndEnergy.SpendEnergy(cost)) {
            Instantiate(tower, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
