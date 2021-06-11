# Better RP
This exiled plugin includes useful features that can improve the RP server experience.

Some cool features of this plugin:

- Elevator have a configurable chance to be broken
- Hints that should represent the player's thoughts while doing certain actions
- A damage indicator showing how much damage is dealt to players
- If you are MTF you can cuff SCPS
- A starting cassie announcement saying a containment breach has occured



# Config:

```yml
BetterRP:
# Whether or not is the plugin enabled?
  is_enabled: true
  # The chance that the elevetor is broken (-1 for disable it)
  elevator_broken_chance: 9
  # The broadcast that shows up when the elevator is broken
  broken_elevator: <size=70><color=red> The elevator was broken</color></size>
  # The hint that shows up when a player find a blocked door
  interacting_blocked_door: <size=30> I need a <size=30><color=green>Key Card</color></size> for open this door</size>
  # The hint that shows up when a player activate the alpha warhead
  activating_warhead_panel: <size=30> Ok, now i can activate the Alpha Warhead</size>
  # The hint that shows up when a player heal himself
  player_heal_hint: <size=20> Now i'm felling good</size>
  # Whether or not is the damage indicator is enabled?
  damage_indicator_is_enabled: true
  # The hint that shows up when a player hit an another player
  damage_indicator_hint: <size=20> You damaged %player, %damage of damage caused</size>
  # Whether or not is the damage indicator is enabled?
  m_t_f_can_cuff_scps: true
  ```
