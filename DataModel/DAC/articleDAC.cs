using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DAC
{
    public class articleDAC
    {
        News_articleEntities db;

        public articleDAC()
        {
            db = new News_articleEntities();
        }


        public int AddArticle(article art)
        {
            var date = DateTime.Now;
            art.publishedOn = date;
            int res = 0;
            try
            {
                db.articles.Add(art);
                db.SaveChanges();
                res = art.Id;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("exception:", ex);
                res = 0;
            }
            return res;
        }

        public IEnumerable<article> getAll()
        {
            List<article> listOfArticle = new List<article>();
            try
            {
                var arti = db.articles.ToList<article>().OrderByDescending(x => x.Id);
                if (arti != null)
                {
                    foreach (var art in arti)
                    {
                        listOfArticle.Add(art);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Excepion:", ex);
                listOfArticle = null;
            }

            return listOfArticle;
        }

        public article getArticleById(int id)
        {
            article ar = new article();
            try
            {
                
                ar = db.articles.FirstOrDefault(x => x.Id == id);
 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Excepion:", ex);
                ar = null;
            }
            return ar;
        }

        public bool deleteEvent(int id)
        {
            try
            {
               
                var ar = db.articles.FirstOrDefault(x => x.Id == id);
                if (ar != null)
                {
                    db.Entry(ar).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Excepion:", ex);
                return false;
            }
        }

        public string EditArticle(article ar)
        {
            try
            {  
                db.Entry(ar).State = EntityState.Modified;
                db.SaveChanges();
                return "True";
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Excepion:", ex);
                return "False";
            }

        }

    }
}
