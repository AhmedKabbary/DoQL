using Action = DoQL.Models.Action;

namespace DoQL.Utilities
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
