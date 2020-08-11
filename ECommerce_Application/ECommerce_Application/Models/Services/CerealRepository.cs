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


        public List<CerealDTO> GetAllCereal()
        {
            throw new NotImplementedException();

        }

        public List<CerealDTO> GetCereal()
        {
            List<CerealDTO> newList = new List<CerealDTO>();
            string path = Environment.CurrentDirectory;
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\cereal.csv"));
            string[] myFile = File.ReadAllLines(newPath);

            for (int i = 1; i < myFile.Length; i++)
            {
                string[] fields = myFile[i].Split(',');
                newList.Add(new CerealDTO
                {
                    Name = fields[0],
                    Manufacturer = fields[1],
                    Calories = fields[2],
                    Protein = fields[3],
                    Fat = fields[4],
                    Sodium = fields[5],
                    Fiber = fields[6],
                    Carbohydrates = fields[7],
                    Sugar = fields[8],
                    Potassium = fields[9],
                    Vitamins = fields[10],
                    Shelf = fields[11],
                    Weight = fields[12],
                    Cups = fields[13],
                    Rating = fields[14]
                });
            }

            return newList;
        }

  
    }
}

