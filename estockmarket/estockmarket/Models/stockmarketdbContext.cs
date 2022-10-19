using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace estockmarket.Models
{
    public partial class stockmarketdbContext : DbContext
    {
        public stockmarketdbContext()
        {
        }

        public stockmarketdbContext(DbContextOptions<stockmarketdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ITCDNFS03;Initial Catalog=stockmarketdb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("company");

                entity.HasIndex(e => e.CompanyCode, "UQ__company__F4E508EA1D5BF803")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyCeo)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_ceo");

                entity.Property(e => e.CompanyCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_code");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_name");

                entity.Property(e => e.CompanyTurnover)
                    .HasColumnType("money")
                    .HasColumnName("company_turnover");

                entity.Property(e => e.CompanyWebsite)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("company_website");

                entity.Property(e => e.StockExchange)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stock_exchange");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("stock");

                entity.Property(e => e.StockId).HasColumnName("stock_id");

                entity.Property(e => e.CompanyCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("company_code");

                entity.Property(e => e.StockEndDate)
                    .HasColumnType("date")
                    .HasColumnName("stock_end_date");

                entity.Property(e => e.StockEndTime).HasColumnName("stock_end_time");

                entity.Property(e => e.StockPrice)
                    .HasColumnType("money")
                    .HasColumnName("stock_price");

                entity.Property(e => e.StockStartDate)
                    .HasColumnType("date")
                    .HasColumnName("stock_start_date");

                entity.Property(e => e.StockStartTime).HasColumnName("stock_start_time");

                entity.HasOne(d => d.CompanyCodeNavigation)
                    .WithMany(p => p.Stocks)
                    .HasPrincipalKey(p => p.CompanyCode)
                    .HasForeignKey(d => d.CompanyCode)
                    .HasConstraintName("fk_company_stock");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
