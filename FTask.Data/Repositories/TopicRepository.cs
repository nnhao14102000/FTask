using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Data.Repositories.IRepository;
using System.Linq;

namespace FTask.Data.Repositories
{
    public class TopicRepository : GenericRepository<Topic>, ITopicRepository
    {
        private FTaskContext context { get; set; }
        public TopicRepository(FTaskContext context) : base (context)
        {
            this.context = context;
        }

        public PagedList<Topic> GetTopics(TopicParameters topicParameters)
        {
            var topics = FindAll();
            SearchByName(ref topics, topicParameters.TopicName);
            return PagedList<Topic>.ToPagedList(topics.OrderBy(t=>t.TopicName)
                , topicParameters.PageNumber, topicParameters.PageSize);
        }

        private void SearchByName(ref IQueryable<Topic> topics, string topicName)
        {
            if (!topics.Any() || string.IsNullOrWhiteSpace(topicName))
            {
                return;
            }
            topics = topics
                .Where(t => t.TopicName.ToLower()
                .Contains(topicName.Trim().ToLower()));
        }

        public Topic GetTopicByTopicId(int id)
        {
            return FindByCondition(topic => topic.TopicId.Equals(id)).FirstOrDefault();
        }
    }
}
