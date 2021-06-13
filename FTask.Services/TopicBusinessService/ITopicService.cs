using FTask.Data.Helpers;
using FTask.Data.Models;
using FTask.Data.Parameters;

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
