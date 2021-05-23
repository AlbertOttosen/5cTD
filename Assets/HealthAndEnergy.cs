using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAndEnergy : MonoBehaviour
{
    public int StartingLives = 20;
    public int StartingEnergy = 0;
    int lives = 0;
    int energy = 0;
    public Text livesText;
    public Text energyText;
    public Image gameOver;

    void Start() {
        GainLives(StartingLives);
        GainEnergy(StartingEnergy);
    }

    public void GainLives(int amount) {
        amount = (amount < 0)? 0 : amount;
        lives += amount;
        livesText.text = lives.ToString();
    }

    public void LoseLife(int liveslost = 1) {
        lives -= liveslost;
        lives = (lives < 0)? 0 : lives;
        livesText.text = lives.ToString();
        if (lives <= 0) {
            //gameOver.enabled = true;
        }
    }

    public void GainEnergy(int amount) {
        amount = (amount < 0)? 0 : amount;
        energy += amount;
        energyText.text = energy.ToString();
    }

    public bool SpendEnergy(int amount) {
        amount = (amount < 0)? 0 : amount;
        if (energy - amount < 0) {
            return false;
        } else {
            energy -= amount;
            energyText.text = energy.ToString();
            return true;
        }
    }
}