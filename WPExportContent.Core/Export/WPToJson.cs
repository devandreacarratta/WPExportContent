using System;
using System.Collections.Generic;
using System.Linq;
using WPExportContent.Core.DTO.Output;

namespace WPExportContent.Core.Export
{
    public class WPToJson : BaseWPExportData
    {

        private List<CategoryDTO> _categories = null;

        private List<TagDTO> _tags = null;

        private List<PostDTO> _posts = null;
        public WPToJson():base()
        {

        }

        public void Run(string outFile)
        {
            _categories = FillCategories();
            _tags = FillTags();
            _posts = FillPosts();
        }

        private List<PostDTO> FillPosts()
        {
            List<PostDTO> result = new List<PostDTO>();

            

            return result;
        }

        private List<TagDTO> FillTags()
        {
            List<TagDTO> result = new List<TagDTO>();

            foreach (var item in this.Tags)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.term_id)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                TagDTO tag = new TagDTO()
                {
                    ID = item.term_id,
                    Name = item.name,
                    Slug = item.slug
                };

                result.Add(tag);

            }

            return result;
        }

        private List<CategoryDTO> FillCategories()
        {

            List<CategoryDTO> result = new List<CategoryDTO>();

            foreach (var item in this.Categories)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.term_id)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                CategoryDTO category = new CategoryDTO()
                {
                    ID = item.term_id,
                    Name = item.name,
                    Slug = item.slug
                };

                result.Add(category);

            }

            return result;
        }
    }
}