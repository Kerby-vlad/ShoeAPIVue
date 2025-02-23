﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Models;
using Shop.DataBase;
using Microsoft.EntityFrameworkCore;
using Shop.Repositories.Basis;
using Shop.Repositories.Contracts;
using Type = Shop.Data.Models.Type;

namespace Shop.Repositories.ModelRepositories
{
    internal class BrandTypeRepository: BaseRepository<BrandType>, IBrandTypeRepository
    {
        public BrandTypeRepository(ShopContext context) : base(context)
        {
        }

        public override async Task<BrandType> Add(BrandType entity)
        {
            entity.Brand = await Context.Brands.FindAsync(entity.BrandId);
            if (entity.Brand == null)
            {
                throw new Exception($"Cannot find Brand with id: {entity.BrandId}");
            }
            entity.Type = await Context.Types.FindAsync(entity.TypeId);
            if (entity.Type == null)
            {
                throw new Exception($"Cannot find Type with id: {entity.TypeId}");
            }
            
            var res = await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return res.Entity;
        }

        public override async Task<List<BrandType>> GetAll()
        {
            return await Context.BrandTypes.Include(t=>t.Type).Include(t=>t.Brand).ToListAsync();
        }

        public async Task<List<Type>> GetByBrand(long id)
        {
            var brand = Context.Brands.FirstOrDefault(t => t.Id == id);
            if (brand == null)
            {
                return null;
            }
            var res = new List<Type>();
            var brandTypes = await Context.BrandTypes.Where(bt => bt.Brand.Id == id).Include(t=>t.Type).ToListAsync();
            foreach (var brandType in brandTypes)
            {
                res.Add(await Context.Types.Where(t=>t.Id == brandType.Type.Id).FirstOrDefaultAsync());
            }
            return res;
        }

        public async Task<List<Brand>> GetByType(long typeId)
        {
            var type = Context.Types.FirstOrDefault(t => t.Id == typeId);
            if (type == null)
            {
                return null;
            }
            var res = new List<Brand>();
            var brandTypes = await Context.BrandTypes.Where(bt => bt.Type.Id == typeId).Include(t=>t.Brand).ToListAsync();
            foreach (var brandType in brandTypes)
            {
                res.Add(await Context.Brands.Where(t=>t.Id == brandType.Brand.Id).FirstOrDefaultAsync());
            }
            return res;
        }

        public override async Task<BrandType> GetById(long id)
        {
            return await Context.BrandTypes.Include(s=>s.Brand).Include(s=>s.Type).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<BrandType> GetByBrandAndType(long brandId, long typeId)
        {
            return await Context.BrandTypes.FirstOrDefaultAsync(bt => bt.BrandId == brandId && bt.TypeId == typeId);
        }
    }
}