using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.DAC;
using DataModel;

namespace businessLogic
{
    public class articleLogic
    {
        articleDAC artDAC;
        public articleLogic()
        {
           artDAC= new articleDAC();
        }


        public int AddArticle(article art)
        {
            if (art.article1.Length < 300 && art.title.Length<10)
            {
                return 0;
            }
            else
            {
                return artDAC.AddArticle(art);
            }
        }

        public IEnumerable<article> getAll()
        {
            return artDAC.getAll();
        }


        public article getArticleById(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            else
            {
                return artDAC.getArticleById(id);
            }
        }

        public bool deleteEvent(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            else
            {
                return artDAC.deleteEvent(id);
            }
        }

        public string EditArticle(article ar)
        {
            if (ar.article1.Length < 300 && ar.title.Length < 10)
            {
                return "Invalid Inputs";
            }
            else
            {
                return artDAC.EditArticle(ar);
            }
        }
    }
}
