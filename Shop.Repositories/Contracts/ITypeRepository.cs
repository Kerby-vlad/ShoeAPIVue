﻿using System.Threading.Tasks;
using Shop.Data.Models;
using Shop.Repositories.Basis;
using Type = Shop.Data.Models.Type;

namespace Shop.Repositories.Contracts
{
    public interface ITypeRepository: IBaseRepository<Type>
    {
        Task<Type> GetSameType(Type type);
    }
}