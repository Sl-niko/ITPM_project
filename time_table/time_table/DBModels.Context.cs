﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace time_table
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class EFDBEntities1 : DbContext
    {
        public EFDBEntities1()
            : base("name=EFDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<lecture_tbl> lecture_tbl { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<subject> subjects { get; set; }
        public virtual DbSet<Academic1> Academic1 { get; set; }
        public virtual DbSet<AddTag11> AddTag11 { get; set; }
        public virtual DbSet<Lecture> Lectures { get; set; }
        public virtual DbSet<Subject1> Subject1 { get; set; }
        public virtual DbSet<working_Day1> working_Day1 { get; set; }
        public virtual DbSet<add_time_slot> add_time_slot { get; set; }
        public virtual DbSet<SubForRoom> SubForRooms { get; set; }
        public virtual DbSet<RoomForGrSub> RoomForGrSubs { get; set; }
        public virtual DbSet<RoomForLrctu> RoomForLrctus { get; set; }
        public virtual DbSet<RoomForTag> RoomForTags { get; set; }
        public virtual DbSet<SessionN> SessionNs { get; set; }
        public virtual DbSet<RoomForS> RoomForSes { get; set; }
        public virtual DbSet<RoomFConsecSessi> RoomFConsecSessis { get; set; }
        public virtual DbSet<consecuTable> consecuTables { get; set; }
        public virtual DbSet<AddLocation11> AddLocation11 { get; set; }
        public virtual DbSet<parellelTable> parellelTables { get; set; }
        public virtual DbSet<NonOverlapTable> NonOverlapTables { get; set; }
        public virtual DbSet<NotAvTime> NotAvTimes { get; set; }
    }
}
