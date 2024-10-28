using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<SmartGlove> SmartGloves { get; set; }
        public DbSet<Sensor_Data> Sensors_data { get; set; }
        public DbSet<SignClassification> SignClassifications { get; set; }
        public DbSet<Mode> Modes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<User>().HasKey(x => x.Id);
             modelBuilder.Entity<Sensor_Data>().HasKey(x => x.DataId);
             modelBuilder.Entity<SmartGlove>().HasKey(x => x.Id);
             modelBuilder.Entity<SignClassification>().HasKey(x => x.Id);

             base.OnModelCreating(modelBuilder);*/
            modelBuilder.Entity<User>()
                 .HasMany(u => u.SmartGloves)
                 .WithOne(s => s.Owner)
                 .HasForeignKey(s => s.OwnerID);

            modelBuilder.Entity<User>()
                .HasMany(u => u.SensorData)
                .WithOne(s => s.user)
                .HasForeignKey(s => s.UserID);

            modelBuilder.Entity<Sensor_Data>()
                .HasOne(sd => sd.Mode)
                .WithMany()
                .HasForeignKey(sd => sd.ModeId);
            /*    
            modelBuilder.Entity<Sensor_Data>()
                .Property(sd => sd.ModeId)
                .HasDefaultValue(1); // Set default value of ModeId to 1*/


            modelBuilder.Entity<User>().HasData(new User() { Id = 1, Name = "Ahmed", Email = "Ahmed12@gmail.com", Password = "123", Gender = true, DateTime = new DateTime(1990, 1, 1), Phone = "0123456789", Address = "123 Main St" });

            modelBuilder.Entity<Mode>().HasData(new Mode()
            {
                ModeId = 1,
                ModeName = "Home",
                A = "I need medicine.",
                B = "Waiting...",
                C = "I'm thirsty.",
                D = "Thank you.",
                E = "I need more.",
                F = "I like this.",
                G = "I don't like this.",
                H = "Call the doctor.",
                I = "I need less.",
                J = "Stop.",
                K = "I want to go out.",
                L = "I'm hungry.",
                M = "It's too noisy.",
                N = "I have a headache."
            },
                new Mode()
                {
                    ModeId = 2,
                    ModeName = "Hospital",
                    A = "I need to see a doctor.",
                    B = "Waiting...",
                    C = "I need help with mobility.",
                    D = "I am in pain.",
                    E = "I need help with feeding.",
                    F = "I am feeling better.",
                    G = "I am feeling worse.",
                    H = "Can you explain the treatment plan?",
                    I = "Can you call my family?",
                    J = "I am having trouble breathing.",
                    K = "I need help finding the pharmacy.",
                    L = "Could you adjust the room temperature?",
                    M = "Can I have a glass of water?",
                    N = "Can I have a pen and paper?"
                },
                new Mode()
                {
                    ModeId = 3,
                    ModeName = "Street",
                    A = "Need help, please.",
                    B = "Waiting...",
                    C = "Please call an ambulance.",
                    D = "Can you tell me the time?",
                    E = "Are there any restaurants around here?",
                    F = "Are there any Mosques around here?",
                    G = "Where is the nearest hospital?",
                    H = "Is there a pharmacy nearby?",
                    I = "I need to find an ATM.",
                    J = "Phone charger?",
                    K = "Is there a police station nearby?",
                    L = "Can you help me find a taxi?",
                    M = "I'm lost, can you guide me?",
                    N = "Where is the nearest subway station."
                });
        }
    }
}
