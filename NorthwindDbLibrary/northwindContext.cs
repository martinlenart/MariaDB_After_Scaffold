using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace NorthwindDbLibrary
{
    public partial class northwindContext : DbContext
    {
        public northwindContext()
        {
        }

        public northwindContext(DbContextOptions<northwindContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeePrivilege> EmployeePrivileges { get; set; }
        public virtual DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public virtual DbSet<InventoryTransactionType> InventoryTransactionTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderDetailsStatus> OrderDetailsStatuses { get; set; }
        public virtual DbSet<OrdersStatus> OrdersStatuses { get; set; }
        public virtual DbSet<OrdersTaxStatus> OrdersTaxStatuses { get; set; }
        public virtual DbSet<Privilege> Privileges { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrderStatus> PurchaseOrderStatuses { get; set; }
        public virtual DbSet<SalesReport> SalesReports { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<String> Strings { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;uid=martin;pwd=seidoab;database=northwind", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<EmployeePrivilege>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.PrivilegeId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_employees1");

                entity.HasOne(d => d.Privilege)
                    .WithMany(p => p.EmployeePrivileges)
                    .HasForeignKey(d => d.PrivilegeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_employee_privileges_privileges1");
            });

            modelBuilder.Entity<InventoryTransaction>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.HasOne(d => d.CustomerOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("fk_inventory_transactions_orders1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_products1");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .HasConstraintName("fk_inventory_transactions_purchase_orders1");

                entity.HasOne(d => d.TransactionTypeNavigation)
                    .WithMany(p => p.InventoryTransactions)
                    .HasForeignKey(d => d.TransactionType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_transactions_inventory_transaction_types1");
            });

            modelBuilder.Entity<InventoryTransactionType>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.AmountDue)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Shipping)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.Tax)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_invoices_orders1");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ShippingFee)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.StatusId).HasDefaultValueSql("'0'");

                entity.Property(e => e.TaxRate).HasDefaultValueSql("'0'");

                entity.Property(e => e.Taxes)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("fk_orders_customers");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("fk_orders_employees1");

                entity.HasOne(d => d.Shipper)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ShipperId)
                    .HasConstraintName("fk_orders_shippers1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_orders_orders_status1");

                entity.HasOne(d => d.TaxStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TaxStatusId)
                    .HasConstraintName("fk_orders_orders_tax_status1");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Quantity).HasPrecision(18, 4);

                entity.Property(e => e.UnitPrice)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_order_details_orders1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_order_details_products1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_order_details_order_details_status1");
            });

            modelBuilder.Entity<OrderDetailsStatus>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrdersStatus>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrdersTaxStatus>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Privilege>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.ListPrice).HasPrecision(19, 4);

                entity.Property(e => e.StandardCost)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.PaymentAmount)
                    .HasPrecision(19, 4)
                    .HasDefaultValueSql("'0.0000'");

                entity.Property(e => e.ShippingFee).HasPrecision(19, 4);

                entity.Property(e => e.StatusId).HasDefaultValueSql("'0'");

                entity.Property(e => e.Taxes).HasPrecision(19, 4);

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("fk_purchase_orders_employees1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_purchase_orders_purchase_order_status1");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.PurchaseOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("fk_purchase_orders_suppliers1");
            });

            modelBuilder.Entity<PurchaseOrderDetail>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Quantity).HasPrecision(18, 4);

                entity.Property(e => e.UnitCost).HasPrecision(19, 4);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.InventoryId)
                    .HasConstraintName("fk_purchase_order_details_inventory_transactions1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_purchase_order_details_products1");

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_purchase_order_details_purchase_orders1");
            });

            modelBuilder.Entity<PurchaseOrderStatus>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");

                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<SalesReport>(entity =>
            {
                entity.HasKey(e => e.GroupBy)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<String>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasCharSet("utf8mb3")
                    .UseCollation("utf8mb3_general_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
