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
                foreach (var tutorial in Player.List)
                {
                    if (tutorial.Role.Type == RoleTypeId.Tutorial)
                    {
                        foreach (var checkNonTutorial in Player.List)
                        {
                            if (checkNonTutorial.Role.Side == Side.Mtf || checkNonTutorial.Role.Side == Side.ChaosInsurgency)
                            {
                                e.IsRoundEnded = false;
                            }
                            else
                            {
                                e.IsRoundEnded = true;
                            }
                        }
                    }
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
            if (ev.Player.Role.Type == RoleTypeId.Tutorial && ev.Attacker.Role.Side == Exiled.API.Enums.Side.Scp)
            {
                ev.IsAllowed = false;
            }
        }
        
        
        
        
        
        public void OnShot(ShotEventArgs ev)
        {
            if (ev.Player.Role.Type == PlayerRoles.RoleTypeId.Tutorial && ev.Target.Role.Side == Exiled.API.Enums.Side.Scp)
            {
                ev.CanHurt = false;
            }
        }
    }
}
