using Base30.Core.Communication.Mediator;
using Base30.Core.DomainObjects;

namespace Base30.SysAdmin.Data
{
    public static class MediatoRExtension
    {
        public static async Task PublishEvents(this IMediatoRHandler mediator, SysAdminDBContext ctx)
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications!)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearEvent());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.PublishEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
