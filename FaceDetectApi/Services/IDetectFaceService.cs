namespace FaceDetectApi.Services
{
    public interface IDetectFaceService
    {
        Task<string> DetectFace(IFormFile file);
    }
}
