using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScpTutorials
{
    public class Config : IConfig
    {
        
        public bool IsEnabled { get; set; } = true;
        
        public bool Debug {  get; set; } = false;
        [Description("With tutorials, chaos or mtf sets whether the round will end or not when the team stays in the game")]
        public bool IsRoundWillBeEnded { get; set; } = true;
        
    }
}
