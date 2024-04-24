using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EditGrid.Models;

public partial class FileStoreContext : DbContext
{

    private readonly IServiceScopeFactory _serviceScopeFactory;

    public FileStoreContext(DbContextOptions<FileStoreContext> options, IServiceScopeFactory serviceScopeFactory) : base(options)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public virtual DbSet<Files2> Files2s { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Files2>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK__Files2");

            entity.ToTable("Files2");

            entity.Property(e => e.FileId).HasColumnName("FileID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    // Using EF to fetch files
    public async Task<List<Files2>> GetFilesAsync()
    {
        // Directly use LINQ to Entities to fetch data
        return await Files2s.ToListAsync();
    }
}
