using AutoMapper;
using FTask.Api.ViewModels.TopicViewModels;
using FTask.Data.Models;
using FTask.Data.Parameters;
using FTask.Services.TopicBusinessService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FTask.Api.Controllers
{
    /// <summary>
    /// Task Category controller
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/topic")]
    [ApiVersion("1.0")]
    public class TopicController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITopicService _topicService;

        /// <summary>
        /// Constructor DI AutoMapper and Topic service
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="topicService"></param>
        public TopicController(IMapper mapper, ITopicService topicService)
        {
            _mapper = mapper;
            _topicService = topicService;
        }

        /// <summary>
        /// Get all Topic, allow search by name | api version v1
        /// </summary>
        /// <param name="topicParameter"></param>
        /// <returns></returns>
        [HttpGet]
        [MapToApiVersion("1.0")]
        public ActionResult<IEnumerable<TopicReadViewModel>> GetAllTopics([FromQuery] TopicParameters topicParameter)
        {
            var topic = _topicService.GetAllTopics(topicParameter);

            var metaData = new
            {
                topic.TotalCount,
                topic.PageSize,
                topic.CurrentPage,
                topic.HasNext,
                topic.HasPrevious
            };
            Response.Headers.Add("Topic-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(_mapper.Map<IEnumerable<TopicReadViewModel>>(topic));
        }

        /// <summary>
        /// Get Task Category by ID | api version v1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTopicByTopicId")]
        [MapToApiVersion("1.0")]
        public ActionResult<TopicReadDetailViewModel> GetTopicByTopicId(int id)
        {
            var topic = _topicService.GetTopicByTopicId(id);
            if (topic is not null)
            {
                return Ok(_mapper.Map<TopicReadDetailViewModel>(topic));
            }
            return NotFound();
        }

        /// <summary>
        /// Add a Topic into database | api version v1
        /// </summary>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPost]
        [MapToApiVersion("1.0")]
        public ActionResult<TopicReadViewModel> AddTopic(TopicAddViewModel topic)
        {
            var topicModel = _mapper.Map<Topic>(topic);
            _topicService.AddTopic(topicModel);
            var TopicReadModel = _mapper.Map<TopicReadViewModel>(topicModel);

            return CreatedAtRoute(nameof(GetTopicByTopicId), new { id = TopicReadModel.TopicId }, TopicReadModel);
        }

        /// <summary>
        /// Update Topic | api version v1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="topic"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult UpdateTopic(int id, TopicUpdateViewModel topic)
        {
            var topicModel = _topicService.GetTopicByTopicId(id);
            if (topicModel is null)
            {
                return NotFound();
            }
            _mapper.Map(topic, topicModel);
            _topicService.UpdateTopic(topicModel);
            return NoContent();
        }

        /// <summary>
        /// Update Task Category by PATCH method...Allow update a single attribute | api version v1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDoc"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult PartialTopicUpdate(int id, JsonPatchDocument<TopicUpdateViewModel> patchDoc)
        {
            var topicModel = _topicService.GetTopicByTopicId(id);
            if (topicModel is null)
            {
                return NotFound();
            }
            var topicToPatch = _mapper.Map<TopicUpdateViewModel>(topicModel);
            patchDoc.ApplyTo(topicToPatch, ModelState);
            if (!TryValidateModel(topicToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(topicToPatch, topicModel);
            _topicService.UpdateTopic(topicModel);
            return NoContent();
        }

        /// <summary>
        /// Remove a Task Category | api version v1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult RemoveTopic(int id)
        {
            var topicModel = _topicService.GetTopicByTopicId(id);
            if (topicModel is null)
            {
                return NotFound();
            }
            _topicService.RemoveTopic(topicModel);
            return NoContent();
        }
    }
}
