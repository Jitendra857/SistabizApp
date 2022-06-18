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
        public virtual DbSet<TblAttachmentBookmark> TblAttachmentBookmark { get; set; }
        public virtual DbSet<TblBadges> TblBadges { get; set; }
        public virtual DbSet<TblBadgesAssignMember> TblBadgesAssignMember { get; set; }
        public virtual DbSet<TblBillingAddress> TblBillingAddress { get; set; }
        public virtual DbSet<TblBookMark> TblBookMark { get; set; }
        public virtual DbSet<TblBreakthrough> TblBreakthrough { get; set; }
        public virtual DbSet<TblChatHistory> TblChatHistory { get; set; }
        public virtual DbSet<TblConversationAnswer> TblConversationAnswer { get; set; }
        public virtual DbSet<TblConversationQuestionAnswer> TblConversationQuestionAnswer { get; set; }
        public virtual DbSet<TblCountry> TblCountry { get; set; }
        public virtual DbSet<TblDigitalLibaryAttachment> TblDigitalLibaryAttachment { get; set; }
        public virtual DbSet<TblDigitalLibrary> TblDigitalLibrary { get; set; }
        public virtual DbSet<TblDigitalLibraryBookmark> TblDigitalLibraryBookmark { get; set; }
        public virtual DbSet<TblDigitalLibraryCategory> TblDigitalLibraryCategory { get; set; }
        public virtual DbSet<TblEvent> TblEvent { get; set; }
        public virtual DbSet<TblEventAttachment> TblEventAttachment { get; set; }
        public virtual DbSet<TblEventBookmark> TblEventBookmark { get; set; }
        public virtual DbSet<TblEventCategory> TblEventCategory { get; set; }
        public virtual DbSet<TblEventRegisterMember> TblEventRegisterMember { get; set; }
        public virtual DbSet<TblFaq> TblFaq { get; set; }
        public virtual DbSet<TblFaqCategory> TblFaqCategory { get; set; }
        public virtual DbSet<TblFaqQuestion> TblFaqQuestion { get; set; }
        public virtual DbSet<TblFundingBookmark> TblFundingBookmark { get; set; }
        public virtual DbSet<TblFundingCategory> TblFundingCategory { get; set; }
        public virtual DbSet<TblFundingResources> TblFundingResources { get; set; }
        public virtual DbSet<TblFundingSection> TblFundingSection { get; set; }
        public virtual DbSet<TblGoal> TblGoal { get; set; }
        public virtual DbSet<TblGoalCategory> TblGoalCategory { get; set; }
        public virtual DbSet<TblGoalCategoryMapping> TblGoalCategoryMapping { get; set; }
        public virtual DbSet<TblGoalMaches> TblGoalMaches { get; set; }
        public virtual DbSet<TblGroup> TblGroup { get; set; }
        public virtual DbSet<TblGroupAttachment> TblGroupAttachment { get; set; }
        public virtual DbSet<TblGroupBookmarks> TblGroupBookmarks { get; set; }
        public virtual DbSet<TblGroupCategory> TblGroupCategory { get; set; }
        public virtual DbSet<TblGroupDiscussion> TblGroupDiscussion { get; set; }
        public virtual DbSet<TblGroupJoinMember> TblGroupJoinMember { get; set; }
        public virtual DbSet<TblGroupMeeting> TblGroupMeeting { get; set; }
        public virtual DbSet<TblMember> TblMember { get; set; }
        public virtual DbSet<TblMemberAttachment> TblMemberAttachment { get; set; }
        public virtual DbSet<TblMemberDesignation> TblMemberDesignation { get; set; }
        public virtual DbSet<TblMemberGoal> TblMemberGoal { get; set; }
        public virtual DbSet<TblMemberMatches> TblMemberMatches { get; set; }
        public virtual DbSet<TblMemberPhotoLikeComment> TblMemberPhotoLikeComment { get; set; }
        public virtual DbSet<TblMemberPostLikeComment> TblMemberPostLikeComment { get; set; }
        public virtual DbSet<TblMemberRoles> TblMemberRoles { get; set; }
        public virtual DbSet<TblMemberSkills> TblMemberSkills { get; set; }
        public virtual DbSet<TblModule> TblModule { get; set; }
        public virtual DbSet<TblModulePermission> TblModulePermission { get; set; }
        public virtual DbSet<TblOnboardingConversation> TblOnboardingConversation { get; set; }
        public virtual DbSet<TblPost> TblPost { get; set; }
        public virtual DbSet<TblPostAttachment> TblPostAttachment { get; set; }
        public virtual DbSet<TblPostBookMark> TblPostBookMark { get; set; }
        public virtual DbSet<TblPostFeedback> TblPostFeedback { get; set; }
        public virtual DbSet<TblReddemPoints> TblReddemPoints { get; set; }
        public virtual DbSet<TblRedeemRefer> TblRedeemRefer { get; set; }
        public virtual DbSet<TblReferralCode> TblReferralCode { get; set; }
        public virtual DbSet<TblServiceRequest> TblServiceRequest { get; set; }
        public virtual DbSet<TblState> TblState { get; set; }
        public virtual DbSet<TblSubscriptionType> TblSubscriptionType { get; set; }
        public virtual DbSet<TblTeckHelp> TblTeckHelp { get; set; }
        public virtual DbSet<TblTestimonials> TblTestimonials { get; set; }
        public virtual DbSet<TblUserNew> TblUserNew { get; set; }
        public virtual DbSet<TblUserSubscription> TblUserSubscription { get; set; }
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

            modelBuilder.Entity<TblAttachmentBookmark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblAttachmentBookmark");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.TblAttachmentBookmark)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_tblAttachmentBookmark_tblAttachment");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblAttachmentBookmark)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblAttachmentBookmark_tblMember");
            });

            modelBuilder.Entity<TblBadges>(entity =>
            {
                entity.HasKey(e => e.BadgesId);

                entity.ToTable("tblBadges");

                entity.Property(e => e.BadgesName).HasMaxLength(300);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Image).HasMaxLength(300);
            });

            modelBuilder.Entity<TblBadgesAssignMember>(entity =>
            {
                entity.HasKey(e => e.BadgesAssignId);

                entity.ToTable("tblBadgesAssignMember");

                entity.Property(e => e.AssginDate).HasColumnType("datetime");

                entity.HasOne(d => d.Badges)
                    .WithMany(p => p.TblBadgesAssignMember)
                    .HasForeignKey(d => d.BadgesId)
                    .HasConstraintName("FK_tblBadgesAssignMember_tblBadges");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblBadgesAssignMember)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblBadgesAssignMember_tblMember");
            });

            modelBuilder.Entity<TblBillingAddress>(entity =>
            {
                entity.HasKey(e => e.BillingAddressId);

                entity.ToTable("tblBillingAddress");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.Country).HasMaxLength(100);

                entity.Property(e => e.State).HasMaxLength(100);

                entity.Property(e => e.ZipCode).HasMaxLength(100);

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.TblBillingAddress)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK_tblBillingAddress_tblSubscription");
            });

            modelBuilder.Entity<TblBookMark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblBookMark");

                entity.Property(e => e.BookmarkDatet).HasColumnType("datetime");

                entity.HasOne(d => d.BookmarkByNavigation)
                    .WithMany(p => p.TblBookMarkBookmarkByNavigation)
                    .HasForeignKey(d => d.BookmarkBy)
                    .HasConstraintName("FK_tblBookMark_tblMember");

                entity.HasOne(d => d.BookmarkToNavigation)
                    .WithMany(p => p.TblBookMarkBookmarkToNavigation)
                    .HasForeignKey(d => d.BookmarkTo)
                    .HasConstraintName("FK_tblBookMark_tblBookmarkMemberTo");
            });

            modelBuilder.Entity<TblBreakthrough>(entity =>
            {
                entity.HasKey(e => e.BreakthroughId);

                entity.ToTable("tblBreakthrough");

                entity.Property(e => e.ConsultingDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblBreakthrough)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblBreakthrough_tblMember");

                entity.HasOne(d => d.SubscriptionTypeNavigation)
                    .WithMany(p => p.TblBreakthrough)
                    .HasForeignKey(d => d.SubscriptionType)
                    .HasConstraintName("FK_tblBreakthrough_tblSubscriptionType");
            });

            modelBuilder.Entity<TblChatHistory>(entity =>
            {
                entity.HasKey(e => e.ChatId);

                entity.ToTable("tblChatHistory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ReachiverId).HasMaxLength(200);

                entity.Property(e => e.SenderId).HasMaxLength(200);

                entity.Property(e => e.TrackerId).HasMaxLength(200);
            });

            modelBuilder.Entity<TblConversationAnswer>(entity =>
            {
                entity.HasKey(e => e.ConversationAnswerId);

                entity.ToTable("tblConversationAnswer");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblConversationAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_tblConversationAnswer_tblQuestion");
            });

            modelBuilder.Entity<TblConversationQuestionAnswer>(entity =>
            {
                entity.HasKey(e => e.QuestionAnswerId);

                entity.ToTable("tblConversationQuestionAnswer");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.TblConversationQuestionAnswer)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_tblConversationQuestionAnswer_tblConversationAnswer");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblConversationQuestionAnswer)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblConversationQuestionAnswer_tblMember");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.TblConversationQuestionAnswer)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_tblConversationQuestionAnswer_tblConversationQuestion");
            });

            modelBuilder.Entity<TblCountry>(entity =>
            {
                entity.HasKey(e => e.CountryId);

                entity.ToTable("tblCountry");

                entity.Property(e => e.CountryName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblDigitalLibaryAttachment>(entity =>
            {
                entity.HasKey(e => e.LibraryAttachmentId);

                entity.ToTable("tblDigitalLibaryAttachment");

                entity.Property(e => e.FileName).HasMaxLength(300);

                entity.HasOne(d => d.DigitalLibary)
                    .WithMany(p => p.TblDigitalLibaryAttachment)
                    .HasForeignKey(d => d.DigitalLibaryId)
                    .HasConstraintName("FK_tblDigitalLibaryAttachment_tblDigitalLibary");
            });

            modelBuilder.Entity<TblDigitalLibrary>(entity =>
            {
                entity.HasKey(e => e.DigitalLibraryId);

                entity.ToTable("tblDigitalLibrary");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ProfileIcon).HasMaxLength(300);

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblDigitalLibrary)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblDigitalLibrary_tblDigitalLibraryCategory");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblDigitalLibrary)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblDigitalLibrary_tblMember");
            });

            modelBuilder.Entity<TblDigitalLibraryBookmark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblDigitalLibraryBookmark");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblDigitalLibraryBookmark)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblDigitalLibraryBookmark_tblDigitalLibraryCategory");

                entity.HasOne(d => d.DigitalLibrry)
                    .WithMany(p => p.TblDigitalLibraryBookmark)
                    .HasForeignKey(d => d.DigitalLibrryId)
                    .HasConstraintName("FK_tblDigitalLibraryBookmark_tblDigitalLibrary");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblDigitalLibraryBookmark)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblDigitalLibraryBookmark_tblMember");
            });

            modelBuilder.Entity<TblDigitalLibraryCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_tblDigittalLibraryCategory");

                entity.ToTable("tblDigitalLibraryCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(300);
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

                entity.Property(e => e.EventLink).HasMaxLength(300);

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

            modelBuilder.Entity<TblEventBookmark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblEventBookmark");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.TblEventBookmark)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_tblEventBookmark_tblEvent");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblEventBookmark)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblEventBookmark_tblMember");
            });

            modelBuilder.Entity<TblEventCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblEventCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(300);
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

            modelBuilder.Entity<TblFaqQuestion>(entity =>
            {
                entity.HasKey(e => e.FaqQuestionId);

                entity.ToTable("tblFaqQuestion");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblFaqQuestion)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblFaqQuestion_tblMember");
            });

            modelBuilder.Entity<TblFundingBookmark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblFundingBookmark");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblFundingBookmark)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblFundingBookmark_tblFundingCategory");

                entity.HasOne(d => d.Funding)
                    .WithMany(p => p.TblFundingBookmark)
                    .HasForeignKey(d => d.FundingId)
                    .HasConstraintName("FK_tblFundingBookmark_tblFundingResource");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblFundingBookmark)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblFundingBookmark_tblMember");
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

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblFundingResources)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblFundingResources_tblMember");
            });

            modelBuilder.Entity<TblFundingSection>(entity =>
            {
                entity.HasKey(e => e.FundingSectionId);

                entity.ToTable("tblFundingSection");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.FileUrl).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<TblGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId);

                entity.ToTable("tblGoal");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.PostponeDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblGoal)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblGoal_tblMember");
            });

            modelBuilder.Entity<TblGoalCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("tblGoalCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblGoalCategoryMapping>(entity =>
            {
                entity.HasKey(e => e.GoalMappingId);

                entity.ToTable("tblGoalCategoryMapping");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblGoalCategoryMapping)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblGoalCategoryMapping_tblGoalCategory");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.TblGoalCategoryMapping)
                    .HasForeignKey(d => d.GoalId)
                    .HasConstraintName("FK_tblGoalCategoryMapping_tblGoal");
            });

            modelBuilder.Entity<TblGoalMaches>(entity =>
            {
                entity.HasKey(e => e.GoalMachId);

                entity.ToTable("tblGoalMaches");

                entity.HasOne(d => d.Goal)
                    .WithMany(p => p.TblGoalMaches)
                    .HasForeignKey(d => d.GoalId)
                    .HasConstraintName("FK_tblGoalMaches_tblGoal");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblGoalMaches)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblGoalMaches_tblMember");
            });

            modelBuilder.Entity<TblGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("tblGroup");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.GroupIcon).HasMaxLength(300);

                entity.Property(e => e.GroupName).HasMaxLength(500);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.HasOne(d => d.CategoryNavigation)
                    .WithMany(p => p.TblGroup)
                    .HasForeignKey(d => d.Category)
                    .HasConstraintName("FK_tblGroup_tblGroupCategory");

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

                entity.Property(e => e.DocumnetType).HasMaxLength(200);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupAttachment)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupAttachment_tblGroup");
            });

            modelBuilder.Entity<TblGroupBookmarks>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblGroupBookmarks");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblGroupBookmarks)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_tblGroupBookmarks_tblGroupCategory");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupBookmarks)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupBookmarks_tblGroup");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblGroupBookmarks)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblGroupBookmarks_tblMember");
            });

            modelBuilder.Entity<TblGroupCategory>(entity =>
            {
                entity.HasKey(e => e.GroupCategoryId);

                entity.ToTable("tblGroupCategory");

                entity.Property(e => e.CategoryName).HasMaxLength(300);
            });

            modelBuilder.Entity<TblGroupDiscussion>(entity =>
            {
                entity.HasKey(e => e.DiscussionId);

                entity.ToTable("tblGroupDiscussion");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupDiscussion)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupDiscussion_tblGroup");

                entity.HasOne(d => d.MessageByNavigation)
                    .WithMany(p => p.TblGroupDiscussion)
                    .HasForeignKey(d => d.MessageBy)
                    .HasConstraintName("FK_tblGroupDiscussion_tblMember");
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

            modelBuilder.Entity<TblGroupMeeting>(entity =>
            {
                entity.HasKey(e => e.MeetingId);

                entity.ToTable("tblGroupMeeting");

                entity.Property(e => e.Agenda).HasMaxLength(300);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.MeetingLink).HasMaxLength(300);

                entity.Property(e => e.MeetingPlace).HasMaxLength(300);

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblGroupMeeting)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblGroupMeeting_tblMember");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.TblGroupMeeting)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_tblGroupMeeting_tblGroup");
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

                entity.Property(e => e.Founded).HasColumnType("date");

                entity.Property(e => e.GovernmentCertifications).HasMaxLength(200);

                entity.Property(e => e.GrowthGoals).HasMaxLength(400);

                entity.Property(e => e.Industry).HasMaxLength(200);

                entity.Property(e => e.Interest).HasMaxLength(300);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.Mobile).HasMaxLength(20);

                entity.Property(e => e.NickName).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.ProfileImage).HasMaxLength(200);

                entity.Property(e => e.ReferralCode).HasMaxLength(200);

                entity.Property(e => e.Size).HasMaxLength(100);

                entity.Property(e => e.SocialMedia).HasMaxLength(200);

                entity.Property(e => e.Stage).HasMaxLength(200);

                entity.Property(e => e.WebsiteUrl).HasMaxLength(200);

                entity.Property(e => e.ZipCode).HasMaxLength(30);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TblMember)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_tblMember_tblRole");
            });

            modelBuilder.Entity<TblMemberAttachment>(entity =>
            {
                entity.HasKey(e => e.AttachmentId);

                entity.ToTable("tblMemberAttachment");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.PhotoVideoUrl).HasMaxLength(300);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberAttachment)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberAttachment_tblMember");
            });

            modelBuilder.Entity<TblMemberDesignation>(entity =>
            {
                entity.HasKey(e => e.DesignationId);

                entity.ToTable("tblMemberDesignation");

                entity.Property(e => e.Designation).HasMaxLength(300);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberDesignation)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberDesignation_tblMember");
            });

            modelBuilder.Entity<TblMemberGoal>(entity =>
            {
                entity.HasKey(e => e.GoalId);

                entity.ToTable("tblMemberGoal");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberGoal)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberGoal_tblMember");
            });

            modelBuilder.Entity<TblMemberMatches>(entity =>
            {
                entity.HasKey(e => e.MatchesId);

                entity.ToTable("tblMemberMatches");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.MatchesMember)
                    .WithMany(p => p.TblMemberMatchesMatchesMember)
                    .HasForeignKey(d => d.MatchesMemberid)
                    .HasConstraintName("FK_tblMemberMatches_tblMember1");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberMatchesMember)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberMatches_tblMember");
            });

            modelBuilder.Entity<TblMemberPhotoLikeComment>(entity =>
            {
                entity.ToTable("tblMemberPhotoLikeComment");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.TblMemberPhotoLikeComment)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_tblMemberPhotoLikeComment_tblMemberAttachment");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberPhotoLikeComment)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberPhotoLikeComment_tblMember");
            });

            modelBuilder.Entity<TblMemberPostLikeComment>(entity =>
            {
                entity.HasKey(e => e.AttachmentLikeId);

                entity.ToTable("tblMemberPostLikeComment");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Attachment)
                    .WithMany(p => p.TblMemberPostLikeComment)
                    .HasForeignKey(d => d.AttachmentId)
                    .HasConstraintName("FK_tblMemberPostLikeComment_tblMemberAttachment");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberPostLikeComment)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberPostLikeComment_tblMember");
            });

            modelBuilder.Entity<TblMemberRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("tblMemberRoles");

                entity.Property(e => e.RoleName).HasMaxLength(200);
            });

            modelBuilder.Entity<TblMemberSkills>(entity =>
            {
                entity.HasKey(e => e.SkillId);

                entity.ToTable("tblMemberSkills");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblMemberSkills)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblMemberSkills_tblMember");
            });

            modelBuilder.Entity<TblModule>(entity =>
            {
                entity.HasKey(e => e.ModuleId);

                entity.ToTable("tblModule");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleName).HasMaxLength(200);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblModule)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblModule_tblMember");
            });

            modelBuilder.Entity<TblModulePermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.ToTable("tblModulePermission");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.TblModulePermission)
                    .HasForeignKey(d => d.ModuleId)
                    .HasConstraintName("FK_tblModulePermission_tblModule");

                entity.HasOne(d => d.SubscriptionTypeNavigation)
                    .WithMany(p => p.TblModulePermission)
                    .HasForeignKey(d => d.SubscriptionType)
                    .HasConstraintName("FK_tblModulePermission_tblSubscription");
            });

            modelBuilder.Entity<TblOnboardingConversation>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.ToTable("tblOnboardingConversation");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblOnboardingConversation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblOnboardingConversation_tblMember");
            });

            modelBuilder.Entity<TblPost>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.ToTable("tblPost");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.WebsiteLink).HasMaxLength(300);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblPost)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblPost_tblMember");
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

            modelBuilder.Entity<TblPostBookMark>(entity =>
            {
                entity.HasKey(e => e.BookmarkId);

                entity.ToTable("tblPostBookMark");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblPostBookMark)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblPostBookMark_tblMember");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.TblPostBookMark)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_tblPostBookMark_tblPost");
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

            modelBuilder.Entity<TblReddemPoints>(entity =>
            {
                entity.HasKey(e => e.ReddemId);

                entity.ToTable("tblReddemPoints");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblReddemPointsMember)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblReddemPoints_tblMember");

                entity.HasOne(d => d.ReddemByNavigation)
                    .WithMany(p => p.TblReddemPointsReddemByNavigation)
                    .HasForeignKey(d => d.ReddemBy)
                    .HasConstraintName("FK_tblReddemPoints_tblReddemBy");

                entity.HasOne(d => d.ReferToNavigation)
                    .WithMany(p => p.TblReddemPointsReferToNavigation)
                    .HasForeignKey(d => d.ReferTo)
                    .HasConstraintName("FK_tblReddemPoints_tblReferToMember");
            });

            modelBuilder.Entity<TblRedeemRefer>(entity =>
            {
                entity.ToTable("tblRedeemRefer");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Redeem)
                    .WithMany(p => p.TblRedeemRefer)
                    .HasForeignKey(d => d.RedeemId)
                    .HasConstraintName("FK_tblRedeemRefer_tblRedeem");
            });

            modelBuilder.Entity<TblReferralCode>(entity =>
            {
                entity.HasKey(e => e.ReferralId);

                entity.ToTable("tblReferralCode");

                entity.Property(e => e.ReferralCode).HasMaxLength(200);
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

            modelBuilder.Entity<TblState>(entity =>
            {
                entity.HasKey(e => e.StateId);

                entity.ToTable("tblState");

                entity.Property(e => e.StateName).HasMaxLength(300);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.TblState)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_tblState_tblCountry");
            });

            modelBuilder.Entity<TblSubscriptionType>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId);

                entity.ToTable("tblSubscriptionType");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.SubscriptionName).HasMaxLength(300);
            });

            modelBuilder.Entity<TblTeckHelp>(entity =>
            {
                entity.HasKey(e => e.TechHelpId);

                entity.ToTable("tblTeckHelp");

                entity.Property(e => e.BookingDate).HasColumnType("date");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Title).HasMaxLength(200);

                entity.HasOne(d => d.AssignByNavigation)
                    .WithMany(p => p.TblTeckHelpAssignByNavigation)
                    .HasForeignKey(d => d.AssignBy)
                    .HasConstraintName("FK_tblTeckHelp_tblMember");

                entity.HasOne(d => d.AssignToNavigation)
                    .WithMany(p => p.TblTeckHelpAssignToNavigation)
                    .HasForeignKey(d => d.AssignTo)
                    .HasConstraintName("FK_tblTeckHelp_tblMemberAssignTo");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.TblTeckHelpCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_tblTeckHelp_tblMemberCreatedBy");
            });

            modelBuilder.Entity<TblTestimonials>(entity =>
            {
                entity.HasKey(e => e.TestimonialId);

                entity.ToTable("tblTestimonials");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.TblTestimonials)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_tblTestimonials_tblMember");
            });

            modelBuilder.Entity<TblUserNew>(entity =>
            {
                entity.ToTable("tblUserNew");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<TblUserSubscription>(entity =>
            {
                entity.HasKey(e => e.SubscriptionId);

                entity.ToTable("tblUserSubscription");

                entity.Property(e => e.CreateOn).HasColumnType("datetime");

                entity.Property(e => e.SubscriptionEndDate).HasColumnType("datetime");

                entity.Property(e => e.SubscriptionStartDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId).HasMaxLength(500);

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.TblUserSubscription)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .HasConstraintName("FK_tblUserSubscription_tblSubscriptionType");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TblUserSubscription)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_tblUserSubscription_tblMember");
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
