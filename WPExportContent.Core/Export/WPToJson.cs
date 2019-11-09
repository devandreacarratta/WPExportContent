using System.Collections.Generic;
using System.Linq;
using WPExportContent.Core.DTO;
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

            foreach (var item in this.Posts)
            {
                bool skipItem = result
                    .Where(x => x.ID == item.ID)
                    .Any();

                if (skipItem)
                {
                    continue;
                }

                PostDTO p = this.MapperPost.Map<WPPostDTO, PostDTO>(item);

                p.Tags = this.Tags
                    .Where(x => x.object_id == p.ID)
                    .Select(x => x.term_id)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                p.Categories = this.Categories
                            .Where(x => x.object_id == p.ID)
                            .Select(x => x.term_id)
                            .Distinct()
                            .OrderBy(x => x)
                            .ToList();


                result.Add(p);
            }

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