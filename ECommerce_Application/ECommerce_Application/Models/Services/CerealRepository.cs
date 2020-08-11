using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce_Application.Models.Services
{
    public class CerealRepository : ICereal
    {

        public CerealDTO CreateCereal(CerealDTO cerealDTO)
        {
            List<string> newList = new List<string>();


            newList.Add(cerealDTO.Name);
            newList.Add(cerealDTO.Manufacturer);
            newList.Add(cerealDTO.Type);
            newList.Add(cerealDTO.Calories.ToString());
            newList.Add(cerealDTO.Protein.ToString());
            newList.Add(cerealDTO.Fat.ToString());
            newList.Add(cerealDTO.Sodium.ToString());
            newList.Add(cerealDTO.Fiber.ToString());
            newList.Add(cerealDTO.Carbohydrates.ToString());
            newList.Add(cerealDTO.Sugar.ToString());
            newList.Add(cerealDTO.Potassium.ToString());
            newList.Add(cerealDTO.Vitamins.ToString());
            newList.Add(cerealDTO.Shelf.ToString());
            newList.Add(cerealDTO.Weight.ToString());
            newList.Add(cerealDTO.Cups.ToString());
            newList.Add(cerealDTO.Rating.ToString());


            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
            File.AppendAllLines(path, newList);
            return cerealDTO;
        }

        public List<CerealDTO> GetAllCereal()
        {
            throw new NotImplementedException();

        }

        public CerealDTO GetCereal()
        {
            throw new NotImplementedException();
        }
    }
}
