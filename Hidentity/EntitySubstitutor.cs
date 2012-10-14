using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hidentity.Configuration;

namespace Hidentity
{
    /// <summary>
    /// Performs entity substitution depending on the configuration provided.
    /// </summary>
    public static class EntitySubstitutor
    {
        //TODO: Move this to strategy provider so that we could get a strategy by Substitutable.
        static EntitySubstitutor() 
        {
            _strategy = new MultiplyBy10Strategy();
        }

        private static ISubstitutionStrategy _strategy;

        private static ISubstitutionStrategy GetStrategyFor(Substitutable item)
        {
            return _strategy;
        }

        public static void EntityToReal<T>(T entity)
        {
            if (entity == null) return;

            Type type = entity.GetType();
            var subs = Configurator.SubstitutesFor(type);

            if (subs == null) return;

            foreach (Substitutable item in subs)
            {
                int hiddenVal = ReflectionHelper.GetValue<T>(entity, item);
                var strategy = GetStrategyFor(item);
                int realVal = strategy.ToReal(hiddenVal);

                ReflectionHelper.SetValue<T>(entity, item, realVal);
            }
        }
    }
}
