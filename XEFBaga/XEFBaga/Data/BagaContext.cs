﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using XEFBaga.Models;
using System.IO;
using XEFBaga.Services;

namespace XEFBaga.Data
{
    public class BagaContext : DbContext, IDataStore<Destination>
    {
        BagaContext context = new BagaContext();
        public BagaContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "XamarinBaga.db");
            optionsBuilder.UseSqlite($"Data Source= {path}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destination>().Property(d => d.Name).IsRequired();
            modelBuilder.Entity<Destination>().Property(d => d.Description).HasMaxLength(200);
            modelBuilder.Entity<Destination>().Property(d => d.Photo).HasColumnType("image");

            modelBuilder.Entity<Lodging>().Property(l => l.Name).IsRequired().HasMaxLength(200);

            modelBuilder.Entity<ActivityTrip>().HasKey(a => new { a.ActivityId, a.TripId });



        }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Lodging> Lodgings { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<ActivityTrip> ActivityTrip { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonPhoto> PersonPhotos { get; set; }

        public async Task<bool> AddItemAsync(Destination item)
        {
            context.Destinations.Add(item);
            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Destination item)
        {
            var oldItem = context.Destinations.Where((Destination arg) => arg.DestinationId == item.DestinationId).FirstOrDefault();
            context.Destinations.Remove(oldItem);
            context.Destinations.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = context.Destinations.Where((Destination arg) => arg.DestinationId == id).FirstOrDefault();
            context.Destinations.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Destination> GetItemAsync(int id)
        {
            return await Task.FromResult(context.Destinations.FirstOrDefault(s => s.DestinationId == id));
        }

        public async Task<IEnumerable<Destination>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(context.Destinations);
        }

    }
}
