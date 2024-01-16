using Exiled.API;
using Exiled.API.Features;
using Exiled.Events.Handlers;

namespace ScpTutorials
{
    public class MainPlugin : Plugin<Config> 
    {

        public override string Author => "Re-RedoX";
        public override string Name => "ScpTutorials";
        public override string Prefix => Name;

        public static MainPlugin Instance;
        
        private EventHandlers _handler { get; set; }


        public override void OnEnabled()
        {
            Instance = this;
            _handler = new EventHandlers(Config)
            
            Exiled.Events.Handlers.Server.EndingRound += _handler.OnEndingRound;
            
            Exiled.Events.Handlers.Player.Hurting += _handler.OnHurting;
            Exiled.Events.Handlers.Player.Shot += _handler.OnShot;
            Exiled.Events.Handlers.Scp049.Attacking += _handler.OnScp049Attacking;
            
            Exiled.Events.Handlers.Scp106.Attacking += _handler.OnScp106Attacking;
            Exiled.Events.Handlers.Scp096.AddingTarget += _handler.OnScp096AddingTargetEvent;
            Exiled.Events.Handlers.Scp0492.ConsumingCorpse += _handler.OnScp0492ConsumingCorpse;
            Exiled.Events.Handlers.Scp0492.TriggeringBloodlust += _handler.OnScp0492TriggeringBloodlust;
            
            base.OnEnabled();
        }
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.EndingRound -= _handler.OnEndingRound;

            Exiled.Events.Handlers.Player.Hurting -= _handler.OnHurting;
            Exiled.Events.Handlers.Player.Shot -= _handler.OnShot;
            Exiled.Events.Handlers.Scp049.Attacking -= _handler.OnScp049Attacking;
            
            Exiled.Events.Handlers.Scp106.Attacking -= _handler.OnScp106Attacking;
            Exiled.Events.Handlers.Scp096.AddingTarget -= _handler.OnScp096AddingTargetEvent;
            Exiled.Events.Handlers.Scp0492.ConsumingCorpse -= _handler.OnScp0492ConsumingCorpse;
            Exiled.Events.Handlers.Scp0492.TriggeringBloodlust -= _handler.OnScp0492TriggeringBloodlust;

            _handler = null;
            base.OnEnabled();
        }
    }
}