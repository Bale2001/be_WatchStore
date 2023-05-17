using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace be_watchStore.DATA;

public partial class WatchShopContext : DbContext
{
    public WatchShopContext()
    {
    }

    public WatchShopContext(DbContextOptions<WatchShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Original> Originals { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=WatchShop;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.ToTable("admin");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Permission).HasColumnName("permission");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CatId);

            entity.ToTable("category");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CatDescription)
                .HasMaxLength(500)
                .HasColumnName("cat_description");
            entity.Property(e => e.CatMetaTitle)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("cat_meta_title");
            entity.Property(e => e.CatName)
                .HasMaxLength(200)
                .HasColumnName("cat_name");
            entity.Property(e => e.CatStatus).HasColumnName("cat_status");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.ComId);

            entity.ToTable("comment");

            entity.Property(e => e.ComId).HasColumnName("com_id");
            entity.Property(e => e.ComContent)
                .HasMaxLength(1000)
                .HasColumnName("com_content");
            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Pro).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK_comment_product");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_comment_user");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FebId);

            entity.ToTable("feedback");

            entity.Property(e => e.FebId).HasColumnName("feb_id");
            entity.Property(e => e.FebContent)
                .HasMaxLength(1000)
                .HasColumnName("feb_content");
            entity.Property(e => e.FebDate)
                .HasColumnType("datetime")
                .HasColumnName("feb_date");
            entity.Property(e => e.FebReply)
                .HasMaxLength(1000)
                .HasColumnName("feb_reply");
            entity.Property(e => e.FebStatus)
                .HasMaxLength(100)
                .HasColumnName("feb_status");
            entity.Property(e => e.FebTitle)
                .HasMaxLength(100)
                .HasColumnName("feb_title");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_feedback_user");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImgId);

            entity.ToTable("image");

            entity.Property(e => e.ImgId).HasColumnName("img_id");
            entity.Property(e => e.ImgFile)
                .IsUnicode(false)
                .HasColumnName("img_file");
            entity.Property(e => e.ProId).HasColumnName("pro_id");

            entity.HasOne(d => d.Pro).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK_image_product");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrId);

            entity.ToTable("order");

            entity.Property(e => e.OrId).HasColumnName("or_id");
            entity.Property(e => e.OrAddressTo)
                .HasMaxLength(200)
                .HasColumnName("or_address_to");
            entity.Property(e => e.OrCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("or_code");
            entity.Property(e => e.OrDate)
                .HasColumnType("datetime")
                .HasColumnName("or_date");
            entity.Property(e => e.OrPrice).HasColumnName("or_price");
            entity.Property(e => e.OrStatus)
                .HasMaxLength(100)
                .HasColumnName("or_status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_order_user");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.ToTable("order_detail");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrId).HasColumnName("or_id");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Or).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrId)
                .HasConstraintName("FK_order_detail_order1");

            entity.HasOne(d => d.Pro).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProId)
                .HasConstraintName("FK_order_detail_product");
        });

        modelBuilder.Entity<Original>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK_supplier");

            entity.ToTable("original");

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProId);

            entity.ToTable("product");

            entity.Property(e => e.ProId).HasColumnName("pro_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.ProAvatar)
                .IsUnicode(false)
                .HasColumnName("pro_avatar");
            entity.Property(e => e.ProCode)
                .HasMaxLength(1000)
                .HasColumnName("pro_code");
            entity.Property(e => e.ProCreateBy)
                .HasMaxLength(200)
                .HasColumnName("pro_create_by");
            entity.Property(e => e.ProCreateDate)
                .HasColumnType("date")
                .HasColumnName("pro_create_date");
            entity.Property(e => e.ProDescription)
                .HasMaxLength(1000)
                .HasColumnName("pro_description");
            entity.Property(e => e.ProName)
                .HasMaxLength(200)
                .HasColumnName("pro_name");
            entity.Property(e => e.ProPrice).HasColumnName("pro_price");
            entity.Property(e => e.ProQuantity).HasColumnName("pro_quantity");
            entity.Property(e => e.ProSale).HasColumnName("pro_sale");
            entity.Property(e => e.ProStatus).HasColumnName("pro_status");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_product_category");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK_product_supplier");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.ToTable("staff");

            entity.Property(e => e.StaffId).HasColumnName("staff_id");
            entity.Property(e => e.StaffAdress)
                .HasMaxLength(200)
                .HasColumnName("staff_adress");
            entity.Property(e => e.StaffBirthday)
                .HasColumnType("date")
                .HasColumnName("staff_birthday");
            entity.Property(e => e.StaffName)
                .HasMaxLength(200)
                .HasColumnName("staff_name");
            entity.Property(e => e.StaffPhone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("staff_phone");
            entity.Property(e => e.StaffSex).HasColumnName("staff_sex");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("user");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.About)
                .HasMaxLength(200)
                .HasColumnName("about");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Passworld)
                .HasMaxLength(100)
                .HasColumnName("passworld");
            entity.Property(e => e.Phone).HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
