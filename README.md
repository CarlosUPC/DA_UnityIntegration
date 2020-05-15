# DA_UnityIntegration
Digital Audio Unity Integration 

## Team Members

* Carlos Peña
* Sebastià López

## Check List

### 1. Bring the silence in the Allegro Kingdom to an end by summoning the magic of music

- [x] **Main goal**: Add background music to the Title Screen scene (WAG_TitleScreen_V1.wav)
- [x] Secondary goal level HERO: try to cut the loop between seconds 0:06 to 1:22
- [x] Secondary goal level GOD: try to keep the 0:06 pre-entry
- [x] **Main goal**: add the background music to the Credits scene with a correct loop
Music_Forest_Mix.wav, pre-exit position 0:16.
- [x] Secondary goal level HERO: fade out music before exiting scene
- [x] **Main goal**: add background music to the game (Main Scene) You can use the
Music_Forest_Mix.wav loop.
- [x] Secondary goal level HERO: add the different background music loops to the different ambiences
(check assets and pre-entry/post-exit points in the Wwise project)
- [x] Secondary goal level GOD: alternate day and night music loops


### 2. Bring Allegro Kingdom characters back to life: make their actions sound

- [x] **Main goal**: Add most main character sounds (footsteps, attack with selected weapon, casting
spells and pick items) See AdventuressAnimationEventHandler.cs, Weapon.cs,
DefaultSpellcraft.cs, Pickup.cs & CoinPickup.cs
- [x] Secondary goal level HERO: randomize footstep sounds
- [x] Secondary goal level HERO: take floor surface into account in footstep sounds (see
SoundMaterial.cs & PlayerManager.cs)
- [x] Secondary goal level GOD: change footsteps volume and assets depending on main character’s
speed
- [x] **Main goal**: Add Evil Head sounds (EvilHeadAI.cs)
- [x] **Main goal**: Add Evil Plant sounds (EvilSpitPlantAI.cs & EvilSpitPlantProjectile.cs)
- [x] **Main goal**: Add Wwizard sounds (WwizardAI.cs & WwizardStaffChargeParticles.cs)


### 3. Bring back Allegro’s magical ambiences
- [x] **Main goal**: Add ambience sound loops
- [x] **Main goal**: Add sound sources to scenes: torchs, lava, windmill, river, waterdrops, birds,
waterfall.
- [x] **Main goal**: Add the teleporter sound at the options screen (WorldTeleporter.cs)
- [x] Secondary goal level HERO/GOD: Add reverb zones where required (Cave, Dungeon, Library, Forge,
Core)


### 4. User is king! Bring back UI sounds
- [x] **Main goal**: add inventory sounds (Inventory.cs)
- [x] **Main goal**: add menu sounds (Menu.cs)
- [ ] **Main goal**: add quest evolution related sounds (QuestGiver.cs y QuestManager.cs)


### 5. Achieve the final control over Allegro’s Kingdom

- [ ] **Main goal**: Create a mixer and add functionality to the music and general audio sliders in the
options screen
- [ ] Secondary goal level HERO: create an appropriate mixer hierarchy
