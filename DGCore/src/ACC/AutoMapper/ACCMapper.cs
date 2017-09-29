using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACC.AutoMapper
{
    public static class ACCMapper
    {
        public static object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, destination, sourceType, destinationType);
        }
        public static TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }
        public static TDestination Map<TDestination>(object source)
        {
            return Mapper.Map<TDestination>(source);
        }
        public static TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }
        public static object Map(object source, Type sourceType, Type destinationType)
        {
            return Mapper.Map(source, sourceType, destinationType);
        }

        public static TDestination MapTo<TSource, TDestination>(this TSource source)
        {
            Mapper.Initialize(p => p.CreateMap<TSource, TDestination>());
            return Mapper.Map<TDestination>(source);
        }
    }
}
