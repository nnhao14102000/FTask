using FTask.Data.Models;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;

namespace FTask.Services.TopicBusinessService
{
    public interface ITopicService
    {
        PagedList<Topic> GetAllTopics(TopicParameters topicPrameters);
        Topic GetTopicByTopicId(int Id);
        void AddTopic(Topic Topic);
        void UpdateTopic(Topic Topic);
        void RemoveTopic(Topic Topic);
    }
}
