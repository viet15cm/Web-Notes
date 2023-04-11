﻿namespace Contracts
{
    public interface IRepositoryWrapper
    {
        ICategoryRepository Category { get; }

        IPostRepository Post { get; }

        IPostCategoryRepository PostCategory {get;}

        IUnitOfWork UnitOfWork { get; }
    }
}