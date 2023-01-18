using Base30.Core.Communication.Mediator;
using Base30.Core.Data;
using Base30.Core.Messages;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class AuthenticationDBContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>, IUnitOfWork 
    {
        private readonly IMediatoRHandler _mediatorHandler;

        public AuthenticationDBContext(DbContextOptions<AuthenticationDBContext> options, IMediatoRHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthenticationDBContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("InsDt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("InsDt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("InsDt").IsModified = false;
                }
            }

            bool sucess = await base.SaveChangesAsync() > 0;
            if (sucess) await _mediatorHandler.PublishEvents(this);

            return sucess;
        }
    }
}
