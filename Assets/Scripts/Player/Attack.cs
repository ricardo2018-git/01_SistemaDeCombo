using UnityEngine;

public class Attack : MonoBehaviour
{
    // Scripts
    // ------------------------

    // Componentes
    // ------------------------

    // Controle lógico
    private int damage;             // Dano
    private bool slowDown;          // Sinaliza se vai desativar defesa do inimigo
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    private AudioClip hitSound;     // Som do ataque
    // ------------------------

    // UI
    // ------------------------

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetAttack(Hit hit)  // Configura ataque
    {
        damage = hit.damage;        // Recebe dano do hit
        slowDown = hit.slowDown;    // Recebe se desativa ou não do hit
        hitSound = hit.hitSound;    // Recebe som do hit
    }
}
