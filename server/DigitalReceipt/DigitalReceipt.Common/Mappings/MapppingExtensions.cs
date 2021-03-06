﻿using System;
using System.Linq;
using System.Linq.Expressions;

using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace DigitalReceipt.Common.Mappings
{
    public static class MappingExtensions
    {
        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo(AutoMapperConfig.MapperInstance.ConfigurationProvider, null, membersToExpand);
        }

        public static IQueryable<TDestination> To<TDestination>(
            this IQueryable source,
            object parameters)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.ProjectTo<TDestination>(AutoMapperConfig.MapperInstance.ConfigurationProvider, parameters);
        }

        public static Destination To<Destination>(this object source) => AutoMapperConfig.MapperInstance.Map<Destination>(source);

        public static Destination To<Destination>(this object source, object destination) =>
            (Destination)AutoMapperConfig.MapperInstance.Map(source, destination, source.GetType(), destination.GetType());

        public static Destination To<Source, Destination>(this Source source, Destination destination, Action<IMappingOperationOptions<Source, Destination>> options) =>
           AutoMapperConfig.MapperInstance.Map(source, destination, options);
    }
}
