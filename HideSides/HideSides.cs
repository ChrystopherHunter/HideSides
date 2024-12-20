using Kitchen;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace KitchenHideSides
{
    internal class HideSides : GenericSystemBase, IModSystem
    {
        private EntityQuery queryCustomerSettings;

        protected override void Initialise()
        {
            base.Initialise();

            queryCustomerSettings = GetEntityQuery(new QueryHelper().All(typeof(CCustomerSettings)));
        }

        protected override void OnUpdate()
        {
            using var groups = queryCustomerSettings.ToEntityArray(Allocator.Temp);

            foreach (var group in groups)
            {
                var settings = EntityManager.GetComponentData<CCustomerSettings>(group);

                var newSidesModifier = settings.Ordering.SidesOptional && Main.PrefManager.Get<bool>(Main.HIDE_SIDES_ENABLED)
                    ? 0f
                    : settings.Ordering.SidesModifier;

                if (settings.Ordering.SidesModifier != newSidesModifier)
                {
                    settings.Ordering.SidesModifier = newSidesModifier;
                    EntityManager.SetComponentData<CCustomerSettings>(group, settings);
                }
            }
        }
    }
}