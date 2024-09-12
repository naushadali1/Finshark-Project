using api.Models;
using api.Models.DTO;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModels)
        {
            return new CommentDto
            {
                Id = commentModels.Id,
                StockId = commentModels.StockId,
                Title = commentModels.Title,
                Content = commentModels.Content,
                CreatedAt = commentModels.CreatedAt
            };
        }

        public static Comment ToCommentFromCreate(this CommentCreateRequestDto commentDto,int stockId)
        {
            return new Comment
            {
                StockId = stockId,
                Title = commentDto.Title,
                Content = commentDto.Content,

            };
        }

        public static Comment ToCommentFromUpdate(this CommentUpdateRequestDto commentDto)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
            };
        }

    }
}