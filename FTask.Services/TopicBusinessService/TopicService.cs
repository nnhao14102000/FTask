using FTask.Data.Models;
using FTask.Data.Repositories.IRepository;
using FTask.Shared.Helpers;
using FTask.Shared.Parameters;
using Microsoft.Extensions.Logging;
using System;

namespace FTask.Services.TopicBusinessService
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly ILogger<TopicService> _log;

        public TopicService(ITopicRepository topicRepository, ILogger<TopicService> log)
        {
            _topicRepository = topicRepository;
            _log = log;
        }

        public void AddTopic(Topic Topic)
        {
            _log.LogInformation($"Add Topic {Topic.TopicName} into database...");
            _topicRepository.Add(Topic);
            try
            {
                if (_topicRepository.SaveChanges())
                {
                    _log.LogInformation($"Add Topic {Topic.TopicName} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogInformation($"Add Topic {Topic.TopicName} fail with error: {e.Message}");
            }
        }

        public PagedList<Topic> GetAllTopics(TopicParameters topicPrameters)
        {
            var topic = _topicRepository.GetTopics(topicPrameters);
            if (topic is null)
            {
                _log.LogInformation("Have no Topic...");
                return null;
            }
            else
            {
                _log.LogInformation($"Get {topic.TotalCount} Topic from database...");
                return topic;
            }

        }

        public Topic GetTopicByTopicId(int Id)
        {
            _log.LogInformation($"Search topic {Id}...");
            var topic = _topicRepository.GetTopicByTopicId(Id);
            if (topic is null)
            {
                _log.LogInformation($"Can not found topic {Id}...");
                return null;
            }
            else
            {
                _log.LogInformation($"Found success topic {Id}...");
                return topic;
            }
        }

        public void RemoveTopic(Topic topic)
        {
            _log.LogInformation($"Remove Topic {topic.TopicId}...");
            _topicRepository.Remove(topic);
            try
            {
                if (_topicRepository.SaveChanges())
                {
                    _log.LogInformation($"Remove Topic {topic.TopicId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Remove Topic {topic.TopicId} fail with error: {e.Message}");
            }
        }

        public void UpdateTopic(Topic topic)
        {
            _log.LogInformation($"Update Topic {topic.TopicId}...");
            _topicRepository.Update(topic);
            try
            {
                if (_topicRepository.SaveChanges())
                {
                    _log.LogInformation($"Update Topic {topic.TopicId} success...");
                }
            }
            catch (Exception e)
            {
                _log.LogError($"Update topic {topic.TopicId} fail with error: {e.Message}");
            }
        }

    }
}
