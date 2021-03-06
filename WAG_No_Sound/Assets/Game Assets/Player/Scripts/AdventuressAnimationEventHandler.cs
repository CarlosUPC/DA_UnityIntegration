////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using UnityEngine;
using System.Collections;

public class AdventuressAnimationEventHandler : MonoBehaviour
{
    [System.Serializable]
    public struct WeaponHit
    {
        public WeaponTypes weapon;
        public SoundMaterial.Materials material;
        public AudioClip clip;
    }

    [Header("Wwise")]
    public AK.Wwise.Event Swing = new AK.Wwise.Event();
    public AK.Wwise.Event GetItem = new AK.Wwise.Event();
    public AK.Wwise.Trigger GetItemStinger = new AK.Wwise.Trigger();

    [Header("Surface Sounds")]
    public AudioClip[] dirtWalk;
    public AudioClip[] dirtRun;
    public AudioClip[] grassWalk;
    public AudioClip[] grassRun;
    public AudioClip[] rubbleWalk;
    public AudioClip[] rubbleRun;
    public AudioClip[] sandWalk;
    public AudioClip[] sandRun;
    public AudioClip[] stoneWalk;
    public AudioClip[] stoneRun;
    public AudioClip[] waterWalk;
    public AudioClip[] waterRun;
    public AudioClip[] woodWalk;
    public AudioClip[] woodRun;

    [Header("Object Pickup Sounds")]
    public AudioClip book;
    public AudioClip evilEssence;
    public AudioClip mushroom;
    public AudioClip crystalShard;
    public AudioClip pinecone;
    public AudioClip key;
    public AudioClip scroll;
    //public AudioClip swing1;
    //public AudioClip swing2;
    //public AudioClip swing3;

    [Header("Weapon Pickup Sounds")]
    public AudioClip sword;
    public AudioClip axe;
    public AudioClip pickaxe;
    public AudioClip hammer;

    [Header("Weapon Attack Sounds")]
    public AudioClip swing_audio_clip;
    AudioSource audioSource;

    [Header("Weapon Attack Material Sounds")]
    public WeaponHit[] weapon_hit;


    [Header("Object Links")]
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private GameObject runParticles;
    [SerializeField]
    private GameObject runParticlesSprint;

    private PlayerFoot foot_L;
    private PlayerFoot foot_R;

   // public AudioClip footsteps;
    //public AudioClip get_item_audio_clip;


    #region private variables
    private bool hasPausedMovement;
    private readonly int canShootMagicHash = Animator.StringToHash("CanShootMagic");
    private readonly int isAttackingHash = Animator.StringToHash("IsAttacking");
    #endregion

    private void Awake()
    {
        GameObject L = GameObject.Find("toe_left");
        GameObject R = GameObject.Find("toe_right");
        audioSource = GetComponent<AudioSource>();

       

        if (L != null)
        {
            foot_L = L.GetComponent<PlayerFoot>();
        }
        else {
            print("Left foot missing");
        }
        if (R != null)
        {
            foot_R = R.GetComponent<PlayerFoot>();
        }
        else
        {
            print("Right foot missing");
        }
    }


    void enableWeaponCollider()
    {
        if (PlayerManager.Instance != null && PlayerManager.Instance.equippedWeaponInfo != null)
        {
            PlayerManager.Instance.equippedWeaponInfo.EnableHitbox();
        }
    }

    void disableWeaponCollider()
    {
        if (PlayerManager.Instance != null && PlayerManager.Instance.equippedWeaponInfo != null)
        {
            PlayerManager.Instance.equippedWeaponInfo.DisableHitbox();
        }

    }

    void ScreenShake()
    {
        PlayerManager.Instance.cameraScript.CamShake(new PlayerCamera.CameraShake(0.4f, 0.7f));
    }

    bool onCooldown = false;
    public enum FootSide { left, right };
    public void TakeFootstep(FootSide side)
    {
        if (foot_L != null && foot_R != null) {
            if (!PlayerManager.Instance.inAir && !onCooldown)
            {
                Vector3 particlePosition;

                if (side == FootSide.left )
                {
                    //if (foot_L.FootstepSound.Validate())
                    //{ 
                        foot_L.PlayFootstepSound();
                        //audioSource.clip = footsteps;
                        //audioSource.Play();
                        particlePosition = foot_L.transform.position;
                        FootstepParticles(particlePosition);
                    //}
                }
                else
                {
                    //if (foot_R.FootstepSound.Validate())
                    //{
                        foot_R.PlayFootstepSound();
                        //audioSource.clip = footsteps;
                        //audioSource.Play();
                        particlePosition = foot_R.transform.position;
                        FootstepParticles(particlePosition);
                    //}
                }
            }
        }
    }

