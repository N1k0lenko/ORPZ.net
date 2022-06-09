using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazineArticles
{
    public class Article
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }

        public int AuthorId { get; set; }

        public int MagazineId { get; set; }

        public DateTime ArticleRelease { get; set; }
    }
}
