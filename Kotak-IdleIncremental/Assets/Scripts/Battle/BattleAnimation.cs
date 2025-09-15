using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BattleAnimation : MonoBehaviour
{
    [Header("Position Markers (Empty UI GameObjects)")]
    public GameObject playerOriginalPosition;   // Empty UI object marking player's base position
    public GameObject monsterOriginalPosition;  // Empty UI object marking monster's base position

    [Header("Battle Characters (UI Images)")]
    public GameObject playerObject;  // The player UI Image
    public GameObject monsterObject; // The monster UI Image

    private Image monsterImage;
    private Image playerImage;

    public GameObject normalMouth;
    public GameObject attackedMouth;

    public Battle battle; // Optional, if you want to call Battle logic

    public SoundManager soundManager; // To play sound effects
    void Start()
    {
        if (monsterObject != null)
        {
            monsterImage = monsterObject.GetComponent<Image>();
        }
        if (playerObject != null)
        {
            playerImage = playerObject.GetComponent<Image>();
        }
    }

    // Player attack lunge forward and back
    public void PlayAttackAnimation()
    {
        StartCoroutine(AttackCoroutine());
    }

    private IEnumerator AttackCoroutine()
    {
        // Move forward relative to marker
        playerObject.transform.position = playerOriginalPosition.transform.position + new Vector3(50f, 0f, 0f); // 50px in UI
        soundManager.PlayAttackSfx(); // Play attack sound effect
        yield return new WaitForSeconds(0.1f);

        // Move back to marker
        playerObject.transform.position = playerOriginalPosition.transform.position;
    }

    // Monster flash red when hit
    public void PlayDamageAnimation()
    {
        StartCoroutine(DamageCoroutine());
    }

    private IEnumerator DamageCoroutine()
    {
        normalMouth.SetActive(false);
        attackedMouth.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        
        normalMouth.SetActive(true);
        attackedMouth.SetActive(false);
    }

    // Monster gets pushed to the right and fades out (death)
    public void PlayDeathAnimation()
    {
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 startPos = monsterOriginalPosition.transform.position;
        Vector3 endPos = startPos + new Vector3(1000f, 0f, 0f); // push by 100px

        Color startColor = monsterImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f); // alpha → 0

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            monsterObject.transform.position = Vector3.Lerp(startPos, endPos, t);
            monsterImage.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }

        // After "death", auto-respawn
        PlaySpawnAnimation();
    }

    // Monster fades in at spawn
    public void PlaySpawnAnimation()
    {
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        monsterObject.transform.position = monsterOriginalPosition.transform.position;

        float duration = 0.5f;
        float elapsed = 0f;
        Color startColor = new Color(monsterImage.color.r, monsterImage.color.g, monsterImage.color.b, 0f); // hidden
        Color endColor = Color.white; // visible

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            monsterImage.color = Color.Lerp(startColor, endColor, t);

            yield return null;
        }
    }
}
