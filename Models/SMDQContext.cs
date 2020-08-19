using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ERPSysterm.Models
{
    public partial class SMDQContext : DbContext
    {
        public SMDQContext()
        {
        }

        public SMDQContext(DbContextOptions<SMDQContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Breakdown> Breakdown { get; set; }
        public virtual DbSet<Cash> Cash { get; set; }
        public virtual DbSet<Colour> Colour { get; set; }
        public virtual DbSet<Cust> Cust { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Personnel> Personnel { get; set; }
        public virtual DbSet<Puser> Puser { get; set; }
        public virtual DbSet<RepairOrder> RepairOrder { get; set; }
        public virtual DbSet<Sale> Sale { get; set; }
        public virtual DbSet<SaleComponent> SaleComponent { get; set; }
        public virtual DbSet<Storehouse> Storehouse { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Sw> Sw { get; set; }
        public virtual DbSet<Swnr> Swnr { get; set; }
        public virtual DbSet<Wxnr> Wxnr { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=218.106.157.204,8094;Database=SMDQ;uid=sa; pwd=123456 ;Trusted_Connection=True;Integrated Security=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("brand");

                entity.Property(e => e.Brandid).HasColumnName("brandid");

                entity.Property(e => e.Brandcount).HasColumnName("brandcount");

                entity.Property(e => e.Brandname)
                    .HasColumnName("brandname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Breakdown>(entity =>
            {
                entity.HasKey(e => e.Brid)
                    .HasName("PK__breakdow__52E7803CC6473D21");

                entity.ToTable("breakdown");

                entity.Property(e => e.Brid).HasColumnName("brid");

                entity.Property(e => e.Brname)
                    .HasColumnName("brname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Brnamecount).HasColumnName("brnamecount");
            });

            modelBuilder.Entity<Cash>(entity =>
            {
                entity.HasKey(e => e.Num)
                    .HasName("PK__cash__DF908D6521159FC1");

                entity.ToTable("cash");

                entity.Property(e => e.Num).HasColumnName("num");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Mtime)
                    .HasColumnName("mtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mtype).HasColumnName("mtype");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Payment).HasColumnName("payment");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("colour");

                entity.Property(e => e.Colourid).HasColumnName("colourid");

                entity.Property(e => e.Colourcount).HasColumnName("colourcount");

                entity.Property(e => e.Colourname)
                    .HasColumnName("colourname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Cust>(entity =>
            {
                entity.ToTable("cust");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Custadr)
                    .HasColumnName("custadr")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Custamount).HasColumnName("custamount");

                entity.Property(e => e.Custlv).HasColumnName("custlv");

                entity.Property(e => e.Custname)
                    .HasColumnName("custname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Custrem)
                    .HasColumnName("custrem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Custtel)
                    .HasColumnName("custtel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Custtype).HasColumnName("custtype");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.Property(e => e.Itemid).HasColumnName("itemid");

                entity.Property(e => e.Itemcount).HasColumnName("itemcount");

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Personnel>(entity =>
            {
                entity.HasKey(e => e.Perid)
                    .HasName("PK__personne__DC45363DC6FE0FED");

                entity.ToTable("personnel");

                entity.Property(e => e.Perid).HasColumnName("perid");

                entity.Property(e => e.Adr)
                    .HasColumnName("adr")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Entrytime)
                    .HasColumnName("entrytime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flag).HasColumnName("flag");

                entity.Property(e => e.Perlv).HasColumnName("perlv");

                entity.Property(e => e.Pername)
                    .HasColumnName("pername")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Perphoto)
                    .HasColumnName("perphoto")
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pertel)
                    .HasColumnName("pertel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Puser>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__puser__F3DBC573B1F50B63");

                entity.ToTable("puser");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Perid)
                    .HasColumnName("perid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Rem).HasColumnName("rem");
            });

            modelBuilder.Entity<RepairOrder>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("repair_order");

                entity.Property(e => e.Brand)
                    .HasColumnName("brand")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Colour)
                    .HasColumnName("colour")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Fault)
                    .HasColumnName("fault")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Itemname)
                    .HasColumnName("itemname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.OEndtime)
                    .HasColumnName("O_endtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.OFinishTime)
                    .HasColumnName("O_finish_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.OId)
                    .HasColumnName("O_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OPrice).HasColumnName("o_price");

                entity.Property(e => e.OStartTime)
                    .HasColumnName("O_start_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Okey)
                    .HasColumnName("okey")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Perid).HasColumnName("perid");

                entity.Property(e => e.Perid2).HasColumnName("perid2");

                entity.Property(e => e.Pwd)
                    .HasColumnName("pwd")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Rem)
                    .HasColumnName("rem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Zcb).HasColumnName("zcb");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sale");

                entity.Property(e => e.Custid).HasColumnName("custid");

                entity.Property(e => e.Kt)
                    .HasColumnName("kt")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Payment).HasColumnName("payment");

                entity.Property(e => e.Perid).HasColumnName("perid");

                entity.Property(e => e.Rem)
                    .HasColumnName("rem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.SaleTime)
                    .HasColumnName("sale_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Saleid)
                    .HasColumnName("saleid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Swid).HasColumnName("swid");

                entity.Property(e => e.Total).HasColumnName("total");
            });

            modelBuilder.Entity<SaleComponent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sale_component");

                entity.Property(e => e.Cbprice).HasColumnName("cbprice");

                entity.Property(e => e.Compnent).HasColumnName("compnent");

                entity.Property(e => e.Comtype).HasColumnName("comtype");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rem)
                    .HasColumnName("rem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Saleid).HasColumnName("saleid");

                entity.Property(e => e.Sellcount).HasColumnName("sellcount");

                entity.Property(e => e.Swid).HasColumnName("swid");
            });

            modelBuilder.Entity<Storehouse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("storehouse");

                entity.Property(e => e.Barcode)
                    .HasColumnName("barcode")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comcost)
                    .HasColumnName("comcost")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Comcount).HasColumnName("comcount");

                entity.Property(e => e.Comname)
                    .HasColumnName("comname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Component)
                    .HasColumnName("component")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Comprice).HasColumnName("comprice");

                entity.Property(e => e.Comrem)
                    .HasColumnName("comrem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("supplier");

                entity.Property(e => e.Supadr)
                    .HasColumnName("supadr")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Supamount).HasColumnName("supamount");

                entity.Property(e => e.Supid)
                    .HasColumnName("supid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Supname)
                    .HasColumnName("supname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Suprem)
                    .HasColumnName("suprem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Suptel)
                    .HasColumnName("suptel")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sw>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sw");

                entity.Property(e => e.Supid).HasColumnName("supid");

                entity.Property(e => e.Swid)
                    .HasColumnName("swid")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Swkey)
                    .HasColumnName("swkey")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Swtime)
                    .HasColumnName("swtime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Swtotal).HasColumnName("swtotal");
            });

            modelBuilder.Entity<Swnr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("swnr");

                entity.Property(e => e.Component).HasColumnName("component");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Nrtotal).HasColumnName("nrtotal");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rem)
                    .HasColumnName("rem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sprice).HasColumnName("sprice");

                entity.Property(e => e.Swid).HasColumnName("swid");
            });

            modelBuilder.Entity<Wxnr>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("wxnr");

                entity.Property(e => e.Comname)
                    .HasColumnName("comname")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Component).HasColumnName("component");

                entity.Property(e => e.Mtype).HasColumnName("mtype");

                entity.Property(e => e.Num)
                    .HasColumnName("num")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Rem)
                    .HasColumnName("rem")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sprice).HasColumnName("sprice");

                entity.Property(e => e.Usetype).HasColumnName("usetype");

                entity.Property(e => e.Wxid).HasColumnName("wxid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
