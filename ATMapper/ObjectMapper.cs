﻿using AutoMapper;

namespace ATMapper
{
    public static class ObjectMapper
    {
      
            private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
            {
                var config = new MapperConfiguration(cfg => {
                    // This line ensures that internal properties are also mapped over.
                    cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                    cfg.AddProfile<MappingProfile>();
                });
                var mapper = config.CreateMapper();
                return mapper;
            });

            public static IMapper Mapper => Lazy.Value;
    }
}
