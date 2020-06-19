using ExpertService.DAL.Repo.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpertService.DAL
{
    public interface IUnitofWork
    {

        IDosyaRepository DosyaRepo { get; }
        IUserRepository UserRepo { get; }
        IZamanCizelgesi ZamanRepo { get; }
        ICalismaDonemi  CalismaRepo { get; }
        ITalepRepository  TalepRepo { get; }
        IUcretRepository  UcretRepo { get; }



        int Complete();

    }
}
