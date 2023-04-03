using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BTL_ClothesStore.Models.Entities
{
    public partial class BTL_ClothesStoreContext : DbContext
    {
        public BTL_ClothesStoreContext()
        {
        }

        public BTL_ClothesStoreContext(DbContextOptions<BTL_ClothesStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Availability> Availabilities { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ADMIN\\SQLEXPRESS;Initial Catalog=BTL_ClothesStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Availability>(entity =>
            {
                entity.ToTable("Availability");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");

                //entity.Property(e => e.InStock).HasColumnName("inStock");

                //entity.Property(e => e.OutOfStock).HasColumnName("outOfStock");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.ToTable("Cart_Item");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quanlity).HasColumnName("quanlity");

                entity.Property(e => e.ShoppingCartId).HasColumnName("shopping_cart_id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Item__produ__44FF419A");

                entity.HasOne(d => d.ShoppingCart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ShoppingCartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart_Item__shopp__45F365D3");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("Order_details");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");

                entity.Property(e => e.OrderStatusId).HasColumnName("order_status_id");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_det__order__4222D4EF");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("Order_Items");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Quanlity).HasColumnName("quanlity");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__order__49C3F6B7");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order_Ite__produ__48CFD27E");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AvaliablityId).HasColumnName("avaliablity_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Avaliablity)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AvaliablityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__avaliab__3F466844");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__categor__3E52440B");
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("shopping_cart");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CreatedAt).HasColumnName("created_at");

                entity.Property(e => e.ModifiedAt).HasColumnName("modified_at");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
