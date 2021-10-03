using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    // Auffälligkeiten: - man kann gegen den Bounce ankommen, besser wäre es, wenn man sich überall bewegen kann, ausser der Richtung des Bounces
    //                  - es klappt zu ziemlich 100% mit der Funktion aus einer Höhe springen und wieder zur gleichen zurückkommen (muss nur aufpassen wie schnell man in den Trigger kommt, sonst hat es keine Zeit rechtzeitig zu reagieren)
    //                    Ausserdem sollte man, wenn man in der Luft ist, nicht zu spät schiessen, sonst wird der Trigger zu spät erstellt, um deine Velocity zu übernehmen.
    //                    Zusätzlich, wenn, wieso auch immer, 2 Splatter-Decals sich verflechten, dann gibt es keinen Bounce, aber nur, wenn man die Linie, wo velocity mit transform.forward gleichgesetzt wird, wegmacht!!!
    //                  - der Bounce ist nicht wirklich korrekt, es reflektiert nicht den Vektor, sondern man bounced zu der Vektorrichtung, wo das Splatter-Decal hinzeigt
    //                  - wenn man von der Wand abgeprall wird und auf einen Bounce-Decal auf den Boden landet und wieder von der Wand abgeprallt wird usw. Dann baut sich der Bounce immer weiter auf...

    private void OnTriggerEnter(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        bounceTrigger.canBounce = true;
        bounceTrigger.canJump = false;

        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        bounceTrigger.canBounce = true;
        bounceTrigger.canJump = false;

        if ((other.gameObject.tag == "Head") || (other.gameObject.tag == "Bottom"))
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
        }

        if (other.gameObject.tag == "Body")
        {
            bounceTrigger.CharacterVelocity = this.transform.forward * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);
            var direction = Vector3.Reflect(bounceTrigger.CharacterVelocity.normalized, this.transform.forward);
            bounceTrigger.CharacterVelocity = direction * Mathf.Max(bounceTrigger.CharacterVelocity.magnitude, 13f);

            bounceTrigger.CharacterVelocity += Vector3.up * 5f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject firstPersonPlayer = GameObject.Find("FirstPersonPlayer");
        NewPlayerMovement bounceTrigger = firstPersonPlayer.GetComponent<NewPlayerMovement>();

        bounceTrigger.canBounce = false;
    }
}
