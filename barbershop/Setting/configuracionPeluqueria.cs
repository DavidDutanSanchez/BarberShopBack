using barbershop.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace barbershop.Setting
{
    public class ClientConfiguration : IEntityTypeConfiguration<Personas>
    {
        public void Configure(EntityTypeBuilder<Personas> builder)
        {
            _ = builder.HasKey(e => e.IdPersona);
            _ = builder.ToTable("personas");
            _ = builder.HasIndex(e => e.CedulaPersona, "cedulaPersona");
            _ = builder.HasIndex(e => e.NombresPersona, "NombresPersona");
            _ = builder.HasIndex(e => e.ApellidosPersona, "apellidosPersona");
            _ = builder.HasIndex(e => e.IdPersona, "idPersona");
            _ = builder.Property(e => e.IdPersona)
                .HasMaxLength(36)
                .HasColumnName("idPersona");
            _ = builder.Property(e => e.CedulaPersona)
                .HasMaxLength(13)
                .HasColumnName("cedulaPersona");
            _ = builder.Property(e => e.NombresPersona)
                .HasMaxLength(255)
                .HasColumnName("nombresPersona");
            _ = builder.Property(e => e.ApellidosPersona)
                .HasMaxLength(255)
                .HasColumnName("apellidosPersona");
            _ = builder.Property(e => e.DireccionPersona)
                .HasColumnName("direccionPersona");
            _ = builder.Property(e => e.FechaNacimientoPersona)
                .HasColumnType("datetime")
                .HasColumnName("fechaNacimientoPersona");
            _ = builder.Property(e => e.CelularPersona)
                .HasMaxLength(20)
                .HasColumnName("celularPersona");
            _ = builder.Property(e => e.CorreoPersona)
                .HasMaxLength(255)
                .HasColumnName("correoPersona");
        }
    }
    public class FilesConfiguration : IEntityTypeConfiguration<Files>
    {
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            _ = builder.HasKey(e => e.IdFiles);
            _ = builder.ToTable("files");
            _ = builder.HasIndex(e => e._persona_id, "fk_Files_Personas1_idx");
            _ = builder.Property(e => e.IdFiles)
                .HasMaxLength(36)
                .HasColumnName("idFiles");
            _ = builder.Property(e => e.ExtensionFiles)
                .HasMaxLength(100)
                .HasColumnName("extensionFiles");
            _ = builder.Property(e => e.TamanioFiles)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("tamanioFiles");
            _ = builder.Property(e => e.PathFiles)
                .HasColumnName("pathFiles");
            _ = builder.Property(e => e.NombreArchivoFiles)
                .HasMaxLength(255)
                .HasColumnName("nombreArchivoFiles");
            _ = builder.Property(e => e._persona_id)
                .HasMaxLength(36)
                .HasColumnName("Personas_idPersona");
            _ = builder.HasOne(x => x.persona)
                .WithMany(x => x._archivos)
                .HasForeignKey(x => x._persona_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class ProductosConfiguration : IEntityTypeConfiguration<Productos>
    {
        public void Configure(EntityTypeBuilder<Productos> builder)
        {
            _ = builder.HasKey(e => e.Idproductos);
            _ = builder.ToTable("productos");
            _ = builder.HasIndex(e => e.NombreProducto, "nombreProducto");
            _ = builder.HasIndex(e => e.CodigoProducto, "codigoProducto");
            _ = builder.HasIndex(e => e.Idproductos, "idProducto");
            _ = builder.Property(e => e.Idproductos)
                .HasMaxLength(36)
                .HasColumnName("idproductos");
            _ = builder.Property(e => e.NombreProducto)
                .HasMaxLength(255)
                .HasColumnName("nombreProducto");
            _ = builder.Property(e => e.CostoProducto)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("costoProducto");
            _ = builder.Property(e => e.StockProducto)
                .HasColumnName("stockProducto");
            _ = builder.Property(e => e.IvaProducto)
                .HasColumnType("decimal(7, 4)")
                .HasColumnName("ivaProducto");
            _ = builder.Property(e => e.CodigoProducto)
                .HasMaxLength(255)
                .HasColumnName("codigoProducto");
        }
    }
    public class ServiciosConfiguration : IEntityTypeConfiguration<Servicios>
    {
        public void Configure(EntityTypeBuilder<Servicios> builder)
        {
            _ = builder.HasKey(e => e.IdServicio);
            _ = builder.ToTable("servicios");
            _ = builder.HasIndex(e => e.IdServicio, "PRIMARY");
            _ = builder.HasIndex(e => e.NombreServicio, "nombreServicio");
            _ = builder.Property(e => e.IdServicio)
                .HasMaxLength(36)
                .HasColumnName("idServicio");
            _ = builder.Property(e => e.NombreServicio)
                .HasMaxLength(255)
                .HasColumnName("nombreServicio");
            _ = builder.Property(e => e.CostoServicio)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("costoServicio");
            _ = builder.Property(e => e.ComisionServicio)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("comisionServicio");
        }
    }
    public class TicketsCabeceraConfiguration : IEntityTypeConfiguration<TicketsCabecera>
    {
        public void Configure(EntityTypeBuilder<TicketsCabecera> builder)
        {
            _ = builder.HasKey(e => e.IdTickets);
            _ = builder.ToTable("ticketscabecera");
            _ = builder.HasIndex(e => e.IdTickets, "PRIMARY");
            _ = builder.HasIndex(e => e._usuario_id, "fk_TicketsCabecera_Usuarios1_idx");
            _ = builder.Property(e => e.IdTickets)
                .HasMaxLength(36)
                .HasColumnName("idTickets");
            _ = builder.Property(e => e.FechaTicket)
                .HasColumnType("datetime")
                .HasColumnName("fechaTicket");
            _ = builder.Property(e => e.EstadoTicketCab)
                .HasColumnName("estadoTicketCab");
            _ = builder.Property(e => e.TotalTicketCab)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("totalTicketCab");
            _ = builder.Property(e => e._usuario_id)
                .HasMaxLength(36)
                .HasColumnName("Usuarios_idUsuarios");
            _ = builder.HasOne(x => x.usuario)
                .WithMany(x => x.list_ticket_cabs)
                .HasForeignKey(x => x._usuario_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class TicketsDetalleConfiguration : IEntityTypeConfiguration<TicketsDetalle>
    {
        public void Configure(EntityTypeBuilder<TicketsDetalle> builder)
        {
            _ = builder.HasKey(e => e.IdTicketsDetalle);
            _ = builder.ToTable("ticketsdetalle");
            _ = builder.HasIndex(e => e.IdTicketsDetalle, "PRIMARY");
            _ = builder.HasIndex(e => e._ticket_cabecera, "fk_TicketsDetalle_TicketsCabecera1_idx");
            _ = builder.HasIndex(e => e._servicio_id, "fk_TicketsDetalle_Servicios1_idx");
            _ = builder.HasIndex(e => e._producto_id, "fk_TicketsDetalle_Productos1_idx");
            _ = builder.Property(e => e.IdTicketsDetalle)
                .HasMaxLength(36)
                .HasColumnName("idTicketsDetalle");
            _ = builder.Property(e => e.SubTotalTicketDet)
                .HasColumnType("decimal(18, 6)")
                .HasColumnName("subTotalTicketDet");
            _ = builder.Property(e => e.FechaTicketDet)
                .HasColumnType("datetime")
                .HasColumnName("fechaTicketDet");
            _ = builder.Property(e => e._ticket_cabecera)
                .HasMaxLength(36)
                .HasColumnName("TicketsCabecera_idTickets");
            _ = builder.Property(e => e._servicio_id)
                .HasMaxLength(36)
                .HasColumnName("Servicios_idServicio");
            _ = builder.Property(e => e._producto_id)
                .HasMaxLength(36)
                .HasColumnName("Productos_idProductos");
            _ = builder.HasOne(x => x.ticektCabecera)
                .WithMany(x => x.detalle_tickets)
                .HasForeignKey(x => x._ticket_cabecera)
                .OnDelete(DeleteBehavior.Restrict);
            _ = builder.HasOne(x => x.servicios)
                .WithMany(x => x.detalle_tickets)
                .HasForeignKey(x => x._servicio_id)
                .OnDelete(DeleteBehavior.Restrict);
            _ = builder.HasOne(x => x.productos)
                .WithMany(x => x.detalle_tickets)
                .HasForeignKey(x => x._producto_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
    public class UsuariosConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            _ = builder.HasKey(e => e.IdUsuarios);
            _ = builder.ToTable("usuarios");
            _ = builder.HasIndex(e => e.IdUsuarios, "PRIMARY");
            _ = builder.HasIndex(e => e._persona_id, "fk_Usuarios_Personas_idx");
            _ = builder.HasIndex(e => e.Usuario, "usuario");
            _ = builder.Property(e => e.IdUsuarios)
                .HasMaxLength(36)
                .HasColumnName("idUsuarios");
            _ = builder.Property(e => e.Usuario)
                .HasMaxLength(255)
                .HasColumnName("usuario");
            _ = builder.Property(e => e.ContraseniaUsuarios)
                .HasColumnName("contraseniaUsuarios");
            _ = builder.Property(e => e.permisosUsuarios)
                .HasMaxLength(100)
                .HasColumnName("permisosUsuarios");
            _ = builder.Property(e => e._persona_id)
                .HasMaxLength(36)
                .HasColumnName("Personas_idPersona");
            _ = builder.HasOne(x => x.persona)
                .WithMany(x => x._usuarios)
                .HasForeignKey(x => x._persona_id)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}