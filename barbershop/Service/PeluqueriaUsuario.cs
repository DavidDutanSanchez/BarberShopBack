using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;
using Microsoft.EntityFrameworkCore;


namespace barbershop.Service
{
    public class PeluqueriaServiceUsuario : IControladorUsuario
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaServiceUsuario(PeluqueriaContext context)
        {
            _context = context;

        }
        public async Task<string> AddUsuarios(Usuarios Usuarios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Add(Usuarios);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }
        public async Task<PaginationDto<Usuarios>> AllUsuarios(QueryParams qParams)
        {
            try
            {
                var servicios = await _context.Usuarios

                .Select(x => new Usuarios
                {
                    IdUsuarios = x.IdUsuarios,
                    Usuario = x.Usuario,
                    ContraseniaUsuarios = x.ContraseniaUsuarios,
                    permisosUsuarios = x.permisosUsuarios,
                    _persona_id = x._persona_id,
                    // persona = (x.persona.ApellidosPersona ?? "") + " " + (x.persona.NombresPersona?? "")
                     PersonaNombreCompleto = x.persona != null
        ? (x.persona.ApellidosPersona + " " + x.persona.NombresPersona)
        : string.Empty


                })
                .OrderBy(c => c.Usuario)

                .GetPagedAsync(qParams);
                return servicios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }
        
 public async Task<Usuarios?> LoginUsuarioAsync(string usuario, string contrasenia)
{
    try
    {
        var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario);
        if (user == null) return null;

        string contraseniaGuardada = System.Text.Encoding.UTF8.GetString(user.ContraseniaUsuarios);

        if (contraseniaGuardada.Trim() == contrasenia.Trim())
        {
            return user;
        }

        return null;
    }
    catch (Exception ex)
    {
        throw new Exception("Error al autenticar usuario: " + ex.Message);
    }
}


        public async Task<string> DeleteUsuarios(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Remove(_context.Usuarios.Where(x => x.IdUsuarios == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
            return response;
        }
        public async Task<string> UpdateUsuarios(Usuarios Usuarios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Update(Usuarios);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }


    }
}