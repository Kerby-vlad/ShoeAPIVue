﻿using System.Collections.Generic;
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
    internal class BrandRepository: BaseRepository<Brand>, IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {
        }

        public override async Task<List<Brand>> GetAll()
        {
            var res = await Context.Brands.Include(e=>e.Goods).ToListAsync();
            List<BrandType> brandTypes = await Context.BrandTypes.Include(e => e.Brand).Include(e=>e.Type).ToListAsync();
            foreach (var brand in res)
            {
                foreach (var brandGood in brand.Goods)
                {
                    brandGood.Type.Goods = null;
                }
                List<Type> types = new List<Type>();
                foreach (var bt in brandTypes)
                {
                    if (bt.BrandId == brand.Id)
                    {
                        types.Add(bt.Type);
                    }
                }
                brand.Types = types;

            }
            return res;
        }

        public override async Task<Brand> GetById(long id)
        {
            var res = await Context.Brands.Include(e => e.Goods).FirstOrDefaultAsync(b=>b.Id==id);
            if (res == null)
            {
                return res;
            }
            List<BrandType> brandTypes = await Context.BrandTypes.Where(bt=>bt.BrandId==id).Include(e => e.Brand).Include(e=>e.Type).ToListAsync();
            foreach (var brandGood in res.Goods)
            {
                brandGood.Type.Goods = null;
            }
            List<Type> types = new List<Type>();
            foreach (var bt in brandTypes)
            {
                if (bt.BrandId == res.Id)
                {
                    types.Add(bt.Type);
                }
            }
            res.Types = types;
            return res;
        }

        public async Task<Brand> GetByName(string name)
        {
            return await Context.Brands.FirstOrDefaultAsync(b => b.Name == name);
        }
    }
}