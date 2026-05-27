using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistenciaPlayer : MonoBehaviour
{
    private static PersistenciaPlayer instancia;

    void Awake()
    {
        Debug.Log("🚨 [CONTROL] ¡El script PersistenciaPlayer ha despertado dentro de: " + gameObject.name + "!");

        if (instancia == null)
        {
            instancia = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += AlCargarNivel;
        }
        else
        {
            Debug.LogWarning("[PERSISTENCIA] Se detectó un hongo duplicado en la escena y fue destruido para conservar el original.");
            Destroy(gameObject);
        }
    }

    void AlCargarNivel(Scene escena, LoadSceneMode modo)
    {
        // Si llegamos al Nivel 5, destruimos el personaje persistente
        if (escena.name == "Nivel5")
        {
            SceneManager.sceneLoaded -= AlCargarNivel;
            Destroy(gameObject);
            return;
        }

        Invoke(nameof(TeletransportarAlSpawnPoint), 0.02f);
    }

    void TeletransportarAlSpawnPoint()
    {
        Scene escenaActiva = SceneManager.GetActiveScene();
        GameObject puntoAparicion = null;

        GameObject[] todosLosSpawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        foreach (GameObject spawn in todosLosSpawnPoints)
        {
            if (spawn.scene == escenaActiva)
            {
                puntoAparicion = spawn;
                break;
            }
        }

        if (escenaActiva.name == "Nivel 4")
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = false;

            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = false;

            MonoBehaviour scriptMovimientoTopDown = GetComponent("PlayerController") as MonoBehaviour;
            if (scriptMovimientoTopDown != null) scriptMovimientoTopDown.enabled = false;

            transform.localScale = Vector3.one;

            Debug.Log("🔍 [SISTEMA] ¡Nivel 4 Detectado! Hongo Top-Down silenciado e invisible.");
        }
        else
        {
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.enabled = true;

            Collider2D col = GetComponent<Collider2D>();
            if (col != null) col.enabled = true;

            MonoBehaviour scriptMovimientoTopDown = GetComponent("PlayerController") as MonoBehaviour;
            if (scriptMovimientoTopDown != null) scriptMovimientoTopDown.enabled = true;

            transform.localScale = Vector3.one;
        }

        if (puntoAparicion != null)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.zero;
                rb.angularVelocity = 0f;
                rb.position = puntoAparicion.transform.position;
                transform.position = puntoAparicion.transform.position;
            }
            else
            {
                transform.position = puntoAparicion.transform.position;
            }

            if (escenaActiva.name != "Nivel 4")
            {
                Invoke(nameof(ReactivarFisicas), 0.02f);
            }

            Debug.Log($"✅ [SISTEMA] Hongo fijado con éxito en el SpawnPoint REAL del {escenaActiva.name}.");
        }
        else
        {
            Debug.LogWarning($"⚠️ [ADVERTENCIA] No se encontró ningún 'SpawnPoint' nativo dentro de la escena activa: {escenaActiva.name}");
        }
    }

    void ReactivarFisicas()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            Debug.Log("🕹️ [SISTEMA] Físicas reactivadas con éxito. ¡Hongo libre para jugar!");
        }
    }

    void OnDestroy()
    {
        if (instancia == this)
        {
            SceneManager.sceneLoaded -= AlCargarNivel;
        }
    }
}