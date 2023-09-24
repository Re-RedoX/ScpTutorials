using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp049;
using Exiled.Events.EventArgs.Scp0492;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.EventArgs.Scp106;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScpTutorials
{
    
    public class EventHandlers
    {
        Config config = new Config();
        public void OnEndingRound(EndingRoundEventArgs e)
        {
            if (config.IsRoundWillBeEnded)
            {
                if(Player.List.Count(t => t.IsTutorial) > 0 && (Player.List.Count(p => p.IsNTF || p.IsCHI) > 0))
                {
                    e.IsRoundEnded = false; 
                }
            }
            
        }
        
        
        
        
        
        
        public void OnScp049Attacking(Exiled.Events.EventArgs.Scp049.AttackingEventArgs ev)
        {
            if (ev.Target.Role.Type == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnScp106Attacking(Exiled.Events.EventArgs.Scp106.AttackingEventArgs ev)
        {
            if (ev.Target.Role.Type == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnScp096AddingTargetEvent(AddingTargetEventArgs ev)
        {
            if (ev.Target.Role.Type == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnScp0492ConsumingCorpse(ConsumingCorpseEventArgs ev)
        {
            if (ev.Ragdoll.Role == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }
        public void OnScp0492TriggeringBloodlust(TriggeringBloodlustEventArgs ev)
        {
            if (ev.Target.Role.Type == RoleTypeId.Tutorial)
            {
                ev.IsAllowed = false;
            }
        }
        
        
        
        
        
        
        
        public void OnHurting(HurtingEventArgs ev)
        {
            //// Exiled Himself Error Check
            if (ev.Player != null && ev.Player.Role != null && ev.Attacker != null && ev.Attacker.Role != null)
            {
                if (ev.Player.Role.Type == RoleTypeId.Tutorial && ev.Attacker.Role.Side == Exiled.API.Enums.Side.Scp || ev.Player.Role.Side == Side.Scp && ev.Attacker.Role.Type == RoleTypeId.Tutorial)
                {
                    ev.IsAllowed = false;
                }
                else
                {
                    ev.IsAllowed = true;
                }
            }
            else
            {
                // Log for exiled.
                if (config.Debug)
                {
                    Log.Warn("OnHurting: Null references detected in event arguments. It's Exiled Himself Error");
                }
            }
        }
        public void OnShot(ShotEventArgs ev)
        {
            // Exiled Himself Error Check
            if (ev.Player != null && ev.Player.Role != null && ev.Target != null && ev.Target.Role != null )
            {
                if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.Tutorial && ev.Target.Role.Side == Exiled.API.Enums.Side.Scp)
                {
                    ev.CanHurt = false;
                }
                else
                {
                    ev.CanHurt = true;
                }
            }
            else
            {
                // Log for exiled.
                if (config.Debug) 
                {
                    Log.Warn("OnShot: Null references detected in event arguments. It's Exiled Himself Error");
                }
            }
        }

    }
}
