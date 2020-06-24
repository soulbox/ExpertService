using ExpertService.DAL.Repo.Abstract;
using ExpertService.DAL.Repo.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public class UnitOfWork : IUnitofWork
    {
        public UnitOfWork()
        {
            DosyaRepo = new DosyaRepository();
            UserRepo = new UserRepository();
            ZamanRepo = new ZamanCizelgesiRepository();
            CalismaRepo = new CalismaDonemiRepository();
            TalepRepo = new TalepRepository();
            UcretRepo = new UcretRepository();
        }

        public IDosyaRepository DosyaRepo { get; }
        public IUserRepository UserRepo { get; }

        public IZamanCizelgesi ZamanRepo { get; }

        public ICalismaDonemi CalismaRepo { get; }

        public ITalepRepository TalepRepo { get; }

        public IUcretRepository UcretRepo { get; }

        public int Complete()
        {
           
            return DbManager.DB.SaveChanges();
        }


    }
}
