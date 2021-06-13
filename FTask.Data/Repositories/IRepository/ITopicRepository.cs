using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        PagedList<Topic> GetTopics(TopicParameters topicParameters);
        Topic GetTopicByTopicId(int id);
    }
}
