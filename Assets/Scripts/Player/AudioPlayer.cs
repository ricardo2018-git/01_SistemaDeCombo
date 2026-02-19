using UnityEngine;

[RequireComponent(typeof(AudioSource))]     // Quando colocar esse script em qualquer gameobject ele vai importar um componente de audio automaticamente
public class AudioPlayer : MonoBehaviour
{
    // Scripts
    // ------------------------

    // Componentes
    private AudioSource audioSource;    // Referencia do componenete de audio
    // ------------------------

    // Controle lógico
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    // ------------------------

    // UI
    // ------------------------

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();  // Acessa componente de audio
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;    // Passa musica para componente de musica
        audioSource.Play();         // Toca música
    }
}
