namespace BetterRP.EventHandlers
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Exiled.API.Enums;
	using Exiled.API.Features;
	using Exiled.Events.EventArgs;
	using MEC;

	public class ServerEvents
	{
		public void OnRoundStarted()
		{
			MEC.Timing.CallDelayed(0.5f, ScpBreakContainmentAnnouncement);
		}

		public void ScpBreakContainmentAnnouncement()
		{

			string text = "";
			string announcement = "attention all personnel detected %scpcounter scpsubject breach %scpsubjects";

			var scps = Player.List.Where(x => x.Side == Side.Scp);
			Dictionary<RoleType, string> pronounciations = new Dictionary<RoleType, string>
			{
				{ RoleType.Scp049, "SCP 0 4 9"},
				{ RoleType.Scp079, "SCP 0 7 9" },
				{ RoleType.Scp096, "SCP 0 9 6" },
				{ RoleType.Scp106, "SCP 1 0 6" },
				{ RoleType.Scp173, "SCP 1 7 3" },
				{ RoleType.Scp93953, "SCP 9 3 9 5 3" },
				{ RoleType.Scp93989, "SCP 9 3 9 8 9" }
			};

			foreach (Player scp in scps)
			{
				text += $" {pronounciations[scp.Role]}";
			}

			if (text == "")
			{
				Cassie.DelayedMessage("class d have breached the Containment", 5, false, true);
			}

			if (announcement.Contains("%scpcounter"))
			{
				announcement.Replace("%scpcounter", scps.Count().ToString());
			}

			if (announcement.Contains("%scpsubjects"))
			{
				announcement.Replace("%scpsubjects", text);
			}

			Cassie.DelayedMessage(announcement, 5, false, true);
		}

	}
}