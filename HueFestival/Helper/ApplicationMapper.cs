using System;
using AutoMapper;
using HueFestival.Models;
using HueFestival.ViewModel;

namespace HueFestival.Helper
{
	public class ApplicationMapper:Profile
	{
		public ApplicationMapper()
		{
			CreateMap<About, AboutViewModel>().ReverseMap();
            CreateMap<News, NewsViewModel>().ReverseMap();
        }
	}
}

