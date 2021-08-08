using AutoMapper;
using Spotter.Models;
using Spotter.ViewModels;

namespace Spotter
{
    public class SpotterMappingProfile : Profile
    {
        public SpotterMappingProfile()
        {
            CreateMap<Plane, PlaneViewModel>();
            CreateMap<PlaneViewModel, Plane>();
        }
    }
}