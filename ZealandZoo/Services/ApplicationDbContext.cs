using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ZealandZoo.Interface;
using ZealandZoo.Models;

namespace ZealandZoo.Services
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IEventRepository
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        private DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var admin = new IdentityRole("admin");
            admin.NormalizedName = "admin";

            var board = new IdentityRole("board");
            board.NormalizedName = "board";

            builder.Entity<IdentityRole>().HasData(admin, board);
        }

        //Create
        public void CreateEvent(Event eventDto)
        {
            Add(eventDto);
            SaveChanges();
        }

        //Read
        public List<Event> GetAllEvents()
        {
            return Events.ToList();
        }

        public Event FindEvent(int? id)
        {
            return Events.Find(id.Value);
        }

        //Update
        public void UpdateEvent(Event eventDto)
        {
            FindEvent(eventDto.EventID).Subject = eventDto.Subject;
            FindEvent(eventDto.EventID).Description = eventDto.Description;
            FindEvent(eventDto.EventID).Start = eventDto.Start;
            FindEvent(eventDto.EventID).End = eventDto.End;
            FindEvent(eventDto.EventID).ThemeColor = eventDto.ThemeColor;
            FindEvent(eventDto.EventID).IsFullDay = eventDto.IsFullDay;
            SaveChanges();
        }

        //Delete
        public void DeleteEvent(int eventID)
        {
            Remove(FindEvent(eventID));
            SaveChanges();
        }
    }
}
