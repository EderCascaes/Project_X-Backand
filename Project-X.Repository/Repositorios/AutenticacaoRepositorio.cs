using Microsoft.EntityFrameworkCore;
using Project_X.Domain.Dto;
using Project_X.Domain.Entities;
using Project_X.Domain.Entities.Shared;
using Project_X.Domain.Enums;
using Project_X.Domain.Static;
using Project_X.Interface.Repositories;
using Project_X.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Project_X.Domain.Enums.TypeNotificationEnum;

namespace Project_X.Repository.Repositories
{
    public class AutenticacaoRepositorio : BaseRepositorio, IAutenticacaoRepositorio
    {

        public AutenticacaoRepositorio(ApplicationDbContext dbContext) : base(dbContext) { }

        public async Task<UsuarioLogin> CriarUsuarioLogin(UsuarioLogin usuariologin)
        {
           

            DbContext.UsuarioLogin.Add(usuariologin);
            DbContext.SaveChanges();
            usuariologin.Password = String.Empty;

            return usuariologin;
        }

        public async Task<UsuarioLogin> Get(UsuarioLogin dto)
        {

            var usuariologin = DbContext.UsuarioLogin
                        .Include(x => x.Pessoa)
                        .Where(x => x.Email == dto.Email
                        && x.Password == dto.Password)
                        .FirstOrDefault();


            if (usuariologin == null) return null;

      
            if (usuariologin != null)
            {
                usuariologin.Pessoa.Funcao = Funcoes.GetListaFuncoes(
                    DbContext.RolePessoa
                    .Where(x => x.Cpf == usuariologin.Pessoa.Cpf)
                    .Select(y => y.Role).ToArray()
                    );
            }

            return usuariologin;

        }
    }
}
