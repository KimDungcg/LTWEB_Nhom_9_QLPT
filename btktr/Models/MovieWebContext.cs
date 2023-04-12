using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace btktr.Models;

public partial class MovieWebContext : DbContext
{
    public MovieWebContext()
    {
    }

    public MovieWebContext(DbContextOptions<MovieWebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaiTap> BaiTaps { get; set; }

    public virtual DbSet<CaLam> CaLams { get; set; }

    public virtual DbSet<CauLacBo> CauLacBos { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Khoahoc> Khoahocs { get; set; }

    public virtual DbSet<LichTap> LichTaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NoiHoc> NoiHocs { get; set; }

    public virtual DbSet<Pt> Pts { get; set; }

    public virtual DbSet<TrinhDo> TrinhDos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NGUYEN-TRONG-VA;Initial Catalog=btltsualan3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaiTap>(entity =>
        {
            entity.HasKey(e => e.MaBaiTap).HasName("pk_BaiTap_MaBaiTap");

            entity.ToTable("BaiTap");

            entity.Property(e => e.MaBaiTap).HasMaxLength(20);
            entity.Property(e => e.Avatar)
                .HasMaxLength(20)
                .HasColumnName("avatar");
            entity.Property(e => e.ChiTietBt)
                .HasMaxLength(2000)
                .HasColumnName("ChiTietBT");
            entity.Property(e => e.TenBaiTap).HasMaxLength(20);

            entity.HasMany(d => d.MaKhoaHocs).WithMany(p => p.MabaiTaps)
                .UsingEntity<Dictionary<string, object>>(
                    "ChiTietKhoaHoc",
                    r => r.HasOne<Khoahoc>().WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_KhoaHoc_ChiTietKhoaHoc"),
                    l => l.HasOne<BaiTap>().WithMany()
                        .HasForeignKey("MabaiTap")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_baiTap_ChiTietKhoaHoc"),
                    j =>
                    {
                        j.HasKey("MabaiTap", "MaKhoaHoc").HasName("pk_ChiTietKhoaHoc");
                        j.ToTable("ChiTietKhoaHoc");
                        j.IndexerProperty<string>("MabaiTap").HasMaxLength(20);
                        j.IndexerProperty<string>("MaKhoaHoc").HasMaxLength(20);
                    });
        });

        modelBuilder.Entity<CaLam>(entity =>
        {
            entity.HasKey(e => e.MaCaLam).HasName("pk_CaLam_MaCaLam");

            entity.ToTable("CaLam");

            entity.Property(e => e.MaCaLam).HasMaxLength(20);
            entity.Property(e => e.TenCaLam).HasMaxLength(20);
        });

        modelBuilder.Entity<CauLacBo>(entity =>
        {
            entity.HasKey(e => e.MaClb).HasName("pk_CauLacBo_MaCLB");

            entity.ToTable("CauLacBo");

            entity.Property(e => e.MaClb)
                .HasMaxLength(20)
                .HasColumnName("MaCLB");
            entity.Property(e => e.Avatar)
                .HasMaxLength(20)
                .HasColumnName("avatar");
            entity.Property(e => e.ChiTietClb)
                .HasMaxLength(2000)
                .HasColumnName("ChiTietCLB");
            entity.Property(e => e.DiachiClb)
                .HasMaxLength(20)
                .HasColumnName("DiachiCLB");
            entity.Property(e => e.TenClb)
                .HasMaxLength(20)
                .HasColumnName("TenCLB");

            entity.HasMany(d => d.MaKhoaHocs).WithMany(p => p.MaClbs)
                .UsingEntity<Dictionary<string, object>>(
                    "KhoaHocCauLacBo",
                    r => r.HasOne<Khoahoc>().WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_KhoaHoc_CauLacBo_KhoaHoc"),
                    l => l.HasOne<CauLacBo>().WithMany()
                        .HasForeignKey("MaClb")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_KhoaHoc_Caulacbo_Caulacbo"),
                    j =>
                    {
                        j.HasKey("MaClb", "MaKhoaHoc").HasName("pk_KhoaHoc_CauLacBo");
                        j.ToTable("KhoaHoc_CauLacBo");
                        j.IndexerProperty<string>("MaClb")
                            .HasMaxLength(20)
                            .HasColumnName("MaCLB");
                        j.IndexerProperty<string>("MaKhoaHoc").HasMaxLength(20);
                    });

            entity.HasMany(d => d.MaPts).WithMany(p => p.MaClbs)
                .UsingEntity<Dictionary<string, object>>(
                    "PtCaulacBo",
                    r => r.HasOne<Pt>().WithMany()
                        .HasForeignKey("MaPt")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_PT_Caulacbo_PT"),
                    l => l.HasOne<CauLacBo>().WithMany()
                        .HasForeignKey("MaClb")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_PT_Caulacbo_Caulacbo"),
                    j =>
                    {
                        j.HasKey("MaClb", "MaPt").HasName("pk_PT_CauLacBo");
                        j.ToTable("PT_CaulacBo");
                        j.IndexerProperty<string>("MaClb")
                            .HasMaxLength(20)
                            .HasColumnName("MaCLB");
                        j.IndexerProperty<string>("MaPt")
                            .HasMaxLength(20)
                            .HasColumnName("MaPT");
                    });
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("pk_DichVu_MaDichVu");

            entity.ToTable("DichVu");

            entity.Property(e => e.MaDichVu).HasMaxLength(20);
            entity.Property(e => e.Avatar)
                .HasMaxLength(20)
                .HasColumnName("avatar");
            entity.Property(e => e.ChiTietDv)
                .HasMaxLength(2000)
                .HasColumnName("ChiTietDV");
            entity.Property(e => e.TenDichVu).HasMaxLength(200);

            entity.HasMany(d => d.MaClbs).WithMany(p => p.MaDichVus)
                .UsingEntity<Dictionary<string, object>>(
                    "DichVuCauLacBo",
                    r => r.HasOne<CauLacBo>().WithMany()
                        .HasForeignKey("MaClb")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_DichVu_CauLacBo_CauLacBo"),
                    l => l.HasOne<DichVu>().WithMany()
                        .HasForeignKey("MaDichVu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_DichVu_CauLacBo_DichVu"),
                    j =>
                    {
                        j.HasKey("MaDichVu", "MaClb").HasName("pk_DichVu_CauLacBo");
                        j.ToTable("DichVu_CauLacBo");
                        j.IndexerProperty<string>("MaDichVu").HasMaxLength(20);
                        j.IndexerProperty<string>("MaClb")
                            .HasMaxLength(20)
                            .HasColumnName("MaCLB");
                    });
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("pk_HoaDon_MaHoaDon");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHoaDon).HasMaxLength(20);
            entity.Property(e => e.GiaHoaDon).HasColumnType("money");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaKhoaHoc).HasMaxLength(20);
            entity.Property(e => e.MaPt)
                .HasMaxLength(20)
                .HasColumnName("MaPT");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_KhachHang_MaKH");

            entity.HasOne(d => d.MaKhoaHocNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKhoaHoc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_HoaDOn_MaKhoaHoc");

            entity.HasOne(d => d.MaPtNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaPt)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_PT_MaPT");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("pk_KhachHang_MaKH");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiachiKh)
                .HasMaxLength(20)
                .HasColumnName("DiachiKH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(20)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<Khoahoc>(entity =>
        {
            entity.HasKey(e => e.MaKhoaHoc).HasName("pk_KhoaHoc_MaKhoaHoc");

            entity.ToTable("Khoahoc");

            entity.Property(e => e.MaKhoaHoc).HasMaxLength(20);
            entity.Property(e => e.GiaKhoahoc).HasColumnType("money");
            entity.Property(e => e.TenKhoaHoc).HasMaxLength(200);
        });

        modelBuilder.Entity<LichTap>(entity =>
        {
            entity.HasKey(e => e.MaLichTap).HasName("pk_LichTap_MaLichTap");

            entity.ToTable("LichTap");

            entity.Property(e => e.MaLichTap).HasMaxLength(20);
            entity.Property(e => e.TenLichTap).HasMaxLength(20);

            entity.HasMany(d => d.MaBaitaps).WithMany(p => p.MaLichTaps)
                .UsingEntity<Dictionary<string, object>>(
                    "LichTapBaiTap",
                    r => r.HasOne<BaiTap>().WithMany()
                        .HasForeignKey("MaBaitap")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_LichTap_BaiTap_BaiTap"),
                    l => l.HasOne<LichTap>().WithMany()
                        .HasForeignKey("MaLichTap")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_LichTap_BaiTap_LichTap"),
                    j =>
                    {
                        j.HasKey("MaLichTap", "MaBaitap").HasName("pk_LichTap_BaiTap");
                        j.ToTable("LichTap_BaiTap");
                        j.IndexerProperty<string>("MaLichTap").HasMaxLength(20);
                        j.IndexerProperty<string>("MaBaitap").HasMaxLength(20);
                    });
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("pk_NhanVien_MaNV");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChiNv)
                .HasMaxLength(20)
                .HasColumnName("DiaChiNV");
            entity.Property(e => e.MaCaLam).HasMaxLength(20);
            entity.Property(e => e.SoDienThoaiNv).HasColumnName("SoDienThoaiNV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(20)
                .HasColumnName("TenNV");
            entity.Property(e => e.TuoiNv).HasColumnName("TuoiNV");

            entity.HasOne(d => d.MaCaLamNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCaLam)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_CaLam_MaCaLam");
        });

        modelBuilder.Entity<NoiHoc>(entity =>
        {
            entity.HasKey(e => e.MaNoiHoc).HasName("pk_NoiHoc_MaNoiHoc");

            entity.ToTable("NoiHoc");

            entity.Property(e => e.MaNoiHoc).HasMaxLength(20);
            entity.Property(e => e.TenNoiHoc).HasMaxLength(20);
        });

        modelBuilder.Entity<Pt>(entity =>
        {
            entity.HasKey(e => e.MaPt).HasName("pk_PT_MaPT");

            entity.ToTable("PT");

            entity.Property(e => e.MaPt)
                .HasMaxLength(20)
                .HasColumnName("MaPT");
            entity.Property(e => e.Avatar)
                .HasMaxLength(20)
                .HasColumnName("avatar");
            entity.Property(e => e.GiaPt)
                .HasColumnType("money")
                .HasColumnName("GiaPT");
            entity.Property(e => e.MaCalam).HasMaxLength(20);
            entity.Property(e => e.MaNoiHoc).HasMaxLength(20);
            entity.Property(e => e.MaTrinhDo).HasMaxLength(20);
            entity.Property(e => e.NamKn)
                .HasMaxLength(200)
                .HasColumnName("NamKN");
            entity.Property(e => e.TenPt)
                .HasMaxLength(20)
                .HasColumnName("TenPT");
            entity.Property(e => e.TuoiPt).HasColumnName("TuoiPT");

            entity.HasOne(d => d.MaCalamNavigation).WithMany(p => p.Pts)
                .HasForeignKey(d => d.MaCalam)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_CaLam1_MaCaLam");

            entity.HasOne(d => d.MaNoiHocNavigation).WithMany(p => p.Pts)
                .HasForeignKey(d => d.MaNoiHoc)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_NoiHoc_MaNoiHoc");

            entity.HasOne(d => d.MaTrinhDoNavigation).WithMany(p => p.Pts)
                .HasForeignKey(d => d.MaTrinhDo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("fk_TrinhDo_MaTrinhDo");

            entity.HasMany(d => d.MaKhoaHocs).WithMany(p => p.MaPts)
                .UsingEntity<Dictionary<string, object>>(
                    "PtKhoaHoc",
                    r => r.HasOne<Khoahoc>().WithMany()
                        .HasForeignKey("MaKhoaHoc")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_PT_KhoaHoc_KhoaHoc"),
                    l => l.HasOne<Pt>().WithMany()
                        .HasForeignKey("MaPt")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_PT_KhoaHoc_PT"),
                    j =>
                    {
                        j.HasKey("MaPt", "MaKhoaHoc").HasName("pk_PT_KhoaHoc");
                        j.ToTable("PT_KhoaHoc");
                        j.IndexerProperty<string>("MaPt")
                            .HasMaxLength(20)
                            .HasColumnName("MaPT");
                        j.IndexerProperty<string>("MaKhoaHoc").HasMaxLength(20);
                    });
        });

        modelBuilder.Entity<TrinhDo>(entity =>
        {
            entity.HasKey(e => e.MaTrinhDo).HasName("pk_TrinhDo_MaTrinhDo");

            entity.ToTable("TrinhDo");

            entity.Property(e => e.MaTrinhDo).HasMaxLength(20);
            entity.Property(e => e.TenTrinhDo).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
