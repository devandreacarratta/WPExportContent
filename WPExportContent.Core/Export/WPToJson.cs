﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class WPToJson : BaseWPExportData
    {
        public WPToJson(WPExportDTO export) : base(export)
        {

        }

        public void Run(string outFile)
        {
            WPExportResult export = new WPExportResult()
            {
                Categories = FillCategories(),
                Tags = FillTags(),
                Posts = FillPosts(),
                Users = FillUsers(),
                Products = FillProducts(),
            };


            string json = Newtonsoft.Json.JsonConvert.SerializeObject(export, Newtonsoft.Json.Formatting.Indented);
            File.Delete(outFile);
            File.WriteAllText(outFile, json);

            outFile = outFile.Replace(".json", ".min.json");
            json = Newtonsoft.Json.JsonConvert.SerializeObject(export, Newtonsoft.Json.Formatting.None);
            File.Delete(outFile);
            File.WriteAllText(outFile, json);
        }

        private IEnumerable<UserDTO> FillUsers()
        {
            List<UserDTO> result = new List<UserDTO>();

            foreach (var item in this._export.WPUsers)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.ID)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                UserDTO user = this.MapperUser.Map<WPUserDTO, UserDTO>(item);

                result.Add(user);
            }

            return result
                .OrderBy(x => x.UserName)
                .Select(x => x);
        }

        private IEnumerable<PostDTO> FillPosts()
        {
            List<PostDTO> result = new List<PostDTO>();

            foreach (var item in this._export.WPPosts)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.ID)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                PostDTO p = this.MapperPost.Map<WPPostDTO, PostDTO>(item);

                p.Tags = this._export.WPTags
                    .Where(x => x.object_id == p.ID)
                    .Select(x => x.term_id)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                p.Categories = this._export.WPCategories
                            .Where(x => x.object_id == p.ID)
                            .Select(x => x.term_id)
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();


                result.Add(p);
            }

            return result
                .OrderBy(x => x.PostTitle)
                .Select(x => x);
        }

        private IEnumerable<ProductDTO> FillProducts()
        {
            List<ProductDTO> result = new List<ProductDTO>();

            if (this._export.WPProducts != null)
            {

                foreach (var item in this._export.WPProducts)
                {
                    bool skipItem = result
                        .Where(x => x.ID == item.ID)
                        .Any();

                    if (skipItem)
                    {
                        continue;
                    }

                    ProductDTO p = this.MapperProduct.Map<WPProductDTO, ProductDTO>(item);

                    p.Tags = this._export.WPTags
                        .Where(x => x.object_id == p.ID)
                        .Select(x => x.term_id)
                        .Distinct()
                        .OrderBy(x => x)
                        .ToList();

                    p.Categories = this._export.WPCategories
                                .Where(x => x.object_id == p.ID)
                                .Select(x => x.term_id)
                                .Distinct()
                                .OrderBy(x => x)
                                .ToList();

                    result.Add(p);
                }

            }

            return result
                .OrderBy(x => x.PostTitle)
                .Select(x => x);
        }

        private IEnumerable<TagDTO> FillTags()
        {
            List<TagDTO> result = new List<TagDTO>();

            foreach (var item in this._export.WPTags)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.term_id)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                TagDTO tag = this.MapperTag.Map<WPTagDTO, TagDTO>(item);

                result.Add(tag);
            }

            return result
                .OrderBy(x => x.Name)
                .Select(x => x);
        }

        private IEnumerable<CategoryDTO> FillCategories()
        {
            List<CategoryDTO> result = new List<CategoryDTO>();

            foreach (var item in this._export.WPCategories)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.term_id)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                CategoryDTO category = this.MapperCategory.Map<WPCategoryDTO, CategoryDTO>(item);

                result.Add(category);

            }

            return result
                .OrderBy(x => x.Name)
                .Select(x => x);
        }
    }
}