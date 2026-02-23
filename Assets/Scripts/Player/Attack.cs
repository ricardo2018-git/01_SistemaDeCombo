using UnityEngine;

public class Attack : MonoBehaviour
{
    // Scripts
    public AudioPlayer audioPlayer;     // Script para tocar musica
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

    private void OnTriggerEnter2D(Collider2D other) // Quando entrar em colisão
    {
        Damage enemy = other.GetComponent<Damage>();    // Cria instancia do enemy
        if(enemy != null)                               // Verifica se realmnete é um enemy
        {
            audioPlayer.PlaySound(hitSound);            // Acessa script de audio e pede para tocar musica ou som
            enemy.TakeDamage(damage);                   // Acessa enemy e aplica dano passando a força do golpe
            if(slowDown)                                // Verifica se SlowDown esta ativo para esse golpe
                SlowDown.instance.SetSlowDown();        // Acessa script de SlowDown e executa

            UIManager.instance.SetCombo();              // 
        }
    }
}
