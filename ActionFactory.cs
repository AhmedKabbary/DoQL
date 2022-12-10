using DoQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = DoQL.Models.Action;

namespace DoQL
{
    class ActionFactory
    {
        public static string GetActionString(Action action)
        {
            return action switch
            {
                Action.SetNull => "SET NULL",
                Action.SetDefault => "SET DEFAULT",
                Action.Cascade => "CASCADE",
                Action.Restrict => "RESTRICT",
                _ => throw new ArgumentException("Unknown action")
            };
        }
    }
}
