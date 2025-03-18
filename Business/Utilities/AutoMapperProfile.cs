using AutoMapper;
using Business.DTOs.ProductsDTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Utilities
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile() 
		{
			CreateMap<Product, ProductDTO>();
			CreateMap<ProductCreationDTO, Product>();
		}
	}
}
