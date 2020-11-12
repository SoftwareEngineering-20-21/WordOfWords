using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WorldOfWords
{
    public partial class WorldOfWordsContext : DbContext
    {
        public WorldOfWordsContext()
        {
        }

        public WorldOfWordsContext(DbContextOptions<WorldOfWordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCard> UserCard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=WorldOfWords;Username=postgres;Password=BOHDAN2001");
            }
        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ForNpgsqlUseIdentityColumns();
            modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("character varying");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Card)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("card_topic_id_fkey");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("character varying");

                entity.Property(e => e.FullName)
                    .HasColumnName("full_name")
                    .HasColumnType("character varying");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<UserCard>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_card_pkey");

                entity.ToTable("user_card");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Answer).HasColumnName("answer");

                entity.Property(e => e.AnswerDate)
                    .HasColumnName("answer_date")
                    .HasColumnType("date");

                entity.Property(e => e.CardId).HasColumnName("card_id");

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.UserCard)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("user_card_card_id_fkey");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserCard)
                    .HasForeignKey<UserCard>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_card_user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
