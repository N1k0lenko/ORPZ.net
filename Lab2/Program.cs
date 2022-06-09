using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;



namespace XMLlab
{
    internal class Program
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
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
            #region WritingXMLfiles
            XmlWriterSettings settings = new XmlWriterSettings { Indent = true };
            using (XmlWriter writer = XmlWriter.Create("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/magazines.xml", settings))
            {
                writer.WriteStartElement("magazines");
                foreach (var magazine in magazines)
                {
                    writer.WriteStartElement("magazine");
                    writer.WriteElementString("Id", magazine.Id.ToString());
                    writer.WriteElementString("MagazineName", magazine.MagazineName);
                    writer.WriteElementString("PeriodRelease", magazine.PeriodRelease.ToString());
                    writer.WriteElementString("ReleaseDate", magazine.ReleaseDate.ToString("dd.MM.yyyy"));
                    writer.WriteElementString("Circulation", magazine.Circulation.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/articles.xml", settings))
            {
                writer.WriteStartElement("articles");
                foreach (var article in articles)
                {
                    writer.WriteStartElement("article");
                    writer.WriteElementString("Id", article.Id.ToString());
                    writer.WriteElementString("ArticleName", article.ArticleName);
                    writer.WriteElementString("AuthorId", article.AuthorId.ToString());
                    writer.WriteElementString("MagazineId", article.MagazineId.ToString());
                    writer.WriteElementString("ArticleRelease", article.ArticleRelease.ToString("dd.MM.yyyy"));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            using (XmlWriter writer = XmlWriter.Create("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/authors.xml", settings))
            {
                writer.WriteStartElement("authors");
                foreach (var author in authors)
                {
                    writer.WriteStartElement("author");
                    writer.WriteElementString("Id", author.Id.ToString());
                    writer.WriteElementString("Name", author.Name);
                    writer.WriteElementString("Surname", author.Surname);
                    writer.WriteElementString("Organization", author.Organization);
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            #endregion
            #region ReadingXMLFiles
            Console.WriteLine("XML File - magazines");
            XDocument magazinesDoc = XDocument.Load("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/magazines.xml");
            foreach (XElement magazine in magazinesDoc.Descendants("magazine"))
            {
                int? id = (int)magazine?.Element("Id");
                string magazineName = (string)magazine.Element("MagazineName");
                int? periodRelease = (int)magazine?.Element("PeriodRelease");
                string releaseDate = (string)magazine.Element("ReleaseDate");
                int? circulation = (int)magazine?.Element("Circulation");
                Console.WriteLine($"id - {id}, Magazine Name - {magazineName}, Period Of Release - {periodRelease} week, Release Date - {releaseDate}, Circulation - {circulation}\n");
            };
            Console.WriteLine("XML File - articles");
            XDocument articlesDoc = XDocument.Load("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/articles.xml");
            foreach (XElement article in articlesDoc.Descendants("article"))
            {
                int? id = (int)article?.Element("Id");
                string articleName = (string)article.Element("ArticleName");
                int? authorId = (int)article?.Element("AuthorId");
                int? magazineId = (int)article?.Element("MagazineId");
                string articleRelease = (string)article.Element("ArticleRelease");
                Console.WriteLine($"id - {id}, Article Name - {articleName}, Author Id- {authorId}, Magazine Id - {magazineId}, Article Release - {articleRelease}\n");
            };
            Console.WriteLine("XML File - articles");
            XDocument authorsDoc = XDocument.Load("D:/!Work/KPI/2.2/.net/Lab2/Lab2/XMLFiles/authors.xml");
            foreach (XElement author in authorsDoc.Descendants("author"))
            {
                int? id = (int)author?.Element("Id");
                string name = (string)author.Element("Name");
                string surname = (string)author.Element("Surname");
                string organization = (string)author.Element("Organization");
                Console.WriteLine($"id - {id}, Name - {name}, Surname - {surname}, Organization - {organization}\n");
            };
            #endregion
            #region Querry#1
            Console.WriteLine("\tShow all the articles available for reading\n");
            var q1 = articlesDoc.Descendants("article")
            .Select(el => el);
            foreach (var article in q1)
            {
                Console.WriteLine((string)article.Element("ArticleName"));
            }
            #endregion
            #region Querry#2
            Console.WriteLine("\n\tShow all the certified authors\n");
            var q2 = authorsDoc.Descendants("author")
                .Select(el => el);
            foreach (var author in q2)
            {
                Console.WriteLine((string)author.Element("Name") + " " + (string)author.Element("Surname"));
            }
            #endregion
            #region Querry#3
            Console.WriteLine("\n\tShow all the Magazines, that names starts with A\n");
            var q3 = magazinesDoc.Descendants("magazine")
            .Where(el => ((string)el.Element("MagazineName"))[0] == 'A')
            .Select(el => (string)el.Element("MagazineName"));
            foreach (var magazine in q3)
            {
                Console.WriteLine(magazine);
            }
            #endregion
            #region Querry#4
            Console.WriteLine("\n\tShow all the articles, that were posted in the period from 2005.12.12 to 2022.06.10\n");
            var q4 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId")
            })
                .Join(authorsDoc.Descendants("author").Select(el => new Author()
                {
                    Id = (int)el.Element("Id"),
                    Name = (string)el.Element("Name"),
                    Surname = (string)el.Element("Surname")
                }),
                ar => ar.AuthorId,
                au => au.Id,
                (ar, au) => new { ar.ArticleRelease, ar.ArticleName, au.Name, au.Surname })
                .Where(ar => ar.ArticleRelease > new DateTime(2005, 12, 12) && ar.ArticleRelease < new DateTime(2022, 06, 10));

            foreach (var data in q4)
            {
                Console.WriteLine(data.ArticleName + " " + data.ArticleRelease + " Author: " + data.Name + " " + data.Surname);
            }

            #endregion
            #region Querry#5
            Console.WriteLine("\n\tShow the magazine`s biggest circulation\n");
            var q5 = magazinesDoc.Descendants("magazine").Max(el => (int)el.Element("Circulation"));
            Console.WriteLine(q5);
            #endregion
            #region Querry#6
            Console.WriteLine("\n\tShow all the articles with their authors ordered by article release\n");
            var q6 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                Id = (int)el.Element("Id"),
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId"),
                MagazineId = (int)el.Element("MagazineId")
            })
                .Join(authorsDoc.Descendants("author").Select(el => new Author()
                {
                    Id = (int)el.Element("Id"),
                    Name = (string)el.Element("Name"),
                    Surname = (string)el.Element("Surname"),
                    Organization = (string)el.Element("Organization")
                }),
                ar => ar.AuthorId,
                au => au.Id,
                (ar, au) => new { ar.ArticleName, ar.ArticleRelease, au.Name, au.Surname }
                )
                .OrderBy(ar => ar.ArticleRelease)
                .Select(res => new { res.ArticleName, res.ArticleRelease, res.Name, res.Surname });
            foreach (var data in q6)
            {
                Console.WriteLine("Article: " + data.ArticleName + " Author: " + data.Name + " " + data.Surname + " Article Release: " + data.ArticleRelease);
            }
            #endregion
            #region Querry#7
            Console.WriteLine("\n\tShow the circulation of all the magazines with Period of release less than 2 weeks\n");
            var q7 = magazinesDoc.Descendants("magazine")
                .Where(el => (int)el.Element("PeriodRelease") < 2)
                .Sum(el => (int)el.Element("Circulation"));
            Console.WriteLine(q7);
            #endregion
            #region Querry#8   
            Console.WriteLine("\n\tShow all the authors who work in organization named 'Yeet'\n");
            var q8 = authorsDoc.Descendants("author")
                .Where(el => ((string)el.Element("Organization")).Contains("Yeet"))
                .Select(el => new Author { Name = (string)el.Element("Name"), Surname = (string)el.Element("Surname"), Organization = (string)el.Element("Organization") });
            foreach (var au in q8)
            {
                Console.WriteLine(au.Name + " " + au.Surname + " Organization: " + au.Organization);
            }
            #endregion
            #region Querry#9
            Console.WriteLine("\n\tShow all the authors, who have written an article for a journals, released before 2015\n");
            var q9 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                Id = (int)el.Element("Id"),
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId"),
                MagazineId = (int)el.Element("MagazineId")
            })
                .Join(authorsDoc.Descendants("author").Select(el => new Author()
                {
                    Id = (int)el.Element("Id"),
                    Name = (string)el.Element("Name"),
                    Surname = (string)el.Element("Surname"),
                    Organization = (string)el.Element("Organization")
                }),
                ar => ar.AuthorId,
                au => au.Id,
                (ar, au) => new { ar, au })
                .Join(magazinesDoc.Descendants("magazine").Select(el => new Magazine()
                {
                    Id = (int)el.Element("Id"),
                    MagazineName = (string)el.Element("MagazineName"),
                    PeriodRelease = (int)el.Element("PeriodRelease"),
                    ReleaseDate = Convert.ToDateTime((string)el.Element("ReleaseDate")),
                    Circulation = (int)el.Element("Circulation")
                }),
                ar => ar.ar.MagazineId,
                ar => ar.Id,
                (ar, m) => new { ar, m }
                ).Where(ar => ar.m.ReleaseDate < new DateTime(2015, 01, 01))
                .Select(res => new { res.ar.au.Name, res.ar.au.Surname });
            foreach (var au in q9)
            {
                Console.WriteLine(au.Name + " " + au.Surname);
            }
            #endregion
            #region Querry#10
            Console.WriteLine("\n\tShow the magazine that has posted more than 1 of articles\n");
            var q10 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                Id = (int)el.Element("Id"),
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId"),
                MagazineId = (int)el.Element("MagazineId")
            })
            .Join(magazinesDoc.Descendants("magazine").Select(el => new Magazine()
            {
                Id = (int)el.Element("Id"),
                MagazineName = (string)el.Element("MagazineName"),
                PeriodRelease = (int)el.Element("PeriodRelease"),
                ReleaseDate = Convert.ToDateTime((string)el.Element("ReleaseDate")),
                Circulation = (int)el.Element("Circulation")
            }),
            ar => ar.MagazineId,
            ar => ar.Id,
            (ar, m) => new { ar.MagazineId, m.MagazineName })
            .GroupBy(res => res.MagazineId)
            .Where(res => res.Count() > 1)
            .Select(res => new { res.FirstOrDefault().MagazineName });

            foreach (var m in q10)
            {
                Console.WriteLine(m.MagazineName);
            }
            #endregion
            #region Querry#11
            Console.WriteLine("\n\tShow the authors, who have written the article in last 3 month\n");
            var q11 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                Id = (int)el.Element("Id"),
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId"),
                MagazineId = (int)el.Element("MagazineId")
            })
                .Join(authorsDoc.Descendants("author").Select(el => new Author()
                {
                    Id = (int)el.Element("Id"),
                    Name = (string)el.Element("Name"),
                    Surname = (string)el.Element("Surname"),
                    Organization = (string)el.Element("Organization")
                }),
                ar => ar.AuthorId,
                au => au.Id,
                (ar, au) => new { ar, au })
                .Where(el => el.ar.ArticleRelease > new DateTime(2022, 03, 10) && el.ar.ArticleRelease < new DateTime(2022, 06, 10))
                .Select(el => new { el.au.Name, el.au.Surname });
            foreach (var au in q11)
            {
                Console.WriteLine(au.Name + " " + au.Surname);
            }
            #endregion
            #region Querry#12
            Console.WriteLine("\n\tShow total amount of magazines released\n");
            var q12 = magazinesDoc.Descendants("magazine").Sum(el => (int)el.Element("Circulation"));
            Console.WriteLine(q12);
            #endregion
            #region Querry#13
            Console.WriteLine("\n\tShow all the magazines, who released between 1200-7000 journals\n");
            var q13 = magazinesDoc.Descendants("magazine").Select(el => new Magazine()
            {
                Id = (int)el.Element("Id"),
                MagazineName = (string)el.Element("MagazineName"),
                PeriodRelease = (int)el.Element("PeriodRelease"),
                ReleaseDate = Convert.ToDateTime((string)el.Element("ReleaseDate")),
                Circulation = (int)el.Element("Circulation")
            })
               .Where(res => res.Circulation > 1200 && res.Circulation < 7000)
               .Select(res => res.MagazineName);
            foreach(var m in q13)
            {
                Console.WriteLine(m);
            }
            #endregion
            #region Querry#14
            Console.WriteLine("\n\tShow all the authors by descending their Id\n");
            var q14 = authorsDoc.Descendants("author").Select(el => new Author()
            {
                Id = (int)el.Element("Id"),
                Name = (string)el.Element("Name"),
                Surname = (string)el.Element("Surname"),
                Organization = (string)el.Element("Organization")
            })
                .OrderByDescending(el => el.Id);
               
            foreach (var author in q14)
            {
                Console.WriteLine(author.Name +" "+author.Surname);
            }
            #endregion
            #region Querry#15
            Console.WriteLine("\n\tShow all the articles, their authors and the magazine it were posted in\n");
            var q15 = articlesDoc.Descendants("article").Select(el => new Article()
            {
                Id = (int)el.Element("Id"),
                ArticleName = (string)el.Element("ArticleName"),
                ArticleRelease = Convert.ToDateTime((string)el.Element("ArticleRelease")),
                AuthorId = (int)el.Element("AuthorId"),
                MagazineId = (int)el.Element("MagazineId")
            })
                .Join(authorsDoc.Descendants("author").Select(el => new Author()
                {
                    Id = (int)el.Element("Id"),
                    Name = (string)el.Element("Name"),
                    Surname = (string)el.Element("Surname"),
                    Organization = (string)el.Element("Organization")
                }),
                ar => ar.AuthorId,
                au => au.Id,
                (ar, au) => new { ar, au })
                .Join(magazinesDoc.Descendants("magazine").Select(el => new Magazine()
                {
                    Id = (int)el.Element("Id"),
                    MagazineName = (string)el.Element("MagazineName"),
                    PeriodRelease = (int)el.Element("PeriodRelease"),
                    ReleaseDate = Convert.ToDateTime((string)el.Element("ReleaseDate")),
                    Circulation = (int)el.Element("Circulation")
                }),
                ar => ar.ar.MagazineId,
                ar => ar.Id,
                (ar, m) => new { ar, m })
                .Select(res => new { res.ar.ar.ArticleName, res.m.MagazineName, res.ar.au.Name, res.ar.au.Surname });
            foreach (var data in q15)
            {
                Console.WriteLine("Magazine:    " + data.MagazineName + "   Article:    " + data.ArticleName + "    Author:    " + data.Name + " " + data.Surname);
            }

            #endregion
        }
    }

}