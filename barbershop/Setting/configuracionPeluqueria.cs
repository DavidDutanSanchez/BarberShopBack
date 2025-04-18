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
            _ = builder.ToTable("cri_animal_cab");
            //_ = builder.HasIndex(e => e._Galpon, "_CRI_ANIMAL_GALPON");
            //_ = builder.HasIndex(e => e.Nombre, "Nombre");
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
            /*_ = builder.HasOne(x => x.Galpon)
                .WithMany(x => x.Cabeceras)
                .HasForeignKey(x => x._Galpon)
                .OnDelete(DeleteBehavior.Restrict);
            _ = builder.HasOne(x => x.Empleados)
                .WithOne(x => x.CriAnimalCab)
                .HasPrincipalKey<CriAnimalCab>(x => x.Encargado)
                .HasForeignKey<Empleado>(x => x.CodigoEmpleado);
            _ = builder.HasOne(x => x.table_standar_Cab)
                .WithMany(x => x.cri_animal_cabs)
                .HasForeignKey(x => x._Table_Standard_Cab)
                .OnDelete(DeleteBehavior.Restrict);
            _ = builder.HasOne(x => x.table_standar_Cab_hembra)
               .WithMany(x => x.cri_animal_cabs_hembra)
               .HasForeignKey(x => x._Table_Standard_Cab_hembra)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);*/
        }
    }
}