using Base30.SysAdmin.Domain;
using Base30.Core.Data;
using Microsoft.EntityFrameworkCore;
using Base30.Core.Communication.Mediator;
using Base30.Core.Messages;

namespace Base30.SysAdmin.Data
{
    public class SysAdminDBContext : DbContext, IUnitOfWork
    {
        private readonly IMediatoRHandler _mediatoRHandler;

        public SysAdminDBContext(DbContextOptions<SysAdminDBContext> options, IMediatoRHandler mediatoRHandler) : base(options)
        {
            _mediatoRHandler = mediatoRHandler;
        }

        public DbSet<Menu> Menu { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SysAdminDBContext).Assembly);
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
            if (sucess) await _mediatoRHandler.PublishEvents(this);

            return sucess;
        }

    }
}