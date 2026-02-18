using TMPro;            // Para manipular elementos de texto TMPro do canvas
using UnityEngine;
using UnityEngine.UI;   // Para manipular elementos de UI Canvas

public class Damage : MonoBehaviour
{
    // Scripts
    // ------------------------

    // Componentes
    private SpriteRenderer sprite;              // Sprite enemy
    public Color damageColor;                   // Cor sprite para dano
    private Color defaultColor;                 // Cor padrão enemy
    public Transform damageTextPositionCanvas;  // Posição onde animação do canvas vai aparecer
    // ------------------------

    // Controle lógico
    public float damageTime = 0.1f;     // Cronometro
    // ------------------------

    // Variaveis de Armas, Ataque, Prefab, Game Object e Audio
    public GameObject damageTextCanvas;     // Animação de dano canvas
    // ------------------------

    // UI
    // ------------------------

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();    // Acessa spriterenderer do enemy
        defaultColor = sprite.color;                // Pega cor do sprite enemy padrão
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)  // Aplica dano no enemy
    {
        sprite.color = damageColor;             // Aplica cor de dano
        Invoke("ReleaseDamage", damageTime);    // Executa função com delay de x segundos
        GameObject newDamageText = Instantiate(damageTextCanvas, damageTextPositionCanvas.position, Quaternion.identity);   // Intancia animação do canvas e guarda na variavel
        TMP_Text tmpText = newDamageText.GetComponentInChildren<TMP_Text>();    // Cria uma varival de texto TMP e acessa essa var filha dentro da animação
        tmpText.text = damage.ToString();                                       // Passa o valor do dano para animação
        Destroy(newDamageText, 1f);                                             // Destroi obj instanciado na cena depois de 1 segundo
    }

    void ReleaseDamage()                // Reseta cor do enemy
    {
        sprite.color = defaultColor;    // Aplica cor padrão no enemy
    }
}