    void FootstepParticles(Vector3 particlePosition) {

        if (PlayerManager.Instance.isSprinting)
        {
       
            GameObject p = Instantiate(runParticlesSprint, particlePosition + -Vector3.forward * 0.1f, Quaternion.identity) as GameObject;
            p.transform.parent = SceneStructure.Instance.TemporaryInstantiations.transform;
            Destroy(p, 5.0f);
            StartCoroutine(FootstepCooldown());
        }
        else
        {
           GameObject p = Instantiate(runParticles, particlePosition + Vector3.up * 0.1f, Quaternion.identity) as GameObject;
           p.transform.parent = SceneStructure.Instance.TemporaryInstantiations.transform;
           Destroy(p, 5.0f);
           StartCoroutine(FootstepCooldown());
        }

    }

    IEnumerator FootstepCooldown()
    {
        onCooldown = true;
        yield return new WaitForSecondsRealtime(0.2f);
        onCooldown = false;
    }

    void ReadyToShootMagic()
    {
        PlayerManager.Instance.playerAnimator.SetBool(canShootMagicHash, true);
    }

    public enum AttackState { NotAttacking, Attacking };
    void SetIsAttacking(AttackState state)
    {
        if (state == AttackState.NotAttacking)
        {
            playerAnimator.SetBool(isAttackingHash, false);
        }
        else
        {
            playerAnimator.SetBool(isAttackingHash, true);
        }
    }

    public void Weapon_SwingEvent()
    {
        // PLAY SOUND
        Weapon W = PlayerManager.Instance.equippedWeaponInfo;
        W.WeaponTypeSwitch.SetValue(PlayerManager.Instance.weaponSlot);
        Swing.Post(PlayerManager.Instance.weaponSlot);
        audioSource.clip = swing_audio_clip;
        audioSource.Play();
    }

    public void PauseMovement()
    {
        if (!hasPausedMovement)
        {
            hasPausedMovement = true;
            PlayerManager.Instance.motor.SlowMovement();
        }
    }

    public void ResumeMovement()
    {
        if (hasPausedMovement)
        {
            hasPausedMovement = false;
            PlayerManager.Instance.motor.UnslowMovement();
        }
    }

    public void FreezeMotor()
    {
        StartCoroutine(PickupEvent());
    }

    private IEnumerator PickupEvent()
    {
        PlayerManager.Instance.PauseMovement(gameObject);
        yield return new WaitForSeconds(2f);
        PlayerManager.Instance.ResumeMovement(gameObject);
    }

    public void PickUpItem()
    {
        PlayerManager.Instance.PickUpEvent();
        //GetItem.Post(this.gameObject);
        //audioSource.clip = get_item_audio_clip;
        //audioSource.Play();
        //GetItemStinger.Post(GameManager.Instance.MusicGameObject);

        AudioSource audio_source = GetComponent<AudioSource>();
        Weapon player_weapon = PlayerManager.Instance.equippedWeaponInfo;

        switch (player_weapon.weaponType)
        {
            case WeaponTypes.Sword:
                audio_source.PlayOneShot(sword, 0.2f);
                break;
            case WeaponTypes.Axe:
                audio_source.PlayOneShot(axe, 0.2f);
                break;
            case WeaponTypes.PickAxe:
                audio_source.PlayOneShot(pickaxe, 0.2f);
                break;
            case WeaponTypes.Hammer:
                audio_source.PlayOneShot(hammer, 0.2f);
                break;
        }

    }

    public void WeaponSound()
    {
        AudioSource audio_source = GetComponent<AudioSource>();
        Weapon EquippedWeapon = PlayerManager.Instance.equippedWeaponInfo;
        SoundMaterial.Materials mat = SoundMaterial.Materials.DIRT;
        //EquippedWeapon.WeaponImpact.Post(EquippedWeapon.transform.parent.gameObject);

        if (EquippedWeapon.LastObjectHit() && EquippedWeapon.LastObjectHit().GetComponent<SoundMaterial>())
            mat = EquippedWeapon.LastObjectHit().GetComponent<SoundMaterial>().material;

        audio_source.PlayOneShot(RetrieveImpactSound(EquippedWeapon.weaponType, mat), 0.05f);

    }

    public AudioClip RetrieveImpactSound(WeaponTypes weapon, SoundMaterial.Materials material)
    {
        foreach (WeaponHit element in weapon_hit)
        {
            if (element.weapon == weapon && element.material == material)
                return element.clip;
        }

        foreach (WeaponHit element in weapon_hit) //If not found return DIRT impact
        {
            if (element.weapon == weapon && element.material == SoundMaterial.Materials.DIRT)
                return element.clip;
        }

        return null;
    }
}
