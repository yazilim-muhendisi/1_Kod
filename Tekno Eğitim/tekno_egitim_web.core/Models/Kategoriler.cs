using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace tekno_egitim_web.core.Model
{
    public class Kategoriler
    {
        public Kategoriler()
        {
            Blogs = new Collection<Blog>();
            Habers = new Collection<Haber>();
            Makales = new Collection<Makale>();
            Videos = new Collection<Video>();
            Nots = new Collection<Not>();
        }
        public int kategori_id { get; set; }
        public string kategori_ad { get; set; }
        public bool Silme { get; set; }

        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Haber> Habers { get; set; }
        public ICollection<Makale> Makales { get; set; }
        public ICollection<Video> Videos { get; set; }
        public ICollection<Not> Nots { get; set; }
    }
}