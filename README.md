   ![img](https://img.shields.io/github/downloads/AleRabo/Better-RP/total.svg)

# Better RP
This exiled plugin includes useful features that can improve the RP server experience. (the scp cuffing don't work if the target scp have a subclass)

Some cool features of this plugin:

- Elevator have a configurable chance to be broken
- Hints that should represent the player's thoughts while doing certain actions
- A damage indicator showing how much damage is dealt to players
- If you are an human you can cuff SCPS
- A starting cassie announcement saying a containment breach has occured
- A tesla gate bypass if you have a tablet in your inventory


# Config:

```yml
BetterRP:
# Whether or not is the plugin enabled?
  is_enabled: true
  # The chance that the elevetor is broken (-1 for disable it)
  elevator_broken_chance: 5
  # The broadcast that shows up when the elevator is broken
  broken_elevator: <size=70><color=red> The elevator was broken</color></size>
  # Whether or not is the broken elevator afflict the SCPS
  elevator_broke_afflict_scps: true
  # The hint that shows up when a player find a blocked door
  interacting_blocked_door: <size=30> I need a <size=30><color=green>Key Card</color></size> for open this door</size>
  # The hint that shows up when a player activate the alpha warhead
  activating_warhead_panel: <size=30> Now I can destroy the facility</size>
  # The hint that shows up when a player heal himself
  player_heal_hint: <size=20> Now I'm feel good</size>
  # Whether or not is the damage indicator is enabled?
  damage_indicator_is_enabled: true
  # The hint that shows up when a player hit an another player
  damage_indicator_hint: <size=20> <color=red> %damage of damage caused </size> </size>
  # The bypass for tesla gate with a tablet
  teslagate_bypass_with_tablet: true
  # The hint that shows up when a stop a tesla gate with a tablet
  tesla_gatebypasst_hint: <size=20> With my tablet the tesla gate are no longer a problem</size>
  # List of SCP roles that can be cuffed
  s_c_p_roles:
  - Scp93989
  - Scp93953
  - Scp049
  - Scp096
  - Scp106
  - Scp173
  - Scp0492
  ```
  
