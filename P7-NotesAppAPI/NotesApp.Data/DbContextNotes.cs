using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data.DataSeeding;
using NotesApp.Models.Domain;

namespace NotesApp.Data
{
    public class DbContextNotes : IdentityDbContext
    {
        public DbContextNotes(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<NoteModel>().ToTable("Note");
            builder.Entity<ToDoTaskModel>().ToTable("ToDoTask");
            builder.Entity<CategoryModel>().ToTable("Category");
            builder.Entity<StatusModel>().ToTable("Status");
            builder.Entity<PriorityModel>().ToTable("Priority");
            builder.Entity<NoteModel>().HasOne(x => x.Category).WithMany(x => x.Notes);
            builder.Entity<NoteModel>().HasOne<IdentityUser>().WithMany().HasPrincipalKey(x => x.Id);

            builder.Entity<ToDoTaskModel>().Property(x => x.NoteId).HasColumnName("NoteId");

            // Seeding
            //IdentitySeeding.GenerateData(builder);
            //NotesAppSeeding.GenerateData(builder);
        }

        public DbSet<NoteModel> Notes { get; set; } = null!;
        public DbSet<ToDoTaskModel> ToDoTasks { get; set; } = null!;
        public DbSet<CategoryModel> Categories { get; set; } = null!;
        public DbSet<StatusModel> Status { get; set; } = null!;
        public DbSet<PriorityModel> Priorities { get; set; } = null!;
    }
}
