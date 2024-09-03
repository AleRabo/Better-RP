   ![img](https://img.shields.io/github/downloads/AleRabo/Better-RP/total.svg)

# Better RP
This exiled plugin includes useful features that can improve the RP server experience.

Some cool features of this plugin:

- Hints that should represent the player's thoughts while doing certain actions
- A damage indicator showing how much damage is dealt to players
- A starting cassie announcement saying a containment breach has occured
- Fully configurable tesla bypass system


# Config:

```yml
BetterRP:
# Whether or not is the plugin enabled?
  is_enabled: true
  # Whether or not is the plugin is in debug mode?
  debug: false
  # The hint that shows up when a player find a blocked door
  interacting_blocked_door: '<size=30> I need a <size=30><color=green>Key Card</color></size> for open this door</size>'
  # The hint that shows up when a player activate the alpha warhead
  activating_warhead_panel: '<size=30> Ok, now i can activate the Alpha Warhead</size>'
  # The hint that shows up when a player heal himself
  player_heal_hint: '<size=20> Now i''m felling good</size>'
  # Whether or not is the damage indicator is enabled
  damage_indicator_is_enabled: true
  # The hint that shows up when a player hit an another player
  damage_indicator_hint: '<size=20> You damaged %player, %damage of damage caused</size>'
  # The tesla gate bypass item (Set an item to None if you want to disable it
  teslagate_bypass_item:
  - KeycardMTFCaptain
  - KeycardMTFOperative
  - KeycardO5
  - KeycardMTFPrivate
  - KeycardGuard
  # If set to false you must manually disable and reenable the tesla pressing T, if true the tesla automatically disables for 5 sec after someone with the bypass item walks through it
  auto_tesla_bypasss: true
  # The hint that shows up when a stop a tesla gate with a keycard
  tesla_gatebypasst_hint: '<size=20> With this keycard the tesla gate are no longer a problem</size>'
  ```
  # Items
Here's a list of all the possible items to set as the tesla bypass items

```yml


- None 
- KeycardJanitor 
- KeycardScientist 
- KeycardResearchCoordinator 
- KeycardZoneManager 
- KeycardGuard 
- KeycardMTFPrivate 
- KeycardContainmentEngineer 
- KeycardMTFOperative 
- KeycardMTFCaptain 
- KeycardFacilityManager 
- KeycardChaosInsurgency 
- KeycardO5 
- Radio 
- GunCOM15 
- Medkit 
- Flashlight 
- MicroHID 
- SCP500 
- SCP207 
- Ammo12gauge 
- GunE11SR 
- GunCrossvec 
- Ammo556x45 
- GunFSP9 
- GunLogicer 
- GrenadeHE 
- GrenadeFlash 
- Ammo44cal 
- Ammo762x39 
- Ammo9x19 
- GunCOM18 
- SCP018 
- SCP268 
- Adrenaline 
- Painkillers 
- Coin 
- ArmorLight 
- ArmorCombat 
- ArmorHeavy 
- GunRevolver 
- GunAK 
- GunShotgun 
- SCP330 
- SCP2176 
- SCP244a 
- SCP244b 
- SCP1853 
- ParticleDisruptor 
- GunCom45 
- SCP1576 
- Jailbird 
- AntiSCP207 
- GunFRMG0 
- GunA7 
- Lantern 

```
