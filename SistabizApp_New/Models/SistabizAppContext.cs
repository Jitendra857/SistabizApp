using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistabizApp_New.Models
{
    public partial class SistabizAppContext : DbContext
    {
        public SistabizAppContext()
        {
        }

        public SistabizAppContext(DbContextOptions<SistabizAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<TblEvent> TblEvent { get; set; }
        public virtual DbSet<TblEventAttachment> TblEventAttachment { get; set; }
        public virtual DbSet<TblEventRegisterMember> TblEventRegisterMember { get; set; }
        public virtual DbSet<TblFaq> TblFaq { get; set; }
        public virtual DbSet<TblFaqCategory> TblFaqCategory { get; set; }
        public virtual DbSet<TblFundingCategory> TblFundingCategory { get; set; }
        public virtual DbSet<TblFundingResources> TblFundingResources { get; set; }
        public virtual DbSet<TblGoal> TblGoal { get; set; }
        public virtual DbSet<TblGroup> TblGroup { get; set; }
        public virtual DbSet<TblGroupAttachment> TblGroupAttachment { get; set; }
        public virtual DbSet<TblGroupJoinMember> TblGroupJoinMember { get; set; }
        public virtual DbSet<TblMember> TblMember { get; set; }
        public virtual DbSet<TblPost> TblPost { get; set; }
        public virtual DbSet<TblPostAttachment> TblPostAttachment { get; set; }
        public virtual DbSet<TblPostFeedback> TblPostFeedback { get; set; }
        public virtual DbSet<TblServiceRequest> TblServiceRequest { get; set; }
        public virtual DbSet<TblUserNew> TblUserNew { get; set; }
        public virtual DbSet<Tbluser> Tbluser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\EXPRESS1;Database=SistabizApp;User Id=sa;Password=joshi@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.ProfileName).HasMaxLength(100);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<TblEvent>(entity =>
            {
                entity.HasKey(e => e.EventId);

                entity.ToTable("tblEvent");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.City).HasMaxLength(500);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.EventEndDate).HasColumnType("datetime");

                entity.Property(e => e.EventName).HasMaxLength(500);

                entity.Property(e => e.EventWebsite).HasMaxLength(500);

                entity.Property(e => e.OrganizerEmail).HasMaxLength(30);

                entity.Property(e => e.OrganizerName).HasMaxLength(500);

                entity.Property(e => e.OrganizerPhone).HasMaxLength(20);

                entity.Property(e => e.OrganizerWebsite).HasMaxLength(500);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.PostalCode).HasMaxLength(100);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.Property(e => e.VenueName).HasMaxLength(200);

                entity.Property(e => e.Website).HasMaxLength(500);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblEvent)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblEvent_tblMember");
            });

            modelBuilder.Entity<TblEventAttachment>(entity =>
            {
                entity.HasKey(e => e.EventAttachmentId);

                entity.ToTable("tblEventAttachment");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblEventAttachment)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tblEventAttachment_tblEvent");
            });

            modelBuilder.Entity<TblEventRegisterMember>(entity =>
            {
                entity.ToTable("tblEventRegisterMember");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblEventRegisterMember)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tblEventRegisterMember_tblEvent");

                entity.HasOne(d => d.RegisterMember)
                    .WithMany(p => p.TblEventRegisterMember)
                    .HasForeignKey(d => d.RegisterMemberId)
                    .HasConstraintName("FK_tblEventRegisterMember_tblMember");
            });

            modelBuilder.Entity<TblFaq>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("tblFaq");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Question).HasMaxLength(500);

                entity.HasOne(d => d.FaqCategory)
                    .WithMany(p => p.TblFaq)
                    .HasForeignKey(d => d.FaqCategoryId)
                    .HasConstraintName("FK_tblFaq_tblFaqCategory");
            });

            modelBuilder.Entity<TblFaqCategory>(entity =>
            {
                entity.HasKey(e => e.FaqCategoryId);

                entity.ToTable("tblFaqCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(500);
            });

            modelBuilder.Entity<TblFundingCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblFundingCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblFundingResources>(entity =>
            {
                entity.HasKey(e => e.FundingId);

                entity.ToTable("tblFundingResources");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.Deadline).HasMaxLength(200);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblFundingResources)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblFundingResources_tblFundingCategory");
            });

            modelBuilder.Entity<TblGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId);

                entity.ToTable("tblGoal");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblGoal)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblGoal_tblMember");
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("tblGroup");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.GroupName).HasMaxLength(500);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblGroup)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblGroup_tblMember");
            });

            modelBuilder.Entity<TblGroupAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.ToTable("tblGroupAttachment");

                entity.Property(e => e.Attachment).HasMaxLength(500);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupAttachment)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupAttachment_tblGroup");
            });

            modelBuilder.Entity<TblGroupJoinMember>(entity =>
            {
                entity.HasKey(e => e.JoinId);

                entity.ToTable("tblGroupJoinMember");

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.LeavingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupJoinMember)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupJoinMember_tblGroup");

                entity.HasOne(d => d.JoinMember)
                    .WithMany(p => p.TblGroupJoinMember)
                    .HasForeignKey(d => d.JoinMemberId)
                    .HasConstraintName("FK_tblGroupJoinMember_tblMember");
            });

            modelBuilder.Entity<TblMember>(entity =>
            {
                entity.HasKey(e => e.MemberId);

                entity.ToTable("tblMember");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.BusinessName).HasMaxLength(200);

                entity.Property(e => e.BusinessState).HasMaxLength(100);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.GovernmentCertifications).HasMaxLength(200);

                entity.Property(e => e.GrowthGoals).HasMaxLength(400);

                entity.Property(e => e.Industry).HasMaxLength(200);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.NickName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.ProfileImage).HasMaxLength(200);

                entity.Property(e => e.SocialMedia).HasMaxLength(200);

                entity.Property(e => e.WebsiteUrl).HasMaxLength(200);

                entity.Property(e => e.ZipCode).HasMaxLength(30);
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tblPost");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblPostAttachment>(entity =>
            {
                entity.HasKey(e => e.PostAttachmentId);

                entity.ToTable("tblPostAttachment");

                entity.Property(e => e.FileName).HasMaxLength(400);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblPostAttachment)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_tblPostAttachment_tblPost");
            });

            modelBuilder.Entity<TblPostFeedback>(entity =>
            {
                entity.HasKey(e => e.PostFeedId);

                entity.ToTable("tblPostFeedback");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblPostFeedback)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblPostFeedback_tblMember");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblPostFeedback)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_tblPostFeedback_tblPost");
            });

            modelBuilder.Entity<TblServiceRequest>(entity =>
            {
                entity.HasKey(e => e.RequestId);

                entity.ToTable("tblServiceRequest");

                entity.Property(e => e.Contributions).HasMaxLength(200);

                entity.Property(e => e.RequestDate).HasColumnType("datetime");

                entity.Property(e => e.ResumeLink)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblServiceRequest)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblServiceRequest_tblMember");
            });

            modelBuilder.Entity<TblUserNew>(entity =>
            {
                entity.ToTable("tblUserNew");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<Tbluser>(entity =>
            {
                entity.ToTable("tbluser");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
