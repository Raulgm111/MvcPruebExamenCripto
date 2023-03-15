﻿using MvcPruebExamenCripto.Data;
using MvcPruebExamenCripto.Helpers;
using MvcPruebExamenCripto.Models;

namespace MvcPruebExamenCripto.Repositories
{
    public class RepositoryUsuarios
    {
        private UsuariosContext context;

        public RepositoryUsuarios(UsuariosContext context)
        {
            this.context = context;
        }

        private int GetMaxIdUsuario()
        {
            if (this.context.Usuarios.Count() == 0)
            {
                return 1;
            }
            else
            {
                return this.context.Usuarios.Max(z => z.IdUsario) + 1;
            }
        }

        public async Task RegisterUsuario(string nombre,string email,string password,string imagen)
        {
            Usuario user=new Usuario();
            user.IdUsario=this.GetMaxIdUsuario();
            user.Nombre=nombre;
            user.Email=email;
            user.Imagen=imagen;
            user.Salt = HelperCryptography.GenerateSalt();
            user.Password = HelperCryptography.EncryptPassword(password, user.Salt);
            this.context.Usuarios.Add(user);
            await this.context.SaveChangesAsync();
        }

        public Usuario LoginUser(string email,string password)
        {
            Usuario user=this.context.Usuarios.FirstOrDefault(z=>z.Email==email);
            if (user == null)
            {
                return null;
            }
            else
            {
                byte[] passUsuario = user.Password;
                string salt = user.Salt;
                byte[] temp=HelperCryptography.EncryptPassword(password, salt);
                bool respuesta=HelperCryptography.CompareArrays(passUsuario, temp);
                if (respuesta == true)
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
