using EBookStore.Domain.Domain;
using EBookStore.Repository.Interface;
using EBookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBookStore.Service.Implementation
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _publisherRepository;

        public PublisherService(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void CreateNewPublisher(Publisher p)
        {
            _publisherRepository.Insert(p);
        }

        public void DeletePublisher(Guid id)
        {
            var publisher = _publisherRepository.Get(id);
            _publisherRepository.Delete(publisher);
        }

        public List<Publisher> GetAllPublishers()
        {
            return _publisherRepository.GetAll().ToList();
        }

        public Publisher GetDetailsForPublisher(Guid? id)
        {
            var publisher = _publisherRepository.Get(id);
            return publisher;
        }

        public void UpdateExistingPublisher(Publisher p)
        {
            _publisherRepository.Update(p);
        }
    }
}
