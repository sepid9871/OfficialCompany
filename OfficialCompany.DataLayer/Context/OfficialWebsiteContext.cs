using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OfficialCompany.DataLayer.Entities;

namespace OfficialCompany.DataLayer.Context;

public partial class OfficialWebsiteContext : IdentityDbContext<AspUser,AspRole,int>
{
    public OfficialWebsiteContext()
    {
    }

    public OfficialWebsiteContext(DbContextOptions<OfficialWebsiteContext> options)
        : base(options)
    {
    }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsGroup> NewsGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
        //=> optionsBuilder.UseSqlServer("name=OfficialConString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		

		modelBuilder.Entity<News>(entity =>
        {
            entity.Property(e => e.NewsDesc).IsUnicode(false);
            entity.Property(e => e.NewsTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.NewsGroup).WithMany(p => p.News)
                .HasForeignKey(d => d.NewsGroupId)
                .HasConstraintName("FK_News_NewsGroup");
        });

        modelBuilder.Entity<NewsGroup>(entity =>
        {
            entity.ToTable("NewsGroup");

            entity.Property(e => e.GroupTitle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RegDate).HasColumnType("smalldatetime");
            entity.Property(e => e.Slug)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

		base.OnModelCreating(modelBuilder);
	}

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
