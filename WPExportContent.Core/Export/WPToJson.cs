using System;
using System.Collections.Generic;
using System.Linq;
using WPExportContent.Core.DTO;
using WPExportContent.Core.DTO.Output;
using WPExportContent.Core.WordPress;

namespace WPExportContent.Core.Export
{
    public class WPToJson : BaseWPExportData
    {

        public bool ExportSeoWithYoast { get; set; }

        public WPToJson(WPExportDTO export) : base(export)
        {
            ExportSeoWithYoast = false;
        }

        public string CreateJSON(Newtonsoft.Json.Formatting formatting)
        {
            WPExportResult export = new WPExportResult()
            {
                Categories = FillCategories(),
                Tags = FillTags(),
            };

            export.Posts = FillPosts();
            export.Users = FillUsers();
            export.Products = FillProducts();

            export.ContentCategories = FillContentCategories();
            export.ContentTags = FillContentTags();

            if (ExportSeoWithYoast)
            {
                export.SeoMeta = FillSeoMetaWithYoast();
            }

            string result = Newtonsoft.Json.JsonConvert.SerializeObject(export, formatting);
            return result;
        }

        private IEnumerable<SeoDTO> FillSeoMetaWithYoast()
        {
            string[] keys = new string[] { Settings.PostMeta.Yoast.FOCUS_KW, Settings.PostMeta.Yoast.META_DESC };

            var yoast = this._export.WPPostsMeta
                .Where(x => Array.IndexOf(keys, x.meta_key) != -1)
                .Select(x => x)
                .ToList();

            SortedDictionary<int, SeoDTO> dict = new SortedDictionary<int, SeoDTO>();

            foreach (var item in yoast)
            {
                SeoDTO dummy;

                if (dict.TryGetValue(item.post_id, out dummy) == false)
                {
                    SeoDTO seo = new SeoDTO()
                    {
                        PostID = item.post_id
                    };

                    dict.Add(item.post_id, seo);
                }

                switch (item.meta_key)
                {
                    case Settings.PostMeta.Yoast.FOCUS_KW:
                        {
                            dict[item.post_id].FocusKW = item.meta_value;
                            break;
                        }
                    case Settings.PostMeta.Yoast.META_DESC:
                        {
                            dict[item.post_id].MetaDescription = item.meta_value;
                            break;
                        }
                }
            }

            return dict
                .Select(x => x.Value)
                .OrderBy(x => x.PostID);
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

            List<WPPostDTO> items = new List<WPPostDTO>();
            items.AddRange(this._export.WPPosts);
            if (this._export.WPPostChildren != null)
            {
                items.AddRange(this._export.WPPostChildren);
            }

            items = items
                .OrderBy(x => x.post_parent)
                .Select(x => x)
                .ToList();

            foreach (var item in items)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.ID)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                PostDTO p = this.MapperPost.Map<WPPostDTO, PostDTO>(item);

                result.Add(p);
            }

            return result
                .OrderBy(x => x.PostTitle)
                .Select(x => x);
        }

        private IEnumerable<ContentCategoriesDTO> FillContentCategories()
        {
            List<ContentCategoriesDTO> result = new List<ContentCategoriesDTO>();

            List<long> ids = this._export.WPPosts.Select(x => x.ID).ToList();
            ids.AddRange(this._export.WPProducts.Select(x => x.ID));

            foreach (var id in ids)
            {
                var categories = this._export.WPCategories
                                                     .Where(x => x.object_id == id)
                                                     .Select(x => x.term_id)
                                                     .Distinct()
                                                     .OrderBy(x => x)
                                                     .ToArray();

                foreach (var item in categories)
                {
                    result.Add(
                        new ContentCategoriesDTO()
                        {
                            IDContent = id,
                            IDCategory = item,
                        }
                    );
                }
            }

          

            return result
                .OrderBy(x => x.IDContent)
                .ThenBy(x => x.IDCategory)
                .Select(x => x);
        }

        private IEnumerable<ContentTagsDTO> FillContentTags()
        {
            List<ContentTagsDTO> result = new List<ContentTagsDTO>();

            List<long> ids = this._export.WPPosts.Select(x => x.ID).ToList();
            ids.AddRange(this._export.WPProducts.Select(x => x.ID));

            foreach (var id in ids)
            {
                var categories = this._export.WPTags
                                                     .Where(x => x.object_id == id)
                                                     .Select(x => x.term_id)
                                                     .Distinct()
                                                     .OrderBy(x => x)
                                                     .ToArray();

                foreach (var item in categories)
                {
                    result.Add(
                        new ContentTagsDTO()
                        {
                            IDContent = id,
                            IDTag = item,
                        }
                    ); 
                }
            }

            return result
                .OrderBy(x => x.IDContent)
                .ThenBy(x => x.IDTag)
                .Select(x => x);
        }


        private IEnumerable<ProductDTO> FillProducts()
        {
            List<ProductDTO> result = new List<ProductDTO>();

            if (this._export.WPProducts != null)
            {

                List<WPProductDTO> items = new List<WPProductDTO>();
                items.AddRange(this._export.WPProducts);
                if (this._export.WPProductChildren != null)
                {
                    items.AddRange(this._export.WPProductChildren);
                }

                items = items
                    .OrderBy(x => x.post_parent)
                    .Select(x => x)
                    .ToList();


                foreach (var item in items)
                {
                    bool skipItem = result
                        .Where(x => x.ID == item.ID)
                        .Any();

                    if (skipItem)
                    {
                        continue;
                    }

                    ProductDTO p = this.MapperProduct.Map<WPProductDTO, ProductDTO>(item);

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