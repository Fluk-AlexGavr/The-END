using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootstepSounds : MonoBehaviour
{
    public List<AudioClip> FootstepSounds;  // List of footstep sounds
    public float StepsInterval = 1f;  // Cooldown between footsteps
    float distToGround = 1f;  // Distance to the ground (used for the raycast)
    private bool isFootstepPlaying = false;  // Flag to check if footstep sound is already playing

    private void Update()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && !isFootstepPlaying)
        {
            if (Physics.Raycast(transform.position, Vector3.down, distToGround + 0.1f))
            {
                StartCoroutine(PlaySounds());
            }
        }
    }

    IEnumerator PlaySounds()
    {
        isFootstepPlaying = true;  // Set the flag to true so that no new coroutines are started

        // Pick a random footstep sound from the list
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = FootstepSounds[Random.Range(0, FootstepSounds.Count)];
        audio.Play();  // Play the selected sound

        // Wait for the duration of the interval before allowing another sound to play
        yield return new WaitForSeconds(StepsInterval);

        isFootstepPlaying = false;  // Reset the flag to allow the next footstep sound to play
    }
}
