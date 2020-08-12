using ECommerce_Application.Data;
using ECommerce_Application.Models;
using ECommerce_Application.Models.DTO;
using ECommerce_Application.Models.Services;
using ECommerce_Application.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;
using static ECommerce_Application.Program;

namespace TestingSprint1
{
    public class UnitTest1
    {
        [Fact]
        public void GetterSetter()
        {
            CerealDTO cerealDTO = new CerealDTO();

            cerealDTO.Name = "Code Fellows Multi Flavored Cups";
            cerealDTO.Manufacturer = "Bryants Blandish Cereal";

            Assert.Equal("Code Fellows Multi Flavored Cups", cerealDTO.Name);
            Assert.Equal("Bryants Blandish Cereal", cerealDTO.Manufacturer);

        }

        [Fact]
        public void GetterSetter2()
        {
            Product product = new Product();

            product.Name = "Code Fellows Multi Flavored Cups";
            product.Description = "Bryants Blandish Cereal";

            Assert.Equal("Code Fellows Multi Flavored Cups", product.Name);
            Assert.Equal("Bryants Blandish Cereal", product.Description);

        }

    }
}
