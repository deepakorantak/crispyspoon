using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace crispySpoonEF.CrispySpoonDataModel
{
    public partial class CrispySpoonDBContext : DbContext
    {
        public virtual DbSet<Cafeteria> Cafeteria { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Entitlement> Entitlement { get; set; }
        public virtual DbSet<EntitlementMapping> EntitlementMapping { get; set; }
        public virtual DbSet<Facility> Facility { get; set; }
        public virtual DbSet<FacilityCafeteriaMapping> FacilityCafeteriaMapping { get; set; }
        public virtual DbSet<Fooditem> FoodItem { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<UserFavorites> UserFavorites { get; set; }
        public virtual DbSet<UserWishlist> UserWishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=tcp:crispyspoonserver.database.windows.net,1433;Initial Catalog=crispyspoonDB;Persist Security Info=False;User ID=crispyspoon-admin;Password=P@55w0rd-1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cafeteria>(entity =>
            {
                entity.HasKey(e => e.CafeteriaCode);

                entity.ToTable("tbm_cafeteria", "cafeteria");

                entity.HasIndex(e => e.VendorCode)
                    .HasName("fkIdx_201");

                entity.Property(e => e.CafeteriaCode)
                    .HasColumnName("cafeteria_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CafeteriaName)
                    .IsRequired()
                    .HasColumnName("cafeteria_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasColumnName("vendor_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Cafeteria)
                    .HasForeignKey(d => d.VendorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_201");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityCode);

                entity.ToTable("tbm_city", "cafeteria");

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasColumnName("city_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Entitlement>(entity =>
            {
                entity.HasKey(e => e.EntitlementCode);

                entity.ToTable("tbm_entitlement", "cafeteria");

                entity.Property(e => e.EntitlementCode)
                    .HasColumnName("entitlement_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EntitlementDescription)
                    .IsRequired()
                    .HasColumnName("entitlement_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntitlementName)
                    .IsRequired()
                    .HasColumnName("entitlement_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EntitlementMapping>(entity =>
            {
                entity.HasKey(e => new { e.RoleCode, e.EntitlementCode });

                entity.ToTable("tbm_entitlement_mapping", "cafeteria");

                entity.HasIndex(e => e.EntitlementCode)
                    .HasName("fkIdx_141");

                entity.HasIndex(e => e.RoleCode)
                    .HasName("fkIdx_129");

                entity.Property(e => e.RoleCode)
                    .HasColumnName("role_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EntitlementCode)
                    .HasColumnName("entitlement_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Entitlement)
                    .WithMany(p => p.EntitlementMapping)
                    .HasForeignKey(d => d.EntitlementCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_141");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EntitlementMapping)
                    .HasForeignKey(d => d.RoleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_129");
            });

            modelBuilder.Entity<Facility>(entity =>
            {
                entity.HasKey(e => e.FacilityCode);

                entity.ToTable("tbm_facility", "cafeteria");

                entity.HasIndex(e => e.CityCode)
                    .HasName("fkIdx_19");

                entity.Property(e => e.FacilityCode)
                    .HasColumnName("facility_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CityCode)
                    .IsRequired()
                    .HasColumnName("city_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityName)
                    .IsRequired()
                    .HasColumnName("facility_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Facility)
                    .HasForeignKey(d => d.CityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_19");
            });

            modelBuilder.Entity<FacilityCafeteriaMapping>(entity =>
            {
                entity.HasKey(e => new { e.FacilityCode, e.CafeteriaCode });

                entity.ToTable("tbm_facility_cafeteria_mapping", "cafeteria");

                entity.HasIndex(e => e.CafeteriaCode)
                    .HasName("fkIdx_210");

                entity.HasIndex(e => e.FacilityCode)
                    .HasName("fkIdx_205");

                entity.Property(e => e.FacilityCode)
                    .HasColumnName("facility_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CafeteriaCode)
                    .HasColumnName("cafeteria_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cafeteria)
                    .WithMany(p => p.FacilityCafeteriaMapping)
                    .HasForeignKey(d => d.CafeteriaCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_210");

                entity.HasOne(d => d.Facility)
                    .WithMany(p => p.FacilityCafeteriaMapping)
                    .HasForeignKey(d => d.FacilityCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_205");
            });

            modelBuilder.Entity<Fooditem>(entity =>
            {
                entity.HasKey(e => e.ItemCode);

                entity.ToTable("tbm_fooditem", "cafeteria");

                entity.HasIndex(e => e.VendorCode)
                    .HasName("fkIdx_164");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CalorieCount)
                    .HasColumnName("calorie_count")
                    .HasColumnType("numeric(18, 4)");

                entity.Property(e => e.ItemDescription)
                    .IsRequired()
                    .HasColumnName("item_description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemVegNonveg)
                    .IsRequired()
                    .HasColumnName("item_veg_nonveg")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.VendorCode)
                    .IsRequired()
                    .HasColumnName("vendor_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Fooditem)
                    .HasForeignKey(d => d.VendorCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_164");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.ToTable("tbm_role", "cafeteria");

                entity.Property(e => e.RoleCode)
                    .HasColumnName("role_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.RoleDescription)
                    .IsRequired()
                    .HasColumnName("role_description")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("tbm_user", "cafeteria");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CafeteriaCode)
                    .HasColumnName("cafeteria_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CityCode)
                    .HasColumnName("city_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FacilityCode)
                    .HasColumnName("facility_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleCode, e.UserId });

                entity.ToTable("tbm_user_role", "cafeteria");

                entity.HasIndex(e => e.RoleCode)
                    .HasName("fkIdx_153");

                entity.HasIndex(e => e.UserId)
                    .HasName("fkIdx_176");

                entity.Property(e => e.RoleCode)
                    .HasColumnName("role_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_153");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_176");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasKey(e => e.VendorCode);

                entity.ToTable("tbm_vendor", "cafeteria");

                entity.Property(e => e.VendorCode)
                    .HasColumnName("vendor_code")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.VendorName)
                    .IsRequired()
                    .HasColumnName("vendor_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.ToTable("tbt_menu", "cafeteria");

                entity.HasIndex(e => e.CafeteriaCode)
                    .HasName("fkIdx_56");

                entity.HasIndex(e => new { e.MenuDate, e.CafeteriaCode })
                    .HasName("Ind_menu_date_cafe");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.CafeteriaCode)
                    .IsRequired()
                    .HasColumnName("cafeteria_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MealType)
                    .IsRequired()
                    .HasColumnName("meal_type")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MenuDate)
                    .HasColumnName("menu_date")
                    .HasColumnType("date");

                entity.Property(e => e.MenuItemName)
                    .IsRequired()
                    .HasColumnName("menu_item_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cafeteria)
                    .WithMany(p => p.Menu)
                    .HasForeignKey(d => d.CafeteriaCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_56");
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => new { e.ItemCode, e.MenuId });

                entity.ToTable("tbt_menu_item", "cafeteria");

                entity.HasIndex(e => e.ItemCode)
                    .HasName("fkIdx_82");

                entity.HasIndex(e => e.MenuId)
                    .HasName("fkIdx_87");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Fooditem)
                    .WithMany(p => p.MenuItem)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_82");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.MenuItem)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_87");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("tbt_order", "cafeteria");

                entity.HasIndex(e => e.MenuId)
                    .HasName("fkIdx_100");

                entity.Property(e => e.OrderId)
                    .HasColumnName("order_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.MenuId)
                    .HasColumnName("menu_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.OrderDelivered)
                    .HasColumnName("order_delivered")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderPlaced)
                    .HasColumnName("order_placed")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderPrinted)
                    .HasColumnName("order_printed")
                    .HasColumnType("datetime");

                entity.Property(e => e.OrderQrCode)
                    .HasColumnName("order_qr_code")
                    .HasColumnType("image");

                entity.Property(e => e.OrderRating)
                    .HasColumnName("order_rating")
                    .HasColumnType("numeric(2, 1)");

                entity.Property(e => e.OrderStatus)
                    .HasColumnName("order_status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_100");
            });

            modelBuilder.Entity<UserFavorites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ItemCode });

                entity.ToTable("tbt_user_favorites", "cafeteria");

                entity.HasIndex(e => e.ItemCode)
                    .HasName("fkIdx_189");

                entity.HasIndex(e => e.UserId)
                    .HasName("fkIdx_183");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ItemCode)
                    .HasColumnName("item_code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fooditem)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.ItemCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_189");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_183");
            });

            modelBuilder.Entity<UserWishlist>(entity =>
            {
                entity.HasKey(e => e.WishlistId);

                entity.ToTable("tbt_user_wishlist", "cafeteria");

                entity.HasIndex(e => e.UserId)
                    .HasName("fkIdx_193");

                entity.Property(e => e.WishlistId)
                    .HasColumnName("wishlist_id")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .HasColumnName("remarks")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserWishlist)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_193");
            });
        }
    }
}
