using ECommerce_Application.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Interfaces
{
    public interface ICereal
    {
        public List<CerealDTO> GetCereal();
        public List<CerealDTO> GetAllCereal();
    }
}
