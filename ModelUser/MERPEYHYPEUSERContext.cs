using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MerpeyHypeServer.ModelUser
{
    public partial class MERPEYHYPEUSERContext : DbContext
    {
        public MERPEYHYPEUSERContext()
        {
        }

        public MERPEYHYPEUSERContext(DbContextOptions<MERPEYHYPEUSERContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LogUsersLogin> LogUsersLogins { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersExt> UsersExts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MERPEYHYPEUSER;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<LogUsersLogin>(entity =>
            {
                entity.ToTable("LOG_UsersLogin");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AttemptTime).HasColumnType("datetime");

                entity.Property(e => e.IsSuccess).HasColumnName("isSuccess");

                entity.Property(e => e.TriedMainUser)
                    .HasMaxLength(20)
                    .HasColumnName("triedMainUser");

                entity.Property(e => e.TriedPassword)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("triedPassword");

                entity.Property(e => e.TriedUsername)
                    .HasMaxLength(20)
                    .HasColumnName("triedUsername");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MainUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("password")
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UsersExt>(entity =>
            {
                entity.HasKey(e => e.Fid);

                entity.ToTable("UsersExt");

                entity.Property(e => e.Fid)
                    .ValueGeneratedNever()
                    .HasColumnName("FID");

                entity.Property(e => e.Adress)
                    .HasMaxLength(255)
                    .HasColumnName("adress");

                entity.Property(e => e.City)
                    .HasMaxLength(255)
                    .HasColumnName("city");

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("country_code");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.District)
                    .HasMaxLength(255)
                    .HasColumnName("district");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(255)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(255)
                    .HasColumnName("lastname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Street)
                    .HasMaxLength(255)
                    .HasColumnName("street");

                entity.Property(e => e.Zip)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("zip");

                entity.HasOne(d => d.FidNavigation)
                    .WithOne(p => p.UsersExt)
                    .HasForeignKey<UsersExt>(d => d.Fid)
                    .HasConstraintName("FK_UsersExt_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
