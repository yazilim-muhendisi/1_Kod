using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tekno_egitim_web.core.Repository;
using tekno_egitim_web.core.UnitOfWorks;
using tekno_egitim_web.data.Repository;

namespace tekno_egitim_web.data.UnitOfWork
{
    public  class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private BlogRepository _blogRepository;
        private HaberRepository _haberRepository;
        private MakaleRepository _makaleRepository;
        private VideoRepository _videoRepository;
        private NotRepository _notRepository;
        private KategoriRepository _kategoriRepository;

        public IBlog Blogs => _blogRepository = _blogRepository ?? new BlogRepository(_context);

        public IHaber Habers => _haberRepository = _haberRepository ?? new HaberRepository(_context);

        public IMakale Makales => _makaleRepository = _makaleRepository ?? new MakaleRepository(_context);

        public INot Nots => _notRepository = _notRepository ?? new NotRepository(_context);

        public IVideo Videos => _videoRepository = _videoRepository ?? new VideoRepository(_context);

        public IKategoriler Kategoris => _kategoriRepository = _kategoriRepository ?? new KategoriRepository(_context);

        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsycn()
        {
           await  _context.SaveChangesAsync();
        }
    }
}
