using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UserManagementMicroService.Models
{
    public partial class FlightBookingDBContext : DbContext
    {
        public FlightBookingDBContext()
        {
        }

        public FlightBookingDBContext(DbContextOptions<FlightBookingDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AirLineMaster> AirLineMasters { get; set; }
        public virtual DbSet<AirportMaster> AirportMasters { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<DiscountMaster> DiscountMasters { get; set; }
        public virtual DbSet<FlightMaster> FlightMasters { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }
        public virtual DbSet<FlightScheduleDay> FlightScheduleDays { get; set; }
        public virtual DbSet<GenderTypeMaster> GenderTypeMasters { get; set; }
        public virtual DbSet<InstrumentTypeMaster> InstrumentTypeMasters { get; set; }
        public virtual DbSet<MealTypeMaster> MealTypeMasters { get; set; }
        public virtual DbSet<PassengerDetail> PassengerDetails { get; set; }
        public virtual DbSet<RoleTypeMaster> RoleTypeMasters { get; set; }
        public virtual DbSet<SeatTypeMaster> SeatTypeMasters { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<WeekDayMaster> WeekDayMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CTSDOTNET361;Initial Catalog=FlightBookingDB;User Id=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AirLineMaster>(entity =>
            {
                entity.HasKey(e => e.AirlineId);

                entity.ToTable("AirLineMaster");

                entity.Property(e => e.ContactNo).HasColumnName("Contact_No");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<AirportMaster>(entity =>
            {
                entity.HasKey(e => e.AirportId);

                entity.ToTable("AirportMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_BookingDeatils");

                entity.Property(e => e.BookingDatetime).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NoOfSeatsBook).HasColumnName("NoOf_Seats_Book");

                entity.Property(e => e.PnrNumber).HasColumnName("PNR_Number");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total_Price");

                entity.HasOne(d => d.AirLine)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.AirLineId)
                    .HasConstraintName("FK__BookingDe__AirLi__5DCAEF64");

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.BookingDetailDestinations)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK__BookingDe__Desti__60A75C0F");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__BookingDe__Disco__6FB49575");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__BookingDe__Fligh__5BE2A6F2");

                entity.HasOne(d => d.FlightScheduleDay)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.FlightScheduleDayId)
                    .HasConstraintName("FK__BookingDe__Fligh__5EBF139D");

                entity.HasOne(d => d.SeatType)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.SeatTypeId)
                    .HasConstraintName("FK__BookingDe__SeatT__70A8B9AE");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.BookingDetailSources)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK__BookingDe__Sourc__5FB337D6");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__BookingDe__UserI__719CDDE7");
            });

            modelBuilder.Entity<DiscountMaster>(entity =>
            {
                entity.HasKey(e => e.DiscountId);

                entity.ToTable("DiscountMaster");

                entity.Property(e => e.DiscountId).HasColumnName("DIscountId");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MaximumDiscount).HasColumnType("decimal(12, 4)");
            });

            modelBuilder.Entity<FlightMaster>(entity =>
            {
                entity.HasKey(e => e.FlightId);

                entity.ToTable("FlightMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.InstrumentId).HasColumnName("instrumentId");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Airline)
                    .WithMany(p => p.FlightMasters)
                    .HasForeignKey(d => d.AirlineId)
                    .HasConstraintName("FK__FlightMas__Airli__4CA06362");

                entity.HasOne(d => d.Instrument)
                    .WithMany(p => p.FlightMasters)
                    .HasForeignKey(d => d.InstrumentId)
                    .HasConstraintName("FK__FlightMas__instr__59063A47");
            });

            modelBuilder.Entity<FlightSchedule>(entity =>
            {
                entity.ToTable("FlightSchedule");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.WeekdaysIds).HasMaxLength(50);

                entity.HasOne(d => d.Destination)
                    .WithMany(p => p.FlightScheduleDestinations)
                    .HasForeignKey(d => d.DestinationId)
                    .HasConstraintName("FK__FlightSch__Desti__5535A963");

                entity.HasOne(d => d.Flight)
                    .WithMany(p => p.FlightSchedules)
                    .HasForeignKey(d => d.FlightId)
                    .HasConstraintName("FK__FlightSch__Fligh__534D60F1");

                entity.HasOne(d => d.Source)
                    .WithMany(p => p.FlightScheduleSources)
                    .HasForeignKey(d => d.SourceId)
                    .HasConstraintName("FK__FlightSch__Sourc__5441852A");
            });

            modelBuilder.Entity<FlightScheduleDay>(entity =>
            {
                entity.ToTable("FlightScheduleDay");

                entity.Property(e => e.ArivalDate).HasColumnType("date");

                entity.Property(e => e.ArrivalTime).HasMaxLength(50);

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DepartureDate).HasColumnType("date");

                entity.Property(e => e.DepartureTime).HasMaxLength(50);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RowNo).HasColumnName("Row_No");

                entity.Property(e => e.TicketCost).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.FlightSchedule)
                    .WithMany(p => p.FlightScheduleDays)
                    .HasForeignKey(d => d.FlightScheduleId)
                    .HasConstraintName("FK__FlightSch__Fligh__5629CD9C");

                entity.HasOne(d => d.MealType)
                    .WithMany(p => p.FlightScheduleDays)
                    .HasForeignKey(d => d.MealTypeId)
                    .HasConstraintName("FK__FlightSch__MealT__571DF1D5");

                entity.HasOne(d => d.Weekday)
                    .WithMany(p => p.FlightScheduleDays)
                    .HasForeignKey(d => d.WeekdayId)
                    .HasConstraintName("FK__FlightSch__Weekd__3A4CA8FD");
            });

            modelBuilder.Entity<GenderTypeMaster>(entity =>
            {
                entity.HasKey(e => e.GenderId);

                entity.ToTable("GenderTypeMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InstrumentTypeMaster>(entity =>
            {
                entity.HasKey(e => e.InstrumentId);

                entity.ToTable("InstrumentTypeMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<MealTypeMaster>(entity =>
            {
                entity.HasKey(e => e.MealTypeId);

                entity.ToTable("MealTypeMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.HasKey(e => e.PassengerId);

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PassengerName).HasColumnName("Passenger_Name");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.BookingId)
                    .HasConstraintName("FK__Passenger__Booki__6477ECF3");

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK__Passenger__Gende__656C112C");

                entity.HasOne(d => d.MealType)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.MealTypeId)
                    .HasConstraintName("FK__Passenger__MealT__66603565");
            });

            modelBuilder.Entity<RoleTypeMaster>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleTypeMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<SeatTypeMaster>(entity =>
            {
                entity.HasKey(e => e.SeatTypeId)
                    .HasName("PK_SEatTypeMaster");

                entity.ToTable("SeatTypeMaster");
            });

            modelBuilder.Entity<UserMaster>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("UserMaster");

                entity.Property(e => e.CreatedBy).HasColumnName("Created_By");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Created_Date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FullName).HasColumnName("Full_Name");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedBy).HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleId).HasDefaultValueSql("((2))");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserMasters)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserMaster_RoleTypeMaster");
            });

            modelBuilder.Entity<WeekDayMaster>(entity =>
            {
                entity.HasKey(e => e.WeekDayId);

                entity.ToTable("WeekDayMaster");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On")
                    .HasDefaultValueSql("(getdate())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
