using Minio;
using Minio.DataModel.Args;

namespace UniversityKitchen.Service;

public class MinioService : IMinioService
{
    private readonly IMinioClient _minioClient;
    private readonly string _bucketName;
    private readonly string _enpoint;
    public MinioService(IConfiguration configuration)
    {
        _enpoint = configuration["Minio:Endpoint"];
        var accessKey = configuration["Minio:AccessKey"];
        var secretKey = configuration["Minio:SecretKey"];
        _bucketName = configuration["Minio:BucketName"];

        _minioClient = new MinioClient()
            .WithEndpoint(_enpoint)
            .WithCredentials(accessKey, secretKey)
            .WithSSL()
            .Build();
    }


    public async Task<string> Uplaod(IFormFile file, string package)
    {
        if (file == null || file.Length == 0)
            throw new ArgumentException("File is empty or null.");
        
        var bucketExistsArgs  = new BucketExistsArgs().WithBucket(_bucketName);
        bool bucketExists = await _minioClient.BucketExistsAsync(bucketExistsArgs);
        
        if (!bucketExists)
        {
            await _minioClient.MakeBucketAsync(new MakeBucketArgs().WithBucket(_bucketName));
        }
        
        var packagePlaceholder = $"{package}/";
        
        await _minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(packagePlaceholder)
            .WithStreamData(new MemoryStream())
            .WithObjectSize(0)
            .WithContentType("application/octet-stream"));
        
        var objectName = $"{package}/{Guid.NewGuid()}_{file.FileName}"; 

        using (var stream = file.OpenReadStream())
        {
            await _minioClient.PutObjectAsync(new PutObjectArgs()
                .WithBucket(_bucketName)
                .WithObject(objectName)
                .WithStreamData(stream)
                .WithObjectSize(file.Length)
                .WithContentType(file.ContentType));
        }
        return objectName;

    }

    public async Task<string> GetImage(string imageName)
    {
        if (string.IsNullOrEmpty(imageName)) 
            return null;
        
        var presignedUrlArgs = new PresignedGetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(imageName)
            .WithExpiry(24 * 60 * 60); 
        
        return await _minioClient.PresignedGetObjectAsync(presignedUrlArgs);

    }
}