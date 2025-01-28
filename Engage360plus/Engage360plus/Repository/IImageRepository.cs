using Engage360plus.Models.Domain;

namespace Engage360plus.Repository
{
    public interface IImageRepository
    {
        Task<Image>Upload(Image image);
    }
}
