using UnityEngine;
using System;       // Para aparecer na unity no player

// Esse script é apenas um componente, não será associado a nenhum game object

[Serializable]      // Para aparecer na unity no player
public class Combo
{
    public Hit[] hits;      // Vetor de hits
}

[Serializable]      // Para aparecer na unity no player
public class Hit
{
    public string animation;    // Animação
    public string inputButton;  // Botão
    public float animationTime; // Tempo da animação
    public float resetTime;     // Reseta o combo

    public int damage;          // Dano
    public AudioClip hitSound;  // Som se o hit atingir o inimigo
    public bool slowDown;       // 
}