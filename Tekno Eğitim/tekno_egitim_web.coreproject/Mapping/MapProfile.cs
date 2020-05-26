using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tekno_egitim_web.core.Model;
using tekno_egitim_web.coreproject.Data_Transfer_Objects;

namespace tekno_egitim_web.coreproject.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Kategoriler, KategoriDto>();
            CreateMap<KategoriDto, Kategoriler>();

            CreateMap<Kategoriler, KategoriWithBlogDto>();
            CreateMap<KategoriWithBlogDto, Kategoriler>();

            CreateMap<Kategoriler, KategoriWithHaberDto>();
            CreateMap<KategoriWithHaberDto, Kategoriler>();

            CreateMap<Kategoriler, KategoriWithMakaleDto>();
            CreateMap<KategoriWithMakaleDto, Kategoriler>();

            CreateMap<Kategoriler, KategoriWithNotDto>();
            CreateMap<KategoriWithNotDto, Kategoriler>();

            CreateMap<Kategoriler, KategoriWithVideoDto>();
            CreateMap<KategoriWithVideoDto, Kategoriler>();

            CreateMap<Blog, BlogDto>();
            CreateMap<BlogDto, Blog>();

            CreateMap<Haber, HaberDto>();
            CreateMap<HaberDto, Haber>();

            CreateMap<Makale, MakaleDto>();
            CreateMap<MakaleDto, Makale>();

            CreateMap<Not, NotDto>();
            CreateMap<NotDto, Not>();

            CreateMap<Video, VideoDto>();
            CreateMap<VideoDto, Video>();

            CreateMap<Blog, BlogWithKategoriDto>();
            CreateMap<BlogWithKategoriDto, Blog>();

            CreateMap<Haber, HaberWithKategoriDto>();
            CreateMap<HaberWithKategoriDto, Haber>();

            CreateMap<Makale, MakaleWithKategoriDto>();
            CreateMap<MakaleWithKategoriDto, Makale>();

            CreateMap<Not, NotWithKategoriDto>();
            CreateMap<NotWithKategoriDto, Not>();

            CreateMap<Video, VideoWithKategoriDto>();
            CreateMap<VideoWithKategoriDto, Video>();
        }
    }
}
