using System;
using System.Collections.Generic;
using System.Linq;
namespace MagazineArticles
{
    internal class Program
    {
        static void Main()
        {
            #region Data
            List<Magazine> magazines = new List<Magazine>()
            {
                new Magazine(){ Id=1, MagazineName="Veselka", PeriodRelease= 1, ReleaseDate=new DateTime(1998,02,12), Circulation= 1458},
                new Magazine(){ Id=2, MagazineName="Patronus", PeriodRelease= 2, ReleaseDate=new DateTime(2014,04,28), Circulation= 78},
                new Magazine(){ Id=3, MagazineName="Astalavista", PeriodRelease= 3, ReleaseDate=new DateTime(1999,12,01), Circulation= 267},
                new Magazine(){ Id=4, MagazineName="Forbez", PeriodRelease= 1, ReleaseDate=new DateTime(1621,12,4), Circulation= 19584},
                new Magazine(){ Id=5, MagazineName="Aklesev", PeriodRelease= 4, ReleaseDate=new DateTime(2005,05,17), Circulation= 8},
                new Magazine(){ Id=6, MagazineName="Elena", PeriodRelease= 1, ReleaseDate=new DateTime(2002,9,21), Circulation= 789},
                new Magazine(){ Id=7, MagazineName="Chamomile", PeriodRelease= 2, ReleaseDate=new DateTime(1994,01,01), Circulation= 2396},
                new Magazine(){ Id=8, MagazineName="Tutorials", PeriodRelease= 4, ReleaseDate=new DateTime(2012,11,12), Circulation= 23568},
                new Magazine(){ Id=9, MagazineName="Jam", PeriodRelease= 6, ReleaseDate=new DateTime(2022,07,08), Circulation= 5},
            };
            List<Article> articles = new List<Article>()
            {
                new Article(){ Id=1,ArticleName="Happy New Year",AuthorId=3,MagazineId=2,ArticleRelease= new DateTime(2021,12,17)},
                new Article(){ Id=2,ArticleName="Upcoming Event in CSGO",AuthorId=2,MagazineId=1,ArticleRelease= new DateTime(2022,04,23)},
                new Article(){ Id=3,ArticleName="Navi kicks Boombl4",AuthorId=1,MagazineId=8,ArticleRelease= new DateTime(2022,05,27)},
                new Article(){ Id=4,ArticleName="PariMatch has business in RB",AuthorId=5,MagazineId=3,ArticleRelease= new DateTime(2022,06,01)},
                new Article(){ Id=5,ArticleName="Help me",AuthorId=4,MagazineId=5,ArticleRelease= new DateTime(2003,04,28)},
                new Article(){ Id=6,ArticleName="XXXTENTACION DIED",AuthorId=7,MagazineId=9,ArticleRelease= new DateTime(2003,2,16)},
                new Article(){ Id=7,ArticleName="Clash Royale update is awful",AuthorId=6,MagazineId=7,ArticleRelease= new DateTime(2022,04,01)},
                new Article(){ Id=8,ArticleName="Professional motion-designer searching for a job",AuthorId=8,MagazineId=6,ArticleRelease= new DateTime(2022,06,09)},
                new Article(){ Id=9,ArticleName="OLX is scam",AuthorId=9,MagazineId=8,ArticleRelease= new DateTime(1982,12,14)},
            };
            List<Author> authors = new List<Author>()
            {
                new Author(){Id =1, Name="Tetyana", Surname="Torova",Organization="Clash Royale" },
                new Author(){Id =2, Name="Andriy", Surname="Renegadov",Organization="Natus Vincere" },
                new Author(){Id =3, Name="Olexiy", Surname="Fazev",Organization="Natus Vincere" },
                new Author(){Id =4, Name="Yevgen", Surname="Cloud",Organization="Yeet" },
                new Author(){Id =5, Name="Olexandr", Surname="Heroic",Organization="Clash Royale" },
                new Author(){Id =6, Name="Li", Surname="Leyon",Organization="Japan Co" },
                new Author(){Id =7, Name="Ley", Surname="Zhingzcinxon",Organization="Chinese Food" },
                new Author(){Id =8, Name="Lucas", Surname="Sunder",Organization="Yeet" },
                new Author(){Id =9, Name="Olega", Surname="Robot",Organization="Yeet" },

            };
            #endregion
            #region Query#1
            Console.WriteLine("\tShow all the articles available for reading\n");
            var q1 = from a in articles
                     select a;
            foreach (var article in q1)
                Console.WriteLine(article.ArticleName);
            #endregion
            #region Query#2
            Console.WriteLine("\n\tShow all the certified authors\n");
            var q2 = authors.Select(a => new { a.Name, a.Surname, a.Organization });
            foreach (var client in q2)
                Console.WriteLine(client.Name + " " + client.Surname);
            #endregion
            #region Query#3
            Console.WriteLine("\n\tShow all the Magazines, that names starts with A\n");
            var q3 = from a in magazines
                     where a.MagazineName[0] == 'A'
                     select a.MagazineName;
            foreach (var journal in q3)
                Console.WriteLine(journal);
            #endregion
            #region Query#4
            Console.WriteLine("\n\tShow all the articles, that were posted in the period from 2005.12.12 to 2022.06.10\n");
            var q4 = articles.Join(authors,
                article => article.AuthorId,
                author => author.Id,
                (article, author) => new
                {
                    articleName = article.ArticleName,
                    authorName = author.Name,
                    articleReleaseDate = article.ArticleRelease
                }).Where(article => article.articleReleaseDate > new DateTime(2005, 12, 12) && article.articleReleaseDate < new DateTime(2022, 06, 10));  
            foreach (var data in q4)
                Console.WriteLine(data.articleName + "\n Author: " + data.authorName+ " " + data.articleReleaseDate);
            #endregion
            #region Query#5
            Console.WriteLine("\n\tShow the magazine`s biggest circulation\n");
            var q5 = magazines.Max(c => c.Circulation);

            Console.WriteLine(q5);
            #endregion
            #region Query#6
            Console.WriteLine("\n\tShow all the articles with their authors ordered by article release\n");
            var q6 = from a in articles
                     join ar in articles on a.Id equals ar.Id
                     join au in authors on a.Id equals au.Id
                     orderby ar.ArticleRelease descending
                     select new { ar.ArticleName, au.Name, au.Surname, ar.ArticleRelease};
            foreach(var data in q6)
            {
                Console.Write("\nArticle: ");
                Console.WriteLine(data.ArticleName);
                Console.Write("Author: ");
                Console.WriteLine(data.Name+" "+data.Surname);
                Console.Write("Release: ");
                Console.WriteLine(data.ArticleRelease);
            }
            #endregion
            #region Query#7
            Console.WriteLine("\n\tShow the circulation of all the magazines which are older than 10 years\n");
            var q7 = magazines.Where(m => m.ReleaseDate < new DateTime(2012, 06, 10))
                .Sum(m => m.Circulation);
            Console.WriteLine(q7);
            #endregion
            #region Query#8
            Console.WriteLine("\n\tShow all the authors who work in organization named 'Yeet'\n");
            var q8 = authors.Where(a => a.Organization.Contains("Yeet"))
            .Select(a => new { a.Name, a.Surname });
            foreach (var a in q8)
            Console.WriteLine(a.Name+" "+a.Surname);
            #endregion
            #region Query#9
            Console.WriteLine("\n\tShow all the authors, who have written an article for a journals, released before 2015\n");
            var q9 = from ar in articles
                     join m in magazines on ar.MagazineId equals m.Id
                     join au in authors on ar.AuthorId equals au.Id
                     where m.ReleaseDate < new DateTime(2015, 01, 01)
                     select new { au.Name, au.Surname, m.MagazineName };
            foreach (var a in q9)
                Console.WriteLine(a.Name + " " + a.Surname+ "    written for:   "+a.MagazineName);
            #endregion
            #region Query#10
            Console.WriteLine("\n\tShow the magazine that has posted more than 1 of articles'n");
            var q10 = articles.Join(magazines,
                ar => ar.MagazineId,
                m => m.Id,
                (ar, m) => new { ar.MagazineId, m.MagazineName })
                .GroupBy(res => res.MagazineId)
                .Where(res => res.Count() > 1)
                .Select(res => new { res.FirstOrDefault().MagazineName });
            foreach (var a in q10)
                Console.WriteLine(a.MagazineName);
            #endregion
            #region Query#11
            Console.WriteLine("\n\tShow the authors, who have written the article in last 3 month\n");
            var q11 = from ar in articles
                      join au in authors on ar.AuthorId equals au.Id
                      where ar.ArticleRelease > new DateTime(2022, 03, 10) && ar.ArticleRelease < new DateTime(2022, 06, 10)
                      select new { au.Name, au.Surname, ar.ArticleName };
            foreach (var au in q11)
                Console.WriteLine(au.Name + " " + au.Surname + " Article: " + au.ArticleName);

            #endregion
            #region Query#12
            Console.WriteLine("\n\tShow total amount of magazines released\n");
            var q12 = magazines.Sum(m => m.Circulation);
            Console.WriteLine(q12);
            #endregion
            #region Query#13
            Console.WriteLine("\n\tShow all the magazines, who released between 1200-7000 journals\n");
            var q13 = from m in magazines
                      where m.Circulation>1200 && m.Circulation <7000
                      select m.MagazineName;
            foreach(var m in q13)
                Console.WriteLine(m);
            #endregion
            #region Query#14
            Console.WriteLine("\n\tShow all the authors in alphabetical order by descending\n");
            var q14 = from au in authors
                      orderby au.Surname
                      select au;
            foreach(var c in q14)
                Console.WriteLine(c.Surname+" "+c.Name+" '"+c.Organization+"'");
            #endregion
            #region Query#15
            Console.WriteLine("\n\tShow all the articles, their authors and the magazine it were posted in\n");
            var q15 = from ar in articles
                      join m in magazines on ar.MagazineId equals m.Id
                      join au in authors on ar.AuthorId equals au.Id
                      select new { m.MagazineName, ar.ArticleName, au.Name, au.Surname };
            foreach (var a in q15)
                Console.WriteLine("Magazine:" + a.MagazineName + " Article: " + a.ArticleName + " Author: " + a.Name + " " + a.Surname);
            #endregion
            var q16 = from ar in articles
                      group ar by ar.AuthorId into newGroup
                      select newGroup;
           foreach (var item in q16)
            Console.WriteLine(item);
        }
    }
    
}
