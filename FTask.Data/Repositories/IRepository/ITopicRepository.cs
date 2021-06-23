using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Data.Repositories.IRepository
{
    public interface ITopicRepository : IGenericRepository<Topic>
    {
        PagedList<Topic> GetTopics(TopicParameters topicParameters);
        Topic GetTopicByTopicId(int id);
    }
}
