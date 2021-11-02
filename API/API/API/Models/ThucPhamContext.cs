using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace API.Models
{
    public partial class ThucPhamContext : DbContext
    {
        
        private string StrConnection;
        public ThucPhamContext(IConfiguration configuration)
        {
            StrConnection = configuration["SQLServer:ConnectionString"];
        }
        public ThucPhamContext(DbContextOptions<ThucPhamContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CtdonDatHang> CtdonDatHangs { get; set; }
        public virtual DbSet<CthoaDonNhap> CthoaDonNhaps { get; set; }
        public virtual DbSet<DangNhapAdmin> DangNhapAdmins { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhaps { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=DESKTOP-JMLKCH5\\SQLEXPRESS;Database=ThucPham;Trusted_Connection=True;");
                optionsBuilder.UseSqlServer(StrConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CtdonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaCtdonDatHang)
                    .HasName("PK__CTDonDat__1A6AD853FC4461AA");

                entity.ToTable("CTDonDatHang");

                entity.Property(e => e.MaCtdonDatHang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaCTDonDatHang");

                entity.Property(e => e.MaDonHang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.HasOne(d => d.MaDonHangNavigation)
                    .WithMany(p => p.CtdonDatHangs)
                    .HasForeignKey(d => d.MaDonHang)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaDonHang_CTDonDatHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CtdonDatHangs)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaSP_CTDonDatHang");
            });

            modelBuilder.Entity<CthoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaCthdnhap)
                    .HasName("PK__CTHoaDon__95B2776C4C2724A7");

                entity.ToTable("CTHoaDonNhap");

                entity.Property(e => e.MaCthdnhap)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaCTHDNhap");

                entity.Property(e => e.HanSuDung).HasColumnType("datetime");

                entity.Property(e => e.MaHoaDonNhap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.HasOne(d => d.MaHoaDonNhapNavigation)
                    .WithMany(p => p.CthoaDonNhaps)
                    .HasForeignKey(d => d.MaHoaDonNhap)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaHDN_CTHDNhap");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.CthoaDonNhaps)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaSP_SanPham");
            });

            modelBuilder.Entity<DangNhapAdmin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("DangNhap_Admin");

                entity.Property(e => e.Acc)
                    .HasMaxLength(20)
                    .HasColumnName("acc");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .HasColumnName("pass");

                entity.Property(e => e.Tenad)
                    .HasMaxLength(20)
                    .HasColumnName("tenad");
            });

            modelBuilder.Entity<DonDatHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__DonDatHa__129584ADF2FD093A");

                entity.ToTable("DonDatHang");

                entity.Property(e => e.MaDonHang)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChiNhan).HasMaxLength(200);

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaKH");

                entity.Property(e => e.NgayDat).HasColumnType("datetime");

                entity.Property(e => e.NgayGiao).HasColumnType("datetime");

                entity.Property(e => e.Sdtnhan)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDTNhan");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonDatHangs)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaKH_KhachHang");
            });

            modelBuilder.Entity<HoaDonNhap>(entity =>
            {
                entity.HasKey(e => e.MaHoaDonNhap)
                    .HasName("PK__HoaDonNh__448838B5EEDCCCBC");

                entity.ToTable("HoaDonNhap");

                entity.Property(e => e.MaHoaDonNhap)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.NgayNhap).HasColumnType("datetime");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HoaDonNhaps)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaNCC_HoaDonNhap");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKh)
                    .HasName("PK__KhachHan__2725CF1E7CEB1226");

                entity.ToTable("KhachHang");

                entity.Property(e => e.MaKh)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaKH");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenKh)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenKH");
            });

            modelBuilder.Entity<LoaiSanPham>(entity =>
            {
                entity.HasKey(e => e.MaLoaiSp)
                    .HasName("PK__LoaiSanP__1224CA7CD22689F3");

                entity.ToTable("LoaiSanPham");

                entity.Property(e => e.MaLoaiSp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaLoaiSP");

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCungC__3A185DEB0AAA633D");

                entity.ToTable("NhaCungCap");

                entity.Property(e => e.MaNcc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaNCC");

                entity.Property(e => e.DiaChi).HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("SDT");

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenNCC");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__SanPham__2725081CF24B47E2");

                entity.ToTable("SanPham");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaSP");

                entity.Property(e => e.DonVi).HasMaxLength(50);

                entity.Property(e => e.HinhAnh).HasMaxLength(500);

                entity.Property(e => e.MaLoaiSp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MaLoaiSP");

                entity.Property(e => e.MoTa).HasMaxLength(500);

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("TenSP");

                entity.HasOne(d => d.MaLoaiSpNavigation)
                    .WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaLoaiSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MaLoaiSP_SanPham");
            });

            modelBuilder.Entity<TinTuc>(entity =>
            {
                entity.ToTable("TinTuc");

                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.HinhAnh).HasMaxLength(200);

                entity.Property(e => e.NgayDang).HasColumnType("date");

                entity.Property(e => e.TieuDe).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.Acc)
                    .HasMaxLength(20)
                    .HasColumnName("acc");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("diachi");

                entity.Property(e => e.Pass)
                    .HasMaxLength(20)
                    .HasColumnName("pass");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Ten)
                    .HasMaxLength(20)
                    .HasColumnName("ten");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
