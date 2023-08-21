using Kitchen;
using KitchenData;
using KitchenMods;
using Unity.Collections;
using Unity.Entities;

namespace KitchenHideSides
{
    [UpdateAfter(typeof(GroupHandleChoosingOrder))]
    [UpdateBefore(typeof(GroupHandleAwaitingOrder))]
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

                settings.Ordering.SidesModifier = settings.Ordering.SidesOptional && Main.PrefManager.Get<bool>(Main.HIDE_SIDES_ENABLED)
                    ? 0f
                    : OrderingValues.Default.SidesModifier;

                EntityManager.SetComponentData<CCustomerSettings>(group, settings);
            }
        }
    }
}